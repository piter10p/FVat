using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;
using FVat.Extensions;
using System.Windows.Media;

namespace FVat.Views.Main
{
    static class VATDocumentGenerator
    {
        static public FlowDocument Generate(Models.VAT vat)
        {
            var doc = LoadFlowDocumentTemplate();

            Span spanElement;
            List listElement;
            TableRowGroup tableRowGroupElement;

            //Dates
            spanElement = LogicalTreeHelper.FindLogicalNode(doc, "DateOfIssue") as Span;
            spanElement.Inlines.Add(vat.DateOfIssueText);

            spanElement = LogicalTreeHelper.FindLogicalNode(doc, "DateOfService") as Span;
            spanElement.Inlines.Add(vat.DateOfServiceText);

            //Number
            spanElement = LogicalTreeHelper.FindLogicalNode(doc, "Number") as Span;
            spanElement.Inlines.Add(vat.Name);

            //Entities
            listElement = LogicalTreeHelper.FindLogicalNode(doc, "Issuer") as List;
            GenerateEntityData(listElement, vat.Issuer);

            listElement = LogicalTreeHelper.FindLogicalNode(doc, "Receiver") as List;
            GenerateEntityData(listElement, vat.Receiver);

            //Items table
            tableRowGroupElement = LogicalTreeHelper.FindLogicalNode(doc, "ItemsTableRow") as TableRowGroup;
            GenerateItemsTable(tableRowGroupElement, vat);
            FormatTable(tableRowGroupElement);

            return doc;
        }

        static private void GenerateEntityData(List list, Models.VATEntity entity)
        {
            list.ListItems.Add(new ListItem(new Paragraph(new Run(entity.Name))));
            list.ListItems.Add(new ListItem(new Paragraph(new Run(entity.FullAddressFormatted))));

            if(entity.NIP != null)
                list.ListItems.Add(new ListItem(new Paragraph(new Run("NIP: " + entity.NIPTextFormatted))));

            if (entity.PESEL != null)
                list.ListItems.Add(new ListItem(new Paragraph(new Run("PESEL: " + entity.PESEL))));

            if (entity.EMail != null)
                list.ListItems.Add(new ListItem(new Paragraph(new Run("email: " + entity.EMail))));

            if (entity.PhoneNumber != null)
                list.ListItems.Add(new ListItem(new Paragraph(new Run("tel: " + entity.PhoneNumber))));
        }

        static private void GenerateItemsTable(TableRowGroup tableRowGroup, Models.VAT vat)
        {
            var items = DAL.ItemsOfVATsManager.GetItemsofVAT(vat);

            var counter = 1;

            foreach(var i in items)
            {
                var row = new TableRow();

                var unitText = ConvertEnumToString(i.VATItem.Unit, typeof(Models.Unit));
                var vatText = ConvertEnumToString(i.VATItem.VATRate, typeof(Models.VAT));

                row.Cells.Add(new TableCell(new Paragraph(new Run(counter.ToString()))));//L.p.
                row.Cells.Add(new TableCell(new Paragraph(new Run(i.Name))));//Name
                row.Cells.Add(new TableCell(new Paragraph(new Run(i.Amount.ToString()))));//Amount
                row.Cells.Add(new TableCell(new Paragraph(new Run(unitText))));//Unit
                row.Cells.Add(new TableCell(new Paragraph(new Run(i.VATItem.PriceText))));//Net unit price
                row.Cells.Add(new TableCell(new Paragraph(new Run(vatText))));//VAT
                row.Cells.Add(new TableCell(new Paragraph(new Run(i.NetPriceText))));//Net price
                row.Cells.Add(new TableCell(new Paragraph(new Run(i.VATPriceText))));//VAT price
                row.Cells.Add(new TableCell(new Paragraph(new Run(i.GrossPriceText))));//Gross price
                tableRowGroup.Rows.Add(row);

                counter++;
            }
        }

        static private void FormatTable(TableRowGroup tableRowGroup)
        {
            for(int rowIndex = 0; rowIndex < tableRowGroup.Rows.Count; rowIndex++)
            {
                var row = tableRowGroup.Rows[rowIndex];

                int borderThicknessBottom = 0;

                if (rowIndex == tableRowGroup.Rows.Count - 1)
                    borderThicknessBottom = 1;

                for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                {
                    var cell = row.Cells[cellIndex];

                    int borderThicknessRight = 0;

                    if (cellIndex == row.Cells.Count - 1)
                        borderThicknessRight = 1;

                    cell.BorderBrush = new SolidColorBrush(Colors.Black);
                    cell.BorderThickness = new Thickness(1, 1, borderThicknessRight, borderThicknessBottom);
                    cell.Padding = new Thickness(5);
                }
            }
        }

        static private string ConvertEnumToString(object e, Type enumType)
        {
            var converter = new EnumDescriptionTypeConverter(enumType);
            return converter.ConvertToInvariantString(e);
        }

        static private FlowDocument LoadFlowDocumentTemplate()
        {
            return Application.LoadComponent(new Uri("/Resources/VATTemplate.xaml", UriKind.RelativeOrAbsolute)) as FlowDocument;
        }
    }
}
