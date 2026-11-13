#nullable disable

namespace Municipal_Application.Forms
{
    partial class ServiceRequestStatusForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private Panel pnlHeader;
        private Label lblHeading;
        private Label lblSubtitle;

        // Track a request
        private Panel pnlTrack;
        private Label lblTrackHeading;
        private TextBox txtReference;
        private Button btnTrack;
        private Label lblTrackMessage;
        private TableLayoutPanel tlpStepper;
        private ProgressBar progressTrack;
        private Label lblStepSubmitted;
        private Label lblStepInProgress;
        private Label lblStepResolved;
        private Label lblStepClosed;

        // Filters
        private Panel spacerTop1;
        private FlowLayoutPanel flpFilters;
        private Panel pnlFilterTitle;
        private Label lblFilterTitle;
        private TextBox txtTitlePrefix;
        private Panel pnlFilterStatus;
        private Label lblFilterStatus;
        private ComboBox cmbStatus;
        private Panel pnlFilterType;
        private Label lblFilterType;
        private ComboBox cmbType;
        private Panel pnlFilterFrom;
        private Label lblFilterFrom;
        private DateTimePicker dtpFrom;
        private Panel pnlFilterTo;
        private Label lblFilterTo;
        private DateTimePicker dtpTo;
        private Panel pnlFilterSort;
        private Label lblFilterSort;
        private ComboBox cmbSort;
        private Button btnReset;
        private Panel spacerTop2;

        // Bottom bar
        private Panel pnlBottom;
        private Label lblStructures;
        private FlowLayoutPanel flpButtons;
        private Button btnViewUpdates;
        private Button btnRefresh;
        private Button btnClose;

        // Right column
        private Panel pnlRight;
        private Panel pnlPriority;
        private Label lblPriorityHeading;
        private ListBox lstPriority;
        private Panel spacerRight;
        private Panel pnlGraph;
        private Label lblGraphHeading;
        private ComboBox cmbTraversal;
        private Label lblGraphSummary;
        private TreeView tvRelated;

        // Request list
        private Panel pnlGrid;
        private Label lblResultSummary;
        private DataGridView dgvRequests;

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
            pnlHeader = new Panel();
            lblHeading = new Label();
            lblSubtitle = new Label();
            pnlTrack = new Panel();
            lblTrackHeading = new Label();
            txtReference = new TextBox();
            btnTrack = new Button();
            lblTrackMessage = new Label();
            tlpStepper = new TableLayoutPanel();
            progressTrack = new ProgressBar();
            lblStepSubmitted = new Label();
            lblStepInProgress = new Label();
            lblStepResolved = new Label();
            lblStepClosed = new Label();
            spacerTop1 = new Panel();
            flpFilters = new FlowLayoutPanel();
            pnlFilterTitle = new Panel();
            lblFilterTitle = new Label();
            txtTitlePrefix = new TextBox();
            pnlFilterStatus = new Panel();
            lblFilterStatus = new Label();
            cmbStatus = new ComboBox();
            pnlFilterType = new Panel();
            lblFilterType = new Label();
            cmbType = new ComboBox();
            pnlFilterFrom = new Panel();
            lblFilterFrom = new Label();
            dtpFrom = new DateTimePicker();
            pnlFilterTo = new Panel();
            lblFilterTo = new Label();
            dtpTo = new DateTimePicker();
            pnlFilterSort = new Panel();
            lblFilterSort = new Label();
            cmbSort = new ComboBox();
            btnReset = new Button();
            spacerTop2 = new Panel();
            pnlBottom = new Panel();
            lblStructures = new Label();
            flpButtons = new FlowLayoutPanel();
            btnViewUpdates = new Button();
            btnRefresh = new Button();
            btnClose = new Button();
            pnlRight = new Panel();
            pnlPriority = new Panel();
            lblPriorityHeading = new Label();
            lstPriority = new ListBox();
            spacerRight = new Panel();
            pnlGraph = new Panel();
            lblGraphHeading = new Label();
            cmbTraversal = new ComboBox();
            lblGraphSummary = new Label();
            tvRelated = new TreeView();
            pnlGrid = new Panel();
            lblResultSummary = new Label();
            dgvRequests = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlTrack.SuspendLayout();
            tlpStepper.SuspendLayout();
            flpFilters.SuspendLayout();
            pnlFilterTitle.SuspendLayout();
            pnlFilterStatus.SuspendLayout();
            pnlFilterType.SuspendLayout();
            pnlFilterFrom.SuspendLayout();
            pnlFilterTo.SuspendLayout();
            pnlFilterSort.SuspendLayout();
            pnlBottom.SuspendLayout();
            flpButtons.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlPriority.SuspendLayout();
            pnlGraph.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();

            // ---- Header
            lblHeading.AutoSize = true;
            lblHeading.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeading.Location = new Point(0, 14);
            lblHeading.Name = "lblHeading";
            lblHeading.Text = "Service Request Status";
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(3, 56);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Text = "Track each request with its unique reference number and see how it relates to other community requests.";
            pnlHeader.Controls.Add(lblHeading);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1160, 88);

            // ---- Track a request
            lblTrackHeading.AutoSize = true;
            lblTrackHeading.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTrackHeading.Location = new Point(16, 12);
            lblTrackHeading.Name = "lblTrackHeading";
            lblTrackHeading.Text = "Track a request by reference number";
            txtReference.Location = new Point(16, 42);
            txtReference.Name = "txtReference";
            txtReference.PlaceholderText = "e.g. SR-00001";
            txtReference.Size = new Size(220, 27);
            txtReference.KeyDown += TxtReference_KeyDown;
            btnTrack.Location = new Point(246, 40);
            btnTrack.Name = "btnTrack";
            btnTrack.Size = new Size(90, 31);
            btnTrack.Text = "Track";
            btnTrack.Click += BtnTrack_Click;
            lblTrackMessage.AutoEllipsis = false;
            lblTrackMessage.Font = new Font("Segoe UI", 9F);
            lblTrackMessage.Location = new Point(16, 78);
            lblTrackMessage.Name = "lblTrackMessage";
            lblTrackMessage.Size = new Size(350, 44);
            lblTrackMessage.Text = "";

            progressTrack.Dock = DockStyle.Fill;
            progressTrack.Margin = new Padding(6, 8, 6, 4);
            progressTrack.Name = "progressTrack";
            progressTrack.Style = ProgressBarStyle.Continuous;
            ConfigureStepLabel(lblStepSubmitted, "lblStepSubmitted", "Submitted");
            ConfigureStepLabel(lblStepInProgress, "lblStepInProgress", "In Progress");
            ConfigureStepLabel(lblStepResolved, "lblStepResolved", "Resolved");
            ConfigureStepLabel(lblStepClosed, "lblStepClosed", "Closed");
            tlpStepper.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpStepper.ColumnCount = 4;
            tlpStepper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStepper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStepper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStepper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpStepper.RowCount = 2;
            tlpStepper.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpStepper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpStepper.Controls.Add(progressTrack, 0, 0);
            tlpStepper.SetColumnSpan(progressTrack, 4);
            tlpStepper.Controls.Add(lblStepSubmitted, 0, 1);
            tlpStepper.Controls.Add(lblStepInProgress, 1, 1);
            tlpStepper.Controls.Add(lblStepResolved, 2, 1);
            tlpStepper.Controls.Add(lblStepClosed, 3, 1);
            tlpStepper.Location = new Point(380, 30);
            tlpStepper.Name = "tlpStepper";
            tlpStepper.Size = new Size(380, 76);

            pnlTrack.BorderStyle = BorderStyle.FixedSingle;
            pnlTrack.Controls.Add(lblTrackHeading);
            pnlTrack.Controls.Add(txtReference);
            pnlTrack.Controls.Add(btnTrack);
            pnlTrack.Controls.Add(lblTrackMessage);
            pnlTrack.Controls.Add(tlpStepper);
            pnlTrack.Dock = DockStyle.Top;
            pnlTrack.Name = "pnlTrack";
            pnlTrack.Size = new Size(780, 126);

            spacerTop1.Dock = DockStyle.Top;
            spacerTop1.Name = "spacerTop1";
            spacerTop1.Size = new Size(780, 10);

            // ---- Filters
            ConfigureFilterGroup(pnlFilterTitle, "pnlFilterTitle", lblFilterTitle, "lblFilterTitle", "Title starts with", 170);
            txtTitlePrefix.Location = new Point(0, 22);
            txtTitlePrefix.Name = "txtTitlePrefix";
            txtTitlePrefix.Size = new Size(160, 27);
            txtTitlePrefix.TextChanged += FiltersChanged;
            pnlFilterTitle.Controls.Add(txtTitlePrefix);

            ConfigureFilterGroup(pnlFilterStatus, "pnlFilterStatus", lblFilterStatus, "lblFilterStatus", "Status", 140);
            ConfigureFilterCombo(cmbStatus, "cmbStatus", 130);
            pnlFilterStatus.Controls.Add(cmbStatus);

            ConfigureFilterGroup(pnlFilterType, "pnlFilterType", lblFilterType, "lblFilterType", "Type", 150);
            ConfigureFilterCombo(cmbType, "cmbType", 140);
            pnlFilterType.Controls.Add(cmbType);

            ConfigureFilterGroup(pnlFilterFrom, "pnlFilterFrom", lblFilterFrom, "lblFilterFrom", "Submitted from", 160);
            ConfigureDatePicker(dtpFrom, "dtpFrom");
            pnlFilterFrom.Controls.Add(dtpFrom);

            ConfigureFilterGroup(pnlFilterTo, "pnlFilterTo", lblFilterTo, "lblFilterTo", "Submitted to", 160);
            ConfigureDatePicker(dtpTo, "dtpTo");
            pnlFilterTo.Controls.Add(dtpTo);

            ConfigureFilterGroup(pnlFilterSort, "pnlFilterSort", lblFilterSort, "lblFilterSort", "Sort by", 220);
            ConfigureFilterCombo(cmbSort, "cmbSort", 210);
            pnlFilterSort.Controls.Add(cmbSort);

            btnReset.Margin = new Padding(0, 22, 0, 0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(90, 30);
            btnReset.Text = "Reset";
            btnReset.Click += BtnReset_Click;

            flpFilters.AutoSize = true;
            flpFilters.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpFilters.BorderStyle = BorderStyle.FixedSingle;
            flpFilters.Controls.Add(pnlFilterTitle);
            flpFilters.Controls.Add(pnlFilterStatus);
            flpFilters.Controls.Add(pnlFilterType);
            flpFilters.Controls.Add(pnlFilterSort);
            flpFilters.Controls.Add(pnlFilterFrom);
            flpFilters.Controls.Add(pnlFilterTo);
            flpFilters.Controls.Add(btnReset);
            flpFilters.Dock = DockStyle.Top;
            flpFilters.Name = "flpFilters";
            flpFilters.Padding = new Padding(12, 8, 12, 6);
            flpFilters.Size = new Size(780, 80);

            spacerTop2.Dock = DockStyle.Top;
            spacerTop2.Name = "spacerTop2";
            spacerTop2.Size = new Size(780, 10);

            // ---- Bottom bar
            lblStructures.Dock = DockStyle.Fill;
            lblStructures.Font = new Font("Segoe UI", 8.5F);
            lblStructures.Name = "lblStructures";
            lblStructures.TextAlign = ContentAlignment.MiddleLeft;
            ConfigureBottomButton(btnViewUpdates, "btnViewUpdates", "View Updates");
            btnViewUpdates.Click += BtnViewUpdates_Click;
            ConfigureBottomButton(btnRefresh, "btnRefresh", "Refresh");
            btnRefresh.Click += BtnRefresh_Click;
            ConfigureBottomButton(btnClose, "btnClose", "Back to Menu");
            btnClose.Click += BtnClose_Click;
            flpButtons.AutoSize = true;
            flpButtons.WrapContents = false;
            flpButtons.Controls.Add(btnViewUpdates);
            flpButtons.Controls.Add(btnRefresh);
            flpButtons.Controls.Add(btnClose);
            flpButtons.Dock = DockStyle.Right;
            flpButtons.Name = "flpButtons";
            flpButtons.Padding = new Padding(0, 10, 0, 0);
            flpButtons.Size = new Size(420, 58);
            pnlBottom.Controls.Add(lblStructures);
            pnlBottom.Controls.Add(flpButtons);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1160, 58);

            // ---- Right column: priority heap + related requests graph
            lblPriorityHeading.Dock = DockStyle.Top;
            lblPriorityHeading.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPriorityHeading.Name = "lblPriorityHeading";
            lblPriorityHeading.Size = new Size(426, 28);
            lblPriorityHeading.Text = "Needs attention first (priority heap)";
            lstPriority.Dock = DockStyle.Fill;
            lstPriority.HorizontalScrollbar = true;
            lstPriority.IntegralHeight = false;
            lstPriority.Name = "lstPriority";
            lstPriority.SelectionMode = SelectionMode.None;
            pnlPriority.Controls.Add(lstPriority);
            pnlPriority.Controls.Add(lblPriorityHeading);
            pnlPriority.Dock = DockStyle.Top;
            pnlPriority.Name = "pnlPriority";
            pnlPriority.Size = new Size(386, 168);

            spacerRight.Dock = DockStyle.Top;
            spacerRight.Name = "spacerRight";
            spacerRight.Size = new Size(386, 14);

            lblGraphHeading.Dock = DockStyle.Top;
            lblGraphHeading.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblGraphHeading.Name = "lblGraphHeading";
            lblGraphHeading.Size = new Size(426, 28);
            lblGraphHeading.Text = "Related requests (graph)";
            cmbTraversal.Dock = DockStyle.Top;
            cmbTraversal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTraversal.Name = "cmbTraversal";
            cmbTraversal.SelectedIndexChanged += CmbTraversal_SelectedIndexChanged;
            lblGraphSummary.Dock = DockStyle.Bottom;
            lblGraphSummary.Name = "lblGraphSummary";
            lblGraphSummary.Padding = new Padding(0, 6, 0, 0);
            lblGraphSummary.Size = new Size(426, 56);
            tvRelated.Dock = DockStyle.Fill;
            tvRelated.HideSelection = false;
            tvRelated.Indent = 18;
            tvRelated.ItemHeight = 24;
            tvRelated.Name = "tvRelated";
            tvRelated.ShowLines = true;
            pnlGraph.Controls.Add(tvRelated);
            pnlGraph.Controls.Add(lblGraphSummary);
            pnlGraph.Controls.Add(cmbTraversal);
            pnlGraph.Controls.Add(lblGraphHeading);
            pnlGraph.Dock = DockStyle.Fill;
            pnlGraph.Name = "pnlGraph";

            pnlRight.Controls.Add(pnlGraph);
            pnlRight.Controls.Add(spacerRight);
            pnlRight.Controls.Add(pnlPriority);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(14, 0, 0, 0);
            pnlRight.Size = new Size(420, 500);

            // ---- Request list
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dgvRequests.AllowUserToResizeRows = false;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.ColumnHeadersHeight = 36;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRequests.Dock = DockStyle.Fill;
            dgvRequests.MultiSelect = false;
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowTemplate.Height = 30;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.CellDoubleClick += DgvRequests_CellDoubleClick;
            dgvRequests.CellFormatting += DgvRequests_CellFormatting;
            dgvRequests.SelectionChanged += DgvRequests_SelectionChanged;
            lblResultSummary.Dock = DockStyle.Top;
            lblResultSummary.Name = "lblResultSummary";
            lblResultSummary.Size = new Size(700, 28);
            lblResultSummary.TextAlign = ContentAlignment.MiddleLeft;
            pnlGrid.Controls.Add(dgvRequests);
            pnlGrid.Controls.Add(lblResultSummary);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Name = "pnlGrid";

            // ---- Form (the last control added is laid out first)
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1240, 720);
            Controls.Add(pnlGrid);
            Controls.Add(spacerTop2);
            Controls.Add(flpFilters);
            Controls.Add(spacerTop1);
            Controls.Add(pnlTrack);
            Controls.Add(pnlRight);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(1180, 660);
            Name = "ServiceRequestStatusForm";
            Padding = new Padding(20, 0, 20, 8);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Service Request Status";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpStepper.ResumeLayout(false);
            pnlTrack.ResumeLayout(false);
            pnlTrack.PerformLayout();
            pnlFilterTitle.ResumeLayout(false);
            pnlFilterTitle.PerformLayout();
            pnlFilterStatus.ResumeLayout(false);
            pnlFilterType.ResumeLayout(false);
            pnlFilterFrom.ResumeLayout(false);
            pnlFilterTo.ResumeLayout(false);
            pnlFilterSort.ResumeLayout(false);
            flpFilters.ResumeLayout(false);
            flpFilters.PerformLayout();
            flpButtons.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            pnlPriority.ResumeLayout(false);
            pnlGraph.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            pnlGrid.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void ConfigureStepLabel(Label label, string name, string text)
        {
            label.Dock = DockStyle.Fill;
            label.Font = new Font("Segoe UI", 9F);
            label.Margin = new Padding(0);
            label.Name = name;
            label.Text = text;
            label.TextAlign = ContentAlignment.TopCenter;
        }

        private static void ConfigureFilterGroup(Panel group, string groupName, Label label, string labelName, string labelText, int width)
        {
            label.AutoSize = true;
            label.Location = new Point(0, 0);
            label.Name = labelName;
            label.Text = labelText;
            group.Controls.Add(label);
            group.Margin = new Padding(0, 0, 10, 0);
            group.Name = groupName;
            group.Size = new Size(width, 54);
        }

        private void ConfigureFilterCombo(ComboBox combo, string name, int width)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Location = new Point(0, 22);
            combo.Name = name;
            combo.Size = new Size(width, 28);
            combo.SelectedIndexChanged += FiltersChanged;
        }

        private void ConfigureDatePicker(DateTimePicker picker, string name)
        {
            picker.Checked = false;
            picker.Format = DateTimePickerFormat.Short;
            picker.Location = new Point(0, 22);
            picker.Name = name;
            picker.ShowCheckBox = true;
            picker.Size = new Size(150, 27);
            picker.ValueChanged += FiltersChanged;
        }

        private static void ConfigureBottomButton(Button button, string name, string text)
        {
            button.Margin = new Padding(8, 0, 0, 0);
            button.Name = name;
            button.Size = new Size(130, 36);
            button.Text = text;
        }
    }
}
