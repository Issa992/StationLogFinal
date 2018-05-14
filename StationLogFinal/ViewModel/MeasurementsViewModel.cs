using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StationLogFinal.Common;
using StationLogFinal.Handlers;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogWebApplication1;

namespace StationLogFinal.ViewModel
{
    class MeasurementsViewModel :NotifyPropertyChange
    {
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net";
        private const string ApiPrefix = "api";
        const string ApiIdMeasurements = "Measurements";

        static IWebAPIAsync<Measurement> iWebApiAsyncMeasure = new WebAPIAsync<Measurement>(ServerUrl, ApiPrefix, ApiIdMeasurements);


        private static ObservableCollection<Measurement> _MeasurementsOC;

        public ObservableCollection<Measurement> MeasurementsOC
        {
            get => _MeasurementsOC;
            set
            {
                MeasurementsOC = value;
                OnPropertyChanged(nameof(MeasurementsOC));
            }
        }

        private Measurement _NewMeasurment;


        public MeasurementsHandler measurementsHandler;
        public Measurement _SelectedMeasurment;


        public Measurement NewMeasurment
        {
            get { return _NewMeasurment; }
            set
            {
                _NewMeasurment = value;
                OnPropertyChanged();
            }
        }

        public Measurement SelectedMeasurment
        {
            get => _SelectedMeasurment;
            set
            {
                _SelectedMeasurment = value;
                OnPropertyChanged(nameof(SelectedMeasurment));
            }
        }


        public async void LoadMeasurments()
        {
            _MeasurementsOC = new ObservableCollection<Measurement>(await iWebApiAsyncMeasure.Load());
        }


     

        public MeasurementsViewModel()
        {
            NewMeasurment = new Measurement();
            LoadMeasurments();
           measurementsHandler = new MeasurementsHandler(this);
        
            CreateCommand = new RelayCommand(measurementsHandler.AddMeasurment);
            DeleteCommand = new RelayCommand(measurementsHandler.DeleteMeasurment);
        }
    }
}
