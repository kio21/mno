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

            /*var operations = DataManager<Operation>.Instance.GetEntries(s => s.UserId == app.CurrentUserId && s.Status != OperationStatus.Deleted && s.Status != OperationStatus.Synchronized).OrderByDescending(s => s.OperationDate);

            foreach (var o in operations)
            {
                var employee = DataManager<Employee>.Instance.GetEntries(e => e.EmployeeId == o.EmployeeId).FirstOrDefault();
                var workZone = DataManager<WorkZone>.Instance.GetEntries(e => e.WorkZoneGuid == o.WorkZoneGuid).FirstOrDefault().WorkZoneName;
                var accessPoint = DataManager<AccessPoint>.Instance.GetEntries(e => e.AccessPointGuid == o.AccessPointGuid).FirstOrDefault().AccessPointName;
                o.OperationDate = o.OperationDate.ToLocalTime();

                displayedOperations.Add(new SynchronizationItem
                {
                    FullEmployeeName = employee?.FullName,
                    //ToDo Search workZOne and access point
                    WorkZoneName = workZone + ". " + accessPoint,//o.Description,
                    OperationInfo = $"{o.OperationName} {GetText(Resource.String.register_text)} {o.OperationDate.ToString("yyyy.MM.dd HH:mm")}",
                    OperationStatus = GetOperationStatus(o.Status),
                    OperationColor = GetOperationColor(o.Status, view.Context),
                    OperationStatusId = (int)o.Status,
                    EmployeeHexCode = employee?.KeyCode,
                    OperationName = o.OperationName,
                    OperationDate = o.OperationDate.ToString(),
                    OperationId = o.OperationId
                });
            }*/

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

            // mnoListView.ItemClick += OnListItemClick;

            var emptyView = view.FindViewById(Resource.Id.empty_mno_text);
            mnoListView.EmptyView = emptyView;

            return view;
        }
    }
}