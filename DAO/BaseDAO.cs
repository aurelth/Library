using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerator = System.Enum;

namespace DAO
{
    public abstract class BaseDAO<T> : SingleBase<T>
    {
        public string oradb
        {
            get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; }
        }



        protected TVal ObterValor<TVal>(object valor)
        {
            return ObterValor<TVal>(valor, default(TVal));
        }


        protected TVal ObterValor<TVal>(object valor, TVal valorDefault)
        {
            if (typeof(TVal).IsEnum)
            {
                return ObterValorEnumerator<TVal>(valor, valorDefault);
            }
            TVal outer = default(TVal);
            if (valor == DBNull.Value)
            {


                return valorDefault;
            }
            outer = (TVal)Convert.ChangeType(valor, typeof(TVal));


            return outer;
        }

        private TVal ObterValorEnumerator<TVal>(object valor, TVal valorPadrao)
        {
            try
            {
                //if (pValor is System.DBNull)
                if (valor == DBNull.Value)
                {
                    return valorPadrao;
                }
                if (valor is string)
                {
                    return (TVal)Enumerator.ToObject(typeof(TVal), Convert.ToChar(valor));
                }
                return (TVal)Enumerator.ToObject(typeof(TVal), valor);
            }
            catch
            {
                return (TVal)Enumerator.GetValues(typeof(TVal)).GetValue(0);
            }
        }
    }

   public class SingleBase<T>
   {
       [ThreadStatic]
       private static T m_Instancia;

       /// <summary>
       /// Singleton, intância atual da classe
       /// </summary>
       public static T GetInstance()
       {
           if (m_Instancia == null)
           {
               m_Instancia = Activator.CreateInstance<T>();    
           }

           return m_Instancia;
       }
   }



}
