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
            Grid.SetRowSpan(title, 2);
            grid.Children.Add(title);
    }

        private void AddTable()
        {
            /// https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.grid?view=netframework-4.7.2
            /// Naam
            Label Naam = new Label();
            Naam.Content = "Naam";
            Naam.FontSize = 15;
            Naam.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(Naam,5);
            Grid.SetColumn(Naam, 6);
            Grid.SetColumnSpan(Naam, 2);
            Grid.SetRowSpan(Naam, 2);
            grid.Children.Add(Naam);
            /// Gemaakt door
            Label Gemaaktdoor = new Label();
            Gemaaktdoor.Content = "Gemaakt door";
            Gemaaktdoor.FontSize = 15;
            Gemaaktdoor.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(Gemaaktdoor, 5);
            Grid.SetColumn(Gemaaktdoor, 8);
            Grid.SetColumnSpan(Gemaaktdoor, 2);
            Grid.SetRowSpan(Gemaaktdoor, 2);
            grid.Children.Add(Gemaaktdoor);

            /// Score
            Label score = new Label();
            score.Content = "Score";
            score.FontSize = 15;
            score.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(score, 5);
            Grid.SetColumn(score, 10);
            Grid.SetColumnSpan(score, 2);
            Grid.SetRowSpan(score, 2);
            grid.Children.Add(score);
            /// Datum
            Label Datum = new Label();
            Datum.Content = "Datum";
            Datum.FontSize = 15;
            Datum.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetRow(Datum, 5);
            Grid.SetColumn(Datum, 12);
            Grid.SetColumnSpan(Datum, 2);
            Grid.SetRowSpan(Datum, 2);
            grid.Children.Add(Datum);
        }
    }
}
