using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SNT.ControlEquipmentStates
{
    public partial class ControlEquipmentStatesViewModal
    {
        private bool _releaseState;
        private bool _alarmState;
        private bool _operationMainDevicesState;
        private bool _autoModeState;
        private bool _manualModeState;
        private bool _downTimeState;

        Dictionary<int, string> States = new Dictionary<int, string>
        {
            {0,"Release" },
            {1,"Alarm" },
            {2,"ManualMode" },
            {3,"AutoMode" },
            {4,"DownTime" },
            {5,"OperationMainDevices" }
        };
        //string[] TotalTimes = new string[6];

        void OpenWindow()
        {
            List<ControlEquipmentState> DBDataList = new List<ControlEquipmentState>();
            string[] TotalTimes = new string[6];
            for (int j = 0; j < 6; j++)
            {
                DBDataList.Clear();
                TimeSpan timeSpan = new TimeSpan();
                TimeSpan totalTimeSpan = new TimeSpan();
                using (var db = new ModelDB())
                {
                    string state = States[j];
                    var Data = from p in db.ControlEquipmentState
                               where p.IDState == state
                               orderby p.Time
                               select p;

                    foreach (ControlEquipmentState p in Data)
                    {
                        DBDataList.Add(p);
                    }
                }
                for (int i = 0; i < DBDataList.Count; i++)
                {
                    if (i != DBDataList.Count - 1)
                    {
                        if (DBDataList[i].Flag == "Active" && DBDataList[i + 1].Flag == "NotActive" && (DBDataList[i].Time.Date == DBDataList[i + 1].Time.Date))
                        {
                            timeSpan = DBDataList[i + 1].Time - DBDataList[i].Time;
                            totalTimeSpan += timeSpan;
                        }
                    }
                    if (i == DBDataList.Count - 1)
                    {
                        if (DBDataList[i].Flag == "Active" && SNT_ReleaseSystem && (DBDataList[i].Time.Date == DateTime.Now.Date))
                        {
                            timeSpan = DateTime.Now - DBDataList[i].Time;
                            totalTimeSpan += timeSpan;
                        }
                    }
                }
                TotalTimes[j] = Convert.ToString($"{totalTimeSpan.Days}. {totalTimeSpan.Hours}:{totalTimeSpan.Minutes}:{totalTimeSpan.Seconds}");
            }
            TotalRelease = TotalTimes[0];
            TotalAlarmTime = TotalTimes[1];
            OperatingTimeInManualMode = TotalTimes[2];
            OperatingTimeInAutomaticMode = TotalTimes[3];
            TotalDowntime = TotalTimes[4];
            OperatingMainDevices = TotalTimes[5];
        }

        void DetailOfState()
        {
            using (var db = new ModelDB())
            {
                string state = States[CurrentlySelectedState];
                var Data = from p in db.ControlEquipmentState
                           where p.IDState == state
                           orderby p.Time
                           select p;
                Details.Clear();
                foreach (ControlEquipmentState p in Data)
                {
                    Details.Add(new Detail
                    {
                        IDState = p.IDState,
                        Time = $"{p.Time.Day}.{p.Time.Month}.{p.Time.Year} {p.Time.Hour}:{p.Time.Minute}:{p.Time.Second}",
                        Flag = p.Flag
                    });
                }
            }
        }
        
        void Clear()
        {
            using (var db = new ModelDB())
            {
                Mouse.OverrideCursor = Cursors.Wait;
                int numberOfRowDeleted = db.Database.ExecuteSqlCommand("TRUNCATE TABLE ControlEquipmentState");
            }
            _releaseState = false;
            _alarmState = false;
            _operationMainDevicesState = false;
            _autoModeState = false;
            _manualModeState = false;
            _downTimeState = false;
            ReleaseSystemStateChanged();
            AlarmActiveStateChanged();
            ModeStateChanged();
            CheckingDownTimeState();
            OperationMainDevicesChanged();
            DetailOfState();
            OpenWindow();
            Mouse.OverrideCursor = Cursors.Arrow;
            MyMessageBox.ShowDialog("Удаление прошло успешно!", MyMessageBox.Buttons.OK, "Сообщение", MessageBoxImage.Information);
        }
        void WritingToDB(string CurrentState, string CurrentFlag)
        {
            DateTime CurrentDateTime = DateTime.Now;
            using (var db = new ModelDB())
            {
                var Data = new ControlEquipmentState()
                {
                    IDState = CurrentState,
                    Time = CurrentDateTime,
                    Flag = CurrentFlag
                };
                db.ControlEquipmentState.Add(Data);
                db.SaveChanges();
            }
        }
        void ReleaseSystemStateChanged()
        {
            CheckingDownTimeState();
            if (SNT_ReleaseSystem && !_releaseState)
            {
                WritingToDB(States[0], "Active");
                _releaseState = true;
            }
            else if (!SNT_ReleaseSystem && _releaseState)
            {
                WritingToDB(States[0], "NotActive");
                _releaseState = false;
            }
        }
        void AlarmActiveStateChanged()
        {
            if (SNT_ReleaseSystem)
            {
                if (SNT_AlarmActive && !_alarmState)
                {
                    WritingToDB(States[1], "Active");
                    _alarmState = true;
                }
                else if (!SNT_AlarmActive && _alarmState)
                {
                    WritingToDB(States[1], "NotActive");
                    _alarmState = false;
                }
            }
        }
        void ModeStateChanged()
        {
            if (SNT_ReleaseSystem)
            {
                if (SNT_RecipeActive && !SNT_ManualModeSystemActive && !_autoModeState)
                {
                    WritingToDB(States[3], "Active");
                    _autoModeState = true;
                }
                else if ((!SNT_RecipeActive || SNT_ManualModeSystemActive) && _autoModeState)
                {
                    WritingToDB(States[3], "NotActive");
                    _autoModeState = false;
                }

                if (SNT_ManualModeSystemActive && !_manualModeState)
                {
                    WritingToDB(States[2], "Active");
                    _manualModeState = true;
                }
                else if (!SNT_ManualModeSystemActive && _manualModeState)
                {
                    WritingToDB(States[2], "NotActive");
                    _manualModeState = false;
                }
                CheckingDownTimeState();
            }
        }
        void OperationMainDevicesChanged()
        {
            if (SNT_ReleaseSystem)
            {
                if (SNT_OperationMainDevices && !_operationMainDevicesState)
                {
                    WritingToDB(States[5], "Active");
                    _operationMainDevicesState = true;
                }
                else if(!SNT_OperationMainDevices && _operationMainDevicesState)
                {
                    WritingToDB(States[5], "NotActive");
                    _operationMainDevicesState = false;

                }
            }
        }
        void CheckingDownTimeState()
        {
            if (SNT_ReleaseSystem)
            {
                if (!SNT_RecipeActive && !SNT_ManualModeSystemActive && !_downTimeState)
                {
                    WritingToDB(States[4], "Active");
                    _downTimeState = true;
                }
                else if ((SNT_RecipeActive || SNT_ManualModeSystemActive) && _downTimeState)
                {
                    WritingToDB(States[4], "NotActive");
                    _downTimeState = false;
                }
            }
        }
    }
}
