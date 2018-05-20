using System;
using System.Diagnostics;
using StationLogFinal.Model;
using StationLogWebApplication1;

namespace StationLogFinal.SessionTools
{
    static class CurrentSessioncs
    {
        #region Props
        public static int Id { get; set; }
        public static DateTime LongTime { get; set; }
        public static DateTime SessionStart { get; set; }
        public static DateTime SessionEnd { get; set; }
        public static User CurrentUser { get; set; }

        public static Stopwatch stopWatch = new Stopwatch();

        #endregion

        #region Methods 
        public static void StartSession()
        {
            SessionStart = DateTime.Now;
            stopWatch.Reset();
            stopWatch.Start();
        }
        public static User GetCurrentUser()
        {
            if (CurrentUser != null)
            {
                return CurrentUser;
            }
            return null;
        }

        public static int GetCurrentUserID()
        {
            if (CurrentUser != null)
            {
                return CurrentUser.UserId;
            }
            return 0;
        }

        public static string GetSessionTime()
        {
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return elapsedTime;
        }

        public static void KillSession()
        {
            SessionEnd = DateTime.Now;
            stopWatch.Stop();
        }
        #endregion
    }
}
