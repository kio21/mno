using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace mno
{
    public abstract class BaseActivity : AppCompatActivity
    {

        // Toolbar
        public Toolbar Toolbar { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(LayoutResource);

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }
        }
        
        protected abstract int LayoutResource
        {
            get;
        }
    }
}