using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows;
using System.IO;
using SquadMaster.TeamGenerationLibrary.Models.Member;
using Newtonsoft.Json;
using SquadMaster.WPFApp.Commands;
using SquadMaster.TeamGenerationLibrary.Readers.FileReaders;

namespace SquadMaster.WPFApp.ViewModels
{
    public class LoadDataViewModel : ViewModelBase
    {
        private readonly HomeWindowViewModel _homeViewModel;
        private string _filePath;
        private bool _isFileValid;

        public ICommand UploadFileCommand { get; }
        public ICommand ProceedCommand { get; }

        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }

        public bool IsFileValid
        {
            get => _isFileValid;
            set
            {
                _isFileValid = value;
                OnPropertyChanged(nameof(IsFileValid));
            }
        }

        public LoadDataViewModel(HomeWindowViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
            UploadFileCommand = new RelayCommand(UploadFile);
            ProceedCommand = new RelayCommand(Proceed, CanProceed);
        }

        private void UploadFile(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Select JSON File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;

                // Validate JSON
                if (ValidateJson(FilePath))
                {
                    MessageBox.Show("File uploaded successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    IsFileValid = true;
                }
                else
                {
                    MessageBox.Show("Invalid JSON file!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    IsFileValid = false;
                }
            }
        }

        private bool ValidateJson(string filePath)
        {
            try
            {
                JsonFileReader jsonFileReader = new JsonFileReader();
                var participants = jsonFileReader.Read(filePath);
                return participants != null && participants.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        private bool CanProceed(object parameter)
        {
            return IsFileValid;
        }

        private void Proceed(object parameter)
        {
            _homeViewModel.NavigateTo(new TeamSetupViewModel(_homeViewModel, FilePath));
        }
    }
}
