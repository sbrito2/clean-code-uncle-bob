using System;

public class Programa
{
    public void main()
    {
        /*Readers shouldn’t have to mentally translate your names into other names they already know*/
        int ct = 0;
        for(int f = 0; f < 5; f ++)
            for(int v = 0; v < 3; v++)
                for(int b = 0; b < 3; b++)
                    ct++;


        /* if its scope is very small and no other names can conﬂict with it.
        This is because those single-letter names for loop counters are traditional. */
        int count = 0;
        for(int i = 0; i < 5; i ++)
            for(int j = 0; j < 3; j++)
                for(int k = 0; k < 3; k++)
                    count++;
    }
}