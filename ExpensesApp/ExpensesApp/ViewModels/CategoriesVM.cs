using System;
using System.Collections.ObjectModel;
using System.Linq;
using ExpensesApp.Models;

namespace ExpensesApp.ViewModels
{
    public class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }

        public CategoriesVM()
        {
            Categories = new ObservableCollection<string>();
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpensesPerCategory();
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        private void GetExpensesPerCategory()
        {
            float totalExpensesAmount = Expense.TotalExpensesAmount();

            foreach (var item in Categories)
            {
                var expenses = Expense.GetExpenses(item);
                float expensesAmountByCategory = expenses.Sum(x=>x.Amount);

                CategoryExpenses ce = new CategoryExpenses
                {
                    Category = item,
                    ExpensesPercentage = expensesAmountByCategory / totalExpensesAmount
                };

                CategoryExpensesCollection.Add(ce);
            }
        }

        public class CategoryExpenses
        {
            public string Category { get; set; }

            public float ExpensesPercentage { get; set; }
        }
    }
}
