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
    /// Interaction logic for Themas.xaml
    /// </summary>
    public partial class Themas : Window
    {
        ThemaClass grid;

        public Themas()
        {
            InitializeComponent();
            grid = new ThemaClass(ThemaWindow , 4 ,4 );
        }


    }
}
