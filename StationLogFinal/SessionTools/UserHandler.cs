using myGenericDBEFandWSMovies;
using StationLogWebService;
using System.Collections.Generic;

namespace StationLogFinal.SessionTools
{
    static class UserHandler
    {
        static List<User> userListToCheck = new List<User>();
        public static List<User> UserListToCheck { get => userListToCheck; set => userListToCheck = value; }

        public static async void GetAllUsers()
        {
            WebAPIAsync<User> UserWebAPI = new WebAPIAsync<User>("http://stationlogwebapplication120180426012243.azurewebsites.net", "api", "Users");
            var users = await UserWebAPI.Load();

            if (users != null)
            {
                foreach (var user in users)
                {
                    UserListToCheck.Add(user);
                }
            }
        }

        public static async void RegisterUser(User newUser)
        {
            WebAPIAsync<User> UserWebAPI = new WebAPIAsync<User>("http://stationlogwebapplication120180426012243.azurewebsites.net", "api", "Users");

            await UserWebAPI.Create(newUser.UserId, newUser);
        }
    }
}
