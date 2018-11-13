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

namespace SneakyBox_Task1_Denas_Kinderis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Columns
        private void TB_Columns_TextChanged(object sender, TextChangedEventArgs e)
        {
            int columns;

            if (!int.TryParse(TB_Columns.Text, out columns))
            {
                return;
            }
            
            DG_Main.Columns.Clear();

            for (int i = 0; i < columns; i++)
            {
                var column = new DataGridTextColumn();
                DG_Main.Columns.Add(column);
            }
        }
        //Rows
        private void TB_Rows_TextChanged(object sender, TextChangedEventArgs e)
        {
            int rows;
            if (!int.TryParse(TB_Rows.Text, out rows))
            {
                return;
            }
            DG_Main.Items.Clear();
            for (int i = 0; i < rows; i++)
            {
                DG_Main.Items.Add((i));
            }
        }

        private void S_Rotation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void DG_Main_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
