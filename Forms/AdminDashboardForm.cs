using System.Text;
using Municipal_Application.Data;
using Municipal_Application.Models;

namespace Municipal_Application.Forms
{
    public partial class AdminDashboardForm : Form
    {
        private readonly Admin _admin;

        public AdminDashboardForm(Admin admin)
        {
            InitializeComponent();
            _admin = admin;
            BackColor = UiTheme.Background;
            lblHeading.ForeColor = UiTheme.Primary;
            UiTheme.ApplyPrimaryButtonStyle(btnViewUpdate);
            UiTheme.ApplyPrimaryButtonStyle(btnPostEvent);

            cmbEventCategory.DataSource = Enum.GetValues(typeof(LocalEventCategory));
            EnumDisplayFormatter.ApplyTo(cmbEventCategory);

            LoadIssues();
            LoadEvents();
        }

        private void LoadIssues()
        {
            var issues = IssueRepository.Instance.GetAll()
                .OrderByDescending(i => i.DateReported)
                .Select(i => new
                {
                    Reference = i.Id,
                    Type = EnumDisplayFormatter.ToDisplayText(i.RequestType),
                    i.Title,
                    Category = EnumDisplayFormatter.ToDisplayText(i.Category),
                    i.Location,
                    Status = EnumDisplayFormatter.ToDisplayText(i.Status),
                    DateReported = i.DateReported.ToString("g"),
                    ReportedBy = i.ReportedByUsername
                })
                .ToList();

            dgvIssues.DataSource = issues;
        }

        private void BtnViewUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvIssues.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Select an issue or service request in the list first.",
                    "No Item Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var reference = (int)dgvIssues.SelectedRows[0].Cells["Reference"].Value!;
            var issue = IssueRepository.Instance.GetById(reference);
            if (issue == null)
            {
                return;
            }

            using var detailForm = new IssueDetailForm(issue, isAdmin: true, admin: _admin);
            detailForm.ShowDialog();
            LoadIssues();
        }

        private void BtnRefreshIssues_Click(object? sender, EventArgs e)
        {
            LoadIssues();
        }

        private void LoadEvents()
        {
            var events = LocalEventRepository.Instance.GetAll();

            if (events.Count == 0)
            {
                rtbEventsList.Text = "No events posted yet.";
                return;
            }

            var sb = new StringBuilder();
            foreach (var localEvent in events)
            {
                sb.AppendLine($"[{localEvent.PostedDate:g}] {localEvent.Title} ({EnumDisplayFormatter.ToDisplayText(localEvent.Category)}) - by {localEvent.PostedByUsername}");
                sb.AppendLine(localEvent.Description);
                sb.AppendLine(new string('-', 60));
            }

            rtbEventsList.Text = sb.ToString();
        }

        private void BtnPostEvent_Click(object? sender, EventArgs e)
        {
            var title = txtEventTitle.Text.Trim();
            var description = rtbEventDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || cmbEventCategory.SelectedItem == null || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show(
                    "Please fill in the title, category and description before posting.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var localEvent = new LocalEvent
            {
                Title = title,
                Category = (LocalEventCategory)cmbEventCategory.SelectedItem!,
                Description = description,
                PostedByUsername = _admin.Username
            };

            LocalEventRepository.Instance.Add(localEvent);

            txtEventTitle.Clear();
            rtbEventDescription.Clear();
            LoadEvents();

            MessageBox.Show(
                "Event posted successfully.",
                "Event Posted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
