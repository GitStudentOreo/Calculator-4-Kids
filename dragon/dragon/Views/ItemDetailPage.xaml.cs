using dragon.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace dragon.Views
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