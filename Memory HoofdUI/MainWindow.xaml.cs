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
using System.Collections;

namespace Memory_HoofdUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Hier begint het programma.
        /// Hij Calld de MainClass die het startscherm opbouwt.
        /// </summary>
        public MainWindow()
        {
            MainClass grid;
            InitializeComponent();
            grid = new MainClass(StartScherm);



        }


        /// <summary>
        /// Deze methode moet het scherm schoonvegen.
        /// </summary>
        public void Opnieuw()
        {
            MessageBox.Show("1ste");

            Class1 grid;
            InitializeComponent();
            grid = new Class1(StartScherm);


            MessageBox.Show("2de");
        }
       

    }
}
