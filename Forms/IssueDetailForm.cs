using System.Text;
using Municipal_Application.Data;
using Municipal_Application.Models;

namespace Municipal_Application.Forms
{
    public partial class IssueDetailForm : Form
    {
        private readonly Issue _issue;
        private readonly bool _isAdmin;
        private readonly Admin? _admin;
        private readonly List<string> _photoPaths = new();

        public IssueDetailForm(Issue issue, bool isAdmin, Admin? admin = null)
        {
            InitializeComponent();
            _issue = issue;
            _isAdmin = isAdmin;
            _admin = admin;

            BackColor = UiTheme.Background;
            lblHeading.ForeColor = UiTheme.Primary;

            var kind = issue.RequestType == RequestType.ServiceRequest ? "Service Request" : "Issue";
            lblHeading.Text = $"{kind} #{issue.Id} - {issue.Title}";
            rtbIssueDescription.Text = issue.Description;

            RefreshInfo();
            RefreshTimeline();

            if (_isAdmin)
            {
                cmbNewStatus.DataSource = Enum.GetValues(typeof(IssueStatus));
                EnumDisplayFormatter.ApplyTo(cmbNewStatus);
                cmbNewStatus.SelectedItem = issue.Status;
                UiTheme.ApplyPrimaryButtonStyle(btnPostUpdate);
            }
            else
            {
                CollapseAdminPanel();
            }
        }

        private void CollapseAdminPanel()
        {
            pnlAdminUpdate.Visible = false;
            rtbTimeline.Height = pnlAdminUpdate.Top - rtbTimeline.Top - 10;
            btnClose.Top = rtbTimeline.Bottom + 10;
            ClientSize = new Size(ClientSize.Width, btnClose.Bottom + 20);
        }

        private void RefreshInfo()
        {
            var kind = _issue.RequestType == RequestType.ServiceRequest ? "Service Request" : "Issue Report";

            lblInfo.Text =
                $"Type: {kind}\n" +
                $"Category: {EnumDisplayFormatter.ToDisplayText(_issue.Category)}\n" +
                $"Location: {_issue.Location}\n" +
                $"Reported By (ID Number): {_issue.ReportedByUsername}\n" +
                $"Date Reported: {_issue.DateReported:g}\n" +
                $"Current Status: {EnumDisplayFormatter.ToDisplayText(_issue.Status)}";
        }

        private void RefreshTimeline()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[{_issue.DateReported:g}] Status: Submitted");
            sb.AppendLine("Reported by the resident.");
            sb.AppendLine(new string('-', 60));

            foreach (var update in IssueUpdateRepository.Instance.GetByIssueId(_issue.Id))
            {
                sb.AppendLine($"[{update.PostedDate:g}] Status: {EnumDisplayFormatter.ToDisplayText(update.Status)} - posted by {update.PostedByUsername}");

                if (!string.IsNullOrWhiteSpace(update.Comment))
                {
                    sb.AppendLine(update.Comment);
                }

                if (update.AttachmentPaths.Count > 0)
                {
                    sb.AppendLine("Photos: " + string.Join(", ", update.AttachmentPaths.Select(Path.GetFileName)));
                }

                sb.AppendLine(new string('-', 60));
            }

            rtbTimeline.Text = sb.ToString();
        }

        private void BtnAddPhoto_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Select a photo to attach",
                Multiselect = true,
                Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileName in dialog.FileNames)
                {
                    if (!_photoPaths.Contains(fileName))
                    {
                        _photoPaths.Add(fileName);
                        lstPhotos.Items.Add(Path.GetFileName(fileName));
                    }
                }
            }
        }

        private void BtnRemovePhoto_Click(object? sender, EventArgs e)
        {
            var index = lstPhotos.SelectedIndex;
            if (index >= 0)
            {
                _photoPaths.RemoveAt(index);
                lstPhotos.Items.RemoveAt(index);
            }
        }

        private void BtnPostUpdate_Click(object? sender, EventArgs e)
        {
            if (cmbNewStatus.SelectedItem == null || _admin == null)
            {
                return;
            }

            var newStatus = (IssueStatus)cmbNewStatus.SelectedItem;

            var update = new IssueUpdate
            {
                IssueId = _issue.Id,
                Status = newStatus,
                Comment = rtbComment.Text.Trim(),
                AttachmentPaths = new List<string>(_photoPaths),
                PostedByUsername = _admin.Username
            };

            IssueUpdateRepository.Instance.Add(update);
            IssueRepository.Instance.UpdateStatus(_issue.Id, newStatus);

            rtbComment.Clear();
            lstPhotos.Items.Clear();
            _photoPaths.Clear();

            RefreshInfo();
            RefreshTimeline();

            MessageBox.Show(
                $"Update posted for #{_issue.Id}. Status set to {newStatus}.",
                "Update Posted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
