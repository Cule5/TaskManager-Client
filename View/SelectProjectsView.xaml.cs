using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskManager_Client.ViewModel;

namespace TaskManager_Client.View
{
    /// <summary>
    /// Interaction logic for SelectProjectsView.xaml
    /// </summary>
    public partial class SelectProjectsView : Window
    {
        public SelectProjectsView()
        {
            InitializeComponent();
            ((SelectProjectsViewModel) DataContext).CurrentWindow = this;

        }
    }
}
