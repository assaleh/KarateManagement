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

            //Start a new task so that it runs on the Dispatcher thread instead of the UI thread
            //TODO thread trying to run on the UI thread
            var t = new Task(() =>
            {
                
                SqlHelper.Connect("Server=localhost;Uid=root;Pwd=;");
                
            });
            t.Start();

            //TODO deal with the case of WAMP not being up and running



        }

        private void DeleteStudentButton_OnClick(object sender, RoutedEventArgs e)
        {
            
            SqlHelper.DeleteStudent(SqlHelper.GetHighestID().Result);
        }

        private void NewStudent_OnClick(object sender, RoutedEventArgs e)
        {
            EditStudent editStudent = new EditStudent();
            bool? result = editStudent.ShowDialog();
            
            Student s = new Student();
            s.ID = SqlHelper.GetHighestID().Result + 1;

            Task t = SqlHelper.CreateStudent(s);
            t.Wait();

            MessageBox.Show(String.Format("Highest ID is now {0}", s.ID));
        }
    }
}
