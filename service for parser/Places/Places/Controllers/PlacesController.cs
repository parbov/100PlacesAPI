﻿using Places.Models;
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
            var site = "http://100obekta.com/en/"+url;
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
