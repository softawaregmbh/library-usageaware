﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace softaware.UsageAware.UI.DemoClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IUsageAwareLogger usageAwareLogger;

        public MainViewModel(IUsageAwareLogger usageAwareLogger)
        {
            this.usageAwareLogger = usageAwareLogger;

            this.TrackPersonCreatedCommand = new RelayCommand(async () => await this.usageAwareLogger.TrackActionAsync("Person", "created"));

            this.TrackPersonChangedCommand = new RelayCommand(async () => await this.usageAwareLogger.TrackActionAsync("Person", "changed", new Dictionary<string, string>() { { "personId", "4711" } }));
        }

        public ICommand TrackPersonCreatedCommand { get; protected set; }

        public ICommand TrackPersonChangedCommand { get; protected set; }

    }
}
