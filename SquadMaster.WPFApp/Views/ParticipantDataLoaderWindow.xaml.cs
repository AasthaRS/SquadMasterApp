using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SquadMaster.WPFApp.Views
{
    /// <summary>
    /// Interaction logic for ParticipantDataLoaderWindow.xaml
    /// </summary>
    public partial class ParticipantDataLoaderWindow : UserControl
    {
        private string participantJsonData;
        public ParticipantDataLoaderWindow()
        {
            InitializeComponent();
        }

        private void generateTeamsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void uploadJsonBtn_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                participantJsonData = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void displayParticipantsBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void NumberOfTeamsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // This regular expression allows only digits to be entered
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
