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

namespace FVat.Views.VATItems
{
    /// <summary>
    /// Interaction logic for VATItemsWindow.xaml
    /// </summary>
    public partial class VATItemsWindow : Window, Models.IShowable
    {
        public VATItemsWindow()
        {
            InitializeComponent();

            var context = DataContext as ViewModels.VATItemsViewModel;
            context.EditorViewModel = new ViewModels.VATItemsEditorViewModel(typeof(VATItemEditorWindow));
        }
    }
}
