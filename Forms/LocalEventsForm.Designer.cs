#nullable disable

namespace Municipal_Application.Forms
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeading;
        private Label lblSubtitle;
        private Panel pnlFilters;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblFrom;
        private DateTimePicker dtpFrom;
        private Label lblTo;
        private DateTimePicker dtpTo;
        private Button btnApplyFilters;
        private Button btnResetFilters;
        private Label lblResults;
        private DataGridView dgvEvents;
        private Label lblRecommendations;
        private ListBox lstRecommendations;
        private Button btnRefresh;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblHeading = new Label();
            lblSubtitle = new Label();
            pnlFilters = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblFrom = new Label();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            btnApplyFilters = new Button();
            btnResetFilters = new Button();
            lblResults = new Label();
            dgvEvents = new DataGridView();
            lblRecommendations = new Label();
            lstRecommendations = new ListBox();
            btnRefresh = new Button();
            btnClose = new Button();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            SuspendLayout();
            // Header
            lblHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeading.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeading.Location = new Point(24, 20);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(1030, 36);
            lblHeading.Text = "Local Events & Announcements";
            lblSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSubtitle.Location = new Point(28, 58);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(1020, 24);
            lblSubtitle.Text = "Find upcoming community notices, municipal services and local activities.";
            // Filters
            pnlFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilters.BackColor = Color.White;
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(lblSearch);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Controls.Add(lblCategory);
            pnlFilters.Controls.Add(cmbCategory);
            pnlFilters.Controls.Add(lblFrom);
            pnlFilters.Controls.Add(dtpFrom);
            pnlFilters.Controls.Add(lblTo);
            pnlFilters.Controls.Add(dtpTo);
            pnlFilters.Controls.Add(btnApplyFilters);
            pnlFilters.Controls.Add(btnResetFilters);
            pnlFilters.Location = new Point(24, 91);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1032, 88);
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(12, 9);
            lblSearch.Name = "lblSearch";
            lblSearch.Text = "Search";
            txtSearch.Location = new Point(12, 32);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(225, 27);
            txtSearch.PlaceholderText = "Title or keywords";
            txtSearch.KeyDown += TxtSearch_KeyDown;
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(249, 9);
            lblCategory.Name = "lblCategory";
            lblCategory.Text = "Category";
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(249, 32);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(175, 27);
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(438, 9);
            lblFrom.Name = "lblFrom";
            lblFrom.Text = "From";
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(438, 32);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(124, 27);
            lblTo.AutoSize = true;
            lblTo.Location = new Point(576, 9);
            lblTo.Name = "lblTo";
            lblTo.Text = "To";
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(576, 32);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(124, 27);
            btnApplyFilters.Location = new Point(718, 30);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(150, 34);
            btnApplyFilters.Text = "Apply filters";
            btnApplyFilters.Click += BtnApplyFilters_Click;
            btnResetFilters.Location = new Point(878, 30);
            btnResetFilters.Name = "btnResetFilters";
            btnResetFilters.Size = new Size(115, 34);
            btnResetFilters.Text = "Reset";
            btnResetFilters.Click += BtnResetFilters_Click;
            // Results
            lblResults.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblResults.ForeColor = Color.FromArgb(101, 117, 126);
            lblResults.Location = new Point(28, 185);
            lblResults.Name = "lblResults";
            lblResults.Size = new Size(1020, 23);
            lblResults.Text = "Upcoming events";
            dgvEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.AllowUserToDeleteRows = false;
            dgvEvents.AllowUserToResizeRows = false;
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEvents.ColumnHeadersHeight = 36;
            dgvEvents.Location = new Point(24, 210);
            dgvEvents.MultiSelect = false;
            dgvEvents.Name = "dgvEvents";
            dgvEvents.ReadOnly = true;
            dgvEvents.RowHeadersVisible = false;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvents.Size = new Size(1032, 365);
            dgvEvents.CellFormatting += DgvEvents_CellFormatting;
            // Recommendations
            lblRecommendations.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblRecommendations.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRecommendations.ForeColor = Color.FromArgb(22, 101, 90);
            lblRecommendations.Location = new Point(28, 586);
            lblRecommendations.Name = "lblRecommendations";
            lblRecommendations.Size = new Size(1020, 24);
            lblRecommendations.Text = "Recommended for you";
            lstRecommendations.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstRecommendations.FormattingEnabled = true;
            lstRecommendations.ItemHeight = 20;
            lstRecommendations.Location = new Point(24, 612);
            lstRecommendations.Name = "lstRecommendations";
            lstRecommendations.Size = new Size(1032, 64);
            // Footer
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Location = new Point(24, 690);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(105, 34);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += BtnRefresh_Click;
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(951, 690);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(105, 34);
            btnClose.Text = "Back";
            btnClose.Click += BtnClose_Click;
            // LocalEventsForm
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 745);
            Controls.Add(lblHeading);
            Controls.Add(lblSubtitle);
            Controls.Add(pnlFilters);
            Controls.Add(lblResults);
            Controls.Add(dgvEvents);
            Controls.Add(lblRecommendations);
            Controls.Add(lstRecommendations);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(960, 620);
            MaximizeBox = true;
            MinimizeBox = false;
            Name = "LocalEventsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Local Events and Announcements";
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            ResumeLayout(false);
        }
    }
}
