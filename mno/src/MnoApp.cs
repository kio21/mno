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
    [Application]
    public class MnoApp : Application
    {
        public MainActivity MainAct;

        public MnoApp(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
		{
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }
    }
}