using StationLogWebService;
using System;
using Windows.UI.Popups;

namespace StationLogFinal.SessionTools
{
    static class LoginTool
    {
        #region Props
        public static User InputUser { get; set; }
        #endregion

        #region Methods
        public static async void LoginUser()
        {
            bool succesfullyLogIn = CheckPassword();

            if (succesfullyLogIn)
            {
                // Login stuff happens
            }
            else
            {
                MessageDialog msg = new MessageDialog("Username or Password was incorrect. Please try again.", "No Acces");
                await msg.ShowAsync();
            }

        }

        public static bool CheckPassword()
        {
            User userToLogIn = FindUser();

            if (true) //userToLogIn password extracting and check if its's the same as the input
            {
                return true;
            }
            return false;
        }

        public static User FindUser()
        {
            UserHandler.GetAllUsers();
            //The reference might be incorrect , if it works then i am going change in the RegistTools.RegisterUser(); 
            foreach (var user in UserHandler.UserListToCheck)
            {
                if (user.Name == InputUser.Name)
                {
                    return user;
                }
            }
            return null;
        }
        #endregion
    }
}
