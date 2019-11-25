using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Enums;
using TaskManager_Client.Helpers;
using TaskManager_Client.Model.User;
using TaskManager_Client.Model.User.Factories;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Group;
using TaskManager_Client.Services.Project;
using TaskManager_Client.Services.User;
using TaskManager_Client.View;

namespace TaskManager_Client.ViewModel
{
    public class CreateUserViewModel:CommonViewModel
    {
        private readonly IUserService _userService=null;
        private readonly IGroupService _groupService = null;
        private readonly IProjectService _projectService = null;
        private readonly IUserFactory _userFactory = null;
        private IEnumerable<string> _selectedProjects;
        public CreateUserViewModel(IUserService userService,
            IGroupService groupService,
            IProjectService projectService,
            IUserFactory userFactory,
            IFrameNavigationService navigationService):base(navigationService)
        {
            _userService = userService;
            _groupService = groupService;
            _projectService = projectService;
            _userFactory = userFactory;
        }

        #region Name Property

        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set { Set(()=>Name,ref _name,value); }
        }

        #endregion

        #region LastName Property

        private string _lastName = string.Empty;

        public string LastName
        {
            get => _lastName;
            set { Set(()=>LastName,ref _lastName,value); }
        }

        #endregion

        #region GroupsCollection Property

        public ObservableCollection<string> GroupsCollection { get; set; }=new ObservableCollection<string>();

        #endregion

        #region ProjectsCollection Property

        public ObservableCollection<string> ProjectsCollection { get; set; }=new ObservableCollection<string>();

        #endregion

        #region UsersTypesCollection Property

        public ObservableCollection<string> UsersTypesCollection { get; set; }=new ObservableCollection<string>();

        #endregion

        #region Email Property

        private string _email = string.Empty;

        public string Email
        {
            get => _email;
            set { Set(()=>Email,ref _email,value); }
        }

        #endregion 

        #region UserType Property

        private EUserType _userType;

        public EUserType UserType
        {
            get => _userType;
            set { Set(()=>UserType,ref _userType,value); }
        }


        #endregion

        #region GroupName Property

        private string _groupName = string.Empty;

        public string GroupName
        {
            get => _groupName;
            set { Set(()=>GroupName,ref _groupName,value); }
        }

        #endregion

        #region CreateUser Command

        private ICommand _createUserCommand = null;

        public ICommand CreateUserCommand => _createUserCommand ?? (_createUserCommand = new RelayCommand(async () => await CreateUserExecute()));

        private async Task CreateUserExecute()
        {
            var newUser = await _userFactory.CreateAsync(Name,LastName,Email,UserType,GroupName,_selectedProjects);
            var response = await _userService.RegisterUserAsync(newUser);
            if (response.IsSuccessStatusCode)
                MessageBox.Show("User was created");
        }

        private bool CreateUserCanExecute()
        {
            return true;
        }


        #endregion

        #region AllGroups Command

        private ICommand _allGroupsCommand = null;

        public ICommand AllGroupsCommand => _allGroupsCommand ?? (_allGroupsCommand = new RelayCommand(async ()=>await AllGroups()));

        private async Task AllGroups()
        {
            var allGroups=await _groupService.AllGroupsAsync();
            GroupsCollection.Clear();
            foreach (var group in allGroups)
            {
                GroupsCollection.Add(group);
            }
            
        }

        #endregion

        #region AllProjects Command

        private ICommand _allProjectsCommand = null;

        public ICommand AllProjectsCommand => _allProjectsCommand ?? (_allProjectsCommand = new RelayCommand(async ()=>await AllProjectsExecute()));

        private async Task AllProjectsExecute()
        {
            var allProjects = await _projectService.AllProjectsAsync();
            foreach (var project in allProjects)
            {
                ProjectsCollection.Add(project);
            }


        }

        #endregion

        #region AllUsersTypes Command

        private ICommand _allUsersTypeCommand = null;

        public ICommand AllUsersTypeCommand => _allUsersTypeCommand ?? (_allUsersTypeCommand = new RelayCommand(async ()=>await AllUsersTypeExecute()));

        private async Task AllUsersTypeExecute()
        {
            var allTypes=await _userService.AllUsersTypesAsync();
            UsersTypesCollection.Clear();
            foreach (var type in allTypes)
            {
                UsersTypesCollection.Add(type);
            }
        }

        #endregion

        #region SelectProject Command

        private ICommand _selectProjectCommand = null;

        public ICommand SelectProjectCommand => _selectProjectCommand ?? (_selectProjectCommand = new RelayCommand(SelectProjectExecute));

        private void SelectProjectExecute()
        {
            var selectProjectsView=new SelectProjectsView();
            
            if (selectProjectsView.ShowDialog() == true)
            {
                _selectedProjects=(selectProjectsView.DataContext as SelectProjectsViewModel)?.SelectedProjects;
            }
        }
        #endregion

        #region BackCommand

        private ICommand _backCommand = null;

        public ICommand BackCommand => _backCommand ?? (_backCommand = new RelayCommand(BackExecute));

        private void BackExecute()
        {
           _navigationService.GoBack();
            
        }

        #endregion

        #region CurrentWindow

        public Window CurrentWindow { get; set; }

        #endregion
    }
}
