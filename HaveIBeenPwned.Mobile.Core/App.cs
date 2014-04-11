using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using HaveIBeenPwned.Mobile.Core.Services;

namespace HaveIBeenPwned.Mobile.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType(HttpClientFactory.Get);
            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}