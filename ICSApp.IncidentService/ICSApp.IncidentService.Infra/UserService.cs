using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Application.Models;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ICSApp.IncidentService.Infra
{
    public class UserService : IUserService
    {
        public Guid IdUser { get; set ; }
        public string Name { get ; set; }

        private static string token;

        public string SignIn(string username, string password)
        {
            token = GetToken(username, password);

            if (String.IsNullOrWhiteSpace(token))
                return null;

            return token;
        }

        //public bool SignUp(UserPasswordDto userPassword)
        //{
        //    var adminToken = GetAdminToken();
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + adminToken);
        //    var serializedUserPassword = JsonConvert.SerializeObject(userPassword);
        //    var httpContent = new StringContent(serializedUserPassword, Encoding.UTF8, "application/json");
        //    var result = httpClient.PostAsync("https://worldbank-gustavo-iam-microservice-api.azurewebsites.net/api/UsersAndRoles", httpContent).Result;

        //    if (!result.IsSuccessStatusCode)
        //        return false;
        //    return true;
        //}

        //private string GetAdminToken()
        //{
        //    var client = new HttpClient();
        //    var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
        //    {
        //        Address = "https://worldbank-gustavo-iam-microservice-identity.azurewebsites.net/connect/token",

        //        ClientId = "WorldBankMobileApp_ClientId",
        //        //ClientSecret = "secret",
        //        //Scope = "api1",

        //        UserName = "admin",
        //        Password = "@dsInf123"
        //    }).Result;

        //    return response.AccessToken;
        //}

        private string GetToken(string username, string password)
        {
            var httpClient = new HttpClient();
            var response = httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://localhost:44310/connect/token",

                ClientId = "ICSAppWebApplication_ClientId",

                UserName = username,
                Password = password
            }).Result;

            return response.AccessToken;

        }
    }
}
