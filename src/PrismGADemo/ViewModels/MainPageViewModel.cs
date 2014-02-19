using DT.GoogleAnalytics.Metro;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;

namespace PrismGADemo.ViewModels
{
    class MainPageViewModel
    {
        public DelegateCommand FireEventCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            AnalyticsHelper.TrackPageView("PrismGADemo Main");

            FireEventCommand = new DelegateCommand(() => AnalyticsHelper.Track("PrismDemo", "EventTest"));
        }
    }
}
