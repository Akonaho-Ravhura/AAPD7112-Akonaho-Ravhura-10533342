using Municipal_Application.Data;
using Municipal_Application.Models;

namespace Municipal_Application.Forms
{
    public partial class LocalEventsForm : Form
    {
        private readonly string _username;
        private readonly System.Windows.Forms.Timer _refreshTimer;
        private List<LocalEvent> _currentResults = new();

        public LocalEventsForm(string username)
        {
            InitializeComponent();
            _username = username;
            UiTheme.Apply(this);
            lblHeading.ForeColor = UiTheme.Primary;
            lblSubtitle.ForeColor = UiTheme.SubtleText;
            lblRecommendations.ForeColor = UiTheme.Primary;
            UiTheme.ApplyPrimaryButtonStyle(btnApplyFilters);
            UiTheme.ApplySecondaryButtonStyle(btnResetFilters);

            cmbCategory.Items.Add("All categories");
            foreach (var category in Enum.GetValues<LocalEventCategory>())
            {
                cmbCategory.Items.Add(category);
            }
            cmbCategory.Format += (_, args) =>
            {
                if (args.Value is LocalEventCategory category)
                    args.Value = EnumDisplayFormatter.ToDisplayText(category);
            };
            cmbCategory.SelectedIndex = 0;

            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddDays(90);
            Resize += (_, _) => LayoutResponsiveControls();
            LayoutResponsiveControls();

            _refreshTimer = new System.Windows.Forms.Timer { Interval = 15000 };
            _refreshTimer.Tick += (_, _) => LoadEvents();
            _refreshTimer.Start();
            FormClosed += (_, _) => _refreshTimer.Stop();
            LoadEvents();
        }

        private void LayoutResponsiveControls()
        {
            if (pnlFilters == null || dgvEvents == null) return;

            var compact = pnlFilters.ClientSize.Width < 1000;
            pnlFilters.Height = compact ? 132 : 88;

            if (compact)
            {
                lblSearch.Location = new Point(12, 8);
                txtSearch.Location = new Point(12, 32);
                txtSearch.Width = 270;
                lblCategory.Location = new Point(298, 8);
                cmbCategory.Location = new Point(298, 32);
                cmbCategory.Width = 240;
                lblFrom.Location = new Point(12, 70);
                dtpFrom.Location = new Point(12, 93);
                lblTo.Location = new Point(150, 70);
                dtpTo.Location = new Point(150, 93);
                btnApplyFilters.Location = new Point(300, 90);
                btnResetFilters.Location = new Point(460, 90);
            }
            else
            {
                lblSearch.Location = new Point(12, 9);
                txtSearch.Location = new Point(12, 32);
                txtSearch.Width = 225;
                lblCategory.Location = new Point(249, 9);
                cmbCategory.Location = new Point(249, 32);
                cmbCategory.Width = 175;
                lblFrom.Location = new Point(438, 9);
                dtpFrom.Location = new Point(438, 32);
                lblTo.Location = new Point(576, 9);
                dtpTo.Location = new Point(576, 32);
                btnApplyFilters.Location = new Point(718, 30);
                btnResetFilters.Location = new Point(878, 30);
            }

            lblResults.Top = pnlFilters.Bottom + 5;
            dgvEvents.Top = lblResults.Bottom + 2;
            dgvEvents.Height = Math.Max(100, lblRecommendations.Top - dgvEvents.Top - 10);
        }

        private LocalEventCategory? SelectedCategory =>
            cmbCategory.SelectedItem is LocalEventCategory category ? category : null;

        private void LoadEvents(bool recordSearch = false)
        {
            if (dtpTo.Value.Date < dtpFrom.Value.Date)
            {
                lblResults.Text = "Choose an end date that is on or after the start date.";
                dgvEvents.DataSource = null;
                lstRecommendations.Items.Clear();
                _currentResults.Clear();
                return;
            }

            var query = txtSearch.Text.Trim();
            var selectedCategory = SelectedCategory;
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date;

            if (recordSearch)
            {
                LocalEventRecommendationService.Instance.RecordSearch(_username, query, selectedCategory, from, to);
            }

            var repository = LocalEventRepository.Instance;
            _currentResults = repository.Search(query, selectedCategory, from, to);
            dgvEvents.DataSource = _currentResults.Select(localEvent => new
            {
                localEvent.EventDate,
                localEvent.Title,
                Category = EnumDisplayFormatter.ToDisplayText(localEvent.Category),
                localEvent.Description
            }).ToList();

            if (dgvEvents.Columns.Count >= 4)
            {
                dgvEvents.Columns[0].HeaderText = "Event date";
                dgvEvents.Columns[0].FillWeight = 18;
                dgvEvents.Columns[1].FillWeight = 22;
                dgvEvents.Columns[2].FillWeight = 20;
                dgvEvents.Columns[3].FillWeight = 40;
            }

            dgvEvents.ClearSelection();
            var uniqueDates = repository.GetUniqueEventDates().Count;
            lblResults.Text = _currentResults.Count == 0
                ? $"No upcoming events match these filters. {uniqueDates} unique event dates are currently listed."
                : $"{_currentResults.Count} upcoming event{(_currentResults.Count == 1 ? "" : "s")} found  ·  {uniqueDates} unique event dates";

            var recommendations = LocalEventRecommendationService.Instance
                .GetRecommendations(_username, _currentResults);
            lstRecommendations.Items.Clear();
            foreach (var localEvent in recommendations)
            {
                lstRecommendations.Items.Add($"{localEvent.EventDate:dd MMM yyyy}  ·  {localEvent.Title}  ·  {EnumDisplayFormatter.ToDisplayText(localEvent.Category)}");
            }
            if (lstRecommendations.Items.Count == 0)
            {
                lstRecommendations.Items.Add("No recommendations yet. Try searching for a category or keyword.");
            }
        }

        private void BtnApplyFilters_Click(object? sender, EventArgs e) => LoadEvents(recordSearch: true);

        private void BtnResetFilters_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddDays(90);
            LoadEvents();
        }

        private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadEvents(recordSearch: true);
            }
        }

        private void DgvEvents_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEvents.Columns[e.ColumnIndex].DataPropertyName == "EventDate" && e.Value is DateTime date)
            {
                e.Value = date.ToString("ddd, dd MMM yyyy");
                e.FormattingApplied = true;
            }
        }

        private void BtnRefresh_Click(object? sender, EventArgs e) => LoadEvents();

        private void BtnClose_Click(object? sender, EventArgs e) => Close();
    }
}
