using System;
using System.Collections.ObjectModel;
using ExpensesApp.Models;
using ExpensesApp.Views;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpensesVM
    {
        public ObservableCollection<Expense> Expenses { get; set; }
        public Command ToAddExpenseCommand { get; set; }

        public ExpensesVM()
        {
            Expenses = new ObservableCollection<Expense>();
            ToAddExpenseCommand = new Command(ToAddExpense);
            GetExpenses();
        }

        private void GetExpenses()
        {
            var expenses = Expense.GetExpenses();

            Expenses.Clear();

            foreach (var item in expenses)
                Expenses.Add(item);
        }

        public void ToAddExpense()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }
    }
}
