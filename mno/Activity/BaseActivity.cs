using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace mno
{
    public abstract class BaseActivity : AppCompatActivity
    {
        public Toolbar Toolbar
        {
            get;
            set;
        }

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

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            // TODO
            /*
            mAppNavigationViewAsDrawer = new AppNavigationViewAsDrawerImpl(new ImageLoader(this), this);
            mAppNavigationViewAsDrawer.activityReady(this, this, getSelfNavDrawerItem());

            if (getSelfNavDrawerItem() != NavigationItemEnum.INVALID)
            {
                setToolbarForNavigation();
            }

            trySetupSwipeRefresh();

            View mainContent = findViewById(R.id.main_content);
            if (mainContent != null)
            {
                mainContent.setAlpha(0);
                mainContent.animate().alpha(1).setDuration(MAIN_CONTENT_FADEIN_DURATION);
            }
            else
            {
                LOGW(TAG, "No view with ID main_content to fade in.");
            }
            */
        }

        private void SetToolbarForNavigation()
        {
            if (Toolbar != null)
            {
                Toolbar.SetNavigationIcon(Resource.Drawable.ic_hamburger);
                //Toolbar.SetNavigationOnClickListener();
                //Toolbar.set
                // TODO
                /*Toolbar.SetNavigationOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view)
                    {
                        mAppNavigationViewAsDrawer.showNavigation();
                    }
                });*/
            }
        }

        protected abstract int LayoutResource
        {
            get;
        }

        protected int ActionBarIcon
        {
            set { Toolbar.SetNavigationIcon(value); }
        }
    }
}
