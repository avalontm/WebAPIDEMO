using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System.Diagnostics;
using PluginAPI;
using libzkfpcsharp;
using MauiDEMO.Sources.Models;

namespace MauiDEMO;

public partial class MainPage : ContentPage
{
	string _email;
	public string email
	{
		get { return _email; }
		set
		{
			_email = value;
			OnPropertyChanged("email");
		}
	}

    string _password;
    public string password
    {
        get { return _password; }
        set
        {
            _password = value;
            OnPropertyChanged("password");
        }
    }

    public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	async void onLogin(object sender, EventArgs e)
	{

		ResponseModel response = await ApiManager.Login(email, password);

		if (!response.status)
		{
			await DisplayAlert("Error", response.message, "OK");
			return;
		}

		await DisplayAlert("Correcto", response.message, "OK");

    }
}

