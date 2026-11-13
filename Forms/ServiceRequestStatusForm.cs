using Municipal_Application.Data;
using Municipal_Application.DataStructures;
using Municipal_Application.Models;
using Municipal_Application.Services;

namespace Municipal_Application.Forms
{
    /// <summary>
    /// Lets a resident track their issue reports and service requests. Behind the
    /// scenes the list is organised with a red-black tree (lookup by reference
    /// number), an AVL tree (date order and date ranges), a binary search tree
    /// (title order and title search) and a max-heap (priority order), while a
    /// weighted graph links related requests across the community and is
    /// explored with breadth-first search, depth-first search and a minimum
    /// spanning tree.
    /// </summary>
    public partial class ServiceRequestStatusForm : Form
    {
        private enum ListOrder
        {
            Newest,
            Oldest,
            Reference,
            Title,
            Priority
        }

        private static readonly (ListOrder Order, string Label)[] SortChoices =
        {
            (ListOrder.Newest, "Newest first (AVL tree)"),
            (ListOrder.Oldest, "Oldest first (AVL tree)"),
            (ListOrder.Reference, "Reference number (Red-Black tree)"),
            (ListOrder.Title, "Title A-Z (Binary search tree)"),
            (ListOrder.Priority, "Priority (Max-heap)")
        };

        private static readonly int[] ProgressValues = { 13, 38, 63, 100 };

        private sealed record RequestRow(
            int Id,
            string Reference,
            string Title,
            string Category,
            string Location,
            string Status,
            string Submitted,
            string Priority);

        private readonly Resident _resident;
        private readonly Label[] _stepLabels;
        private ServiceRequestIndex _index = ServiceRequestIndex.Build(Array.Empty<Issue>());
        private RequestRelationshipGraph _graph = RequestRelationshipGraph.Build(Array.Empty<Issue>());
        private Dictionary<int, Issue> _communityById = new();
        private bool _loading = true;
        private bool _binding;

        public ServiceRequestStatusForm(Resident resident)
        {
            InitializeComponent();
            _resident = resident;
            _stepLabels = new[] { lblStepSubmitted, lblStepInProgress, lblStepResolved, lblStepClosed };

            UiTheme.Apply(this);
            ApplyStyling();
            ConfigureFilters();
            LoadData();

            _loading = false;
            ApplyFilters();
        }

        private void ApplyStyling()
        {
            lblHeading.Font = UiTheme.HeadingFont;
            lblHeading.ForeColor = UiTheme.Primary;
            lblSubtitle.ForeColor = UiTheme.SubtleText;

            pnlTrack.BackColor = UiTheme.Surface;
            flpFilters.BackColor = UiTheme.Surface;
            lblTrackHeading.ForeColor = UiTheme.Text;
            lblTrackMessage.ForeColor = UiTheme.SubtleText;
            UiTheme.ApplyPrimaryButtonStyle(btnTrack);
            UiTheme.ApplyPrimaryButtonStyle(btnViewUpdates);

            lblPriorityHeading.ForeColor = UiTheme.Text;
            lblGraphHeading.ForeColor = UiTheme.Text;
            lblGraphSummary.ForeColor = UiTheme.SubtleText;
            lblResultSummary.ForeColor = UiTheme.SubtleText;
            lblStructures.ForeColor = UiTheme.SubtleText;

            // Stop the header of the current column turning system-blue when a row is selected.
            dgvRequests.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvRequests.ColumnHeadersDefaultCellStyle.BackColor;
            dgvRequests.ColumnHeadersDefaultCellStyle.SelectionForeColor = UiTheme.Text;

            lstPriority.BorderStyle = BorderStyle.FixedSingle;
            lstPriority.BackColor = UiTheme.Surface;
            tvRelated.BorderStyle = BorderStyle.FixedSingle;
            tvRelated.BackColor = UiTheme.Surface;
            tvRelated.ForeColor = UiTheme.Text;
            tvRelated.Font = new Font("Segoe UI", 9F);

            foreach (var label in _stepLabels)
            {
                label.ForeColor = UiTheme.SubtleText;
            }
        }

        private void ConfigureFilters()
        {
            cmbStatus.Items.Add("All statuses");
            foreach (var status in Enum.GetValues<IssueStatus>())
            {
                cmbStatus.Items.Add(status);
            }

            cmbType.Items.Add("All types");
            cmbType.Items.Add(RequestType.ServiceRequest);
            cmbType.Items.Add(RequestType.IssueReport);

            EnumDisplayFormatter.ApplyTo(cmbStatus);
            EnumDisplayFormatter.ApplyTo(cmbType);

            foreach (var (_, label) in SortChoices)
            {
                cmbSort.Items.Add(label);
            }

            cmbTraversal.Items.Add("Breadth-first search (nearest relations first)");
            cmbTraversal.Items.Add("Depth-first search (follow one chain)");
            cmbTraversal.Items.Add("Minimum spanning tree (closest links)");

            cmbStatus.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            cmbTraversal.SelectedIndex = 0;
        }

        /// <summary>Reloads the resident's requests and rebuilds every data structure from them.</summary>
        private void LoadData()
        {
            var own = IssueRepository.Instance.GetByResident(_resident.Username);
            var everyone = IssueRepository.Instance.GetAll();

            _index = ServiceRequestIndex.Build(own);
            _graph = RequestRelationshipGraph.Build(everyone);
            _communityById = everyone.ToDictionary(request => request.Id);

            RefreshPriorityList();

            lblStructures.Text =
                $"Red-Black tree: {_index.ById.Count} nodes (height {_index.ById.Height})  |  " +
                $"AVL tree: {_index.ByDate.Count} (height {_index.ByDate.Height})  |  " +
                $"Binary search tree: {_index.ByTitle.Count} (height {_index.ByTitle.Height})  |  " +
                $"Priority heap: {_index.OpenCount} open  |  " +
                $"Graph: {_graph.Graph.NodeCount} nodes, {_graph.Graph.EdgeCount} edges";
        }

        private void RefreshPriorityList()
        {
            lstPriority.Items.Clear();

            var top = _index.TopPriorities(5);
            if (top.Count == 0)
            {
                lstPriority.Items.Add(_index.Count == 0
                    ? "No requests yet - submit a report or service request."
                    : "Nothing is waiting - all of your requests are resolved.");
                return;
            }

            var rank = 1;
            foreach (var ranked in top)
            {
                lstPriority.Items.Add(
                    $"{rank++}.  {ranked.Issue.ReferenceNumber}  {Shorten(ranked.Issue.Title, 22)}  [{ranked.Score}]");
            }
        }

        // ---- Filtering and the request list -------------------------------------------------

        private void FiltersChanged(object? sender, EventArgs e) => ApplyFilters();

        private ListOrder SelectedSort => SortChoices[Math.Max(0, cmbSort.SelectedIndex)].Order;

        private IEnumerable<Issue> GetVisibleRequests()
        {
            // Retrieve candidates with the trees first...
            HashSet<int>? allowed = null;

            var prefix = txtTitlePrefix.Text.Trim();
            if (prefix.Length > 0)
            {
                allowed = _index.SearchByTitlePrefix(prefix).Select(request => request.Id).ToHashSet();
            }

            if (dtpFrom.Checked || dtpTo.Checked)
            {
                var inRange = _index
                    .SearchByDateRange(dtpFrom.Checked ? dtpFrom.Value : null, dtpTo.Checked ? dtpTo.Value : null)
                    .Select(request => request.Id)
                    .ToHashSet();

                if (allowed == null)
                {
                    allowed = inRange;
                }
                else
                {
                    allowed.IntersectWith(inRange);
                }
            }

            // ...then walk the structure that matches the chosen sort order.
            IEnumerable<Issue> ordered = SelectedSort switch
            {
                ListOrder.Newest => _index.NewestFirst(),
                ListOrder.Oldest => _index.OldestFirst(),
                ListOrder.Reference => _index.InReferenceOrder(),
                ListOrder.Title => _index.InTitleOrder(),
                _ => _index.InPriorityOrder()
            };

            IssueStatus? statusFilter = cmbStatus.SelectedItem is IssueStatus status ? status : null;
            RequestType? typeFilter = cmbType.SelectedItem is RequestType type ? type : null;

            return ordered.Where(request =>
                (allowed == null || allowed.Contains(request.Id)) &&
                (statusFilter == null || request.Status == statusFilter) &&
                (typeFilter == null || request.RequestType == typeFilter));
        }

        private void ApplyFilters()
        {
            if (_loading)
            {
                return;
            }

            var previouslySelected = SelectedIssue?.Id;
            var visible = GetVisibleRequests().ToList();

            _binding = true;
            dgvRequests.DataSource = visible.Select(ToRow).ToList();
            ConfigureGridColumns();
            _binding = false;

            if (_index.Count == 0)
            {
                lblResultSummary.Text = "You have not submitted any reports or requests yet.";
            }
            else
            {
                lblResultSummary.Text =
                    $"Showing {visible.Count} of {_index.Count} requests, ordered by {SortChoices[Math.Max(0, cmbSort.SelectedIndex)].Label}";
            }

            var restored = previouslySelected.HasValue && SelectRow(previouslySelected.Value);
            if (!restored)
            {
                dgvRequests.ClearSelection();
                if (dgvRequests.Rows.Count > 0)
                {
                    dgvRequests.Rows[0].Selected = true;
                }
            }

            UpdateSelectionPanels();
        }

        private RequestRow ToRow(Issue request)
        {
            var open = RequestPriorityCalculator.IsOpen(request);

            return new RequestRow(
                request.Id,
                request.ReferenceNumber,
                request.Title,
                EnumDisplayFormatter.ToDisplayText(request.Category),
                request.Location,
                EnumDisplayFormatter.ToDisplayText(request.Status),
                request.DateReported.ToString("d MMM yyyy"),
                open ? _index.ScoreOf(request).ToString() : "-");
        }

        private void ConfigureGridColumns()
        {
            if (dgvRequests.Columns.Count == 0)
            {
                return;
            }

            dgvRequests.Columns[nameof(RequestRow.Id)]!.Visible = false;
            SetColumn(nameof(RequestRow.Reference), "Reference", 80, 92);
            SetColumn(nameof(RequestRow.Title), "Title", 170, 120);
            SetColumn(nameof(RequestRow.Category), "Category", 130, 100);
            SetColumn(nameof(RequestRow.Location), "Location", 110, 90);
            SetColumn(nameof(RequestRow.Status), "Status", 90, 96);
            SetColumn(nameof(RequestRow.Submitted), "Submitted", 100, 112);
            SetColumn(nameof(RequestRow.Priority), "Priority", 60, 68);
            dgvRequests.Columns[nameof(RequestRow.Priority)]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void SetColumn(string name, string header, float weight, int minimumWidth)
        {
            var column = dgvRequests.Columns[name]!;
            column.HeaderText = header;
            column.FillWeight = weight;
            column.MinimumWidth = minimumWidth;
        }

        private Issue? SelectedIssue
        {
            get
            {
                if (dgvRequests.SelectedRows.Count == 0 ||
                    dgvRequests.SelectedRows[0].DataBoundItem is not RequestRow row)
                {
                    return null;
                }

                return _index.ById.TryGetValue(row.Id, out var request) ? request : null;
            }
        }

        private bool SelectRow(int requestId)
        {
            foreach (DataGridViewRow gridRow in dgvRequests.Rows)
            {
                if (gridRow.DataBoundItem is RequestRow row && row.Id == requestId)
                {
                    dgvRequests.ClearSelection();
                    dgvRequests.CurrentCell = gridRow.Cells[nameof(RequestRow.Reference)];
                    gridRow.Selected = true;
                    return true;
                }
            }

            return false;
        }

        private void DgvRequests_SelectionChanged(object? sender, EventArgs e)
        {
            if (!_binding && !_loading)
            {
                UpdateSelectionPanels();
            }
        }

        private void UpdateSelectionPanels()
        {
            var selected = SelectedIssue;
            ShowProgress(selected);
            UpdateRelatedPanel(selected);
        }

        private void DgvRequests_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value is not string text ||
                dgvRequests.Columns[e.ColumnIndex].Name != nameof(RequestRow.Status))
            {
                return;
            }

            e.CellStyle!.ForeColor = text switch
            {
                "Submitted" => Color.FromArgb(52, 86, 160),
                "In Progress" => Color.FromArgb(176, 102, 0),
                "Resolved" => UiTheme.Primary,
                _ => UiTheme.SubtleText
            };
        }

        private void DgvRequests_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OpenUpdates();
            }
        }

        // ---- Tracking progress --------------------------------------------------------------

        private void TxtReference_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTrack.PerformClick();
            }
        }

        private void BtnTrack_Click(object? sender, EventArgs e)
        {
            var text = txtReference.Text.Trim();
            if (text.Length == 0)
            {
                MessageBox.Show(
                    "Enter the reference number of a request, for example SR-00001.",
                    "Reference Needed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var request = _index.FindByReference(text);
            if (request == null)
            {
                ShowProgress(null);
                lblTrackMessage.Text = $"No request with reference \"{text}\" was found on your account. Check the number and try again.";
                return;
            }

            if (SelectRow(request.Id))
            {
                UpdateSelectionPanels();
                return;
            }

            ShowProgress(request);
            UpdateRelatedPanel(request);
            lblTrackMessage.Text += "\nThe current filters hide it - click Reset to see it in the list.";
        }

        private void ShowProgress(Issue? request)
        {
            if (request == null)
            {
                progressTrack.Value = 0;
                HighlightStep(-1);
                lblTrackMessage.Text = "Select a request below, or enter its reference number, to see its progress.";
                return;
            }

            var stage = request.Status switch
            {
                IssueStatus.Submitted => 0,
                IssueStatus.InProgress => 1,
                IssueStatus.Resolved => 2,
                _ => 3
            };

            progressTrack.Value = ProgressValues[stage];
            HighlightStep(stage);

            var lastUpdate = IssueUpdateRepository.Instance.GetByIssueId(request.Id)
                .Select(update => (DateTime?)update.PostedDate)
                .LastOrDefault() ?? request.DateReported;

            lblTrackMessage.Text =
                $"{request.ReferenceNumber} - {Shorten(request.Title, 30)}\n" +
                $"{EnumDisplayFormatter.ToDisplayText(request.Status)}. Last update {lastUpdate:d MMM yyyy, HH:mm}";
        }

        private void HighlightStep(int currentStage)
        {
            for (var i = 0; i < _stepLabels.Length; i++)
            {
                var reached = i <= currentStage;
                _stepLabels[i].ForeColor = reached ? UiTheme.Primary : UiTheme.SubtleText;
                _stepLabels[i].Font = new Font("Segoe UI", 9F, i == currentStage ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        // ---- Related requests (graph) -------------------------------------------------------

        private void CmbTraversal_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!_loading)
            {
                UpdateRelatedPanel(SelectedIssue);
            }
        }

        private void UpdateRelatedPanel(Issue? request)
        {
            tvRelated.BeginUpdate();
            tvRelated.Nodes.Clear();

            if (request == null || !_graph.Graph.Contains(request.Id))
            {
                tvRelated.EndUpdate();
                lblGraphSummary.Text = _index.Count == 0
                    ? "Once you submit a request, you will see how it relates to others in your community."
                    : "Select a request to see how it relates to other requests in the community.";
                return;
            }

            IReadOnlyList<TraversalStep> steps;
            var spanningWeight = 0;

            switch (cmbTraversal.SelectedIndex)
            {
                case 1:
                    steps = _graph.Graph.DepthFirst(request.Id);
                    break;
                case 2:
                    var spanningTree = _graph.Graph.MinimumSpanningTree(request.Id);
                    steps = spanningTree.Steps;
                    spanningWeight = spanningTree.TotalWeight;
                    break;
                default:
                    steps = _graph.Graph.BreadthFirst(request.Id);
                    break;
            }

            var treeNodes = new Dictionary<int, TreeNode>();
            foreach (var step in steps)
            {
                var related = _communityById[step.Node];
                var text = DescribeRequest(related);
                if (step.Parent != null)
                {
                    text += $"   [{RequestRelationshipGraph.DescribeWeight(step.EdgeWeight)}]";
                }

                var node = new TreeNode(text);
                if (step.Parent is int parentId)
                {
                    treeNodes[parentId].Nodes.Add(node);
                }
                else
                {
                    node.ForeColor = UiTheme.Primary;
                    tvRelated.Nodes.Add(node);
                }

                treeNodes[step.Node] = node;
            }

            tvRelated.ExpandAll();
            tvRelated.EndUpdate();
            tvRelated.TopNode = tvRelated.Nodes[0];

            var others = steps.Count - 1;
            lblGraphSummary.Text = others == 0
                ? $"No other requests are related to {request.ReferenceNumber} yet."
                : cmbTraversal.SelectedIndex switch
                {
                    1 => $"{others} related request(s) reached from {request.ReferenceNumber}, following one chain of relations as deep as it goes.",
                    2 => $"Closest links joining these {steps.Count} requests: total weight {spanningWeight} (lower means more closely related).",
                    _ => $"{others} related request(s) reached from {request.ReferenceNumber}, nearest relations first."
                };
        }

        private string DescribeRequest(Issue request)
        {
            var owner = request.ReportedByUsername == _resident.Username ? "  (yours)" : string.Empty;
            return $"{request.ReferenceNumber}  {EnumDisplayFormatter.ToDisplayText(request.Category)}  -  " +
                   $"{EnumDisplayFormatter.ToDisplayText(request.Status)}{owner}";
        }

        // ---- Buttons ------------------------------------------------------------------------

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            _loading = true;
            txtTitlePrefix.Clear();
            cmbStatus.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            dtpFrom.Checked = false;
            dtpTo.Checked = false;
            _loading = false;

            ApplyFilters();
        }

        private void BtnViewUpdates_Click(object? sender, EventArgs e) => OpenUpdates();

        private void OpenUpdates()
        {
            var request = SelectedIssue;
            if (request == null)
            {
                MessageBox.Show(
                    "Select a request in the list first.",
                    "No Request Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var detailForm = new IssueDetailForm(request, isAdmin: false);
            detailForm.ShowDialog();
            Reload();
        }

        private void BtnRefresh_Click(object? sender, EventArgs e) => Reload();

        private void Reload()
        {
            LoadData();
            ApplyFilters();
        }

        private void BtnClose_Click(object? sender, EventArgs e) => Close();

        private static string Shorten(string text, int maxLength) =>
            text.Length <= maxLength ? text : text[..(maxLength - 3)] + "...";
    }
}
