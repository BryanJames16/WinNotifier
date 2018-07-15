using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNotifier
{
    public class Notifier
    {
        /**
         *  Class Members
         */
        private int dialogType;
        private NotifierBalloon balloon;

        /**
         *  Class Properties
         */
        public int DialogType
        {
            get => dialogType;
            set => dialogType = value;
        }

        public NotifierBalloon Balloon
        {
            get => balloon;
            set => balloon = value;
        }

        /**
         *  Class Enums
         */
        public enum DType
        {
            NONE = 0x00,
            INFO = 0x01, 
            QUESTION = 0x02, 
            WARNING = 0x03, 
            ERROR = 0x04
        }

        /**
         *  Class Constructors
         */
        public Notifier()
        {
            this.dialogType = 0;
        }

        public Notifier(NotifierBalloon balloon)
        {
            this.balloon = balloon;
        }

        /**
         *  Class Methods
         */
        public void SetNotificationArea(NotifierBalloon.NotificationPosition n_pos)
        {
            this.balloon.SetPosition(n_pos);
        }
        
        public void ShowNotification()
        {
            this.balloon.Show();
        }

        public void ShowNotification(long milliseconds)
        {

        }
    }
}
