using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CSV_Mergerv3
{

    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate() { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

     
        private void btnBrowseInput_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtInputDir.Text = dialog.SelectedPath;
            }
        }

        private void btnBrowseOutput_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtOutputDir.Text = dialog.SelectedPath;
            }
        }


        private void btnMerge_Click(object sender, RoutedEventArgs e)
        {
                btnMerge.Content = "Running";
                btnMerge.IsEnabled = false;
                btnMerge.Refresh();
                lblStatus.Text = "Process started";
                lblStatus.Refresh();
         
                string inputdir = txtInputDir.Text;
                string outputdir = txtOutputDir.Text;
                if (inputdir == "" || outputdir == "")
                {
                    btnMerge.Content = "Run";
                    btnMerge.IsEnabled = true;
                    btnMerge.Refresh();
                    lblStatus.Text = "No Input or Output directory to process";
                    lblStatus.Refresh();
                    return;
                }
                if (!checkcsvFiles(inputdir))
                {
                    btnMerge.Content = "Run";
                    btnMerge.IsEnabled = true;
                    btnMerge.Refresh();
                    lblStatus.Text = "No CSV files exist on input directory";
                    lblStatus.Refresh();
                    return;
                }
                lblStatus.Text = "Preparing Files";
                List<string> allheaders = getcsv_header(inputdir);

                merge_headers(allheaders, inputdir, outputdir);
                lblStatus.Text = "Process complete";
                lblStatus.Refresh();
                btnMerge.Content = "Run";
                btnMerge.IsEnabled = true;
                btnMerge.Refresh();

        }

        public static List<string> getcsv_header(string inputdir)
        {

            List<string> allheaders = new List<string>();
            string[] csvFiles = Directory.GetFiles(inputdir, "*.csv");
            foreach (var file in csvFiles)
            {
                string[] lines = File.ReadAllLines(file);
                string header = lines[0];
                allheaders.Add(header);
            }

            return allheaders;
        }

        /// <summary>
        /// Minimize Headers by merging.
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        public void merge_headers(List<string> headers, string inputdir, string outputdir)
        {
          
            List<string> newHeaderList = new List<string>();
            List<string> alreadyMerged = new List<string>();
            int filecount = headers.Count();
            int file1_number = 0;
            int percentage = 100 / filecount;
            int load = 0;
            while (file1_number < filecount)
            {
                int file2_number = 0;
                int comparecounter = 0;
                foreach (var header in headers)
                {
                    if (file2_number != file1_number)
                    {
                        string data1 = headers[file1_number];
                        string data2 = header;
                        bool existOnNew = false;
                        bool merged = false;
                        if (data1 == data2)
                        {
                            comparecounter++;
                            string[] csvFiles = Directory.GetFiles(inputdir, "*.csv");
                            string currentdir = "";
                            foreach (var newcsv in newHeaderList)
                            {
                                string[] lines = File.ReadAllLines(newcsv);
                                string headerstring = lines[0];
                                if (data1 == headerstring)
                                {
                                    currentdir = newcsv;
                                    existOnNew = true;
                                }
                            }
                            foreach (var mergecheck in alreadyMerged)
                            {
                                if (csvFiles[file1_number] == mergecheck)
                                {
                                    merged = true;
                                }
                            }

                            if (merged == false)
                            {
                                alreadyMerged.Add(csvFiles[file1_number]);
                                if (existOnNew == false)
                                {
                                    string filename = System.IO.Path.GetFileName(csvFiles[file1_number]) + "_merged";
                                    string extension = System.IO.Path.GetExtension(csvFiles[file1_number]);
                                    string newcsv = System.IO.Path.Combine(outputdir, filename + extension);
                                    File.Create(newcsv).Close();
                                    lblStatus.Text = "Creating and Merging CSV file " + filename + extension;
                                    statBar.InvalidateVisual();
                                    foreach (string contents in File.ReadAllLines(csvFiles[file1_number]))
                                    {
                                        File.AppendAllText(newcsv, contents + Environment.NewLine);
                                    }
                                    newHeaderList.Add(newcsv);
                                }
                                else
                                {
                                    int lineCount = 0;
                                    lblStatus.Text = "Merging CSV file " + System.IO.Path.GetFileName(currentdir);
                                    statBar.InvalidateVisual();
                                    foreach (string contents in File.ReadAllLines(csvFiles[file1_number]))
                                    {
                                        if (lineCount != 0)
                                        {
                                            File.AppendAllText(currentdir, contents + Environment.NewLine);
                                        }
                                        lineCount++;
                                    }
                                }
                            }
                        }
                    }
                    file2_number++;
                }
                if (comparecounter == 0)
                {
                    string[] csvFiles = Directory.GetFiles(inputdir, "*.csv");
                    string filename = System.IO.Path.GetFileName(csvFiles[file1_number]) + "_merged";
                    string extension = System.IO.Path.GetExtension(csvFiles[file1_number]);
                    string newcsv = System.IO.Path.Combine(outputdir, filename + extension);
                    File.Create(newcsv).Close();
                    lblStatus.Text = "Creating CSV file " + filename + extension;
                    statBar.InvalidateVisual();
                    foreach (string contents in File.ReadAllLines(csvFiles[file1_number]))
                    {
                        File.AppendAllText(newcsv, contents + Environment.NewLine);
                    }
                    newHeaderList.Add(newcsv);
                }
                file1_number++;
                load = load + percentage;
                progBar.Value = load;
                progBar.Refresh();
                lblPercent.Text = load + "%";
                lblPercent.Refresh();
            }

            return;
        }

        /// <summary>
        /// Check for input files.
        /// </summary>
        /// <returns></returns>
        public static bool checkcsvFiles(string inputdir)
        {
            bool exists = false;
            int fileCount = Directory.GetFiles(inputdir, "*.csv").Count();
            if (fileCount != 0)
            {
                exists = true;
            }
            return exists;
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            about about = new about();
            about.Show();
        }
    }
}
