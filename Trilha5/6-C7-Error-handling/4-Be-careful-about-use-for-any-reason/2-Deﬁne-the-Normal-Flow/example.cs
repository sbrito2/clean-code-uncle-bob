public class Program
{
    public void main()
    {     
    }

    public double GetTotal()
    {
        try 
        {  
            MealExpenses expenses = expenseReportDAO.getMeals(employee.getID());  
            return m_total += expenses.getTotal(); 

        } catch(MealExpensesNotFound e) 
        {  
            return m_total += getMealPerDiem(); 
        }
    }

    public class MealExpenses
    {

    }

    public class PerDiemMealExpenses : MealExpenses 
    {  
        public double GetTotal()
        {
            MealExpenses expenses = expenseReportDAO.getMeals(employee.getID()); 
            return m_total += expenses.getTotal();
        }
    } 
    

}



/* separation between your business logic and your error handling: This is called the SPECIAL CASE PATTERN [Fowler]. 
You create a class or conﬁgure an object so that it handles a special case for you. When you do, 
the client code doesn’t have to deal with exceptional behavior. That behavior is encapsulated 
in the special case object */