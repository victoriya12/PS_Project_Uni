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

namespace WPFExample
{
    /// <summary>
    /// Interaction logic for NamesWIndow.xaml
    /// </summary>
    public partial class NamesWIndow : Window
    {
        public NamesWindow()
        {
            InitializeComponent();
            DataContext = new NamesList();
        }
        


    }
}
