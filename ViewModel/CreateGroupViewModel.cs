using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Services.Group;

namespace TaskManager_Client.ViewModel
{
    public class CreateGroupViewModel:ViewModelBase
    {
        private readonly IGroupService _groupService = null;
        public CreateGroupViewModel(IGroupService groupService)
        {
            _groupService = groupService;
        }

        #region GroupName Property

        private string _groupName = string.Empty;

        public string GroupName
        {
            get => _groupName;
            set { Set(()=>GroupName,ref _groupName,value); }
        }

        #endregion

        #region CreateGroup Command

        private ICommand _createGroupCommand = null;

        public ICommand CreateGroupCommand =>
            _createGroupCommand ??
            (_createGroupCommand = new RelayCommand(async ()=>await CreateGroupExecute(), CreateGroupCanExecute));

        private async Task CreateGroupExecute()
        {
            await _groupService.CreateGroupAsync(GroupName);
        }

        private bool CreateGroupCanExecute()
        {
            return true;
        }

        #endregion


    }
}
