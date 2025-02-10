using System;
using System.Collections.Generic;
using System.IO;
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

namespace SquadMaster.WPFApp.Views
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();

            //this.Icon = new BitmapImage(new Uri("pack://application:,,,/Resources/appIcon.png"));
        }

        private void closeWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
