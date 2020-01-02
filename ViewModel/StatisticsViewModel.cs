using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Dto;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Group;
using TaskManager_Client.Services.Project;

namespace TaskManager_Client.ViewModel
{
    public class StatisticsViewModel:CommonViewModel
    {
        private readonly IProjectService _projectService = null;
        private readonly IGroupService _groupService = null;
        public StatisticsViewModel(IFrameNavigationService navigationService,IProjectService projectService,IGroupService groupService):base(navigationService)
        {
            _projectService = projectService;
            _groupService = groupService;
        }

        #region UsersProjects Property

        public IEnumerable<CommonProjectDto> UsersProjects { get; set; }

        #endregion

        #region Groups Property

        public IEnumerable<CommonGroupDto> Groups { get; set; }

        #endregion

        #region SelectedProject Property

        public CommonProjectDto SelectedProject { get; set; }

        #endregion

        #region SelectedGroup Property

        public CommonGroupDto SelectedGroup { get; set; }

        #endregion

        #region UsersProjects Command

        private ICommand _usersProjectsCommand = null;

        public ICommand UsersProjectsCommand => _usersProjectsCommand ?? (_usersProjectsCommand = new RelayCommand(async ()=>await UsersProjectsExecute()));

        private async Task UsersProjectsExecute()
        {
            var response = await _projectService.UserProjectsAsync();
            if (response.IsSuccessStatusCode)
            {
                UsersProjects = await response.Content.ReadAsAsync<IEnumerable<CommonProjectDto>>();
                RaisePropertyChanged("UsersProjects");
            }
            
        }

        #endregion

        #region Groups Command

        private ICommand _groupsCommand = null;

        public ICommand GroupsCommand => _groupsCommand ?? (_groupsCommand = new RelayCommand(async ()=>await GroupsExecute()));

        private async Task GroupsExecute()
        {
            var response = await _groupService.AllGroupsAsync();
            if(response.IsSuccessStatusCode)
            {
                Groups = await response.Content.ReadAsAsync<IEnumerable<CommonGroupDto>>();
                RaisePropertyChanged("Groups");
            }
        }

        #endregion
    }
}
