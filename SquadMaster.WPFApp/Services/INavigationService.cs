using SquadMaster.WPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.WPFApp.Services
{
    public interface INavigationService
    {
        void NavigateTo(ViewModelBase viewModel);
    }
}
