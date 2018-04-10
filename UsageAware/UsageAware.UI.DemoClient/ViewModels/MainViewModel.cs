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

        public MainViewModel(IUsageAwareLogger usageAwareLogger)
        {
            this.TrackPersonCreatedCommand = new RelayCommand(async () => await usageAwareLogger.TrackActionAsync("Person", "erstellt"));
        }

        public ICommand TrackPersonCreatedCommand { get; protected set; }

    }
}
