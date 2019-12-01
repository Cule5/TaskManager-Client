using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Conversation;

namespace TaskManager_Client.ViewModel
{
    public class MessageViewModel:CommonViewModel
    {
        private readonly IConversationService _conversationService;
        public MessageViewModel(IFrameNavigationService navigationService,IConversationService conversationService):base(navigationService)
        {
            _conversationService = conversationService;
        }

        #region MessageContent Property

        private string _messageContent = string.Empty;

        public string MessageContent
        {
            get => _messageContent;
            set { Set(() => MessageContent, ref _messageContent, value); }
        }

        #endregion

        #region Load Command

        private ICommand _loadCommand = null;

        public ICommand LoadCommand => _loadCommand ?? (_loadCommand = new RelayCommand(async ()=>await LoadExecute()));

        private async Task LoadExecute()
        {
            var response=await _conversationService.GetMessageAsync((int)_navigationService.Parameter);
            if (response.IsSuccessStatusCode)
                MessageContent = await response.Content.ReadAsAsync<string>();
        }

        #endregion
    }
}
