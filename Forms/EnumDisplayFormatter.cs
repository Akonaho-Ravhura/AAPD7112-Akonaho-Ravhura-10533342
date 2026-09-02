using System.Text.RegularExpressions;

namespace Municipal_Application.Forms
{
    /// <summary>
    /// Turns PascalCase enum names (e.g. "NewWaterConnection") into readable
    /// text (e.g. "New Water Connection") for display in combo boxes.
    /// </summary>
    public static class EnumDisplayFormatter
    {
        public static string ToDisplayText(Enum value)
        {
            return ToDisplayText(value.ToString());
        }

        /// <summary>
        /// Same spacing rule, for PascalCase text that isn't itself an enum
        /// value (e.g. an enum's ToString() already stored as a plain string).
        /// </summary>
        public static string ToDisplayText(string pascalCaseText)
        {
            return Regex.Replace(pascalCaseText, "(?<!^)([A-Z])", " $1");
        }

        /// <summary>
        /// Wires a combo box bound to an enum DataSource so it displays
        /// spaced-out text while SelectedItem still returns the enum value.
        /// </summary>
        public static void ApplyTo(ComboBox comboBox)
        {
            comboBox.FormattingEnabled = true;
            comboBox.Format += (_, e) =>
            {
                if (e.Value is Enum enumValue)
                {
                    e.Value = ToDisplayText(enumValue);
                }
            };
        }
    }
}
