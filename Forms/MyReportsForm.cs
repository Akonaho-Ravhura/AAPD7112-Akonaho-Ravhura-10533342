using Municipal_Application.Data;
using Municipal_Application.Models;

namespace Municipal_Application.Forms
{
    public partial class MyReportsForm : Form
    {
        private readonly Resident _resident;

        public MyReportsForm(Resident resident)
        {
            InitializeComponent();
            _resident = resident;
            BackColor = UiTheme.Background;
            lblHeading.ForeColor = UiTheme.Primary;
            LoadIssues();
        }

        private void LoadIssues()
        {
            var issues = IssueRepository.Instance.GetByResident(_resident.Username)
                .OrderByDescending(i => i.DateReported)
                .Select(i => new
                {
                    Reference = i.Id,
                    Type = EnumDisplayFormatter.ToDisplayText(i.RequestType),
                    i.Title,
                    Category = EnumDisplayFormatter.ToDisplayText(i.Category),
                    i.Location,
                    Status = EnumDisplayFormatter.ToDisplayText(i.Status),
                    DateReported = i.DateReported.ToString("g")
                })
                .ToList();

            dgvIssues.DataSource = issues;
        }

        private void BtnViewUpdates_Click(object? sender, EventArgs e)
        {
            if (dgvIssues.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Select a report in the list first.",
                    "No Report Selected",
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

            using var detailForm = new IssueDetailForm(issue, isAdmin: false);
            detailForm.ShowDialog();
            LoadIssues();
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadIssues();
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
