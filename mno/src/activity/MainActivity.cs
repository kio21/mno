using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace mno
{
    [Activity(MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : BaseActivity
    {
        DrawerLayout drawerLayout;

        NavigationView navigationView;

        IMenuItem previousItem;

        int currentFragmentResId;

        Android.Support.V4.App.Fragment currentFragment;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.activity_main;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            App.MainAct = this;

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_hamburger);

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            InflateMenu();

            navigationView.NavigationItemSelected += (sender, e) =>
            {

                if (previousItem != null && previousItem.ItemId != e.MenuItem.ItemId)
                {
                    previousItem.SetChecked(false);
                }

                navigationView.SetCheckedItem(e.MenuItem.ItemId);

                previousItem = e.MenuItem;

                ListItemClicked(e.MenuItem.ItemId);

                drawerLayout.CloseDrawers();
            };

            // default first screen
            if (savedInstanceState == null)
            {
                SelectMenuItem(Resource.Id.nav_mno);
            }
        }

        public void InflateMenu()
        {
            if (navigationView.Menu != null)
            {
                navigationView.Menu.Clear();
            }

            var navHeaderText = navigationView.GetHeaderView(0).FindViewById<TextView>(Resource.Id.nav_header_text);

            navigationView.InflateMenu(Resource.Menu.drawer_items);
        }

        void ListItemClicked(int resId)
        {
            currentFragmentResId = resId;
            switch (resId)
            {
                case Resource.Id.nav_dashboard:
                    Title = GetText(Resource.String.nav_dashboard);
                    // TODO currentFragment = new DashboardFragment();
                    currentFragment = new Android.Support.V4.App.Fragment();
                    break;
                case Resource.Id.nav_mno:
                    Title = GetText(Resource.String.nav_mno);
                    currentFragment = new MnoFragment();
                    break;
                case Resource.Id.nav_warfarin:
                    Title = GetText(Resource.String.nav_warfarin);
                    // TODO currentFragment = new WarfarinFragment();
                    currentFragment = new Android.Support.V4.App.Fragment();
                    break;
                case Resource.Id.nav_about:
                    Title = GetText(Resource.String.nav_about);
                    // TODO currentFragment = new AboutFragment();
                    currentFragment = new Android.Support.V4.App.Fragment();
                    break;
                case Resource.Id.nav_settings:
                    Title = GetText(Resource.String.nav_settings);
                    // TODO currentFragment = new SettingsFragment();
                    currentFragment = new Android.Support.V4.App.Fragment();
                    break;
                default:
                    currentFragment = new Android.Support.V4.App.Fragment();
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, currentFragment)
                .Commit();
        }

        public void SelectMenuItem(int resId)
        {
            navigationView.SetCheckedItem(resId);
            ListItemClicked(resId);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}
