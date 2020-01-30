using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace CalculadoraDeMunicao.Droid
{
    [Activity(Label = "PrintWayy Devices", Theme = "@style/SplashScreenTheme", MainLauncher = true, NoHistory = true)]
    public class SplashScreenActivity : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistableBundle)
        {
            base.OnCreate(savedInstanceState, persistableBundle);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { StartActivity(new Intent(Application.Context, typeof(MainActivity))); });
            startupWork.Start();
        }
    }
}