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

namespace KarateManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var t = new Task(() =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    SqlHelper.Connect("Server=localhost;Uid=root;Pwd=;");
                }));
            });
            t.Start();



        }

        private void CreateStudentButton_OnClick(object sender, RoutedEventArgs e)
        {
            Student s = new Student();
            s.ID = SqlHelper.GetHighestID().Result + 1;

            Task t = SqlHelper.CreateStudent(s);
            t.Wait();

            MessageBox.Show(String.Format("Highest ID is now {0}", s.ID));

        }

       
    }
}
