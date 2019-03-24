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

namespace FVat.Views.VATEntities
{
    /// <summary>
    /// Interaction logic for VATEntitiesWindow.xaml
    /// </summary>
    public partial class VATEntitiesWindow : Window
    {
        public VATEntitiesWindow()
        {
            InitializeComponent();
        }

        private void AddNewEntityButton_Click(object sender, RoutedEventArgs e)
        {
            var context = (ViewModels.VATEntitiesViewModel)DataContext;
            var win = new VATEntityEditorWindow(new ViewModels.VATEntitiesEditorViewModel(context.AddNewEntity));
            win.ShowDialog();
        }

        private void ModifyEntityButton_Click(object sender, RoutedEventArgs e)
        {
            var context = (ViewModels.VATEntitiesViewModel)DataContext;
            var win = new VATEntityEditorWindow(new ViewModels.VATEntitiesEditorViewModel(context.ModifyEntity, context.SelectedEntity));
            win.ShowDialog();
        }
    }
}
