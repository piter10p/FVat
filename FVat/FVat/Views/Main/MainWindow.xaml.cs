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
    public partial class MainWindow : Window
    {
        private AboutWindow AboutWindow = null;
        private VATEntities.VATEntitiesWindow VATEntitiesWindow = null;

        public MainWindow()
        {
            InitializeComponent();
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

            if (VATEntitiesWindow != null)
                VATEntitiesWindow.Close();
        }

        private void NewVATMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var newVatWindow = new NewVAT.NewVATWindow();
            newVatWindow.ShowDialog();
        }

        private void VATEntitiesListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (VATEntitiesWindow == null)
            {
                VATEntitiesWindow = new VATEntities.VATEntitiesWindow();
                VATEntitiesWindow.Closed += (x, y) => { VATEntitiesWindow = null; };
                VATEntitiesWindow.Show();
            }
        }
    }
}
