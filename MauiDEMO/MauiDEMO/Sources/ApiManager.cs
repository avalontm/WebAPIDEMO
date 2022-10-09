using MauiDEMO.Sources.Models;
using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class ApiManager
{
    static string HOST = "http://192.168.1.113:8080"; //API HOST URL

    static WebClientManager _client;
    public static WebClientManager client => _client ?? (_client = new WebClientManager(string.Format("{0}/api", HOST)));

    public static async Task<ResponseModel> Login(string email, string password)
    {
        ResponseModel response = new ResponseModel();

        LoginModel model = new LoginModel();
        model.email = email;
        model.password = password;

        try
        {
            return await client.PostAsync<ResponseModel>("user/login", model);
        }
        catch (Exception ex)
        {
            response.message = ex.Message;
            return response;
        }
    }
}

