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

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для WindowFilter.xaml
    /// </summary>
    public partial class WindowFilter : Window
    {
        public WindowFilter()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            formfilterdata data = new formfilterdata();
            Owner.DataContext = data;
            data.Selector = Selector.SelectedIndex;
            data.SearchString = SearchString.Text;
            Close();

        }
    }
}
