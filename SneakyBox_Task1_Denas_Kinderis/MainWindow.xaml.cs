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
        /// <summary>  
        /// Adding columns & rows & rotating (works without)
        /// </summary>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CreateColumns();
            CreateRows();
            SkewDataGrid();
        }
        //-------------------------------------------------------------------------
        private void TB_Columns_TextChanged(object sender, TextChangedEventArgs e)
        {
            CreateColumns();
        }
        //-------------------------------------------------------------------------
        private void TB_Rows_TextChanged(object sender, TextChangedEventArgs e)
        {
            CreateRows();
        }
        //-------------------------------------------------------------------------
        private void S_Rotation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SkewDataGrid();
        }
        //-------------------------------------------------------------------------
        /// <summary>  
        /// Puttin actual stuff in
        /// </summary>
        /// <param name="MyNumber"></param>
        class MyData
        {
            public string MyNumber { get; set; }
            public MyData(string n)
            {
                MyNumber = n;
            }
        }
        /// <summary>  
        /// Columns method with UI check for crash
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="column"></param>
        private void CreateColumns()
        {
            int columns = 0;

            if (DG_Main == null)
            {
                return;
            }

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
        /// <summary>  
        /// Rows method with UI check for crash & filling DataGrid with chosen element.
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="column"></param>
        private void CreateRows()
        {
            int rows = 0;

            if (DG_Main == null)
            {
                return;
            }

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
        /// <summary>  
        /// Skewing or rotating DataGrid
        /// </summary>
        /// <param name="angle"></param>
        private void SkewDataGrid()
        {
            if (DG_Main == null)
            {
                return;
            }

            double angle = S_Rotation.Value;

            DG_Main.RenderTransform = new SkewTransform(angle,0, 0, 0);
            //DG_Main.RenderTransform = new RotateTransform(S_Rotation.Value);
        }
    }
}
