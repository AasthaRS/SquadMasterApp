using Newtonsoft.Json;
using SquadMaster.TeamGenerationLibrary.Models.Group;
using SquadMaster.TeamGenerationLibrary.Models.Member;
using SquadMaster.WPFApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SquadMaster.WPFApp.ViewModels
{
    public class TeamSetupViewModel : ViewModelBase
    {
        private readonly HomeWindowViewModel _homeViewModel;
        private ObservableCollection<Member> _participants;
        private string _numTeams;

        public ICommand GenerateTeamsCommand { get; }

        public ObservableCollection<Member> Participants
        {
            get => _participants;
            set
            {
                _participants = value;
                OnPropertyChanged(nameof(Participants));
            }
        }

        public string NumTeams
        {
            get => _numTeams;
            set
            {
                _numTeams = value;
                OnPropertyChanged(nameof(NumTeams));
            }
        }

        public TeamSetupViewModel(HomeWindowViewModel homeViewModel, string filePath)
        {
            _homeViewModel = homeViewModel;
            LoadParticipants(filePath);
            GenerateTeamsCommand = new RelayCommand(GenerateTeams, CanGenerateTeams);
        }

        private void LoadParticipants(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                Participants = JsonConvert.DeserializeObject<ObservableCollection<Member>>(jsonData);
            }
            catch
            {
                MessageBox.Show("Error loading participants.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanGenerateTeams(object parameter)
        {
            return int.TryParse(NumTeams, out int teams) && teams > 0;
        }

        private void GenerateTeams(object parameter)
        {
            int teams = int.Parse(NumTeams);
            //_homeViewModel.NavigateTo(new TeamDisplayViewModel(_homeViewModel, Participants, teams));
        }
    }
}
