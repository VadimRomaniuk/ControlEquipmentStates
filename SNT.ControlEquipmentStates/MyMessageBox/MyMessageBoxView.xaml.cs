using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SNT.ControlEquipmentStates
{
    /// <summary>
    /// Логика взаимодействия для MyMessageBoxView.xaml
    /// </summary>
    public partial class MyMessageBoxView : Window
    {
        public string ReturnString { get; set; }

        public MyMessageBoxView(string Text, MyMessageBox.Buttons buttons, MessageBoxImage messageBoxImage)
        {
            InitializeComponent();
            MessageText.Text = Text;

            switch (buttons)
            {
                case MyMessageBox.Buttons.Yes_No:
                    btnYes.Visibility = Visibility.Visible;
                    btnNo.Visibility = Visibility.Visible;
                    break;
                case MyMessageBox.Buttons.OK:
                    btnOk.Visibility = Visibility.Visible;
                    break;
            }

            switch ((int)messageBoxImage)
            {
                case 0:
                    GridForIcon.Width = new GridLength(0);
                    break;
                case 16:
                    icon.Source = new BitmapImage(new Uri("../Resources/ico103.ico", UriKind.Relative));
                    //icon.Source = new BitmapImage(new Uri("Resources/ico103.ico", UriKind.Relative));
                    break;
                case 32:
                    icon.Source = new BitmapImage(new Uri("../Resources/ico102.ico", UriKind.Relative));
                    //icon.Source = new BitmapImage(new Uri("Resources/ico102.ico", UriKind.Relative));
                    break;
                case 48:
                    icon.Source = new BitmapImage(new Uri("../Resources/ico101.ico", UriKind.Relative));
                    //icon.Source = new BitmapImage(new Uri("Resources/ico101.ico", UriKind.Relative));
                    break;
                case 64:
                    icon.Source = new BitmapImage(new Uri("../Resources/ico104.ico", UriKind.Relative));
                    //icon.Source = new BitmapImage(new Uri("Resources/ico104.ico", UriKind.Relative));
                    break;
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReturnString = ((Button)sender).Uid.ToString();
            Button button = sender as Button;
            MyMessageBox.GetPushButton(Convert.ToInt32(button.Uid));
            Close();
        }
    }
}
