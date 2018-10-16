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
    /// Interaction logic for SelectOptions.xaml
    /// </summary>
    public partial class SelectOptions : Window
    {
        SelectClass grid;
        private const int kolommen = 9;
        private const int rijen = 20;

        public SelectOptions()
        {
            InitializeComponent();
            grid = new SelectClass(this, SelectOpties ,kolommen , rijen);
        }
    }
}
