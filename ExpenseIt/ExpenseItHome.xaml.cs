using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public string Name { get; set; }
        public  List<Person> ExpenseDataSource { get; set; }
        private DateTime lastChecked;
        public DateTime LastChecked { get { return lastChecked; } set
            {
                lastChecked = value;
                // Извикване на PropertyChanged
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
                }
                //PropertyChanged(this, LastChecked);
            }
        }
        public ObservableCollection<string> PersonsChecked
        { get; set; }

        public ExpenseItHome()
        {
            InitializeComponent();
            MainCaptionText = "View Expense Report :";
            PersonsChecked = new ObservableCollection<string>();
            LastChecked = DateTime.Now;

            ExpenseDataSource = new List<Person>(){
            new Person()
            {
                Name="Mike",
                Department ="Legal",
                Expenses = new List<Expense>()
            {
            new Expense() { ExpenseType="Lunch", ExpenseAmount =50 },
            new Expense() { ExpenseType="Transportation", ExpenseAmount=50 }
            }
            }, 
            new Person()
            {
                Name ="Lisa",
                Department ="Marketing",
                Expenses = new List<Expense>()
            {
            new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
            new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
            }
            },
            new Person()
            {
                Name="John",
                Department ="Engineering",
                Expenses = new List<Expense>()

            {
            new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 },
            new Expense() { ExpenseType="New machine", ExpenseAmount=600 },
            new Expense() { ExpenseType="Software", ExpenseAmount=500 }
            }
            },
            new Person()
            {
                Name="Mary",
                Department ="Finance",
                Expenses = new List<Expense>()
            {
            new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
            }
            },
            new Person()
            {
                Name="Theo",
                Department ="Marketing",
                Expenses = new List<Expense>()
            {
            new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
            }
            },
            new Person()
            {
                Name ="James",
                Department ="Marketing",
                Expenses = new List<Expense>()
            {
            new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
            new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
            }
            },
            new Person()
            {
                Name ="David",
                Department ="SW",
                Expenses = new List<Expense>()
            {
            new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
            new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
            }
            }
            };

            peopleListBox.DataContext = ExpenseDataSource;
        }


        public string MainCaptionText { get; set; }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport expenseReport = new ExpenseReport();
            expenseReport.Show();
        }
        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add(peopleListBox.SelectedItem.ToString());
            //PersonsChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value);
        }

    }
}
