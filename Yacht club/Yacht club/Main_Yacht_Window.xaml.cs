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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Yacht_club.UsingControls;

namespace Yacht_club
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main_Yacht_Window : Window
    {
        public Main_Yacht_Window()
        {
            InitializeComponent();
        }

        private void miFoold_Click(object sender, RoutedEventArgs e)
        {
            stLogin.Visibility = Visibility.Hidden;
            ccWindow_3.Content = new ucOldalSav_1();
        }
    }
}
