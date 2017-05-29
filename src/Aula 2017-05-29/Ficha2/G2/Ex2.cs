using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_05_29.Ficha2.G2
{
    class Ex2
    {

        class Utils<T>
        {

            int CountIf(T[] source, Func<T, bool>[] predicates)
            {
                int count = 0;
                foreach (T t in source)
                {
                    bool allTrue = true;
                    foreach (Func<T, bool> predicate in predicates)
                    {
                        if (!predicate(t))
                        {
                            allTrue = false;
                            break;
                        }
                    }
                    count += allTrue ? 1 : 0;
                }
                return count;

            }
        }
    }
}
