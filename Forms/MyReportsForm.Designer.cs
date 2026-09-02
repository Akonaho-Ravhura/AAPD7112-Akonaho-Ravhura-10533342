#nullable disable

namespace Municipal_Application.Forms
{
    partial class MyReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeading;
        private DataGridView dgvIssues;
        private Button btnViewUpdates;
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
            dgvIssues = new DataGridView();
            btnViewUpdates = new Button();
            btnRefresh = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvIssues).BeginInit();
            SuspendLayout();
            //
            // lblHeading
            //
            lblHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeading.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeading.Location = new Point(20, 15);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(620, 30);
            lblHeading.Text = "My Reports & Updates";
            //
            // dgvIssues
            //
            dgvIssues.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvIssues.AllowUserToAddRows = false;
            dgvIssues.AllowUserToDeleteRows = false;
            dgvIssues.ReadOnly = true;
            dgvIssues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIssues.MultiSelect = false;
            dgvIssues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIssues.Location = new Point(20, 55);
            dgvIssues.Name = "dgvIssues";
            dgvIssues.Size = new Size(620, 320);
            //
            // btnViewUpdates
            //
            btnViewUpdates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnViewUpdates.Location = new Point(20, 385);
            btnViewUpdates.Name = "btnViewUpdates";
            btnViewUpdates.Size = new Size(140, 30);
            btnViewUpdates.Text = "View Updates";
            btnViewUpdates.UseVisualStyleBackColor = true;
            btnViewUpdates.Click += BtnViewUpdates_Click;
            //
            // btnRefresh
            //
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Location = new Point(170, 385);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += BtnRefresh_Click;
            //
            // btnClose
            //
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(540, 385);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 30);
            btnClose.Text = "Back";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            //
            // MyReportsForm
            //
            ClientSize = new Size(660, 435);
            Controls.Add(lblHeading);
            Controls.Add(dgvIssues);
            Controls.Add(btnViewUpdates);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(560, 350);
            MaximizeBox = true;
            MinimizeBox = false;
            Name = "MyReportsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "My Reports & Updates";
            ((System.ComponentModel.ISupportInitialize)dgvIssues).EndInit();
            ResumeLayout(false);
        }
    }
}
