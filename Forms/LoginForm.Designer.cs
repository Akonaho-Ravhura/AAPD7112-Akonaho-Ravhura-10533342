#nullable disable

namespace Municipal_Application.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private GroupBox groupBoxRole;
        private RadioButton rbResident;
        private RadioButton rbAdmin;
        private Panel pnlResident;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblIdNumber;
        private TextBox txtIdNumber;
        private Label lblContact;
        private TextBox txtContact;
        private Panel pnlAdmin;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnTogglePassword;
        private Button btnContinue;

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
            lblTitle = new Label();
            groupBoxRole = new GroupBox();
            rbResident = new RadioButton();
            rbAdmin = new RadioButton();
            pnlResident = new Panel();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblIdNumber = new Label();
            txtIdNumber = new TextBox();
            lblContact = new Label();
            txtContact = new TextBox();
            pnlAdmin = new Panel();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnTogglePassword = new Button();
            btnContinue = new Button();
            groupBoxRole.SuspendLayout();
            pnlResident.SuspendLayout();
            pnlAdmin.SuspendLayout();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(380, 40);
            lblTitle.Text = "Municipal Engagement Platform";
            //
            // groupBoxRole
            //
            groupBoxRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxRole.Controls.Add(rbResident);
            groupBoxRole.Controls.Add(rbAdmin);
            groupBoxRole.Location = new Point(20, 70);
            groupBoxRole.Name = "groupBoxRole";
            groupBoxRole.Size = new Size(380, 50);
            groupBoxRole.TabStop = false;
            groupBoxRole.Text = "I am a:";
            //
            // rbResident
            //
            rbResident.AutoSize = true;
            rbResident.Checked = true;
            rbResident.Location = new Point(20, 22);
            rbResident.Name = "rbResident";
            rbResident.Size = new Size(90, 19);
            rbResident.TabIndex = 0;
            rbResident.TabStop = true;
            rbResident.Text = "Resident";
            rbResident.CheckedChanged += RoleChanged;
            //
            // rbAdmin
            //
            rbAdmin.AutoSize = true;
            rbAdmin.Location = new Point(160, 22);
            rbAdmin.Name = "rbAdmin";
            rbAdmin.Size = new Size(94, 19);
            rbAdmin.TabIndex = 1;
            rbAdmin.Text = "Municipal Admin";
            rbAdmin.CheckedChanged += RoleChanged;
            //
            // pnlResident
            //
            pnlResident.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlResident.Controls.Add(lblFullName);
            pnlResident.Controls.Add(txtFullName);
            pnlResident.Controls.Add(lblIdNumber);
            pnlResident.Controls.Add(txtIdNumber);
            pnlResident.Controls.Add(lblContact);
            pnlResident.Controls.Add(txtContact);
            pnlResident.Location = new Point(20, 130);
            pnlResident.Name = "pnlResident";
            pnlResident.Size = new Size(380, 160);
            //
            // lblFullName
            //
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(0, 6);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(63, 15);
            lblFullName.Text = "Full Name:";
            //
            // txtFullName
            //
            txtFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFullName.Location = new Point(0, 24);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(360, 23);
            //
            // lblIdNumber
            //
            lblIdNumber.AutoSize = true;
            lblIdNumber.Location = new Point(0, 54);
            lblIdNumber.Name = "lblIdNumber";
            lblIdNumber.Size = new Size(120, 15);
            lblIdNumber.Text = "SA ID Number:";
            //
            // txtIdNumber
            //
            txtIdNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIdNumber.Location = new Point(0, 72);
            txtIdNumber.MaxLength = 13;
            txtIdNumber.Name = "txtIdNumber";
            txtIdNumber.Size = new Size(360, 23);
            //
            // lblContact
            //
            lblContact.AutoSize = true;
            lblContact.Location = new Point(0, 102);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(96, 15);
            lblContact.Text = "Contact Number:";
            //
            // txtContact
            //
            txtContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtContact.Font = new Font("Segoe UI", 12F);
            txtContact.Location = new Point(0, 120);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(360, 29);
            //
            // pnlAdmin
            //
            pnlAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAdmin.Controls.Add(lblUsername);
            pnlAdmin.Controls.Add(txtUsername);
            pnlAdmin.Controls.Add(lblPassword);
            pnlAdmin.Controls.Add(txtPassword);
            pnlAdmin.Controls.Add(btnTogglePassword);
            pnlAdmin.Location = new Point(20, 130);
            pnlAdmin.Name = "pnlAdmin";
            pnlAdmin.Size = new Size(380, 110);
            pnlAdmin.Visible = false;
            //
            // lblUsername
            //
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(0, 6);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.Text = "Username:";
            //
            // txtUsername
            //
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(0, 24);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(360, 23);
            //
            // lblPassword
            //
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(0, 54);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.Text = "Password:";
            //
            // txtPassword
            //
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(0, 72);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(290, 29);
            //
            // btnTogglePassword
            //
            btnTogglePassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTogglePassword.Location = new Point(296, 72);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(64, 29);
            btnTogglePassword.Text = "Show";
            btnTogglePassword.UseVisualStyleBackColor = true;
            btnTogglePassword.Click += BtnTogglePassword_Click;
            //
            // btnContinue
            //
            btnContinue.Location = new Point(20, 310);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(120, 32);
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += BtnContinue_Click;
            //
            // LoginForm
            //
            AcceptButton = btnContinue;
            ClientSize = new Size(420, 370);
            Controls.Add(lblTitle);
            Controls.Add(groupBoxRole);
            Controls.Add(pnlResident);
            Controls.Add(pnlAdmin);
            Controls.Add(btnContinue);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(420, 370);
            MaximizeBox = true;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign In - Municipal Engagement Platform";
            groupBoxRole.ResumeLayout(false);
            groupBoxRole.PerformLayout();
            pnlResident.ResumeLayout(false);
            pnlResident.PerformLayout();
            pnlAdmin.ResumeLayout(false);
            pnlAdmin.PerformLayout();
            ResumeLayout(false);
        }
    }
}
