
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.WPFApp.ViewModels
{
    public class HomeWindowViewModel : ViewModelBase
    {

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView)); // Notify UI of changes
            }
        }

        // Constructor initializes first view
        public HomeWindowViewModel()
        {
            CurrentView = new LoadDataViewModel(this); // Set default view
        }

        // Method to switch views manually
        public void NavigateTo(object viewModel)
        {
            CurrentView = viewModel;
        }
    }
}
