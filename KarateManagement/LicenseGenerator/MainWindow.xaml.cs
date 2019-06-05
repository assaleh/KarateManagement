using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Xml.Linq;
using KarateManagement;

namespace LicenseGenerator
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

        private void GenerateButton_OnClick(object sender, RoutedEventArgs e)
        {
            GenerateLicense();
        }

        private void GenerateLicense()
        {
            try
            {
                string decrypted = StringCipher.Decrypt(EncryptedTextBox.Text, "35F47BFAF51A515D1562FE4A2F5F8");
                //Decrypt
                XDocument xDocument = XDocument.Parse(decrypted);
                DecryptedTextBox.Text = xDocument.ToString();
                ErrorLogger.Logger.Write(xDocument.ToString());

                xDocument.Root.Element("MAC").Remove();
                xDocument.Root.Element("REGISTERED").Value = true.ToString().ToLower();
                string license = FingerPrint.GetHash(xDocument.ToString());

                LicenseTextBox.Text = license;

            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
