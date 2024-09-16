using System;

public namespace C4COMMENTS.example
{
    public class Paper
    {
        public bool HasBookCover { get; set;}
        public bool HasAnalyticalSpeech { get; set;}
    }

    public class Newpaper : Paper
    {
        public Newpaper()
        {
            this.HasBookCover = false;
            this.HasAnalyticalSpeech = false;
        }
    }

    public class Book : Paper
    {
        public Book()
        {
            this.HasBookCover = true;
            this.HasAnalyticalSpeech = false;
        }
    }

    public class Magazine : Paper
    {
        public Magazine()
        {
            this.HasBookCover = false;
            this.HasAnalyticalSpeech = true;
        }
    }

    public class Programa
    {
        public float compareTo (Paper obj, Paper obj2)
        {
            float result = 0;

            if(obj.GetType() == obj2.GetType())
                return 1; // we are greater because we are the right type.
            
            if(obj.HasBookCover == obj2.HasBookCover)
                result += 0.5;
            
            if(obj.HasAnalyticalSpeech == obj2.HasAnalyticalSpeech)
                result += 0.5;

            return result;
        }

        public void main()
        {
            
            Newpaper newpaper = new Newpaper();
            Magazine magazine = new Magazine();

            var response = this.compareTo(newpaper, magazine);

            Console.WriteLine(reponse);
        }
    }
}