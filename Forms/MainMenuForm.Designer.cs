#nullable disable

namespace Municipal_Application.Forms
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private Label lblStats;
        private Button btnReportIssue;
        private Button btnServiceRequest;
        private Button btnLocalEvents;
        private Button btnMyReports;
        private Button btnLogout;

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
            lblWelcome = new Label();
            lblStats = new Label();
            btnReportIssue = new Button();
            btnServiceRequest = new Button();
            btnLocalEvents = new Button();
            btnMyReports = new Button();
            btnLogout = new Button();
            SuspendLayout();
            //
            // lblWelcome
            //
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWelcome.Location = new Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(440, 30);
            lblWelcome.Text = "Welcome";
            //
            // lblStats
            //
            lblStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStats.ForeColor = Color.DimGray;
            lblStats.Location = new Point(20, 55);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(440, 25);
            lblStats.Text = "0 issues reported by the community so far.";
            //
            // btnReportIssue
            //
            btnReportIssue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnReportIssue.Font = new Font("Segoe UI", 11F);
            btnReportIssue.Location = new Point(20, 95);
            btnReportIssue.Name = "btnReportIssue";
            btnReportIssue.Size = new Size(440, 45);
            btnReportIssue.Text = "Report Issues";
            btnReportIssue.UseVisualStyleBackColor = true;
            btnReportIssue.Click += BtnReportIssue_Click;
            //
            // btnServiceRequest
            //
            btnServiceRequest.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnServiceRequest.Font = new Font("Segoe UI", 11F);
            btnServiceRequest.Location = new Point(20, 145);
            btnServiceRequest.Name = "btnServiceRequest";
            btnServiceRequest.Size = new Size(440, 45);
            btnServiceRequest.Text = "Submit a Service Request";
            btnServiceRequest.UseVisualStyleBackColor = true;
            btnServiceRequest.Click += BtnServiceRequest_Click;
            //
            // btnLocalEvents
            //
            btnLocalEvents.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLocalEvents.Font = new Font("Segoe UI", 11F);
            btnLocalEvents.Location = new Point(20, 195);
            btnLocalEvents.Name = "btnLocalEvents";
            btnLocalEvents.Size = new Size(440, 45);
            btnLocalEvents.Text = "Local Events and Announcements";
            btnLocalEvents.UseVisualStyleBackColor = true;
            btnLocalEvents.Click += BtnLocalEvents_Click;
            //
            // btnMyReports
            //
            btnMyReports.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnMyReports.Font = new Font("Segoe UI", 11F);
            btnMyReports.Location = new Point(20, 245);
            btnMyReports.Name = "btnMyReports";
            btnMyReports.Size = new Size(440, 45);
            btnMyReports.Text = "My Reports && Updates";
            btnMyReports.UseVisualStyleBackColor = true;
            btnMyReports.Click += BtnMyReports_Click;
            //
            // btnLogout
            //
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnLogout.Location = new Point(20, 305);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(120, 32);
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += BtnLogout_Click;
            //
            // MainMenuForm
            //
            ClientSize = new Size(480, 360);
            Controls.Add(lblWelcome);
            Controls.Add(lblStats);
            Controls.Add(btnReportIssue);
            Controls.Add(btnServiceRequest);
            Controls.Add(btnLocalEvents);
            Controls.Add(btnMyReports);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(420, 400);
            MaximizeBox = true;
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resident Menu - Municipal Engagement Platform";
            Activated += MainMenuForm_Activated;
            ResumeLayout(false);
        }
    }
}
