using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SNT.ControlEquipmentStates
{
    public class MyMessageBox
    {
        public enum Buttons { Yes_No, OK}
        //public enum TypeMessage { }
        public static int PushButton { get; set; }
        
        public static string Show(string text, Buttons buttons, MessageBoxImage image)
        {
            MyMessageBoxView myMessageBoxView = new MyMessageBoxView(text, buttons, image);
            myMessageBoxView.Show();
            return myMessageBoxView.ReturnString;
        }
        public static string ShowDialog(string text)
        {
            return ShowDialog(text, Buttons.OK, MessageBoxImage.None);
        }
        public static string ShowDialog(string text, Buttons buttons, MessageBoxImage image)
        {
            MyMessageBoxView myMessageBoxView = new MyMessageBoxView(text, buttons, image);
            myMessageBoxView.ShowDialog();
            return myMessageBoxView.ReturnString;
        }
        public static string ShowDialog(string text, Buttons buttons, string title, MessageBoxImage image)
        {
            MyMessageBoxView myMessageBoxView = new MyMessageBoxView(text, buttons, image);
            myMessageBoxView.Title = title;
            myMessageBoxView.ShowDialog();
            return myMessageBoxView.ReturnString;
        }
        public static int GetPushButton(int index)
        {
            PushButton = 0;
            return PushButton = index;
        }
        
    }
}
