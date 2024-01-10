using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
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
    /// Логика взаимодействия для WindowNew.xaml
    /// </summary>
    public partial class WindowNew : Window
    {
        public WindowNew()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                formnewdata data = new formnewdata();
                data.Title = _Title.Text;
                data.Author = _Author.Text;
                data.Genre = _Genre.Text;
                data.PublicationDate = Convert.ToDateTime(_Date.Text);
                data.Annotation = _Annotation.Text;
                data.ISBN = _ISBN.Text;
                Owner.DataContext = data;
                Close();
            }
            catch
            {
                Close();
            }
        }
    }
}
