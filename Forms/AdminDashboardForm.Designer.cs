#nullable disable

namespace Municipal_Application.Forms
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeading;
        private TabControl tabMain;
        private TabPage tabIssues;
        private TabPage tabEvents;
        private DataGridView dgvIssues;
        private Button btnViewUpdate;
        private Button btnRefreshIssues;
        private Label lblExistingEvents;
        private RichTextBox rtbEventsList;
        private Label lblNewEvent;
        private Label lblEventTitle;
        private TextBox txtEventTitle;
        private Label lblEventCategory;
        private ComboBox cmbEventCategory;
        private Label lblEventDate;
        private DateTimePicker dtpEventDate;
        private Label lblEventDescription;
        private RichTextBox rtbEventDescription;
        private Button btnPostEvent;
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
            lblHeading = new Label();
            tabMain = new TabControl();
            tabIssues = new TabPage();
            dgvIssues = new DataGridView();
            btnViewUpdate = new Button();
            btnRefreshIssues = new Button();
            tabEvents = new TabPage();
            lblExistingEvents = new Label();
            rtbEventsList = new RichTextBox();
            lblNewEvent = new Label();
            lblEventTitle = new Label();
            txtEventTitle = new TextBox();
            lblEventCategory = new Label();
            cmbEventCategory = new ComboBox();
            lblEventDate = new Label();
            dtpEventDate = new DateTimePicker();
            lblEventDescription = new Label();
            rtbEventDescription = new RichTextBox();
            btnPostEvent = new Button();
            btnLogout = new Button();
            tabMain.SuspendLayout();
            tabIssues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIssues).BeginInit();
            tabEvents.SuspendLayout();
            SuspendLayout();
            //
            // lblHeading
            //
            lblHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeading.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeading.Location = new Point(20, 15);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(720, 30);
            lblHeading.Text = "Admin Dashboard";
            //
            // tabMain
            //
            tabMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabMain.Controls.Add(tabIssues);
            tabMain.Controls.Add(tabEvents);
            tabMain.Location = new Point(20, 55);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(720, 440);
            //
            // tabIssues
            //
            tabIssues.Controls.Add(dgvIssues);
            tabIssues.Controls.Add(btnViewUpdate);
            tabIssues.Controls.Add(btnRefreshIssues);
            tabIssues.Location = new Point(4, 24);
            tabIssues.Name = "tabIssues";
            tabIssues.Padding = new Padding(10);
            tabIssues.Size = new Size(712, 412);
            tabIssues.Text = "Issues && Service Requests";
            tabIssues.UseVisualStyleBackColor = true;
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
            dgvIssues.Location = new Point(10, 10);
            dgvIssues.Name = "dgvIssues";
            dgvIssues.Size = new Size(692, 320);
            //
            // btnViewUpdate
            //
            btnViewUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnViewUpdate.Location = new Point(10, 340);
            btnViewUpdate.Name = "btnViewUpdate";
            btnViewUpdate.Size = new Size(150, 30);
            btnViewUpdate.Text = "View / Update";
            btnViewUpdate.UseVisualStyleBackColor = true;
            btnViewUpdate.Click += BtnViewUpdate_Click;
            //
            // btnRefreshIssues
            //
            btnRefreshIssues.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefreshIssues.Location = new Point(170, 340);
            btnRefreshIssues.Name = "btnRefreshIssues";
            btnRefreshIssues.Size = new Size(100, 30);
            btnRefreshIssues.Text = "Refresh";
            btnRefreshIssues.UseVisualStyleBackColor = true;
            btnRefreshIssues.Click += BtnRefreshIssues_Click;
            //
            // tabEvents
            //
            tabEvents.Controls.Add(lblExistingEvents);
            tabEvents.Controls.Add(rtbEventsList);
            tabEvents.Controls.Add(lblNewEvent);
            tabEvents.Controls.Add(lblEventTitle);
            tabEvents.Controls.Add(txtEventTitle);
            tabEvents.Controls.Add(lblEventCategory);
            tabEvents.Controls.Add(cmbEventCategory);
            tabEvents.Controls.Add(lblEventDate);
            tabEvents.Controls.Add(dtpEventDate);
            tabEvents.Controls.Add(lblEventDescription);
            tabEvents.Controls.Add(rtbEventDescription);
            tabEvents.Controls.Add(btnPostEvent);
            tabEvents.Location = new Point(4, 24);
            tabEvents.Name = "tabEvents";
            tabEvents.Padding = new Padding(10);
            tabEvents.Size = new Size(712, 412);
            tabEvents.Text = "Local Events";
            tabEvents.UseVisualStyleBackColor = true;
            //
            // lblExistingEvents
            //
            lblExistingEvents.AutoSize = true;
            lblExistingEvents.Location = new Point(10, 10);
            lblExistingEvents.Name = "lblExistingEvents";
            lblExistingEvents.Size = new Size(85, 15);
            lblExistingEvents.Text = "Posted Events:";
            //
            // rtbEventsList
            //
            rtbEventsList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtbEventsList.Location = new Point(10, 28);
            rtbEventsList.Name = "rtbEventsList";
            rtbEventsList.ReadOnly = true;
            rtbEventsList.Size = new Size(692, 140);
            //
            // lblNewEvent
            //
            lblNewEvent.AutoSize = true;
            lblNewEvent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNewEvent.Location = new Point(10, 178);
            lblNewEvent.Name = "lblNewEvent";
            lblNewEvent.Size = new Size(180, 15);
            lblNewEvent.Text = "Post a New Event / Announcement";
            //
            // lblEventTitle
            //
            lblEventTitle.AutoSize = true;
            lblEventTitle.Location = new Point(10, 198);
            lblEventTitle.Name = "lblEventTitle";
            lblEventTitle.Size = new Size(34, 15);
            lblEventTitle.Text = "Title:";
            //
            // txtEventTitle
            //
            txtEventTitle.Location = new Point(10, 216);
            txtEventTitle.Name = "txtEventTitle";
            txtEventTitle.Size = new Size(230, 23);
            //
            // lblEventCategory
            //
            lblEventCategory.AutoSize = true;
            lblEventCategory.Location = new Point(250, 198);
            lblEventCategory.Name = "lblEventCategory";
            lblEventCategory.Size = new Size(58, 15);
            lblEventCategory.Text = "Category:";
            //
            // cmbEventCategory
            //
            cmbEventCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEventCategory.Location = new Point(250, 216);
            cmbEventCategory.Name = "cmbEventCategory";
            cmbEventCategory.Size = new Size(170, 23);
            //
            // lblEventDate
            //
            lblEventDate.AutoSize = true;
            lblEventDate.Location = new Point(440, 198);
            lblEventDate.Name = "lblEventDate";
            lblEventDate.Size = new Size(62, 15);
            lblEventDate.Text = "Event Date:";
            //
            // dtpEventDate
            //
            dtpEventDate.Format = DateTimePickerFormat.Short;
            dtpEventDate.Location = new Point(440, 216);
            dtpEventDate.MinDate = DateTime.Today;
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(150, 23);
            //
            // lblEventDescription
            //
            lblEventDescription.AutoSize = true;
            lblEventDescription.Location = new Point(10, 246);
            lblEventDescription.Name = "lblEventDescription";
            lblEventDescription.Size = new Size(70, 15);
            lblEventDescription.Text = "Description:";
            //
            // rtbEventDescription
            //
            rtbEventDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtbEventDescription.Location = new Point(10, 264);
            rtbEventDescription.Name = "rtbEventDescription";
            rtbEventDescription.Size = new Size(692, 70);
            //
            // btnPostEvent
            //
            btnPostEvent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPostEvent.Location = new Point(602, 340);
            btnPostEvent.Name = "btnPostEvent";
            btnPostEvent.Size = new Size(100, 30);
            btnPostEvent.Text = "Post Event";
            btnPostEvent.UseVisualStyleBackColor = true;
            btnPostEvent.Click += BtnPostEvent_Click;
            //
            // btnLogout
            //
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLogout.Location = new Point(660, 505);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(80, 30);
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += BtnLogout_Click;
            //
            // AdminDashboardForm
            //
            ClientSize = new Size(760, 550);
            Controls.Add(lblHeading);
            Controls.Add(tabMain);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(650, 480);
            MaximizeBox = true;
            MinimizeBox = false;
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Admin Dashboard - Municipal Engagement Platform";
            tabMain.ResumeLayout(false);
            tabIssues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvIssues).EndInit();
            tabEvents.ResumeLayout(false);
            tabEvents.PerformLayout();
            ResumeLayout(false);
        }
    }
}
