using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SNT.ControlEquipmentStates
{
    public partial class ControlEquipmentStatesViewModal
    {
        public class Detail
        {

            public Detail() { }
            public Detail(Detail detail)
            {
                IDState = detail.IDState;
                Time = detail.Time;
                Flag = detail.Flag;
            }
            public string IDState { get; set; }
            public string Time { get; set; }
            public string Flag { get; set; }
        }

        public delegate void ButtonClick();

        public event ButtonClick SNT_Detail;
        public event ButtonClick SNT_Clear;
        public event ButtonClick SNT_Update;
        


        public void CallEvent(int Index)
        {
            switch (Index)
            {
                case 1:
                    DetailOfState();
                    SNT_Detail?.Invoke();
                    break;
                case 2:
                    OpenWindow();
                    SNT_Update?.Invoke();
                    break;
                case 3:
                    MyMessageBox.ShowDialog("Вы действительно хотите очистить базу данных?",
                                             MyMessageBox.Buttons.Yes_No,
                                             "Очистка базы данных",
                                             System.Windows.MessageBoxImage.Warning);
                    if (MyMessageBox.PushButton == 1)
                    {
                        Clear();
                        SNT_Clear?.Invoke();
                    }
                    break;
            }
        }
        


    }
}
