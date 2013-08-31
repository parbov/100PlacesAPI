using Places.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Places.Controllers
{
    public class PlacesController : BaseApiController
    {

        [HttpGet]
        [ActionName("get-place")]
        public string GetPlace(string url)
        {
            var site = "http://100obekta.com/en/%D0%BD%D0%B0%D1%86%D0%B8%D0%BE%D0%BD%D0%B0%D0%BB%D0%BD%D0%B0-%D1%85%D1%83%D0%B4%D0%BE%D0%B6%D0%B5%D1%81%D1%82%D0%B2%D0%B5%D0%BD%D0%B0-%D0%B3%D0%B0%D0%BB%D0%B5%D1%80%D0%B8%D1%8F/";
            var client = new WebClient();
            var htmlText = client.DownloadString(site);

            var htmlDoc = new HtmlAgilityPack.HtmlDocument
            {
                OptionFixNestedTags = true,
                OptionAutoCloseOnEnd = true
            };

            htmlDoc.LoadHtml(htmlText);

            var anchorTags = htmlDoc.DocumentNode.SelectNodes("//div[@class='entry']//div")
                     .Select(a => a.InnerText.Replace("\n", string.Empty))
                     .ToList();
            string text = anchorTags[0];
            StringBuilder result = new StringBuilder();
            foreach (var item in text)
            {
                result.Append(item);
            }
            return result.ToString();
        }
    }
}
