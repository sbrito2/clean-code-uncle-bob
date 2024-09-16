using System;

public namespace C4Formatting.example
{
    public class Example1
    {
        public class ReporterConfig 
        {
            /**   * The class name of the reporter listener   */  
            private String m_className;

            /**   * The properties of the reporter listener   */  
            private List<Property> m_properties = new ArrayList<Property>();

            public void addProperty(Property property) 
            {   
                m_properties.add(property);  
            }
        }

        public class Example2
        {
            public class ReporterConfig 
            {  
                private String m_className;  
                private List<Property> m_properties = new ArrayList<Property>();
                public void addProperty(Property property) 
                {    
                    m_properties.add(property);  
                }
            }
        }
    }
}