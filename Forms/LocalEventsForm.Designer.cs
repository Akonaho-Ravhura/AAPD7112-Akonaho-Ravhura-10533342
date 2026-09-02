#nullable disable

namespace Municipal_Application.Forms
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeading;
        private RichTextBox rtbEvents;
        private Button btnRefresh;
        private Button btnClose;

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
            rtbEvents = new RichTextBox();
            btnRefresh = new Button();
            btnClose = new Button();
            SuspendLayout();
            //
            // lblHeading
            //
            lblHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeading.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeading.Location = new Point(20, 15);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(520, 30);
            lblHeading.Text = "Local Events and Announcements";
            //
            // rtbEvents
            //
            rtbEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbEvents.Location = new Point(20, 55);
            rtbEvents.Name = "rtbEvents";
            rtbEvents.ReadOnly = true;
            rtbEvents.Size = new Size(520, 340);
            //
            // btnRefresh
            //
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Location = new Point(20, 405);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += BtnRefresh_Click;
            //
            // btnClose
            //
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(440, 405);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 30);
            btnClose.Text = "Back";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            //
            // LocalEventsForm
            //
            ClientSize = new Size(560, 455);
            Controls.Add(lblHeading);
            Controls.Add(rtbEvents);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(460, 380);
            MaximizeBox = true;
            MinimizeBox = false;
            Name = "LocalEventsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Local Events and Announcements";
            ResumeLayout(false);
        }
    }
}
