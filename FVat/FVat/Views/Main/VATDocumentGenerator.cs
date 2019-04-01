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

            spanElement = LogicalTreeHelper.FindLogicalNode(doc, "PlaceOfIssue") as Span;
            spanElement.Inlines.Add(vat.PlaceOfIssue);

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

            //VAT table
            tableRowGroupElement = LogicalTreeHelper.FindLogicalNode(doc, "VATTableRow") as TableRowGroup;
            GenerateVATTable(tableRowGroupElement, vat);
            FormatTable(tableRowGroupElement);

            //Bottom info
            spanElement = LogicalTreeHelper.FindLogicalNode(doc, "PaymentMethod") as Span;
            spanElement.Inlines.Add(ConvertEnumToString(vat.PaymentMethod, typeof(Models.PaymentMethod)));

            spanElement = LogicalTreeHelper.FindLogicalNode(doc, "PaymentTermDate") as Span;
            spanElement.Inlines.Add(vat.PaymentTermDateText);

            spanElement = LogicalTreeHelper.FindLogicalNode(doc, "DateOfPayment") as Span;
            spanElement.Inlines.Add(vat.DateOfPaymentText);

            spanElement = LogicalTreeHelper.FindLogicalNode(doc, "DeliveryMethod") as Span;
            spanElement.Inlines.Add(ConvertEnumToString(vat.DeliveryMethod, typeof(Models.DeliveryMethod)));

            spanElement = LogicalTreeHelper.FindLogicalNode(doc, "FinalPrice") as Span;
            spanElement.Inlines.Add(vat.Price.GrossText);

            spanElement = LogicalTreeHelper.FindLogicalNode(doc, "FinalPriceInWords") as Span;
            spanElement.Inlines.Add("liczba słownie");

            return doc;
        }

        static private void GenerateEntityData(List list, Models.VATEntity entity)
        {
            if(entity != null)
            {
                list.ListItems.Add(new ListItem(new Paragraph(new Run(entity.Name))));
                list.ListItems.Add(new ListItem(new Paragraph(new Run(entity.FullAddressFormatted))));

                if (entity.NIP != null)
                    list.ListItems.Add(new ListItem(new Paragraph(new Run("NIP: " + entity.NIPTextFormatted))));

                if (entity.PESEL != null)
                    list.ListItems.Add(new ListItem(new Paragraph(new Run("PESEL: " + entity.PESEL))));

                if (entity.EMail != null)
                    list.ListItems.Add(new ListItem(new Paragraph(new Run("email: " + entity.EMail))));

                if (entity.PhoneNumber != null)
                    list.ListItems.Add(new ListItem(new Paragraph(new Run("tel: " + entity.PhoneNumber))));
            }
        }

        static private void GenerateItemsTable(TableRowGroup tableRowGroup, Models.VAT vat)
        {
            var items = DAL.ItemsOfVATsManager.GetItemsofVAT(vat);

            var counter = 1;

            foreach(var i in items)
            {
                var row = new TableRow();

                var unitText = ConvertEnumToString(i.VATItem.Unit, typeof(Models.Unit));
                var vatText = ConvertEnumToString(i.VATItem.VATRate, typeof(Models.VATRate));
                var price = i.Price;

                row.Cells.Add(new TableCell(new Paragraph(new Run(counter.ToString()))));//L.p.
                row.Cells.Add(new TableCell(new Paragraph(new Run(i.Name))));//Name
                row.Cells.Add(new TableCell(new Paragraph(new Run(i.Amount.ToString()))));//Amount
                row.Cells.Add(new TableCell(new Paragraph(new Run(unitText))));//Unit
                row.Cells.Add(new TableCell(new Paragraph(new Run(i.VATItem.PriceText))));//Net unit price
                row.Cells.Add(new TableCell(new Paragraph(new Run(vatText))));//VAT
                row.Cells.Add(new TableCell(new Paragraph(new Run(price.NetText))));//Net price
                row.Cells.Add(new TableCell(new Paragraph(new Run(price.VATText))));//VAT price
                row.Cells.Add(new TableCell(new Paragraph(new Run(price.GrossText))));//Gross price
                tableRowGroup.Rows.Add(row);

                counter++;
            }
        }

        static private void GenerateVATTable(TableRowGroup tableRowGroup, Models.VAT vat)
        {
            var vatRateCalculator = new Models.VATRateCalulator();
            var pricesLits = vatRateCalculator.Calulate(vat);

            var endPrice = new Models.Price();

            //Generates basic table
            foreach(var price in pricesLits)
            {
                var row = new TableRow();

                var vatText = ConvertEnumToString(price.Key, typeof(Models.VATRate));

                row.Cells.Add(new TableCell(new Paragraph(new Run(vatText))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(price.Value.NetText))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(price.Value.VATText))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(price.Value.GrossText))));

                endPrice += price.Value;

                tableRowGroup.Rows.Add(row);
            }

            //Adds end row
            var endRow = new TableRow();
            endRow.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));

            endRow.Cells.Add(new TableCell(new Paragraph(new Run("Razem"))));
            endRow.Cells.Add(new TableCell(new Paragraph(new Run(endPrice.NetText))));
            endRow.Cells.Add(new TableCell(new Paragraph(new Run(endPrice.VATText))));
            endRow.Cells.Add(new TableCell(new Paragraph(new Run(endPrice.GrossText))));

            tableRowGroup.Rows.Add(endRow);
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
