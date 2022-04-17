﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyShop.ViewModel.Command
{
    public class RelayCommand : ICommand
    {

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
         public RelayCommand(Action<object> execute)
         : this(execute, null)
      {
         _execute = execute;
      }
 
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;   
            }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : CanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
