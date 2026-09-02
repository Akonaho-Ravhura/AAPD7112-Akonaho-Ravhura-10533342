#nullable disable

namespace Municipal_Application.Forms
{
    partial class IssueDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeading;
        private Label lblInfo;
        private Label lblDescriptionHeading;
        private RichTextBox rtbIssueDescription;
        private Label lblTimelineHeading;
        private RichTextBox rtbTimeline;
        private Panel pnlAdminUpdate;
        private Label lblNewStatus;
        private ComboBox cmbNewStatus;
        private Label lblComment;
        private RichTextBox rtbComment;
        private Label lblPhotos;
        private ListBox lstPhotos;
        private Button btnAddPhoto;
        private Button btnRemovePhoto;
        private Button btnPostUpdate;
        private Button btnClose;
        private OpenFileDialog openFileDialog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblHeading = new Label();
            lblInfo = new Label();
            lblDescriptionHeading = new Label();
            rtbIssueDescription = new RichTextBox();
            lblTimelineHeading = new Label();
            rtbTimeline = new RichTextBox();
            pnlAdminUpdate = new Panel();
            lblNewStatus = new Label();
            cmbNewStatus = new ComboBox();
            lblComment = new Label();
            rtbComment = new RichTextBox();
            lblPhotos = new Label();
            lstPhotos = new ListBox();
            btnAddPhoto = new Button();
            btnRemovePhoto = new Button();
            btnPostUpdate = new Button();
            btnClose = new Button();
            openFileDialog = new OpenFileDialog();
            pnlAdminUpdate.SuspendLayout();
            SuspendLayout();
            //
            // lblHeading
            //
            lblHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeading.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHeading.Location = new Point(20, 15);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(520, 30);
            lblHeading.Text = "Issue Details";
            //
            // lblInfo
            //
            lblInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInfo.Location = new Point(20, 50);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(520, 110);
            lblInfo.Text = "";
            //
            // lblDescriptionHeading
            //
            lblDescriptionHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblDescriptionHeading.AutoSize = true;
            lblDescriptionHeading.Location = new Point(20, 165);
            lblDescriptionHeading.Name = "lblDescriptionHeading";
            lblDescriptionHeading.Size = new Size(70, 15);
            lblDescriptionHeading.Text = "Description:";
            //
            // rtbIssueDescription
            //
            rtbIssueDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtbIssueDescription.Location = new Point(20, 183);
            rtbIssueDescription.Name = "rtbIssueDescription";
            rtbIssueDescription.ReadOnly = true;
            rtbIssueDescription.Size = new Size(520, 55);
            //
            // lblTimelineHeading
            //
            lblTimelineHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblTimelineHeading.AutoSize = true;
            lblTimelineHeading.Location = new Point(20, 248);
            lblTimelineHeading.Name = "lblTimelineHeading";
            lblTimelineHeading.Size = new Size(90, 15);
            lblTimelineHeading.Text = "Update History:";
            //
            // rtbTimeline
            //
            rtbTimeline.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbTimeline.Location = new Point(20, 266);
            rtbTimeline.Name = "rtbTimeline";
            rtbTimeline.ReadOnly = true;
            rtbTimeline.Size = new Size(520, 140);
            //
            // pnlAdminUpdate
            //
            pnlAdminUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAdminUpdate.Controls.Add(lblNewStatus);
            pnlAdminUpdate.Controls.Add(cmbNewStatus);
            pnlAdminUpdate.Controls.Add(lblComment);
            pnlAdminUpdate.Controls.Add(rtbComment);
            pnlAdminUpdate.Controls.Add(lblPhotos);
            pnlAdminUpdate.Controls.Add(lstPhotos);
            pnlAdminUpdate.Controls.Add(btnAddPhoto);
            pnlAdminUpdate.Controls.Add(btnRemovePhoto);
            pnlAdminUpdate.Controls.Add(btnPostUpdate);
            pnlAdminUpdate.Location = new Point(20, 416);
            pnlAdminUpdate.Name = "pnlAdminUpdate";
            pnlAdminUpdate.Size = new Size(520, 210);
            //
            // lblNewStatus
            //
            lblNewStatus.AutoSize = true;
            lblNewStatus.Location = new Point(0, 0);
            lblNewStatus.Name = "lblNewStatus";
            lblNewStatus.Size = new Size(70, 15);
            lblNewStatus.Text = "New Status:";
            //
            // cmbNewStatus
            //
            cmbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNewStatus.Location = new Point(90, -3);
            cmbNewStatus.Name = "cmbNewStatus";
            cmbNewStatus.Size = new Size(160, 23);
            //
            // lblComment
            //
            lblComment.AutoSize = true;
            lblComment.Location = new Point(0, 30);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(63, 15);
            lblComment.Text = "Comment:";
            //
            // rtbComment
            //
            rtbComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtbComment.Location = new Point(0, 48);
            rtbComment.Name = "rtbComment";
            rtbComment.Size = new Size(520, 50);
            //
            // lblPhotos
            //
            lblPhotos.AutoSize = true;
            lblPhotos.Location = new Point(0, 104);
            lblPhotos.Name = "lblPhotos";
            lblPhotos.Size = new Size(140, 15);
            lblPhotos.Text = "Attach Photos (optional):";
            //
            // lstPhotos
            //
            lstPhotos.Location = new Point(0, 122);
            lstPhotos.Name = "lstPhotos";
            lstPhotos.Size = new Size(350, 48);
            //
            // btnAddPhoto
            //
            btnAddPhoto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddPhoto.Location = new Point(360, 122);
            btnAddPhoto.Name = "btnAddPhoto";
            btnAddPhoto.Size = new Size(160, 24);
            btnAddPhoto.Text = "Add Photo...";
            btnAddPhoto.UseVisualStyleBackColor = true;
            btnAddPhoto.Click += BtnAddPhoto_Click;
            //
            // btnRemovePhoto
            //
            btnRemovePhoto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemovePhoto.Location = new Point(360, 150);
            btnRemovePhoto.Name = "btnRemovePhoto";
            btnRemovePhoto.Size = new Size(160, 24);
            btnRemovePhoto.Text = "Remove Selected";
            btnRemovePhoto.UseVisualStyleBackColor = true;
            btnRemovePhoto.Click += BtnRemovePhoto_Click;
            //
            // btnPostUpdate
            //
            btnPostUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPostUpdate.Location = new Point(370, 178);
            btnPostUpdate.Name = "btnPostUpdate";
            btnPostUpdate.Size = new Size(150, 28);
            btnPostUpdate.Text = "Post Update";
            btnPostUpdate.UseVisualStyleBackColor = true;
            btnPostUpdate.Click += BtnPostUpdate_Click;
            //
            // btnClose
            //
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(460, 636);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 30);
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            //
            // IssueDetailForm
            //
            ClientSize = new Size(560, 690);
            Controls.Add(lblHeading);
            Controls.Add(lblInfo);
            Controls.Add(lblDescriptionHeading);
            Controls.Add(rtbIssueDescription);
            Controls.Add(lblTimelineHeading);
            Controls.Add(rtbTimeline);
            Controls.Add(pnlAdminUpdate);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(520, 500);
            MaximizeBox = true;
            MinimizeBox = false;
            Name = "IssueDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Issue Details";
            pnlAdminUpdate.ResumeLayout(false);
            pnlAdminUpdate.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
