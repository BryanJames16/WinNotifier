using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNotifier
{
    public partial class NotifierBalloon : Form
    {
        private enum TaskBarLocation
        {
            TOP, 
            BOTTOM, 
            LEFT, 
            RIGHT
        }

        public enum NotificationPosition
        {
            TOP_LEFT, 
            BOTTOM_LEFT, 
            TOP_RIGHT, 
            BOTTOM_RIGHT
        }

        private int closeFlag;

        public NotifierBalloon()
        {
            closeFlag = 0;
            InitializeComponent();
            PostInitialize();
        }

        private void PostInitialize()
        {
            /*
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height;

            if (this.GetTaskBarLocation() == TaskBarLocation.BOTTOM || 
                this.GetTaskBarLocation() == TaskBarLocation.TOP)
            {
                this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 3;
                this.Top = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height) - this.Height - 3;
            }
            else
            {
                this.Left = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.WorkingArea.Width) - this.Width - 3;
                this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height - 3;
            }
            */
            this.lblTitle.Text = this.GetTaskBarLocation().ToString();
        }

        private TaskBarLocation GetTaskBarLocation()
        {
            TaskBarLocation taskBarLocation = TaskBarLocation.BOTTOM;

            bool taskBarOnTopOrBottom = (Screen.PrimaryScreen.WorkingArea.Width == Screen.PrimaryScreen.Bounds.Width);

            if (taskBarOnTopOrBottom)
            {
                if (Screen.PrimaryScreen.WorkingArea.Top > 0)
                {
                    taskBarLocation = TaskBarLocation.TOP;
                }
            }
            else
            {
                if (Screen.PrimaryScreen.WorkingArea.Left > 0)
                {
                    taskBarLocation = TaskBarLocation.LEFT;
                }
                else
                {
                    taskBarLocation = TaskBarLocation.RIGHT;
                }
            }

            return (taskBarLocation);
        }

        public void SetPosition(NotificationPosition n_position)
        {
            TaskBarLocation t_position = this.GetTaskBarLocation();
            this.StartPosition = FormStartPosition.Manual;

            if (n_position == NotificationPosition.TOP_LEFT)
            {
                if (t_position == TaskBarLocation.LEFT)
                {
                    this.Left = (Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.WorkingArea.Width) + 3;
                }
                else
                {
                    this.Left = 3;
                }

                if (t_position == TaskBarLocation.TOP)
                {
                    this.Top = (Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height) + 3;
                }
                else
                {
                    this.Top = 3;
                }
            }
            else if (n_position == NotificationPosition.BOTTOM_LEFT)
            {
                if (t_position == TaskBarLocation.LEFT)
                {
                    this.Left = (Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.WorkingArea.Width) + 3;
                }
                else
                {
                    this.Left = 3;
                }

                if (t_position == TaskBarLocation.TOP)
                {
                    this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height - 3;
                }
                else
                {
                    this.Top = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height) - this.Height - 3;
                }
            }
            else if (n_position == NotificationPosition.TOP_RIGHT)
            {
                if (t_position == TaskBarLocation.LEFT)
                {
                    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 3;
                }
                else
                {
                    this.Left = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.WorkingArea.Width) - this.Width - 3;
                }

                if (t_position == TaskBarLocation.TOP)
                {
                    this.Top = (Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height) + 3;
                }
                else
                {
                    this.Top = 3;
                }
            }
            else
            {
                if (t_position == TaskBarLocation.LEFT)
                {
                    this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 3;
                }
                else
                {
                    this.Left = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width - Screen.PrimaryScreen.WorkingArea.Width) - this.Width - 3;
                }

                if (t_position == TaskBarLocation.TOP)
                {
                    this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height - 3;
                }
                else
                {
                    this.Top = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height) - this.Height - 3;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            closeFlag = 1;
            this.Close();
        }

        private void NotifierBalloon_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1.0;
        }

        private void NotifierBalloon_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (closeFlag == 0)
                {
                    this.Opacity = 0.75;
                }
            }
            catch (Win32Exception)
            {

            }
        }

        private void NotifierBalloon_Shown(object sender, EventArgs e)
        {
            this.Opacity = 0.75;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            this.NotifierBalloon_MouseEnter(sender, e);
            this.btnClose.BackColor = Color.Red;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            this.NotifierBalloon_MouseLeave(sender, e);
            this.btnClose.BackColor = Color.Transparent;
        }
    }
}
