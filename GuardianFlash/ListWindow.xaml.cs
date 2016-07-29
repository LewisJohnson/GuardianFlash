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

namespace GuardianFlash
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public ListWindow()
        {
            InitializeComponent();
            string[] cardEntries = System.IO.Directory.GetFiles("cards");
            listBox.ItemsSource = cardEntries.ToList();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            


        }
    }
}
