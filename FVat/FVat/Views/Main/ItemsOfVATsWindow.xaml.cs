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
    /// Interaction logic for ItemsOfVATsWindow.xaml
    /// </summary>
    public partial class ItemsOfVATsWindow : Window, Models.IShowable, Models.IClosable
    {
        public ItemsOfVATsWindow(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
