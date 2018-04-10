using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UsageAware.UI.DemoClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IUsageAwareLogger usageAwareLogger;

        public MainViewModel(IUsageAwareLogger usageAwareLogger)
        {
            this.usageAwareLogger = usageAwareLogger;

            this.TrackPersonCreatedCommand = new RelayCommand(async () => await this.usageAwareLogger.TrackActionAsync("Person", "erstellt"));
        }

        public ICommand TrackPersonCreatedCommand { get; protected set; }

    }
}
