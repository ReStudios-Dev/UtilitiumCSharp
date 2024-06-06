using System;
using System.Diagnostics;
using System.Reflection;

namespace org.ReStudios.utitlitium
{
    public class Utilitium
    {
        /// <summary>
        /// Приводит объект к указанному типу.
        /// </summary>
        /// <typeparam name="T">Параметр типа</typeparam>
        /// <param name="clazz">Тип, к которому необходимо привести объект</param>
        /// <param name="obj">Объект, который необходимо привести</param>
        /// <returns>Приведенный объект или null</returns>
        public static T CastOrNull<T>(Type clazz, object obj)
        {
            return clazz.IsAssignableFrom(obj.GetType()) ? (T)obj : default(T);
        }

        /// <summary>
        /// Возвращает вызывающий метод.
        /// </summary>
        /// <param name="depth">Глубина поиска</param>
        /// <returns>Вызывающий метод</returns>
        public static MethodBase GetCaller(int depth)
        {
            var st = new StackTrace();
            var actualDepth = Math.Min(depth + 1, st.FrameCount);
            return st.GetFrame(actualDepth - 1)?.GetMethod();
        }

        /// <summary>
        /// Выполняет безопасную проверку на равенство.
        /// </summary>
        /// <param name="a">Объект A</param>
        /// <param name="b">Объект B</param>
        /// <returns>True, если объекты равны, иначе false</returns>
        public static bool SafeEquals(object a, object b)
        {
            if (a == null && b == null)
            {
                return true;
            }
            else
            {
                return a != null && a.Equals(b);
            }
        }
    }
}
