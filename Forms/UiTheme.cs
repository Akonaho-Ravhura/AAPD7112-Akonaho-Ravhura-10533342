namespace Municipal_Application.Forms
{
    
    /// Shared visual language for the application.
    
    public static class UiTheme
    {
        public static readonly Color Primary = Color.FromArgb(22, 101, 90);
        public static readonly Color PrimaryHover = Color.FromArgb(18, 82, 74);
        public static readonly Color Background = Color.FromArgb(244, 247, 249);
        public static readonly Color Surface = Color.White;
        public static readonly Color Border = Color.FromArgb(221, 229, 234);
        public static readonly Color Text = Color.FromArgb(32, 47, 55);
        public static readonly Color PrimaryText = Color.White;
        public static readonly Color SubtleText = Color.FromArgb(101, 117, 126);

        public static readonly Font HeadingFont = new("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font BaseFont = new("Segoe UI", 10F);

        public static void Apply(Form form)
        {
            form.BackColor = Background;
            form.Font = BaseFont;
            form.ForeColor = Text;
            StyleControls(form.Controls);
        }

        private static void StyleControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    ApplySecondaryButtonStyle(button);
                }
                else if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = Surface;
                    textBox.ForeColor = Text;
                }
                else if (control is RichTextBox richTextBox)
                {
                    richTextBox.BorderStyle = BorderStyle.FixedSingle;
                    richTextBox.BackColor = Surface;
                    richTextBox.ForeColor = Text;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                    comboBox.BackColor = Surface;
                    comboBox.ForeColor = Text;
                }
                else if (control is ListBox listBox)
                {
                    listBox.BorderStyle = BorderStyle.FixedSingle;
                    listBox.BackColor = Surface;
                    listBox.ForeColor = Text;
                }
                else if (control is DataGridView grid)
                {
                    grid.BackgroundColor = Surface;
                    grid.BorderStyle = BorderStyle.None;
                    grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    grid.GridColor = Border;
                    grid.EnableHeadersVisualStyles = false;
                    grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 241, 243);
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = Text;
                    grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    grid.DefaultCellStyle.BackColor = Surface;
                    grid.DefaultCellStyle.ForeColor = Text;
                    grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 239, 233);
                    grid.DefaultCellStyle.SelectionForeColor = Text;
                    grid.RowHeadersVisible = false;
                }
                else if (control is Label label)
                {
                    label.ForeColor = Text;
                }

                StyleControls(control.Controls);
            }
        }

        public static void ApplySecondaryButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Border;
            button.FlatAppearance.BorderSize = 1;
            button.BackColor = Surface;
            button.ForeColor = Text;
            button.Cursor = Cursors.Hand;
            button.Font = BaseFont;
        }

        public static void ApplyPrimaryButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Primary;
            button.ForeColor = PrimaryText;
            button.Cursor = Cursors.Hand;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }
    }
}
