using System;
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
        #endregion

        #region Methods 
        public static void StartSession()
        {
             SessionStart = DateTime.Now;
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

        //public static string GetSessionTime(DateTime start , DateTime end)
        //{
        //    end - start = LongTime;
        //}

        public static void KillSession()
        {
            SessionEnd = DateTime.Now;
        }
        #endregion
    }
}
