using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Dto;
using TaskManager_Client.Services.Project;

namespace TaskManager_Client.ViewModel
{
    public class SelectProjectsViewModel:ViewModelBase
    {
        private readonly IProjectService _projectService = null;
        public SelectProjectsViewModel(IProjectService projectService)
        {
            _projectService = projectService;
            
        }
        #region AllProjects Property

        public IEnumerable<CommonProjectDto> AllProjects { get; set; }=new List<CommonProjectDto>();

        #endregion

        #region SelectedProjects Property

        public IEnumerable<CommonProjectDto> SelectedProjects { get; set; }

        #endregion

        #region CurrentWindow Property

        public Window CurrentWindow { get; set; }

        #endregion

        #region Apply Command

        private ICommand _applyCommand = null;

        public ICommand ApplyCommand => _applyCommand ?? (_applyCommand = new RelayCommand(ApplyExecute));

        private void ApplyExecute()
        {
            CurrentWindow.DialogResult = true;

        }

        #endregion

        #region Cancel Command

        private ICommand _cancelCommand = null;

        public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(CancelExecute));

        private void CancelExecute()
        {
            CurrentWindow.DialogResult = false;
        }

        #endregion

        #region Load Command

        private ICommand _loadCommand = null;

        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(async ()=>await LoadExecute()));

        private async Task LoadExecute()
        {
            var response = await _projectService.AllProjectsAsync();
            if (response.IsSuccessStatusCode)
            {
                AllProjects = await response.Content.ReadAsAsync<IEnumerable<CommonProjectDto>>();
                RaisePropertyChanged("AllProjects");
            }
                


        }



        #endregion

        #region SelectionChanged Command
         
        private ICommand _selectionChangedCommand = null;

        public ICommand SelectionChangedCommand => _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand<IList>(SelectionChangedExecute));


        private void SelectionChangedExecute(IList list)
        {
            SelectedProjects = list.Cast<CommonProjectDto>();

        }

        #endregion

        


    }
}
