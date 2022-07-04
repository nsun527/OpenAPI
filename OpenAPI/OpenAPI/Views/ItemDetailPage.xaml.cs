using OpenAPI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace OpenAPI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}