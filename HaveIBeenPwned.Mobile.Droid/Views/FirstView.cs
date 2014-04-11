using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace HaveIBeenPwned.Mobile.Droid.Views
{
    [Activity(Label = "Have I Been Pwned")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}