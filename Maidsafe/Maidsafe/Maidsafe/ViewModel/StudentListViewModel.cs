using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Maidsafe
{
    public class StudentListViewModel
    {
        private INavigation navigation;

        public StudentListViewModel() { }
        
        public StudentListViewModel(INavigation nav)
        {
            this.navigation = nav;
            GenerateStudents();
            CreateEditCommand = new Command<object>(CreateOrEditStudent);
            UpdateCommand = new Command(UpdateStudent);
        }

        public Student SelectedStudent { get; set; }

        public bool IsNewStudent { get; set; }

        public ObservableCollection<Student> Students { get; set; }

        public Command<object> CreateEditCommand { get; set; }

        public Command UpdateCommand { get; set; }

        private void GenerateStudents()
        {
            Students = new ObservableCollection<Student>
            {
                new Student() { Name = "Student1", Subject = new Subject() { Subject1 = 80, Subject2 = 70, Subject3 = 65 } },
                new Student() { Name = "Student2", Subject = new Subject() { Subject1 = 50, Subject2 = 65, Subject3 = 59 } },
                new Student() { Name = "Student3", Subject = new Subject() { Subject1 = 75, Subject2 = 84, Subject3 = 73 } },
                new Student() { Name = "Student4", Subject = new Subject() { Subject1 = 92, Subject2 = 88, Subject3 = 85 } },
                new Student() { Name = "Student5", Subject = new Subject() { Subject1 = 86, Subject2 = 80, Subject3 = 95 } }
            };
        }

        private void CreateOrEditStudent(object obj)
        {
            var args = obj as ItemTappedEventArgs;
            var page = new CreateEditStudent();
            if (obj == null)
            {
                IsNewStudent = true;
                SelectedStudent = new Student();
                page.Title = "Add Student";
            }
            else
            {
                IsNewStudent = false;
                SelectedStudent = args.Item as Student;
                page.Title = "Edit Student Details";
            }
            page.BindingContext = this;
            this.navigation.PushAsync(page);
        }

        private void UpdateStudent()
        {
            if(IsNewStudent)
            {
                if (string.IsNullOrEmpty(SelectedStudent.Name))
                {
                    Application.Current.MainPage.DisplayAlert("Error", "Enter the Student name", "OK");
                    return;
                }
                Students.Add(SelectedStudent);
            }
            this.navigation.PopAsync(true);
        }
    }
}
