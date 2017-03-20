using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace mno
{
    [Activity(MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : BaseActivity
    {
        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.activity_main;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
        }
    }
}

