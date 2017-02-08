using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using CefSharp;
using CefSharp.WinForms;
using AutoUpdaterDotNET;
namespace chromium
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start
            string ip = "http://ilinpage.me";
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            ChromiumWebBrowser chrome = new ChromiumWebBrowser(ip);
            
            chrome.Parent = metroTabControl1.SelectedTab;
            chrome.Dock = DockStyle.Fill;
            chrome.AddressChanged += Chrome_AddressChanged;
            chrome.TitleChanged += Chrome_TitleChanged;

        }

        private void Chrome_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                metroTabControl1.SelectedTab.Text = e.Title;
            }));
        }

        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                label1.Text = e.Address;
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "new Tab";
            metroTabControl1.Controls.Add(tab);
            metroTabControl1.SelectTab(metroTabControl1.TabCount - 1);
            ChromiumWebBrowser bowser = new ChromiumWebBrowser("http://ilinpage.me");
            bowser.Parent = tab;
            bowser.Dock = DockStyle.Fill;
            bowser.AddressChanged += Chrome_AddressChanged;
            bowser.TitleChanged += Chrome_TitleChanged;
        }

    }
}
