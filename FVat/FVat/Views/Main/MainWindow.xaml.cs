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

namespace FVat.Views.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Models.IShowable, Models.IClosable
    {
        private AboutWindow AboutWindow = null;

        public MainWindow(object context)
        {
            InitializeComponent();
            DataContext = context;

            var vatContext = DataContext as ViewModels.VATsViewModel;

            vatContext.VATEntitiesViewModel = new ViewModels.VATEntitiesViewModel(typeof(VATEntities.VATEntitiesWindow));
            vatContext.VATEntitiesViewModel.EditorViewModel = new ViewModels.VATEntitiesEditorViewModel(typeof(VATEntities.VATEntityEditorWindow));

            vatContext.VATItemsViewModel = new ViewModels.VATItemsViewModel(typeof(VATItems.VATItemsWindow));
            vatContext.VATItemsViewModel.EditorViewModel = new ViewModels.VATItemsEditorViewModel(typeof(VATItems.VATItemEditorWindow));

            vatContext.EditorViewModel = new ViewModels.VATsEditorViewModel(typeof(VATEditorWindow), vatContext.VATEntitiesViewModel, vatContext.VATItemsViewModel, typeof(ItemsOfVATsWindow), typeof(ItemsOfVATsEditorWindow));
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(AboutWindow == null)
            {
                AboutWindow = new AboutWindow();
                AboutWindow.Closed += (x, y) => { AboutWindow = null; };
                AboutWindow.Show();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (AboutWindow != null)
                AboutWindow.Close();
        }
    }
}
