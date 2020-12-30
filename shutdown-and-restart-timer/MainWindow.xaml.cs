using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace shutdown_and_restart_timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int valNum;
        Int32 time;

        public MainWindow()
        {
            InitializeComponent();
            addItemsToComboBoxes();

        }


        private void addItemsToComboBoxes() {

            string[] choices = {"Shutdown", "Restart"};
            string[] hms = {"Hour(s)", "Minute(s)", "Second(s)"};

            foreach (String choice in choices) {
                choiceCmb.Items.Add(choice);
            }

            foreach (String choice in hms){
                hmsCmb.Items.Add(choice);
            }

            choiceCmb.SelectedIndex = 0;
            hmsCmb.SelectedIndex = 0;
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {

            bool isEnteredNumber = int.TryParse(valTxt.Text, out valNum);

            if (isEnteredNumber == true)
            {

                switch (hmsCmb.SelectedIndex)
                {
                    case 0:
                        time = valNum * 3600;
                        break;
                    case 1:
                        time = valNum * 60;
                        break;
                    case 2:
                        time = valNum;
                        break;
                    default:
                        break;
                }

                switch (choiceCmb.SelectedIndex)
                {
                    case 0:
                        var shutdown = new ProcessStartInfo("shutdown", "/s /t " + time);
                        shutdown.CreateNoWindow = true;
                        shutdown.UseShellExecute = false;
                        Process.Start(shutdown);
                        break;
                    case 1:
                        var restart = new ProcessStartInfo("shutdown", "/r /t " + time);
                        restart.CreateNoWindow = true;
                        restart.UseShellExecute = false;
                        Process.Start(restart);
                        break;
                    default:
                        break;
                }



            }
            else {

                MessageBox.Show("Please enter a valid number", "Error",  MessageBoxButton.OK);
                valTxt.Text = "";
            
            }
            
        }

        private void cancelTimerBtn_Click(object sender, RoutedEventArgs e)
        {
            var cancelTimer = new ProcessStartInfo("shutdown", "/a");
            cancelTimer.CreateNoWindow = true;
            cancelTimer.UseShellExecute = false;
            Process.Start(cancelTimer);
        }
    }
}
