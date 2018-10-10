using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;


namespace WpfApp1
{

    public class LaadSchermGrid
    {
        private Grid grid;

        public LaadSchermGrid(Grid grid, int kolommen, int rijen)
        {
            this.grid = grid;
            InitializeLaadScherm(kolommen, rijen);

            AddTitle();
            AddTable();
        }

        private void InitializeLaadScherm(int kolommen, int rijen)
        {
            for (int i = 0; i < rijen; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < kolommen; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        private void AddTitle()
        {
            Label title = new Label();
            title.Content = "Load your game";
            title.FontSize = 40;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(title, 0);
            Grid.SetColumn(title, 0);
            Grid.SetColumnSpan(title, 20);
            Grid.SetRowSpan(title, 3);
            grid.Children.Add(title);
    }

        private void AddTable()
        {
            Label Naam = new Label();
            Naam.Content = "Naam";
            Naam.FontSize = 20;
            Naam.HorizontalAlignment = HorizontalAlignment.Center;
        }
        private void TableGrid()
        {
            Border TableGrid = new Border();
            TableGrid.Height = 30;
            TableGrid.Width = 30;
        }
    }
}
