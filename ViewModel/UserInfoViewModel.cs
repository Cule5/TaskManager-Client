using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Dto;
using TaskManager_Client.Enums;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Group;
using TaskManager_Client.Services.Project;
using TaskManager_Client.Services.User;

namespace TaskManager_Client.ViewModel
{
    public class UserInfoViewModel : CommonViewModel
    {
        private readonly IUserService _userService = null;
        private readonly IProjectService _projectService = null;
        private readonly IGroupService _groupService = null;
        public UserInfoViewModel(IUserService userService, IProjectService projectService,IGroupService groupService, IFrameNavigationService frameNavigationService) : base(frameNavigationService)
        {
            _userService = userService;
            _projectService = projectService;
            _groupService = groupService;
        }

        #region UserInfo Property

        private ExtendedUserDto _userInfo;

        public ExtendedUserDto UserInfo
        {
            get => _userInfo;
            set { Set(() => UserInfo, ref _userInfo, value); }
        }

        #endregion

        #region CurrentWindow Property

        public Window CurrentWindow { get; set; }

        #endregion

        #region User Poperty

        public CommonUserDto User { get; set; }

        #endregion

        #region AllProjects

        public IEnumerable<CommonProjectDto> AllProjects { get; set; } = new List<CommonProjectDto>();

        #endregion

        #region AllGroups Property

        public IEnumerable<CommonGroupDto> AllGroups { get; set; }=new List<CommonGroupDto>();

        #endregion

        #region AllUserTypes Property

        public IEnumerable<EUserType> AllUserTypes { get; set; }=new List<EUserType>();

        #endregion

        #region UserProjects

        public ObservableCollection<CommonProjectDto> UserProjects { get; set; }
        
        #endregion

        #region SelectedProject Property

        public CommonProjectDto SelectedProject { get; set; }

        #endregion

        #region SelectedGroup Property

        public CommonGroupDto SelectedGroup { get; set; }

        #endregion

        #region SelectedUserType Property

        public EUserType SelectedUserType { get; set; }

        #endregion

        #region Apply Command

        private ICommand _applyCommand = null;

        public ICommand ApplyCommand => _applyCommand ?? (_applyCommand = new RelayCommand(ApplyExecute));
        private async void ApplyExecute()
        {
            var response = await _userService.EditUserAsync(new ExtendedUserDto(UserInfo.UserId,SelectedUserType,SelectedGroup,UserProjects));
            if (response.IsSuccessStatusCode)
                MessageBox.Show("Operation processed");
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

        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(async () => await LoadExecute()));

        private async Task LoadExecute()
        {
            var response = await _userService.UserInfoAsync(User.UserId);
            if (response.IsSuccessStatusCode)
            {
                UserInfo = await response.Content.ReadAsAsync<ExtendedUserDto>();
                UserProjects = new ObservableCollection<CommonProjectDto>(UserInfo.Projects);
                SelectedGroup = UserInfo.Group;
                SelectedUserType = UserInfo.UserType;
                RaisePropertyChanged("UserProjects");
                RaisePropertyChanged("SelectedGroup");
                RaisePropertyChanged("SelectedUserType");
            }
        }

        #endregion

        #region AddProject Command

        private ICommand _addProjectCommand = null;

        public ICommand AddProjectCommand => _addProjectCommand ?? (_addProjectCommand = new RelayCommand(AddProjectExecute));

        private void AddProjectExecute()
        {
            if (UserProjects.Contains(SelectedProject)) return;
            UserProjects.Add(SelectedProject);
        }

        #endregion

        #region EditProjects Command

        private ICommand _editProjectsCommand = null;

        public ICommand EditProjectsCommand => _editProjectsCommand ?? (_editProjectsCommand = new RelayCommand(EditProjectsExecute));
        private void EditProjectsExecute()
        {

        }

        #endregion

        #region EditGroup Command

        private ICommand _editGroupCommand = null;

        public ICommand EditGroupCommand => _editGroupCommand ?? (_editGroupCommand = new RelayCommand(EditGroupExecute));

        private void EditGroupExecute()
        {

        }

        #endregion

        #region AllProjects Command

        private ICommand _allProjectsCommand = null;

        public ICommand AllProjectsCommand
        {
            get
            {
                return _allProjectsCommand ??
                       (_allProjectsCommand = new RelayCommand(async () => await AllProjectsExecute()));
            }
        }

        private async Task AllProjectsExecute()
        {
            var response = await _projectService.AllProjectsAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<CommonProjectDto>>();
                AllProjects = new List<CommonProjectDto>(result);
                RaisePropertyChanged("AllProjects");
            }

        }

        #endregion

        #region Remove Command

        private ICommand _removeCommand = null;
        public ICommand RemoveCommand => _removeCommand ?? (_removeCommand = new RelayCommand(RemoveExecute));
        private void RemoveExecute()
        {
            UserProjects.Remove(SelectedProject);
        }

        #endregion

        #region AllGroups Command

        private ICommand _allGroupsCommand = null;

        public ICommand AllGroupsCommand => _allGroupsCommand ?? (_allGroupsCommand = new RelayCommand(async ()=>await AllGroupsExecute()));
        private async Task AllGroupsExecute()
        {
            var response = await _groupService.AllGroupsAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<CommonGroupDto>>();
                AllGroups=new List<CommonGroupDto>(result);
                RaisePropertyChanged("AllGroups");

            }


        }

        #endregion

        #region AllUserTypes Command

        private ICommand _allUserTypesCommand = null;

        public ICommand AllUserTypesCommand => _allUserTypesCommand ?? (_allUserTypesCommand = new RelayCommand(async ()=>await AllUserTypesExecute()));
        private async Task AllUserTypesExecute()
        {
            var response = await _userService.AllUsersTypesAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<EUserType>>();
                AllUserTypes=new List<EUserType>(result);
                RaisePropertyChanged("AllUserTypes");

            }

        }

        #endregion

        #region Delete Command

        private ICommand _deleteCommand = null;

        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(async ()=>await DeleteExecute()));

        private async Task DeleteExecute()
        {

        }
        #endregion
    }
}
