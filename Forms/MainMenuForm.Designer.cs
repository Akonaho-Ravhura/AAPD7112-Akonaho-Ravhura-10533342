#nullable disable

namespace Municipal_Application.Forms
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblWelcome;
        private Label lblSubtitle;
        private Label lblStats;
        private FlowLayoutPanel flpActions;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lblSubtitle = new Label();
            lblStats = new Label();
            flpActions = new FlowLayoutPanel();
            btnLogout = new Button();
            SuspendLayout();
            // Header
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWelcome.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWelcome.Location = new Point(30, 26);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(700, 43);
            lblWelcome.Text = "Welcome";
            lblSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.FromArgb(101, 117, 126);
            lblSubtitle.Location = new Point(33, 76);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(690, 28);
            lblSubtitle.Text = "How can we help your community today?";
            lblStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStats.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStats.Location = new Point(33, 119);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(690, 24);
            // Action cards
            flpActions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpActions.AutoScroll = true;
            flpActions.Location = new Point(22, 155);
            flpActions.Name = "flpActions";
            flpActions.Size = new Size(716, 300);
            flpActions.Padding = new Padding(4);
            flpActions.WrapContents = true;
            flpActions.FlowDirection = FlowDirection.LeftToRight;
            // Footer
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogout.Location = new Point(618, 476);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(120, 38);
            btnLogout.Text = "Sign out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += BtnLogout_Click;
            // MainMenuForm
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 535);
            Controls.Add(lblWelcome);
            Controls.Add(lblSubtitle);
            Controls.Add(lblStats);
            Controls.Add(flpActions);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(620, 480);
            MaximizeBox = true;
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resident Services | Municipal Connect";
            Activated += MainMenuForm_Activated;
            ResumeLayout(false);
        }
    }
}
