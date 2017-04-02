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
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class AddMnoActivity : BaseActivity
    {
        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.activity_add_mno;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Title = GetText(Resource.String.title_add_mno);
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {
                // Respond to the action bar's Up/Home button
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}
