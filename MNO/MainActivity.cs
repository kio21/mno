using Android.App;
using Android.Widget;
using Android.OS;
using Android;
using Android.Support.V7.App;
using Android.Support.V4.Widget;

namespace mno
{
    [Activity(MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.activity_main);
        }
    }
}

