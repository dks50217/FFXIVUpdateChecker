using FFXIVUCBLL.Helper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FFXIVUpdateCheckerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenPath_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;

            if (btn == null) return;

            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                string folderName = dialog.SelectedPath;
                
                if (btn.Name == "new")
                {
                    this.newPath.Text = folderName;
                }
                else
                {
                    this.oldPath.Text = folderName;
                }
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var result = FileHelper.CompareFiles(this.oldPath.Text, this.newPath.Text);

            foreach (var file in result)
            {
                this.listBox.Items.Add(file.FileName);
            }
        }
    }
}
