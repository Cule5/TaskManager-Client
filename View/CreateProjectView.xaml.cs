﻿using System;
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
    /// Interaction logic for CreateProjectView.xaml
    /// </summary>
    public partial class CreateProjectView : Window
    {
        public CreateProjectView()
        {
            InitializeComponent();
            ((CreateProjectViewModel) DataContext).CurrentWindow = this;
        }
    }
}