using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Windows.Forms;

using Webhooks.Models;

namespace Webhooks.Controllers
{
    public class HomeController : Controller
    {

        #region Simple

        /// <summary>
        /// http://myurl.com/home/simpleexample
        /// </summary>
        [HttpPost]
        public ActionResult SimpleExample()
        {
            using (var reader = new StreamReader(Request.InputStream))
            {
                var text = reader.ReadToEnd();

                //display the response body as a message box.
                MessageBox.Show(text);

                return Content(string.Empty);
            }
        }

        #endregion

        #region Complex

        /// <summary>
        /// http://myurl.com/home/complexexample
        /// </summary>
        [HttpPost]
        public ActionResult ComplexExample(
            Event[] events)
        {
            foreach (var item in events)
            {
                if (item.ObjectType == "Product")
                {
                    //the event is for a product.

                    if (item.NewValues?.Count == 0 && item.OldValues?.Count > 0)
                    {
                        //product was deleted.
                        var productNumber = (string)item.OldValues["ObjectIdentifier"];

                        MessageBox.Show(
                            GetEventData(
                                item.PropertiesChanged,
                                item.OldValues),
                            $"Product deleted with product number {productNumber}");

                    }
                    else if (item.NewValues?.Count > 0 && item.OldValues?.Count == 0)
                    {
                        //product was created.
                        var productNumber = (string)item.NewValues["ObjectIdentifier"];
                        
                        MessageBox.Show(
                            GetEventData(
                                item.PropertiesChanged, 
                                item.NewValues),
                            $"Product created with product number {productNumber}");

                    } else if (item.NewValues?.Count > 0 && item.OldValues?.Count > 0)
                    {
                        //product was modified.
                        var oldProductNumber = (string)item.OldValues["ObjectIdentifier"];
                        var newProductNumber = (string)item.NewValues["ObjectIdentifier"];

                        MessageBox.Show(
                            GetEventChangeData(item),
                            $"Product modified with product numbers {oldProductNumber} -> {newProductNumber}");
                    }
                    else
                    {
                        //this should not happen, so throw an error.
                        throw new InvalidOperationException("Could not determine from the event what type of operation was performed on the object.");
                    }
                }
            }

            return Content(string.Empty);
        }

        private static string GetEventData(
            IEnumerable<string> propertiesChanged,
            IDictionary<string, object> values)
        {
            var changeBuilder = new StringBuilder();
            
            foreach (var propertyChanged in propertiesChanged)
            {
                var value = values[propertyChanged];

                changeBuilder.AppendLine(
                    $"{propertyChanged}: \"{value}\"");

                changeBuilder.AppendLine();
            }

            return changeBuilder.ToString();
        }

        private static string GetEventChangeData(Event item)
        {
            var changeBuilder = new StringBuilder();

            foreach (var propertyChanged in item.PropertiesChanged)
            {
                var oldValue = item.OldValues[propertyChanged];
                var newValue = item.NewValues[propertyChanged];

                changeBuilder.AppendLine(
                    $"{propertyChanged}: \"{oldValue}\" -> \"{newValue}\"");

                changeBuilder.AppendLine();
            }

            return changeBuilder.ToString();
        }

        #endregion

    }
}