using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CheckProcessStatus
{
    class Timer
    {
        private static System.Timers.Timer aTimer;

        public static void StartTimer()
        {
                aTimer = new System.Timers.Timer();
                aTimer.Interval = 30000;
                aTimer = new System.Timers.Timer(30000);
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            HandleCheck.StartHandleCheck();
        }
    }
}
