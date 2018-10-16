using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace MemoryGame
{

    public partial class MainMenuWindow : Window
    {

        MainClass grid;

        public MainMenuWindow()
        {
            InitializeComponent();

            grid = new MainClass(this, StartScherm);


        }
       
    }

}

