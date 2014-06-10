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
using System.Windows.Shapes;

namespace KarateManagement
{
    /// <summary>
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        public EditStudent()
        {
            //Setting language references
            ResourceDictionary dict = new ResourceDictionary();

            if (MainWindow.FrenchLanguage)
                dict.Source = new Uri("..\\Resources\\StringResources.fr-CA.xaml", UriKind.Relative);
            else
                dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);

            InitializeComponent();

            //TESTING Binding to studentItem
            Student student = new Student(156, "Joe", "Blow", new DateTime(1988,11,29), "185 Varry", "H4nSTFUNICK", 
            "5146220022", "Octopus@gmail.com", 22, Belt.Black, 11.52m, new DateTime(2011,11,29));

            StudentItem studentItem = new StudentItem(student);
            
            DataGrid.DataContext = studentItem;
            //END TEST
        } 

        public EditStudent(StudentItem studentItem):this()
        {
            //Binding StudentItem to XAML
            DataGrid.DataContext = studentItem;
        }
    }
}
