using SquadMaster.WPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.WPFApp.Services
{
    public enum ViewType
    {
        ParticipantDataLoader,
        TeamSetup,
        TeamDisplay
    }

    public class NavigationService : INavigationService
    {
        public event Action<ViewModelBase> OnViewChanged;

        public void NavigateTo(ViewModelBase viewModel)
        {
            OnViewChanged?.Invoke(viewModel);
        }
    }
}
