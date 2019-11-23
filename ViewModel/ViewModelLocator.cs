/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TaskManager_Client"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using TaskManager_Client.Model.Account.Factories;
using TaskManager_Client.Model.Conversation.Factories;
using TaskManager_Client.Model.Group.Factories;
using TaskManager_Client.Model.Project.Factories;
using TaskManager_Client.Model.User.Factories;
using TaskManager_Client.Navigation;
using TaskManager_Client.Services.Conversation;
using TaskManager_Client.Services.Group;
using TaskManager_Client.Services.Project;
using TaskManager_Client.Services.Task;
using TaskManager_Client.Services.User;
using TaskManager_Client.ViewModel;

namespace TaskManager_Client.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<AdminPanelViewModel>();
            SimpleIoc.Default.Register<CreateGroupViewModel>();
            SimpleIoc.Default.Register<CreateProjectViewModel>();
            SimpleIoc.Default.Register<CreateUserViewModel>();
            SimpleIoc.Default.Register<SelectProjectsViewModel>();
            SimpleIoc.Default.Register<ProjectManagerPanelViewModel>();
            SimpleIoc.Default.Register<FindUserViewModel>();
            SimpleIoc.Default.Register<UserInfoViewModel>();
            SimpleIoc.Default.Register<SendMessageViewModel>();
            SimpleIoc.Default.Register<MessagesViewModel>();
            SimpleIoc.Default.Register<CreateTaskViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<IUserService,UserService>();
            SimpleIoc.Default.Register<IGroupService,GroupService>();
            SimpleIoc.Default.Register<IProjectService,ProjectService>();
            SimpleIoc.Default.Register<ITaskService,TaskService>();
            SimpleIoc.Default.Register<IConversationService, ConversationService>();
            SimpleIoc.Default.Register<IAccountFactory,AccountFactory>();
            SimpleIoc.Default.Register<IUserFactory,UserFactory>();
            SimpleIoc.Default.Register<IGroupFactory,GroupFactory>();
            SimpleIoc.Default.Register<IProjectFactory,ProjectFactory>();
            SimpleIoc.Default.Register<IConversationFactory,ConversationFactory>();
            SetupNavigation();
            //SimpleIoc.Default.Register<NavigationService>();

        }
        public AdminPanelViewModel AdminPanelViewModel
        {
            get { return ServiceLocator.Current.GetInstance<AdminPanelViewModel>(); }
        }
        public CreateGroupViewModel CreateGroupViewModel
        {
            get { return ServiceLocator.Current.GetInstance<CreateGroupViewModel>(); }
        }

        public CreateProjectViewModel CreateProjectViewModel
        {
            get { return ServiceLocator.Current.GetInstance<CreateProjectViewModel>(); }
        }

        public CreateUserViewModel CreateUserViewModel
        {
            get { return ServiceLocator.Current.GetInstance<CreateUserViewModel>(); }
        }

        public LoginViewModel LoginViewModel
        {
            get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); }
        }

        public ProjectManagerPanelViewModel ProjectManagerPanelViewModel
        {
            get { return ServiceLocator.Current.GetInstance<ProjectManagerPanelViewModel>(); }
        }

        public SelectProjectsViewModel SelectProjectsViewModel
        {
            get { return ServiceLocator.Current.GetInstance<SelectProjectsViewModel>(); }
        }

        public FindUserViewModel FindUserViewModel
        {
            get { return ServiceLocator.Current.GetInstance<FindUserViewModel>(); }
        }

        public UserInfoViewModel UserInfoViewModel
        {
            get { return ServiceLocator.Current.GetInstance<UserInfoViewModel>(); }
        }

        public SendMessageViewModel SendMessageViewModel
        {
            get { return ServiceLocator.Current.GetInstance<SendMessageViewModel>(); }
        }

        public MessagesViewModel MessagesViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MessagesViewModel>(); }
        }

        public CreateTaskViewModel CreateTaskViewModel
        {
            get { return ServiceLocator.Current.GetInstance<CreateTaskViewModel>(); }
        }

        public MainViewModel MainViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("AdminPanel", new Uri("../View/AdminPanelView.xaml", UriKind.Relative));
            navigationService.Configure("CreateGroup", new Uri("../View/CreateGroupView.xaml", UriKind.Relative));
            navigationService.Configure("CreateProject", new Uri("../View/CreateProjectView.xaml", UriKind.Relative));
            navigationService.Configure("CreateTask", new Uri("../View/CreateTaskView.xaml", UriKind.Relative));
            navigationService.Configure("CreateUser", new Uri("../View/CreateUserView.xaml", UriKind.Relative));
            navigationService.Configure("FindUser", new Uri("../View/FindUserView.xaml", UriKind.Relative));
            navigationService.Configure("Login",new Uri("../View/LoginView.xaml",UriKind.Relative));
            navigationService.Configure("MailBox", new Uri("../View/MailBoxView.xaml", UriKind.Relative));
            navigationService.Configure("Messages", new Uri("../View/MessagesView.xaml", UriKind.Relative));
            navigationService.Configure("ProjectManagerPanel", new Uri("../View/ProjectManagerPanelView.xaml", UriKind.Relative));
            navigationService.Configure("SelectProjects", new Uri("../View/SelectProjectsView.xaml", UriKind.Relative));
            navigationService.Configure("SendMessage", new Uri("../View/SendMessageView.xaml", UriKind.Relative));
            navigationService.Configure("UserInfo", new Uri("../View/UserInfoView.xaml", UriKind.Relative));
            //SimpleIoc.Default.Register<IFrameNavigationService>();
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }
    }
}