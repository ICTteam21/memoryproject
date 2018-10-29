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


namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Window
    {
        HighScoresClass grid;
        private const int kolommen = 9;
        private const int rijen = 9;

        public HighScores()
        {
            InitializeComponent();
            grid = new HighScoresClass(this, HighScoresScreen, kolommen, rijen );            
        }




        



    }





}
