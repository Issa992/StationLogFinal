using StationLogFinal.Views;
using System;
using Windows.UI.Popups;
using StationLogWebApplication1;
using StationLogFinal.Common;

namespace StationLogFinal.SessionTools
{
    public static class LoginTool
    {
        #region Methods
        public static async void LoginUser(User userToLogIn)
        {
            User foundUser = FindUser(userToLogIn);
            bool succesfullyLogIn = CheckPassword(foundUser,userToLogIn);

            if (succesfullyLogIn)
            {
                CurrentSessioncs.CurrentUser = foundUser;
                CurrentSessioncs.StartSession();
                FrameNavigationClass.ActivateFrameNavigation(typeof(HomeView));
            }
            else
            {
                MessageDialog msg = new MessageDialog("Username or Password was incorrect. Please try again.", "No Acces");
                await msg.ShowAsync();
            }
        }

        public static bool CheckPassword(User foundUser , User userInput)
        {
            string inputPwToHashValue = Security.GenerateSHA256Hash(userInput.HashPass, foundUser.Salt);

            if (foundUser.HashPass == inputPwToHashValue) 
            {
                return true;
            }
            return false;
        }

        public static User FindUser(User userToFind)
        {
            UserHandler.GetAllUsers();
          
                foreach (var user in UserHandler.UserListToCheck)
                {
                    if (user.UserId == userToFind.UserId)
                    {
                        return user;
                    }
                }
            return null;
        }
        #endregion
    }
}
