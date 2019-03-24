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

namespace FVat.Views.VATEntities
{
    /// <summary>
    /// Interaction logic for VATEntityEditorWindow.xaml
    /// </summary>
    public partial class VATEntityEditorWindow: Window, Models.IClosable, Models.IShowable
    {
        public VATEntityEditorWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
