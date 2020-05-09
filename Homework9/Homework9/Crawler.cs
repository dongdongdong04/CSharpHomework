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
 * 
 *  注：是学习老师的示例程序后照着写的，实在是不太会写
 */

namespace Homework9
{
    class Crawler
    {
        public event Action<Crawler> CrawlerStopped;
        public event Action<Crawler, string, string> PageDownloaded;

        //所有已下载和待下载URL，key是URL，value表示是否下载成功
        private Dictionary<string, bool> urls = new Dictionary<string, bool>();

        // URL解析表达式
        public static string urlParseRegex = @"^(?<site>https?://(?<host>[\w.-]+)(:\d+)?($|/))(\w+/)*(?<file>[^#?]*)";
        public string HostFilter { get; set; } //主机过滤规则
        public string FileFilter { get; set; } //文件过滤规则
        public int MaxPage { get; set; }     //最大下载数量
        public string StartURL { get; set; } //起始网址
        public Encoding HtmlEncoding { get; set; } //网页编码
        private Queue<string> pending = new Queue<string>(); // 待下载队列
        private string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";// URL检测表达式
        
        public Crawler()
        {
            MaxPage = 100;
            HtmlEncoding = Encoding.UTF8;
        }
        
        public void Start()
        {
            urls.Clear();
            pending.Clear();
            pending.Enqueue(StartURL);
            // 开始爬行了......
            while (urls.Count < MaxPage && pending.Count > 0)
            {
                string url = pending.Dequeue(); //当前网址
                try
                {
                    string html = DownLoad(url);
                    urls[url] = true;
                    PageDownloaded(this, url, "success");
                    Parse(html, url); //解析，并加入新的链接
                }
                catch(Exception e)
                {
                    PageDownloaded(this, url, "  Error:" + e.Message);
                }
            }
            CrawlerStopped(this); //爬行结束
        }

        public string DownLoad(string url)
        {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = urls.Count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
        }

        private void Parse(string html, string pageUrl)
        {
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "") continue;
                linkUrl =  FixUrl(linkUrl, pageUrl); //转绝对路径

                // 解析出host和file两个部分，过滤出html文件，进行下一层爬取
                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (file == "") file = "index.html";
                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter))
                {
                    if (!urls.ContainsKey(linkUrl))
                    {
                        pending.Enqueue(linkUrl);
                        urls.Add(linkUrl, false);
                    }
                }
            }
        }

        /*
         * 网络搜索后 路径有以下几种形式
         * 第一种是含 '://'，是绝对路径
         * 第二种是以 './'开头，则去掉./，前面补全即可
         * 第三种是以 字母开头，直接补全即可
         * 第四种是以 '../'开头，则需要回到上一级地址，去掉../补全
         * 第五种是以 '/'开头，表示从根目录开始，去掉/补全
         * 
         * 示例里还有一种是以 '//'开头，直接补上'http:'
         */
        static private string FixUrl(string url, string pageUrl)
        {
            if (url.Contains("://"))
            {
                return url;
            }

            if (url.StartsWith("./"))
            {
                return FixUrl(url.Substring(2), pageUrl);
            }

            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = pageUrl.LastIndexOf('/');
                return FixUrl(url, pageUrl.Substring(0, idx));
            }

            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(pageUrl, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            if (url.StartsWith("//"))
            {
                return "http:" + url;
            }

            int end = pageUrl.LastIndexOf("/");
            return pageUrl.Substring(0, end) + "/" + url;
        }
    }
}
