using System.Collections.Generic;
using StationLogWebApplication1;

namespace StationLogFinal.SessionTools
{
    static class RegisterTool
    {
        #region Props
        
        #endregion

        #region Methods
        public static void RegisterUser(User userToRegister)
        {
            userToRegister.HashPass = Security.GenerateSHA256Hash(userToRegister.HashPass , Security.CreatingSalt(10));
            UserHandler.RegisterUser(userToRegister);
        }
     
        public static bool CheckIfExist(User inputUser)
        {
            UserHandler.GetAllUsers();
            List<User> usersToCheck = UserHandler.UserListToCheck;

            foreach (var user in usersToCheck)
            {
                if (user.UserId == inputUser.UserId)
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
