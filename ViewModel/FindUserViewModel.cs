﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Dto;
using TaskManager_Client.Services.User;
using TaskManager_Client.View;

namespace TaskManager_Client.ViewModel
{
    public class FindUserViewModel:ViewModelBase
    {
        private readonly IUserService _userService = null;
        public FindUserViewModel(IUserService userService)
        {
            _userService = userService;
        }
        #region Name Property

        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set { Set(()=>Name,ref _name,value); }
        }

        #endregion

        #region IsListBoxVisible Property

        private bool _isListBoxVisible;

        public bool IsListBoxVisible
        {
            get => _isListBoxVisible;
            set { Set(()=>IsListBoxVisible,ref _isListBoxVisible,value); }
        }

        #endregion

        #region LastName Property

        private string _lastName = string.Empty;

        public string LastName
        {
            get => _lastName;
            set { Set(() => LastName, ref _lastName, value); }
        }

        #endregion

        #region UsersCollection Property

        private ObservableCollection<FindUserDto> _userCollection;

        public ObservableCollection<FindUserDto> UsersCollection
        {
            get => _userCollection;
            set { Set(()=>UsersCollection,ref _userCollection,value); }
        }


        #endregion



        #region FindUsers Command

        private ICommand _findUsersCommand = null;

        public ICommand FindUsersCommand => _findUsersCommand ?? (_findUsersCommand = new RelayCommand(async ()=>await FindUsersExecute()));

        private async Task FindUsersExecute()
        {
            var users = await _userService.FindUserAsync(new FindUserDto(Name,LastName));
            var findUserDtos = users as FindUserDto[] ?? users.ToArray();
            if (findUserDtos.Count() != 0)
            {
                IsListBoxVisible = true;
                UsersCollection=new ObservableCollection<FindUserDto>(findUserDtos);
            }
        }

        #endregion
    }
}