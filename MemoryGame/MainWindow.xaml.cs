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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int NIET_KLAAR_ROWS = 4;
        public const int NIET_KLAAR_COLS = 4;
        GameGrid grid;

        public MainWindow()
        {
            InitializeComponent();
            grid = new GameGrid(GameGrid, NIET_KLAAR_COLS, NIET_KLAAR_ROWS);
        }

 
    }
}
