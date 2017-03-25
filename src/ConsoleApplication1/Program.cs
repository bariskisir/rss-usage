using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string RssFeedUrl = "http://rss.nytimes.com/services/xml/rss/nyt/HomePage.xml";
            List<RssItem> rssItems = new List<RssItem>();
            XDocument xDoc = new XDocument();
            xDoc = XDocument.Load(RssFeedUrl);
            var tempItems = xDoc.Descendants("item");
            foreach (var item in tempItems)
            {
                var rssItem = new RssItem();
                rssItem.Title = item.Element("title").Value;
                rssItem.Link = item.Element("link").Value;
                rssItem.Description = item.Element("description").Value;
                rssItems.Add(rssItem);
            }
            foreach (var item in rssItems)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Link);
                Console.WriteLine(item.Description);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}