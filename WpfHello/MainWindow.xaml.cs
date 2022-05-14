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

namespace WpfHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);

            ListBoxItem david = new ListBoxItem();
            james.Content = "David";
            peopleListBox.Items.Add(david);

            peopleListBox.SelectedItem = james;
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            //foreach (var item in GroupBox.Children)
            //{
            //    if (item is TextBox)
            //    {
            //        string name = ((TextBox)item).Text;
            //        if (name.Length >= 2)
            //        {
            //            sb  .Append(name)
            //                .Append(Environment.NewLine)
            //                .Append("Това е твоята първа програма на Visual Studio 2012!")
            //                .Append(Environment.NewLine);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Въведете име с повече от два символа!");
            //        }
            //    }
            //}
            //MessageBox.Show(sb.ToString());
       

    }

        private void btnGreet_Click(object sender, RoutedEventArgs e)
        {
            //string greetingMsg;
            //greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            //MessageBox.Show("Hi " + greetingMsg);
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();




        }
    }
}
