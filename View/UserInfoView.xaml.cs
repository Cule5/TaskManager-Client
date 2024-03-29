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
using TaskManager_Client.Dto;
using TaskManager_Client.ViewModel;

namespace TaskManager_Client.View
{
    /// <summary>
    /// Interaction logic for UserInfoView.xaml
    /// </summary>
    public partial class UserInfoView : Window
    {
        public UserInfoView(CommonUserDto commonUserDto)
        {
            InitializeComponent();
            ((UserInfoViewModel) DataContext).CurrentWindow = this;
            ((UserInfoViewModel) DataContext).User = commonUserDto;
        }
    }
}
