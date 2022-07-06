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
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private async void BtnCreateSignature_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageCreateSignature());
        }

        private async void BtnListSignature_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageListSignature());
        }
    }
}