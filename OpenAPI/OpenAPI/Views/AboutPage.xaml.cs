using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace OpenAPI.Views
{
    public partial class AboutPage : ContentPage
    {
        HttpClient client;
        public AboutPage()
        {
            InitializeComponent();
        }

        public class DataObject
        {

        }
        // 
        private const string URL = @"https://openapi.gg.go.kr/TBGGSCREECLSTM";
        private string urlParameters => @"?KEY=d9635c15071c41378f76dc0cea2ed024&Type=json";
        private async Task RunAsync()
        {
            client = new()
            {
                BaseAddress = new Uri(URL)
            };
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                // List data response.
                HttpResponseMessage response =await client.GetAsync(URL + urlParameters);  // Blocking call! Program will wait here until a response is received or a timeout occurs.

                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    List<DataObject> dataObjects = await response.Content.ReadAsAsync<List<DataObject>>();  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    await DisplayAlert("Noti", $"{dataObjects})", "OK");

                }
                else
                {
                    await DisplayAlert("Error", $"{(int)response.StatusCode} ({response.ReasonPhrase})", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "OK");
            }

            client.Dispose();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await RunAsync();
        }
    }
}