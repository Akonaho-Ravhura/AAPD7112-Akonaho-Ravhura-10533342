using System.Text;
using Municipal_Application.Data;

namespace Municipal_Application.Forms
{
    public partial class LocalEventsForm : Form
    {
        public LocalEventsForm()
        {
            InitializeComponent();
            BackColor = UiTheme.Background;
            lblHeading.ForeColor = UiTheme.Primary;
            LoadEvents();
        }

        private void LoadEvents()
        {
            var events = LocalEventRepository.Instance.GetAll();

            if (events.Count == 0)
            {
                rtbEvents.Text = "There are no local events or announcements yet. Check back soon.";
                return;
            }

            var sb = new StringBuilder();
            foreach (var localEvent in events)
            {
                sb.AppendLine($"[{localEvent.PostedDate:g}] {localEvent.Title} ({EnumDisplayFormatter.ToDisplayText(localEvent.Category)})");
                sb.AppendLine(localEvent.Description);
                sb.AppendLine(new string('-', 60));
            }

            rtbEvents.Text = sb.ToString();
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadEvents();
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
