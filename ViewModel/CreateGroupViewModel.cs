﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Model.Group.Factories;
using TaskManager_Client.Services.Group;
using TaskManager_Client.View;

namespace TaskManager_Client.ViewModel
{
    public class CreateGroupViewModel:ViewModelBase
    {
        private readonly IGroupService _groupService = null;
        private readonly IGroupFactory _groupFactory = null;
        public CreateGroupViewModel(IGroupService groupService,IGroupFactory groupFactory)
        {
            _groupService = groupService;
            _groupFactory = groupFactory;
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

        #region CreateGroup Command

        private ICommand _createGroupCommand = null;

        public ICommand CreateGroupCommand =>
            _createGroupCommand ??
            (_createGroupCommand = new RelayCommand(async ()=>await CreateGroupExecute(), CreateGroupCanExecute));

        private async Task CreateGroupExecute()
        {
            var newGroup = await _groupFactory.CreateAsync(GroupName);
            await _groupService.CreateGroupAsync(newGroup);
        }

        private bool CreateGroupCanExecute()
        {
            return true;
        }

        #endregion

        #region BackCommand

        private ICommand _backCommand = null;

        public ICommand BackCommand => _backCommand ?? (_backCommand = new RelayCommand(BackExecute));

        private void BackExecute()
        {
            var adminPanelView = new AdminPanelView();
            adminPanelView.Show();
            CurrentWindow.Hide();
        }

        #endregion


    }
}