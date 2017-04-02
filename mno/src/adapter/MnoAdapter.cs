using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System;

namespace mno
{
    class MnoAdapter : BaseAdapter<Mno>
    {
        LayoutInflater inflater;

        List<Mno> items;

        public MnoAdapter(LayoutInflater inf, List<Mno> list)
        {
            inflater = inf;
            items = list;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Mno this[int position]
        {
            get {
                return items[position];
            }
        }

        public override int Count
        {
            get {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;

            if (view == null) // no view to re-use, create new
            {
                view = inflater.Inflate(Resource.Layout.cell_mno, null);
            }

            view.FindViewById<TextView>(Resource.Id.mno_value_text).Text = item.Value.ToString();
            view.FindViewById<TextView>(Resource.Id.mno_date_text).Text = item.Date.ToString();
            view.FindViewById<TextView>(Resource.Id.dosage_text).Text = item.Dosage.ToString();
            view.FindViewById<TextView>(Resource.Id.place_text).Text = item.Place;

            return view;
        }

        public void OnChanged()
        {
            this.NotifyDataSetChanged();
        }
    }
}