using Municipal_Application.Data;
using Municipal_Application.Models;
using Municipal_Application.Validation;

namespace Municipal_Application.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            UiTheme.Apply(this);
            lblTitle.ForeColor = UiTheme.Primary;
            UiTheme.ApplyPrimaryButtonStyle(btnContinue);
        }

        private void RoleChanged(object? sender, EventArgs e)
        {
            pnlResident.Visible = rbResident.Checked;
            pnlAdmin.Visible = rbAdmin.Checked;
        }

        private void BtnTogglePassword_Click(object? sender, EventArgs e)
        {
            var isRevealing = txtPassword.PasswordChar != '\0';
            txtPassword.PasswordChar = isRevealing ? '\0' : '*';
            btnTogglePassword.Text = isRevealing ? "Hide" : "Show";
        }

        private void BtnContinue_Click(object? sender, EventArgs e)
        {
            if (rbResident.Checked)
            {
                SignInAsResident();
            }
            else
            {
                SignInAsAdmin();
            }
        }

        private void SignInAsResident()
        {
            var fullName = txtFullName.Text.Trim();
            var idNumber = txtIdNumber.Text.Trim();
            var contact = txtContact.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(idNumber) || string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show(
                    "Please enter your full name, SA ID number and contact number.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!SouthAfricanIdValidator.IsValid(idNumber))
            {
                MessageBox.Show(
                    "Please enter a valid 13-digit South African ID number.",
                    "Invalid ID Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var resident = new Resident
            {
                Username = idNumber,
                FullName = fullName,
                IdNumber = idNumber,
                ContactNumber = contact
            };

            Hide();
            using (var mainMenu = new MainMenuForm(resident))
            {
                mainMenu.ShowDialog();
            }
            txtFullName.Clear();
            txtIdNumber.Clear();
            txtContact.Clear();
            Show();
        }

        private void SignInAsAdmin()
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (!AdminAccountStore.Validate(username, password))
            {
                MessageBox.Show(
                    "Invalid admin username or password.",
                    "Sign In Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var admin = new Admin
            {
                Username = username,
                FullName = username
            };

            Hide();
            using (var dashboard = new AdminDashboardForm(admin))
            {
                dashboard.ShowDialog();
            }
            txtUsername.Clear();
            txtPassword.Clear();
            txtPassword.PasswordChar = '*';
            btnTogglePassword.Text = "Show";
            Show();
        }
    }
}
