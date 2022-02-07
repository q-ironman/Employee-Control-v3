using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Control_v3
{
    static class ServiceActivator
    {
            
            
        /// <summary>
        /// Eğer bir path verilmezse kullanılır
        /// </summary>
        /// <returns></returns>
        public static T  CreateService<T> () where T : class,new()
        {


            return new T();
        }
        /// <summary>
        /// Verilen path'de işlem yapılır
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T CreateService<T>(string path) where T : class, new()
        {
            T clss = new T();
            Type cls_typ = clss.GetType();
            Type[] types = new Type[1];
            types[0] = typeof(string);
            ConstructorInfo ctor = cls_typ.GetConstructor(types);
            clss = (T)ctor.Invoke(new object[] { path});
            return clss;
        }
    }
}
