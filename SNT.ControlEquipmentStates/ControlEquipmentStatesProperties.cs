using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SNT.ControlEquipmentStates
{
    public partial class ControlEquipmentStatesViewModal : INotifyPropertyChanged
    {

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Detail> Details { get; set; } = new ObservableCollection<Detail>();
        public ObservableCollection<ControlEquipmentState> DetailsOfRelease = new ObservableCollection<ControlEquipmentState>();

        public bool SNT_OpenWindow { get => _openWindow; set { _openWindow = value; OnPropertyChanged(); OpenWindow(); } }
        private bool _openWindow;
        public bool SNT_ReleaseSystem { get => _releaseSystem; set { _releaseSystem = value; OnPropertyChanged(); ReleaseSystemStateChanged(); } }
        private bool _releaseSystem = false;
        public bool SNT_AlarmActive { get => _alarmActive; set { _alarmActive = value; OnPropertyChanged(); AlarmActiveStateChanged(); } }
        private bool _alarmActive = false;
        public bool SNT_RecipeActive { get => _recipeActive; set { _recipeActive = value; OnPropertyChanged(); ModeStateChanged(); } }
        private bool _recipeActive = false;
        public bool SNT_ManualModeSystemActive { get => _manualModeSystemActive; set { _manualModeSystemActive = value; OnPropertyChanged(); ModeStateChanged(); } }
        private bool _manualModeSystemActive = false;
        public bool SNT_OperationMainDevices { get => _operationMainDevices; set { _operationMainDevices = value; OnPropertyChanged(); OperationMainDevicesChanged(); } }
        private bool _operationMainDevices;

        public string SNT_CurrentState { get => _currentState; set { _currentState = value; OnPropertyChanged(); } }
        private string _currentState;

        public int CurrentlySelectedState { get => _currentlySelectedState; set { _currentlySelectedState = value; OnPropertyChanged(); } }
        private int _currentlySelectedState;



        public string TotalRelease { get => _totalRelease; set { _totalRelease = value; OnPropertyChanged(); } }
        private string _totalRelease;
        public string TotalAlarmTime { get => _totalAlarmTime; set { _totalAlarmTime = value; OnPropertyChanged(); } }
        private string _totalAlarmTime;
        public string OperatingTimeInManualMode { get => _operatingTimeInManualMode; set { _operatingTimeInManualMode = value; OnPropertyChanged(); } }
        private string _operatingTimeInManualMode;
        public string OperatingTimeInAutomaticMode { get => _operatingTimeInAutomaticMode; set { _operatingTimeInAutomaticMode = value; OnPropertyChanged(); } }
        private string _operatingTimeInAutomaticMode;
        public string TotalDowntime { get => _totalDowntime; set { _totalDowntime = value; OnPropertyChanged(); } }
        private string _totalDowntime;
        public string OperatingMainDevices { get => _operatingMainDevices; set { _operatingMainDevices = value; OnPropertyChanged(); } }
        private string _operatingMainDevices;
        public string TotalTime { get => _totalTime; set { _totalTime = value; OnPropertyChanged(); } }
        private string _totalTime;



    }
}
