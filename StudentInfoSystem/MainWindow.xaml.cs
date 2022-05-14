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
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student student1;
        public List<string> StudStatusChoices { get; set; }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }

        }


        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();
            this.DataContext = this;

        }
       
        private void clearFields()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }
        }
        private Boolean isStudentDataCorrect(Student student)
        {
            return student != null 
                && !String.IsNullOrWhiteSpace(student.firstName) 
                && !String.IsNullOrWhiteSpace(student.secondName) 
                && !String.IsNullOrWhiteSpace(student.lastName)
                && !String.IsNullOrWhiteSpace(student.faculty) 
                && !String.IsNullOrWhiteSpace(student.program) 
                && !String.IsNullOrWhiteSpace(student.degree)
                && !String.IsNullOrWhiteSpace(student.status) 
                && !String.IsNullOrWhiteSpace(student.facultyNumber) 
                && student.course != 0
                && student.flow != 0 
                && student.group != 0;
        }
        private void setStudent(Student student)
        {
            if (isStudentDataCorrect(student))
            {
                enableFields();
                fillStudentInfo(student);
            }
            else
            {
                clearFields();
                disableFields();
            }
        }
        private void fillStudentInfo(Student student)
        {
            this.student1 = student;

            txtFirstName.Text = this.student1.firstName;
            txtSecondName.Text = this.student1.secondName;
            txtLastName.Text = this.student1.lastName;
            txtFaculty.Text = this.student1.faculty;
            txtSpeciality.Text = this.student1.program;
            txtDegree.Text = this.student1.degree;
            txtStatus.SelectedItem = this.student1.status;
            txtFacultyNumber.Text = this.student1.facultyNumber;
            txtCourse.Text = Convert.ToString(this.student1.course);
            txtFlow.Text = Convert.ToString(this.student1.flow);
            txtGroup.Text = Convert.ToString(this.student1.group);
        }
        private void disableFields()
        {
            foreach (Control control in MainGrid.Children)
            {
                if (control.Name == "btnEnableFields" || control.Name == "btnDisableFields")
                {
                    control.IsEnabled = true;
                }
                else
                {
                    control.IsEnabled = false;
                }
            }
        }
        private void enableFields()
        {
            foreach ( Control control in MainGrid.Children) 
            {
                control.IsEnabled = true;
            }
            TestStudentsIfEmpty();
            if (TestStudentsIfEmpty())
                CopyTestStudents();
        }
       
        private void btnDisableFields_Click(object sender, RoutedEventArgs e)
        {
            disableFields();
        }

        private void btnEnableFields_Click(object sender, RoutedEventArgs e)
        {
            enableFields();
        }

        private void btnFillStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentData studentData = new StudentData();
            setStudent(studentData.getStudents().First());
        }

        private void btnNull_Click(object sender, RoutedEventArgs e)
        {
            setStudent(null);
        }

        private Boolean TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();          
            IEnumerable<Student> queryStudents = context.Students;
           
            int countStudents = queryStudents.Count();
            if (queryStudents == null)
            {
                return true;
            }
            else
                return false;
        }
        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            StudentData studentData = new StudentData();
             foreach (Student st in studentData.getStudents())
            {
                context.Students.Add(st);
            }            
            context.SaveChanges();          
           

        }
    }
}
