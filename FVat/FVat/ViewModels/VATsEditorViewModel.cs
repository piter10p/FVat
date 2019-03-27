using FVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.ViewModels
{
    sealed class VATsEditorViewModel: EditorViewModel<VAT>
    {
        public VATsEditorViewModel(Type editorWindowType)
            : base(editorWindowType)
        {
            CreateControlViewsModels();
        }

        private void CreateControlViewsModels()
        {
            IssuerControlViewModel = new ItemSelectControlViewModel(Item);
            ReceiverControlViewModel = new ItemSelectControlViewModel(Item);
        }

        private void OpenIssuerSelectDialog()
        {
            System.Windows.MessageBox.Show("Issuer");
        }

        private void OpenReceiverSelectDialog()
        {
            System.Windows.MessageBox.Show("Receiver");
        }

        public ItemSelectControlViewModel IssuerControlViewModel { get; private set; }
        public ItemSelectControlViewModel ReceiverControlViewModel { get; private set; }
    }
}
