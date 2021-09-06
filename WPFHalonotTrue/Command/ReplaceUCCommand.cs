//using DemoDataProtocol;
using BE;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WPFHalonotTrue.Models;
using WPFHalonotTrue.View;

namespace WPFHalonotTrue.Command
{

    public class ReplaceUCCommand : ICommand
    {
        public event Action<string> ReplaceUserControl;


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }


        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                var good = parameter.ToString();
                if (good.Length > 0)
                    return true;

            }
            return false;

        }

        public void Execute(object parameter)
        {
            if (ReplaceUserControl != null)
            {
                ReplaceUserControl(parameter.ToString());
            }
        }

    }
}
