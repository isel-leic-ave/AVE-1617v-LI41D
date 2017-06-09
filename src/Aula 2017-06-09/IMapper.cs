using System;
using System.Linq;

namespace Aula_2017_06_09
{
    public interface IMapper<TSrc, TDest> : IMapper
    {
        TDest Map(TSrc src);
        TDest[] Map(TSrc[] src);
    }

    public interface IMapper
    {
        Object Map(Object src);
        Object[] Map(Object[] src);
    }


    public class Mapper : IMapper
    {
        public Object Map(Object src)
        {
            return null;
        }

        public Object[] Map(Object[] src)
        {
            return null;
        }
    }


    public class Mapper<TSrc, TDest> : IMapper<TSrc, TDest>
    {
        public TDest Map(TSrc src)
        {
            return (TDest) ((IMapper)this).Map(src);
        }

        public TDest[] Map(TSrc[] src)
        {
            return null;
        }


        Object IMapper.Map(Object src)
        {
            return this.Map((TSrc)src);
        }

        Object[] IMapper.Map(Object[] src)
        {
            TSrc[] array = src.OfType<TSrc>().ToArray();
            return Map(array).OfType<Object>().ToArray();
        }
    }



    class AutoMapper
    {
        Mapper Build()
        {
            return null;
        }

        Mapper<T,D> Build<T, D>()
        {
            return new Mapper<T, D>();
        }
    }
}
