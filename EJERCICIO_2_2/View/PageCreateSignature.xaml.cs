using EJERCICIO_2_2.Model;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJERCICIO_2_2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCreateSignature : ContentPage
    {
        public PageCreateSignature()
        {
            InitializeComponent();
        }

        private async void BtnSaveSignature_Clicked(object sender, EventArgs e)
        {
            if (Sign.IsBlank)
            {
                await DisplayAlert("Advertencia", "Debes agregar tu firma.", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                await DisplayAlert("Advertencia", "Debes ingresar tu nombre.", "Ok");
                return;
            }

            Stream img = await Sign.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            BinaryReader br = new BinaryReader(img);

            Byte[] bytes = br.ReadBytes((Int32)img.Length);
            string base64 = Convert.ToBase64String(bytes, 0, bytes.Length);

            Signature signature = new Signature()
            {
                id = 0,
                name = txtName.Text,
                description = txtDescripcion.Text,
                image = base64
            };

            var result = await App.DBase.createOrUpdateSignature(signature);

            if (result > 0)
            {
                cleanElement();
                SaveSignatureToDevice(img);
                await DisplayAlert("Aviso", "Firma Guardado Correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Se produjo un error al guardar la firma", "OK");
            }

        }

        private void cleanElement()
        {
            Sign.Clear();
            txtDescripcion.Text = "";
            txtName.Text = "";
        }

        private void SaveSignatureToDevice(Stream img)
        {
            try
            {
                var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures).ToString(), "Signatures");

                if (!Directory.Exists(filename))
                {
                    Directory.CreateDirectory(filename);
                }

                string nameFile = DateTime.Now.ToString("yyyyMMddhhmmss") + ".png";
                filename = Path.Combine(filename, nameFile);

                var mStream = (MemoryStream)img;
                Byte[] bytes = mStream.ToArray();
                File.WriteAllBytes(filename, bytes);
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Ok");
            }

        }
    }
}