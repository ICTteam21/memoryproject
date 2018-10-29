using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace MemoryGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public const int NIET_KLAAR_ROWS = 4;
        public const int NIET_KLAAR_COLS = 4;
        GameGrid grid;

        public GameWindow(string thema, int windowstate, int windowstyle)
        {
            InitializeComponent();
            grid = new GameGrid(this, GameGrid,  NIET_KLAAR_COLS, NIET_KLAAR_ROWS, thema);
            //WindowState = WindowState.Maximized;
        }
        
    }
}
