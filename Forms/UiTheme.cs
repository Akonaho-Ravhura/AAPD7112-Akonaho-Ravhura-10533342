namespace Municipal_Application.Forms
{
    
    /// Shared colours and fonts so every form in the application looks consistent.
    
    public static class UiTheme
    {
        public static readonly Color Primary = Color.FromArgb(31, 78, 121);
        public static readonly Color PrimaryText = Color.White;
        public static readonly Color Background = Color.White;
        public static readonly Color SubtleText = Color.DimGray;

        public static readonly Font HeadingFont = new("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font BaseFont = new("Segoe UI", 10F);

        public static void ApplyPrimaryButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Primary;
            button.ForeColor = PrimaryText;
            button.Cursor = Cursors.Hand;
        }
    }
}
