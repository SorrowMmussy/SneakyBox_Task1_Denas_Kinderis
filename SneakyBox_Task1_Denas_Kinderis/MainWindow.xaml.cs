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
        //-------------------------------------------------------------------------
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DG_Main.Items.Clear();
            for (int i = 0; i < int.Parse(TB_Rows.Text); i++)
            {
                DG_Main.Items.Add(new MyData("SB"));
            }
            DG_Main.Columns.Clear();
            for (int i = 0; i < int.Parse(TB_Columns.Text); i++)
            {
                var column = new DataGridTextColumn();
                column.Binding = new Binding("MyNumber");
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                DG_Main.Columns.Add(column);
            }
        }
        //-------------------------------------------------------------------------
        //Columns
        private void TB_Columns_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DG_Main == null)
            {
                return;
            }
            int columns = 0;
            if (!int.TryParse(TB_Columns.Text, out columns))
            {
                return;
            }
            DG_Main.Columns.Clear();
            for (int i = 0; i < columns; i++)
            {
                var column = new DataGridTextColumn();
                column.Binding = new Binding("MyNumber");
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                DG_Main.Columns.Add(column);
            }
        }
        //Rows
        private void TB_Rows_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DG_Main == null)
            {
                return;
            }
            int rows = 0;
            if (!int.TryParse(TB_Rows.Text, out rows))
            {
                return;
            }
            DG_Main.Items.Clear();
            for (int i = 0; i < rows; i++)
            {
                DG_Main.Items.Add(new MyData("SB"));
            }
        }
        //Rotate
        private void S_Rotation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DG_Main == null)
            {
                return;
            }
            double angle = S_Rotation.Value;
            //RotateTransform rtt = new RotateTransform(angle);
            SkewTransform skewTransform1 = new SkewTransform(angle, 0, -0.5, 0.5);
            DG_Main.RenderTransform = skewTransform1;
        }
        //-------------------------------------------------------------------------
        class MyData
        {
            public string MyNumber { get; set; }
            public MyData(string n)
            {
                MyNumber = n;
            }
        }
    }
}
