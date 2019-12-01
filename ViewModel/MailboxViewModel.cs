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
using TaskManager_Client.Services.Conversation;

namespace TaskManager_Client.ViewModel
{
    public class MailboxViewModel:CommonViewModel
    {
        private readonly IConversationService _conversationService = null;
        public MailboxViewModel(IFrameNavigationService navigationService,IConversationService conversationService):base(navigationService)
        {
            _conversationService = conversationService;
        }

        #region AllMessages Property

        public IEnumerable<UserMessagesDto> AllMessages { get; set; }

        #endregion

        #region Message Property

        public UserMessagesDto Message { get; set; }

        #endregion

        #region Load Command

        private ICommand _loadCommand = null;

        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(async ()=>await LoadExecute()));

        private async Task LoadExecute()
        {
            var response = await _conversationService.UserMessagesAsync();
            if (response.IsSuccessStatusCode)
            {
                AllMessages = await response.Content.ReadAsAsync<IEnumerable<UserMessagesDto>>();
                RaisePropertyChanged("AllMessages");
            }
        }

        #endregion

        #region Open Command

        private ICommand _openMessageCommand = null;

        public ICommand OpenMessageCommand => _openMessageCommand ?? (_openMessageCommand = new RelayCommand(OpenMessageExecute,OpenMessageCanExecute));

        private void OpenMessageExecute()
        {
            _navigationService.NavigateTo("Message",Message.ConversationId);
        }

        private bool OpenMessageCanExecute()
        {
            return Message != null;
        }

        #endregion
    }
}
