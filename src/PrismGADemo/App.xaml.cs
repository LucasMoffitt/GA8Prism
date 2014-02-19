using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using DT.GoogleAnalytics.Metro;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Unity;

namespace PrismGADemo
{
    sealed partial class App : MvvmAppBase
    {
        private readonly UnityContainer _container = new UnityContainer();

        public App()
        {
            InitializeComponent();
        }

        protected override Task OnLaunchApplication(LaunchActivatedEventArgs args)
        {
            AnalyticsHelper.Setup();

            NavigationService.Navigate("Main", null);

            return Task.FromResult<object>(null);
        }

        protected override void OnInitialize(IActivatedEventArgs args)
        {
            _container.RegisterInstance(SessionStateService);
            _container.RegisterInstance(NavigationService);

            ViewModelLocator.SetDefaultViewModelFactory(viewModelType => _container.Resolve(viewModelType));
        }
    }
}
