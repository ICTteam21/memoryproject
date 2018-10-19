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

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for LoadScreen.xaml
    /// </summary>
    public partial class LoadScreen : Window
    {
        LoadClass grid;
        private const int kolommen = 9;
        private const int rijen = 20;

        public LoadScreen()
        {

            InitializeComponent();
            grid = new LoadClass(this, LoadingScreen, kolommen, rijen);
        }
    }
}