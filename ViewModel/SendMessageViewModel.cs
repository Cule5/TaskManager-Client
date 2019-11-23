using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Dto;
using TaskManager_Client.Model.Conversation.Factories;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Conversation;
using TaskManager_Client.Services.User;

namespace TaskManager_Client.ViewModel
{
    public class SendMessageViewModel:CommonViewModel
    {
        private readonly IUserService _userService = null;
        private readonly IConversationService _conversationService = null;
        private readonly IConversationFactory _conversationFactory = null;
        public SendMessageViewModel(IUserService userService,
            IConversationService conversationService,
            IConversationFactory conversationFactory,
            IFrameNavigationService frameNavigationService):base(frameNavigationService)
        {
            _userService = userService;
            _conversationService = conversationService;
            _conversationFactory = conversationFactory;
        }

        #region Name

        private string _name = string.Empty;

        public string Name
        {
            get => _name;
            set { Set(()=>Name,ref _name,value); }
        }

        #endregion

        #region LastName

        private string _lastName = string.Empty;

        public string LastName
        {
            get => _lastName;
            set { Set(() => LastName, ref _lastName, value); }
        }

        #endregion

        #region Message Property

        private string _messageContent = string.Empty;

        public string MessageContent
        {
            get => _messageContent;
            set { Set(()=>MessageContent,ref _messageContent,value); }
        }

        #endregion

        #region AllUsers Property

        private ObservableCollection<FindUserDto> _usersCollection=new ObservableCollection<FindUserDto>();

        public ObservableCollection<FindUserDto> UsersCollection
        {
            get => _usersCollection;
            set { Set(()=>UsersCollection,ref _usersCollection,value); }
        }

        #endregion

        #region SelectedUser Property

        public FindUserDto SelectedUser { get; set; }

        #endregion

        #region Send Command

        private ICommand _sendCommand = null;

        public ICommand SendCommand => _sendCommand ?? (_sendCommand = new RelayCommand(async ()=>await SendExecute()));

        private async Task SendExecute()
        {
            var conversation = await _conversationFactory.CreateAsync(SelectedUser.UserId, MessageContent);
            await _conversationService.SendAsync(conversation);
        }

        #endregion

        #region FindUser Command

        private ICommand _findUser = null;

        public ICommand FindUserCommand => _findUser ?? (_findUser = new RelayCommand(async ()=>await FindUserExecute()));

        private async Task FindUserExecute()
        {
            var users = await _userService.FindUserAsync(new FindUserDto(Name, LastName));
            UsersCollection=new ObservableCollection<FindUserDto>(users);
            IsListBoxVisible = true;
        }

        #endregion

        #region IsListBoxVisible Property

        private bool _isListBoxVisible;

        public bool IsListBoxVisible
        {
            get => _isListBoxVisible;
            set { Set(()=> IsListBoxVisible,ref _isListBoxVisible,value); }
        }


        #endregion
    }
}
