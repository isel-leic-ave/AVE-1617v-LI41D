using System;
using System.Collections;
using System.Collections.Generic;

namespace Aula_2017_06_05.Lazy
{
    public static class EnumerableQueriesLazy
    {
        public static void ForEach<T>(this IEnumerable<T> elements, Action<T> action)
        {
            foreach (T curr in elements)
            {
                action(curr);
            }
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> elements, Predicate<T> pred)
        {
            return new MyEnumerable<T>(() => new WhereEnumerator<T>(elements.GetEnumerator(), pred));
        }

        public static IEnumerable<U> Select<T, U>(this IEnumerable<T> elements, Func<T, U> mapper)
        {
            return new MyEnumerable<U>(() => new SelectEnumerator<U, T>(elements.GetEnumerator(), mapper));
        }

       

        public static IEnumerable<T> Take<T>(this IEnumerable<T> elements, int count)
        {
            return new MyEnumerable<T>(() => new TakeEnumerator<T>(elements.GetEnumerator(), count));
        }


    }

    public class WhereEnumerator<T>: MyEnumeratorBase<T>
    {
        private readonly IEnumerator<T> _prev;
        private readonly Predicate<T> _predicate;

        public WhereEnumerator(IEnumerator<T> prev, Predicate<T> predicate)
        {
            _prev = prev;
            _predicate = predicate;
        }

        public override bool MoveNext()
        {
            while (_prev.MoveNext()) {
                Console.WriteLine("where: procesing element {0}", _prev.Current);
                if(_predicate(_prev.Current)) { 
                    Current = _prev.Current;
                    return true;
                }
            }
            return false;
        }
    }


    public class MyEnumerable<T> : IEnumerable<T>
    {
        private readonly Func<IEnumerator<T>> _enumerator;

        public MyEnumerable(Func<IEnumerator<T>> enumeratorSuplier)
        {
            _enumerator = enumeratorSuplier;
            ;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Object>)this).GetEnumerator();
        }

        
    }
    public class SelectEnumerator<W, X> : MyEnumeratorBase<W>
    {
        private readonly IEnumerator<X> _prev;
        private readonly Func<X, W> _mapper;

        public SelectEnumerator(IEnumerator<X> prev, Func<X, W> mapper)
        {
            _prev = prev;
            _mapper = mapper;
        }

        public override bool MoveNext()
        {
            bool hasNext = _prev.MoveNext();
            if (hasNext)
            {
                Current = _mapper(_prev.Current);
                Console.WriteLine("select: processing element {0}", Current);

            }
            return hasNext;
        }
    }

    public class TakeEnumerator<T> : MyEnumeratorBase<T>
    {
        private readonly IEnumerator<T> _prev;
        private int _count;

        public TakeEnumerator(IEnumerator<T> prev, int count)
        {
            _prev = prev;
            _count = count;
        }

        
        public override bool MoveNext()
        {
            if (_count == 0 || !_prev.MoveNext())
            {
                return false;
            }
            --_count;
            Current = _prev.Current;
            return true;
        }
    
    }

    public abstract class MyEnumeratorBase<T> : IEnumerator<T>
    {
        public void Dispose()
        {
            
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public T Current { get; protected set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public abstract bool MoveNext();
    }
}