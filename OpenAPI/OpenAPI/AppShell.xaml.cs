using OpenAPI.ViewModels;
using OpenAPI.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace OpenAPI
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
