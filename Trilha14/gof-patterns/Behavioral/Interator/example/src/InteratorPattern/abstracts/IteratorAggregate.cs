using System.Collections;

namespace InteratorPattern.abstracts
{
    abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}