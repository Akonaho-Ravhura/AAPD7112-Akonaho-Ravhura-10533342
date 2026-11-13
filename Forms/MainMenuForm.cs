using Municipal_Application.Data;
using Municipal_Application.Models;

namespace Municipal_Application.Forms
{
    public partial class MainMenuForm : Form
    {
        private readonly Resident _resident;

        public MainMenuForm(Resident resident)
        {
            InitializeComponent();
            _resident = resident;
            UiTheme.Apply(this);
            lblWelcome.ForeColor = UiTheme.Primary;
            lblWelcome.Font = UiTheme.HeadingFont;
            lblSubtitle.ForeColor = UiTheme.SubtleText;
            lblStats.ForeColor = UiTheme.Primary;
            UiTheme.ApplySecondaryButtonStyle(btnLogout);
            flpActions.Controls.Add(CreateActionCard("Report Issues", "Tell us about a service delivery problem.", "!", BtnReportIssue_Click));
            flpActions.Controls.Add(CreateActionCard("Local Events & Announcements", "See notices and updates from your municipality.", "i", BtnLocalEvents_Click));
            flpActions.Controls.Add(CreateActionCard("Service Request Status", "Track your requests, reports and updates.", "✓", BtnServiceStatus_Click));
            flpActions.Controls.Add(CreateActionCard("Submit a Service Request", "Request a municipal service or support.", "+", BtnServiceRequest_Click));
            flpActions.Resize += (_, _) => LayoutActionCards();
            LayoutActionCards();
            lblWelcome.Text = $"Welcome, {_resident.FullName}";
            RefreshStats();
        }

        private void LayoutActionCards()
        {
            if (flpActions.Controls.Count == 0)
            {
                return;
            }

            var availableWidth = flpActions.ClientSize.Width - flpActions.Padding.Horizontal;
            const int cardMinimumWidth = 260;
            const int cardHeight = 124;
            const int cardMargin = 9;

            var useTwoColumns = availableWidth >= (cardMinimumWidth * 2) + (cardMargin * 4);
            var columns = useTwoColumns ? 2 : 1;
            var cardWidth = (availableWidth - (cardMargin * 2 * columns)) / columns;

            foreach (Control control in flpActions.Controls)
            {
                control.Size = new Size(Math.Max(cardMinimumWidth, cardWidth), cardHeight);
            }
        }

        private Panel CreateActionCard(string title, string description, string symbol, EventHandler action)
        {
            var card = new Panel
            {
                BackColor = UiTheme.Surface,
                BorderStyle = BorderStyle.None,
                Size = new Size(330, 124),
                Margin = new Padding(9),
                Cursor = Cursors.Hand,
                Tag = action
            };
            card.Paint += (_, e) => ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                UiTheme.Border, ButtonBorderStyle.Solid);

            var icon = new Label
            {
                Text = symbol,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                ForeColor = UiTheme.Primary,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(232, 243, 240),
                Location = new Point(15, 18),
                Size = new Size(42, 42),
                Cursor = Cursors.Hand
            };
            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = UiTheme.Text,
                Location = new Point(70, 19),
                Size = new Size(244, 27),
                Cursor = Cursors.Hand
            };
            var descriptionLabel = new Label
            {
                Text = description,
                Font = UiTheme.BaseFont,
                ForeColor = UiTheme.SubtleText,
                Location = new Point(70, 50),
                Size = new Size(244, 48),
                Cursor = Cursors.Hand
            };

            card.Controls.Add(icon);
            card.Controls.Add(titleLabel);
            card.Controls.Add(descriptionLabel);
            card.Click += action;
            icon.Click += action;
            titleLabel.Click += action;
            descriptionLabel.Click += action;
            return card;
        }

        private void MainMenuForm_Activated(object? sender, EventArgs e)
        {
            RefreshStats();
        }

        private void RefreshStats()
        {
            var count = IssueRepository.Instance.Count;
            lblStats.Text = count == 1
                ? "1 community report or request submitted so far"
                : $"{count} community reports and requests submitted so far";
        }

        private void BtnReportIssue_Click(object? sender, EventArgs e)
        {
            using var reportForm = new ReportIssueForm(_resident);
            reportForm.ShowDialog();
            RefreshStats();
        }

        private void BtnServiceRequest_Click(object? sender, EventArgs e)
        {
            using var requestForm = new ServiceRequestForm(_resident);
            requestForm.ShowDialog();
            RefreshStats();
        }

        private void BtnLocalEvents_Click(object? sender, EventArgs e)
        {
            using var eventsForm = new LocalEventsForm(_resident.Username);
            eventsForm.ShowDialog();
        }

        private void BtnServiceStatus_Click(object? sender, EventArgs e)
        {
            using var statusForm = new ServiceRequestStatusForm(_resident);
            statusForm.ShowDialog();
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
