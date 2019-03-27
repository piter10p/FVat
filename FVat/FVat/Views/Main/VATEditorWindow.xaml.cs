using FVat.ViewModels;
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
    /// Interaction logic for VATEditorWindow.xaml
    /// </summary>
    public partial class VATEditorWindow : Window, Models.IClosable, Models.IShowable
    {
        public VATEditorWindow(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
