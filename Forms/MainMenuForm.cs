using Municipal_Application.Data;
using Municipal_Application.Models;

namespace Municipal_Application.Forms
{
    public partial class MainMenuForm : Form
    {
        private readonly Resident _resident;

        public MainMenuForm(Resident resident)
        {
            InitializeComponent();
            _resident = resident;
            BackColor = UiTheme.Background;
            lblWelcome.ForeColor = UiTheme.Primary;
            UiTheme.ApplyPrimaryButtonStyle(btnReportIssue);
            lblWelcome.Text = $"Welcome, {_resident.FullName}";
            RefreshStats();
        }

        private void MainMenuForm_Activated(object? sender, EventArgs e)
        {
            RefreshStats();
        }

        private void RefreshStats()
        {
            var count = IssueRepository.Instance.Count;
            lblStats.Text = count == 1
                ? "1 issue reported by the community so far."
                : $"{count} issues reported by the community so far.";
        }

        private void BtnReportIssue_Click(object? sender, EventArgs e)
        {
            using var reportForm = new ReportIssueForm(_resident);
            reportForm.ShowDialog();
            RefreshStats();
        }

        private void BtnServiceRequest_Click(object? sender, EventArgs e)
        {
            using var requestForm = new ServiceRequestForm(_resident);
            requestForm.ShowDialog();
            RefreshStats();
        }

        private void BtnLocalEvents_Click(object? sender, EventArgs e)
        {
            using var eventsForm = new LocalEventsForm();
            eventsForm.ShowDialog();
        }

        private void BtnMyReports_Click(object? sender, EventArgs e)
        {
            using var myReportsForm = new MyReportsForm(_resident);
            myReportsForm.ShowDialog();
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
