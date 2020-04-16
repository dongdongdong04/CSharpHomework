using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

/**
 * 改进书上例子9-10的爬虫程序。
 * （1）只爬取起始网站上的网页 
 * （2）只有当爬取的是html文本时，才解析并爬取下一级URL。
 * （3）相对地址转成绝对地址进行爬取。
 * （4）尝试使用Winform来配置初始URL，启动爬虫，显示已经爬取的URL和错误的URL信息。
 */

namespace Crawler
{
    public class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);//加入初始页面
            new Thread(myCrawler.Crawl).Start();
        }

        private void Crawl()
        {
            Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                Parse(html, current);//解析,并加入新的链接
                Console.WriteLine("爬行结束");
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        
        private void Parse(string html, string current)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            Regex regex1 = new Regex(@"(/.+[.]html$|/$)");
            Regex regex2 = new Regex(@"https://.+[.]com/");
            string temp = current;
            
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (!Regex.IsMatch(strRef, @"^https"))  // 处理相对地址
                {
                    if (Regex.IsMatch(strRef, @"^/")) // 开头是反斜杠
                    {
                        //strRef = regex1.Replace(current, strRef); // 这样会出错 不知道为什么……
                        temp = regex1.Replace(temp, "");
                        strRef = temp + strRef;
                    }
                    else  // 开头是字母或数字等
                    {
                        //strRef = Regex.Replace(current, @"[^/]+(?!.*/)", strRef);
                        temp = regex2.Match(temp).ToString();
                        strRef = temp + strRef;
                    }
                        
                }
                // 这里是保证在起始网站上的网页
                if (!Regex.IsMatch(strRef, regex2.Match(current).ToString())) continue; 

                // 这里保证转绝对地址成功
                if (!Regex.IsMatch(strRef, @"html$")) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}