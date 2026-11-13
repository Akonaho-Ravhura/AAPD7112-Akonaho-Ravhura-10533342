using Municipal_Application.Data;
using Municipal_Application.Models;

namespace Municipal_Application.Forms
{
    public partial class ServiceRequestForm : Form
    {
        private readonly Resident _resident;
        private readonly List<string> _attachmentPaths = new();

        public ServiceRequestForm(Resident resident)
        {
            InitializeComponent();
            UiTheme.Apply(this);
            _resident = resident;
            lblHeading.ForeColor = UiTheme.Primary;
            UiTheme.ApplyPrimaryButtonStyle(btnSubmit);
            cmbServiceType.DataSource = Enum.GetValues(typeof(ServiceRequestType));
            EnumDisplayFormatter.ApplyTo(cmbServiceType);
            UpdateEngagementFeedback();
        }

        private void FieldChanged(object? sender, EventArgs e)
        {
            UpdateEngagementFeedback();
        }

        private void UpdateEngagementFeedback()
        {
            var fieldsCompleted = 0;
            const int totalFields = 4;

            if (!string.IsNullOrWhiteSpace(txtTitle.Text)) fieldsCompleted++;
            if (cmbServiceType.SelectedItem != null) fieldsCompleted++;
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) fieldsCompleted++;
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text)) fieldsCompleted++;

            var percentage = fieldsCompleted * 100 / totalFields;
            progressCompletion.Value = percentage;

            lblEncouragement.Text = percentage switch
            {
                0 => "Let's get started - fill in the details below.",
                100 => "All set! Thank you for helping improve your community - click Submit.",
                _ => $"Great progress - {percentage}% complete. Every request helps your community."
            };
        }

        private void BtnAddAttachment_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Select a file to attach",
                Multiselect = true,
                Filter = "All Files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileName in dialog.FileNames)
                {
                    if (!_attachmentPaths.Contains(fileName))
                    {
                        _attachmentPaths.Add(fileName);
                        lstAttachments.Items.Add(Path.GetFileName(fileName));
                    }
                }
            }
        }

        private void BtnRemoveAttachment_Click(object? sender, EventArgs e)
        {
            var index = lstAttachments.SelectedIndex;
            if (index >= 0)
            {
                _attachmentPaths.RemoveAt(index);
                lstAttachments.Items.RemoveAt(index);
            }
        }

        private void BtnSubmit_Click(object? sender, EventArgs e)
        {
            var title = txtTitle.Text.Trim();
            var location = txtLocation.Text.Trim();
            var description = rtbDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || cmbServiceType.SelectedItem == null ||
                string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show(
                    "Please fill in the title, service type, location and details before submitting.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var request = new Issue
            {
                RequestType = RequestType.ServiceRequest,
                Title = title,
                Description = description,
                Location = location,
                Category = ((ServiceRequestType)cmbServiceType.SelectedItem!).ToString(),
                ReportedByUsername = _resident.Username,
                AttachmentPaths = new List<string>(_attachmentPaths)
            };

            IssueRepository.Instance.Add(request);

            MessageBox.Show(
                $"Thank you, {_resident.FullName}! Your service request has been logged as {request.ReferenceNumber}.\n\n" +
                "Use this reference number under \"Service Request Status\" on the main menu to track its progress.",
                "Service Request Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
