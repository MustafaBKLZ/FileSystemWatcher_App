using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSystemWatcher_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string izlenecek_klasor = "C:\\Izlenen";
        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FileSystemWatcher dosya_izleme = new FileSystemWatcher(izlenecek_klasor);
            dosya_izleme.Filter = "";
            FileSystemEventHandler tetikle = new FileSystemEventHandler(tetikleme);
            dosya_izleme.Changed += tetikle;
            dosya_izleme.Deleted += tetikle;
            dosya_izleme.Created += tetikle;
            dosya_izleme.Created += new FileSystemEventHandler(Created);
            dosya_izleme.Changed += new FileSystemEventHandler(Changed);
            dosya_izleme.Renamed += new RenamedEventHandler(Renamed);
            dosya_izleme.Deleted += new FileSystemEventHandler(Deleted);
            dosya_izleme.EnableRaisingEvents = true;
        }
        private void Created(object gelen, FileSystemEventArgs e)
        {
            textBox1.Text += e.Name + "'da yeni bir dosya oluşturuldu " + Environment.NewLine;  
        }
        private void Changed(object gelen, FileSystemEventArgs e)
        {
            textBox1.Text += e.Name + "'da bir dosya değişti " + Environment.NewLine;
        }
        private void Deleted(object gelen, FileSystemEventArgs e)
        {
            textBox1.Text += e.Name + "'da bir dosya silindi " + Environment.NewLine;
        }
        private void Renamed(object gelen, RenamedEventArgs e)
        {
            textBox1.Text += e.Name + "'da bir dosyanın adı değiştirildi" + Environment.NewLine;
        }
        private void tetikleme(object gelen, FileSystemEventArgs e)
        {
            textBox1.Text += "Bu klasörde birşeyler oluyor " + e.Name + Environment.NewLine;
        }
    }
}
