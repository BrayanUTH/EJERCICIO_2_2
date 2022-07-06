using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJERCICIO_2_2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListSignature : ContentPage
    {
        public PageListSignature()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (await App.DBase.getAllSignature() != null)
            {
                base.OnAppearing();
                ListSignatures.ItemsSource = await App.DBase.getAllSignature();
            }
            else
            {
                await DisplayAlert("Advertencia", "No hay sitios agregados", "Ok");
            }
            
        }
    }
}