using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

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

            vatContext.ViewDocument = ViewDocument;
            vatContext.SaveDocument = SaveDocument;

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

        private void ViewDocument()
        {
            var vatContext = DataContext as ViewModels.VATsViewModel;

            if(vatContext.SelectedItem != null)
                DocumentViewer.Document = VATDocumentGenerator.Generate(vatContext.SelectedItem);
        }

        private void SaveDocument()
        {
            var vatContext = DataContext as ViewModels.VATsViewModel;

            if (DocumentViewer.Document != null)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = vatContext.SelectedItem.Name;
                dlg.DefaultExt = ".rtf"; 
                dlg.Filter = "Dokumenty RTF (.rtf)|*.rtf";

                bool? result = dlg.ShowDialog();

                if (result == true)
                {
                    string path = dlg.FileName;
                    var doc = DocumentViewer.Document;
                    var content = new TextRange(doc.ContentStart, doc.ContentEnd);

                    if (content.CanSave(System.Windows.Forms.DataFormats.Rtf))
                    {
                        using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            content.Save(stream, System.Windows.Forms.DataFormats.Rtf);
                        }
                    }
                }
            }
        }
    }
}
