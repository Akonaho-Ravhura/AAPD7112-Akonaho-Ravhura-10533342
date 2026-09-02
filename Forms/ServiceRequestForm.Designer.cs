#nullable disable

namespace Municipal_Application.Forms
{
    partial class ServiceRequestForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeading;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblServiceType;
        private ComboBox cmbServiceType;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblDescription;
        private RichTextBox rtbDescription;
        private Label lblAttachments;
        private ListBox lstAttachments;
        private Button btnAddAttachment;
        private Button btnRemoveAttachment;
        private ProgressBar progressCompletion;
        private Label lblEncouragement;
        private Button btnSubmit;
        private Button btnBackToMenu;
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
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblServiceType = new Label();
            cmbServiceType = new ComboBox();
            lblLocation = new Label();
            txtLocation = new TextBox();
            lblDescription = new Label();
            rtbDescription = new RichTextBox();
            lblAttachments = new Label();
            lstAttachments = new ListBox();
            btnAddAttachment = new Button();
            btnRemoveAttachment = new Button();
            progressCompletion = new ProgressBar();
            lblEncouragement = new Label();
            btnSubmit = new Button();
            btnBackToMenu = new Button();
            openFileDialog = new OpenFileDialog();
            SuspendLayout();
            //
            // lblHeading
            //
            lblHeading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHeading.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeading.Location = new Point(20, 15);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(500, 30);
            lblHeading.Text = "Submit a Service Request";
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 55);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(78, 15);
            lblTitle.Text = "Request Title:";
            //
            // txtTitle
            //
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.Location = new Point(20, 73);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(500, 23);
            txtTitle.TextChanged += FieldChanged;
            //
            // lblServiceType
            //
            lblServiceType.AutoSize = true;
            lblServiceType.Location = new Point(20, 104);
            lblServiceType.Name = "lblServiceType";
            lblServiceType.Size = new Size(78, 15);
            lblServiceType.Text = "Service Type:";
            //
            // cmbServiceType
            //
            cmbServiceType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServiceType.Location = new Point(20, 122);
            cmbServiceType.Name = "cmbServiceType";
            cmbServiceType.Size = new Size(220, 23);
            cmbServiceType.SelectedIndexChanged += FieldChanged;
            //
            // lblLocation
            //
            lblLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(280, 104);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(56, 15);
            lblLocation.Text = "Location:";
            //
            // txtLocation
            //
            txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLocation.Location = new Point(280, 122);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(240, 23);
            txtLocation.TextChanged += FieldChanged;
            //
            // lblDescription
            //
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(20, 155);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(90, 15);
            lblDescription.Text = "Request Details:";
            //
            // rtbDescription
            //
            rtbDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            rtbDescription.Location = new Point(20, 173);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(500, 90);
            rtbDescription.TextChanged += FieldChanged;
            //
            // lblAttachments
            //
            lblAttachments.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblAttachments.AutoSize = true;
            lblAttachments.Location = new Point(20, 275);
            lblAttachments.Name = "lblAttachments";
            lblAttachments.Size = new Size(133, 15);
            lblAttachments.Text = "Attachments (optional):";
            //
            // lstAttachments
            //
            lstAttachments.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstAttachments.Location = new Point(20, 293);
            lstAttachments.Name = "lstAttachments";
            lstAttachments.Size = new Size(500, 69);
            //
            // btnAddAttachment
            //
            btnAddAttachment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddAttachment.Location = new Point(20, 372);
            btnAddAttachment.Name = "btnAddAttachment";
            btnAddAttachment.Size = new Size(140, 28);
            btnAddAttachment.Text = "Add File...";
            btnAddAttachment.UseVisualStyleBackColor = true;
            btnAddAttachment.Click += BtnAddAttachment_Click;
            //
            // btnRemoveAttachment
            //
            btnRemoveAttachment.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemoveAttachment.Location = new Point(166, 372);
            btnRemoveAttachment.Name = "btnRemoveAttachment";
            btnRemoveAttachment.Size = new Size(140, 28);
            btnRemoveAttachment.Text = "Remove Selected";
            btnRemoveAttachment.UseVisualStyleBackColor = true;
            btnRemoveAttachment.Click += BtnRemoveAttachment_Click;
            //
            // progressCompletion
            //
            progressCompletion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressCompletion.Location = new Point(20, 412);
            progressCompletion.Name = "progressCompletion";
            progressCompletion.Size = new Size(500, 18);
            //
            // lblEncouragement
            //
            lblEncouragement.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEncouragement.ForeColor = Color.FromArgb(31, 78, 121);
            lblEncouragement.Location = new Point(20, 434);
            lblEncouragement.Name = "lblEncouragement";
            lblEncouragement.Size = new Size(500, 20);
            lblEncouragement.Text = "Let's get started - fill in the details below.";
            //
            // btnSubmit
            //
            btnSubmit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSubmit.Location = new Point(360, 462);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(80, 32);
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += BtnSubmit_Click;
            //
            // btnBackToMenu
            //
            btnBackToMenu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBackToMenu.DialogResult = DialogResult.Cancel;
            btnBackToMenu.Location = new Point(20, 462);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(150, 32);
            btnBackToMenu.Text = "Back to Main Menu";
            btnBackToMenu.UseVisualStyleBackColor = true;
            //
            // ServiceRequestForm
            //
            AcceptButton = btnSubmit;
            CancelButton = btnBackToMenu;
            ClientSize = new Size(540, 510);
            Controls.Add(lblHeading);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblServiceType);
            Controls.Add(cmbServiceType);
            Controls.Add(lblLocation);
            Controls.Add(txtLocation);
            Controls.Add(lblDescription);
            Controls.Add(rtbDescription);
            Controls.Add(lblAttachments);
            Controls.Add(lstAttachments);
            Controls.Add(btnAddAttachment);
            Controls.Add(btnRemoveAttachment);
            Controls.Add(progressCompletion);
            Controls.Add(lblEncouragement);
            Controls.Add(btnSubmit);
            Controls.Add(btnBackToMenu);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(500, 480);
            MaximizeBox = true;
            MinimizeBox = false;
            Name = "ServiceRequestForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Submit a Service Request";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
