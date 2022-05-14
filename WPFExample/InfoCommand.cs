using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;


namespace WPFExample
{
    public class InfoCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
            throw new NotImplementedException();
          
        }

        public void Execute(object? parameter)
        {

            MessageBox.Show("Hello world");
            NamesWIndow namesWindow = new NamesWIndow();
            namesWindow.Show();
            //throw new NotImplementedException();
        }
    }
}
