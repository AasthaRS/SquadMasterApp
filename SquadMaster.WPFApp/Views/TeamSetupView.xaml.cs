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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SquadMaster.WPFApp.Views
{
    /// <summary>
    /// Interaction logic for TeamSetupView.xaml
    /// </summary>
    public partial class TeamSetupView : UserControl
    {
        public TeamSetupView()
        {
            InitializeComponent();
        }

        private void TextBox_OnlyNumberInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
