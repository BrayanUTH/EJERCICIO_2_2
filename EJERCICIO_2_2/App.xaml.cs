using EJERCICIO_2_2.Controllers;
using EJERCICIO_2_2.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJERCICIO_2_2
{
    public partial class App : Application
    {
        static Database db;

        public static Database DBase
        {
            get
            {
                if (db == null)
                {
                    string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Signature.db3");
                    db = new Database(folderPath);
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PagePrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
