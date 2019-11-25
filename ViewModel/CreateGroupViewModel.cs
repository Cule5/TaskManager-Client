using System;
using System.Collections;
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
using TaskManager_Client.Model.Group.Factories;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Group;
using TaskManager_Client.Services.User;
using TaskManager_Client.View;

namespace TaskManager_Client.ViewModel
{
    public class CreateGroupViewModel:CommonViewModel
    {
        private readonly IGroupService _groupService = null;
        private readonly IGroupFactory _groupFactory = null;
        private readonly IUserService _userService = null;
        private IEnumerable<CommonUserDto> _selectedUsers = null;
        public CreateGroupViewModel(IGroupService groupService,
            IGroupFactory groupFactory,
            IFrameNavigationService navigationService,
            IUserService userService):base(navigationService)
        {
            _groupService = groupService;
            _groupFactory = groupFactory;
            _userService = userService;
        }

        #region GroupName Property

        private string _groupName = string.Empty;

        public string GroupName
        {
            get => _groupName;
            set { Set(()=>GroupName,ref _groupName,value); }
        }

        #endregion

        #region CurrentWindow Property

        public Window CurrentWindow { get; set; }

        #endregion

        #region AllUsers Property

        private ObservableCollection<CommonUserDto> _allUsers=new ObservableCollection<CommonUserDto>();

        public ObservableCollection<CommonUserDto> AllUsers
        {
            get => _allUsers;
            set { Set(()=>AllUsers,ref _allUsers,value); }
        }

        

        #endregion

        #region CreateGroup Command

        private ICommand _createGroupCommand = null;

        public ICommand CreateGroupCommand =>
            _createGroupCommand ??
            (_createGroupCommand = new RelayCommand(async ()=>await CreateGroupExecute()));

        private async Task CreateGroupExecute()
        {
            var response=await _groupService.CreateGroupAsync(new CreateGroupDto(GroupName,_selectedUsers));
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Group was created");
            }
        }

        #endregion

        #region SelectionChanged Command

        private ICommand _selectionChangedCommand = null;

        public ICommand SelectionChangedCommand => _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand<IList>(SelectionChangedExecute));

        private void SelectionChangedExecute(IList list)
        {
            _selectedUsers = list.Cast<CommonUserDto>();
        }

        #endregion

        #region Load Command

        private ICommand _loadCommand = null;

        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(LoadExecute));

        private async void LoadExecute()
        {
            var response = await _userService.UsersWithoutGroupAsync();
            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadAsAsync<IEnumerable<CommonUserDto>>();
                AllUsers = new ObservableCollection<CommonUserDto>(users);
            }
            
        }

        #endregion

    }
}
