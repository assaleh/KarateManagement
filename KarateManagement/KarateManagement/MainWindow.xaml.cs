﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public static bool French { get; set; }
        private ObservableCollection<StudentItem> m_Students = new ObservableCollection<StudentItem>();

        private GridViewColumnHeader _lastHeaderClicked = null;
        private ListSortDirection _lastDirection = ListSortDirection.Ascending;

        public MainWindow()
        {
            InitializeComponent();

            French = true;
            SetLanguageDictionary();

            StudentList.ItemsSource = m_Students;

            //Start a new task so that it runs on the Dispatcher thread instead of the UI thread
            var t = new Task(() =>
            {
                SqlHelper.Connect("Server=localhost;Uid=root;Pwd=;Convert Zero Datetime=True;");
                AddExamples();
            });
            t.Start();
        }

        private void DeleteStudentButton_OnClick(object sender, RoutedEventArgs e)
        {
            StudentItem studentItem = StudentList.SelectedItem as StudentItem;

            if (studentItem != null)
            {
                m_Students.Remove(studentItem);
                SqlHelper.DeleteStudent(studentItem.ID);
            }
        }

        private async void AddExamples()
        {
            ArrayList array = await SqlHelper.GetAllStudents();
            foreach (Student student in array)
            {
                Dispatcher.Invoke(() =>
                {
                    m_Students.Add(new StudentItem(student));
                });
            }
        }

        private void SetLanguageDictionary()
        {
            ResourceDictionary dict = new ResourceDictionary();
            //TODO: make this better

            if (French)
                dict.Source = new Uri("..\\Resources\\StringResources.fr-CA.xaml", UriKind.Relative);
            else
                dict.Source = new Uri("..\\Resources\\StringResources.xaml", UriKind.Relative);

            this.Resources.MergedDictionaries.Add(dict);
        }

        private void StudentList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StudentItem studentItem = StudentList.SelectedItem as StudentItem;

            if (studentItem != null)
            {
                StudentItem studentItemCopy = new StudentItem(studentItem);

                EditStudent editStudent = new EditStudent(studentItemCopy);
                bool? result = editStudent.ShowDialog();

                if (result.HasValue && result.Value)
                {
                    //TODO Call UpdateStudent
                    studentItem.CopyFields(studentItemCopy);
                    SqlHelper.UpdateStudent(studentItem.ToStudent());
                }
            }
        }

        private void NewStudentButton_OnClick(object sender, RoutedEventArgs e)
        {
            StudentItem student = new StudentItem();

            EditStudent editStudent = new EditStudent(student);
            bool? result = editStudent.ShowDialog();

            if (result.HasValue && result.Value)
            {
                m_Students.Add(student);
                SqlHelper.CreateStudent(student.ToStudent());
            }
        }

        private void EditStudentButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Just double click on a student, N00b");
        }

        private void TestButton1_OnClick(object sender, RoutedEventArgs e)
        {
            GetBirthdayStudents();
        }

        private async void GetBirthdayStudents()
        {
            Dispatcher.Invoke(() =>
            {
                m_Students.Clear();
            });
            ArrayList array = await SqlHelper.GetBirthday(1);
            foreach (Student student in array)
            {
                Dispatcher.Invoke(() =>
                {
                    m_Students.Add(new StudentItem(student));
                });
            }
        }

        private async void GetExpiredMembers()
        {
            Dispatcher.Invoke(() =>
            {
                m_Students.Clear();
            });
            ArrayList array = await SqlHelper.GetExpiredStudents();
            foreach (Student student in array)
            {
                Dispatcher.Invoke(() =>
                {
                    m_Students.Add(new StudentItem(student));
                });
            }
        }

        private async void GetBalance()
        {
            Dispatcher.Invoke(() =>
            {
                m_Students.Clear();
            });
            ArrayList array = await SqlHelper.GetBalance();
            foreach (Student student in array)
            {
                Dispatcher.Invoke(() =>
                {
                    m_Students.Add(new StudentItem(student));
                });
            }
        }

        private void TestButton2_OnClick(object sender, RoutedEventArgs e)
        {
            GetExpiredMembers();
        }

        private void TestButton3_OnClick(object sender, RoutedEventArgs e)
        {
            GetBalance();
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(StudentList.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);

            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked =
              e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    string header = headerClicked.Tag as string;

                    Sort(header, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }


                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }
    }
}
