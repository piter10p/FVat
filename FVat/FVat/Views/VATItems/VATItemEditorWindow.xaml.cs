﻿using System;
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
    /// Interaction logic for VATItemEditorWindow.xaml
    /// </summary>
    ///
    public partial class VATItemEditorWindow : Window, Models.IShowable, Models.IClosable
    {
        public VATItemEditorWindow(object viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
