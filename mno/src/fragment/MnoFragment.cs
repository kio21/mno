using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;

namespace mno
{
    class MnoFragment : Android.Support.V4.App.Fragment
    {
        // reference to MnoApp instance
        MnoApp app;

        // fragment view
        View view;

        List<Mno> mnoList;

        ListView mnoListView;

        LayoutInflater inflater;

        public MnoFragment()
        {
            RetainInstance = true;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            app = (MnoApp)Activity.Application;

            LoadMnoData();
        }

        private void LoadMnoData()
        {
            mnoList = new List<Mno>();

            // FIXME
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                mnoList.Add(new Mno
                {
                    Id = i,
                    Value = (float)(2 + Math.Round(rnd.NextDouble(), 2)),
                    Date = new DateTimeOffset(),
                    Dosage = 2,
                    Place = "Консультант"
                });
            }
            
            if (mnoList != null)
            {
                mnoListView.Adapter = new MnoAdapter(inflater, mnoList);
            }
        }

        public override View OnCreateView(LayoutInflater inf, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            inflater = inf;

            // HasOptionsMenu = true;

            view = inflater.Inflate(Resource.Layout.fragment_mno, null);

            mnoListView = view.FindViewById<ListView>(Resource.Id.mno_list_view);

            // TODO
            // mnoListView.ItemClick += OnListItemClick;

            View emptyView = view.FindViewById(Resource.Id.empty_mno_text);
            mnoListView.EmptyView = emptyView;

            FloatingActionButton fabAddMno = view.FindViewById<FloatingActionButton>(Resource.Id.fab_add_mno);
            fabAddMno.Click += FabAddMno_Click;

            return view;
        }

        private void FabAddMno_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Context, typeof(AddMnoActivity));
            StartActivity(intent);
        }
    }
}