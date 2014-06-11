using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static readonly DependencyProperty BeltsProperty = DependencyProperty.Register(
            "Belts", typeof(ObservableCollection<Belt>), typeof(EditStudent), new PropertyMetadata(default(ObservableCollection<Belt>)));

        public ObservableCollection<Belt> Belts
        {
            get { return (ObservableCollection<Belt>)GetValue(BeltsProperty); }
            set { SetValue(BeltsProperty, value); }
        }


        public EditStudent()
        {
            SetLanguageDictionary();

            Belts = new ObservableCollection<Belt>(new[] { Belt.White, Belt.Orange, Belt.Blue, Belt.Yellow, Belt.Green, Belt.Brown, Belt.Black, Belt.Nidan, Belt.Sandan });

            InitializeComponent();
        }

        public EditStudent(StudentItem studentItem)
            : this()
        {
            //Binding StudentItem to XAML
            DataGrid.DataContext = studentItem;
        }

        private void SetLanguageDictionary()
        {
            ResourceDictionary dict = new ResourceDictionary();
            //TODO make this better

            if (MainWindow.French)
                dict.Source = new Uri("..\\Resources\\StringResources.fr-CA.xaml", UriKind.Relative);
            else
                dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void AddExample()
        {
            //TESTING Binding to studentItem
            Student student = new Student(156, "Joe", "Blow", new DateTime(1988, 11, 29), "185 Varry", "H4nSTFUNICK",
            "5146220022", "Octopus@gmail.com", 22, Belt.Black, 11.52m, new DateTime(2011, 11, 29));

            StudentItem studentItem = new StudentItem(student);

            DataGrid.DataContext = studentItem;
            //END TEST
        }

        private void OK_Button_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Button_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
