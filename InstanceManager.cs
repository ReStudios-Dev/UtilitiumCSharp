using System;
using System.Collections.Generic;
using System.Linq;

namespace org.ReStudios.utitlitium
{
    /// <summary>
    /// Менеджер экземпляров
    /// </summary>
    public class InstanceManager
    {
        /// <summary>
        /// Список экземпляров
        /// </summary>
        private static readonly List<object> instances = new List<object>();

        /// <summary>
        /// Регистрация нового экземпляра
        /// </summary>
        /// <param name="instance">Экземпляр для регистрации</param>
        public static void Register(object instance)
        {
            // Если существует экземпляр этого типа, удаляем его
            if (HasInstance(instance.GetType()))
            {
                instances.RemoveAll(o => instance.GetType().IsAssignableFrom(o.GetType()));
            }
            instances.Add(instance);
        }

        /// <summary>
        /// Получить экземпляр
        /// </summary>
        /// <typeparam name="T">Родительский тип экземпляра</typeparam>
        /// <returns>Экземпляр класса</returns>
        public static T GetInstance<T>()
        {
            return (T)instances.FirstOrDefault(o => typeof(T).IsAssignableFrom(o.GetType()));
        }

        /// <summary>
        /// Проверка наличия экземпляра указанного класса
        /// </summary>
        /// <param name="type">Указанный класс</param>
        /// <returns>True, если экземпляр существует, иначе False</returns>
        public static bool HasInstance(Type type)
        {
            return instances.Any(o => type.IsAssignableFrom(o.GetType()));
        }
    }
}
