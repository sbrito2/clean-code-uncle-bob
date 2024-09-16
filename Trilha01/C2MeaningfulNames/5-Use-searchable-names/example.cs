using System;

public class Program
{
    public void main()
    {
        //how would u search to find it?  
        for (int j=0; j<34; j++) 
        { 
            s += (t[j]*4)/5; 
        }

        //it would be easier search like that one:
        this.GetTotalTasks();

    }

    public int GetTotalTasks(int num)
    {
        //If a variable or constant might be seen or used in multiple places in a body of code, it is imperative to give it a search-friendly name
        int realDaysPerIdealDay = 4; 
        const int WORK_DAYS_PER_WEEK = 5; 
        int NUMBER_OF_TASKS = 2;

        int sum = 0; 
        for (int j=0; j < NUMBER_OF_TASKS; j++) 
        { 
            int realTaskDays = taskEstimate[j] * realDaysPerIdealDay; 
            int realTaskWeeks = (realdays / WORK_DAYS_PER_WEEK); 
            sum += realTaskWeeks; 
        } 

        return sum;
    }
}