﻿using Crawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * 改进书上例子9-10的爬虫程序。
 * （1）只爬取起始网站上的网页 
 * （2）只有当爬取的是html文本时，才解析并爬取下一级URL。
 * （3）相对地址转成绝对地址进行爬取。
 * （4）尝试使用Winform来配置初始URL，启动爬虫，显示已经爬取的URL和错误的URL信息。
 */

namespace Homework9_winform
{
    public partial class Form1 : Form
    {
        SimpleCrawler crawler = new SimpleCrawler();

        public Form1()
        {
            InitializeComponent();
        }

    }
}