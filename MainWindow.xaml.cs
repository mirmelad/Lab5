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
using System.Collections.ObjectModel;
using System.Security.Policy;
using Microsoft.SqlServer.Server;

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Library library = new Library();
        public static IEnumerable<Library.BookSearchResult> foundBooksResult;
        public MainWindow()
        {
            InitializeComponent();
            library.LoadFromXML();
            foundBooksResult = library.ReturnAll();
            DataGrid1.ItemsSource = foundBooksResult;
            DataGrid1.Items.Refresh();
        }
        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            var formnew = new WindowNew();
            formnew.Owner = this;
            formnew.ShowDialog();
            if (DataContext != null)
            {
                library.Add(new Book(((formnewdata)DataContext).Title, ((formnewdata)DataContext).Author, ((formnewdata)DataContext).Genre, ((formnewdata)DataContext).PublicationDate, ((formnewdata)DataContext).ISBN, ((formnewdata)DataContext).Annotation));
                foundBooksResult = library.ReturnAll();
                DataGrid1.ItemsSource = null;
                DataGrid1.ItemsSource = foundBooksResult;
                DataGrid1.Items.Refresh();
            }
        }
        private void ButtonFilter_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            var formfilter = new WindowFilter();
            formfilter.Owner = this;
            formfilter.ShowDialog();
            if (DataContext != null)
            {
                switch (((formfilterdata)DataContext).Selector)
                {
                    case 0:
                        foundBooksResult = library.ReturnAll();
                        break;
                    case 1:                        
                        Predicate <Book> titlePredicate = book => book.Title.Contains(((formfilterdata)DataContext).SearchString);
                        foundBooksResult = library.Search(titlePredicate);
                        break;
                    case 2:
                        Predicate<Book> authorPredicate = book => book.Author.Contains(((formfilterdata)DataContext).SearchString);
                        foundBooksResult = library.Search(authorPredicate);
                        break;
                    case 3:
                        string[] searchKeyWords = ((formfilterdata)DataContext).SearchString.Split();
                        foundBooksResult = library.SearchKeywords(searchKeyWords);
                        break;

                }
                DataGrid1.ItemsSource = null;
                DataGrid1.ItemsSource = foundBooksResult;
                DataGrid1.Items.Refresh();
            }
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            library.SaveToXML();
            Application.Current.Shutdown();
        }

    }
}
