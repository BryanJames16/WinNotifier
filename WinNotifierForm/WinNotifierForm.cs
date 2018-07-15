using System;
using System.Windows.Forms;
using WinNotifier;

namespace WinNotifierForm
{
    public partial class FormWinNotifier : Form
    {
        public FormWinNotifier()
        {
            InitializeComponent();
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            Notifier notifier = new Notifier();
            NotifierBalloon balloon = new NotifierBalloon();
            notifier.Balloon = balloon;
            notifier.SetNotificationArea(NotifierBalloon.NotificationPosition.BOTTOM_RIGHT);
            notifier.ShowNotification();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {

        }

        private void btnWarning_Click(object sender, EventArgs e)
        {

        }

        private void btnError_Click(object sender, EventArgs e)
        {

        }
    }
}
