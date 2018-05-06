using StationLogWebService;
using System.Collections.Generic;

namespace StationLogFinal.SessionTools
{
    static class RegisterTool
    {
        #region Props
        static public User InputUser { get; set; }
        #endregion

        #region Methods
        public static void RegisterUser(User userToRegister)
        {
            UserHandler.RegisterUser(userToRegister);
        }
        //public static string HashPass()
        //{


        //}

        public static bool CheckIfExist()
        {
            UserHandler.GetAllUsers();
            List<User> usersToCheck = UserHandler.UserListToCheck;

            foreach (var user in usersToCheck)
            {
                if (user.Name == InputUser.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckRequiredInfo(User userToCheck)
        {
            if (userToCheck.UserId != 0 && userToCheck.HashPass != string.Empty && userToCheck.Email != string.Empty && userToCheck.PhoneNumber != 0 && userToCheck.Name != string.Empty && userToCheck.PermessionLevel != 0)
            {
                return true;
            }
            return false;

        }
        #endregion
    }
}
