using System;
using System.Collections.Generic;
using System.Linq;

namespace org.ReStudios.utitlitium
{
    public class ArrayUtils
    {
        /// <summary>
        /// Простой способ создания даже самых сложных карт.
        /// Например, если вы вводите данные: "int", 4, "str", "good game", "Custom class", new CustomClass()
        /// Мы получим следующую структуру карты: {"int": 4, "str": "good game", "Custom class": CustomClass@0000}
        /// </summary>
        /// <param name="values">Аргументы в форме: ключ, значение, ключ, значение. Где значение может быть любым объектом, а ключ может быть строкой.</param>
        /// <returns>Карта</returns>
        public static Dictionary<string, object> CreateMap(params object[] values)
        {
            var returnValue = new Dictionary<string, object>();
            if (values.Length > 0 && values.Length % 2 == 0)
            {
                for (int i = 0; i < values.Length; i += 2)
                {
                    returnValue.Add((string)values[i], values[i + 1]);
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Простой способ создания списка из перечисления объектов
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="values">Объекты...</param>
        /// <returns>Список ArrayList</returns>
        public static List<T> ToArrayList<T>(params T[] values)
        {
            return new List<T>(values);
        }

        /// <summary>
        /// Удалить элементы из списка
        /// </summary>
        /// <typeparam name="T">Тип списка</typeparam>
        /// <param name="list">Список</param>
        /// <param name="way">Что удалять</param>
        /// <returns>Очищенный список</returns>
        public static List<T> RemoveSame<T>(List<T> list, ComparingMode way)
        {
            list.RemoveAll(t =>
            {
                int count = 0;
                foreach (var t1 in list)
                {
                    if (way == ComparingMode.Equality)
                    {
                        if (t1.Equals(t)) count++;
                    }
                    if (way == ComparingMode.Class)
                    {
                        if (t1.GetType().IsAssignableFrom(t.GetType())) count++;
                    }
                    if (way == ComparingMode.HashCode)
                    {
                        if (t1.GetHashCode() == t.GetHashCode()) count++;
                    }
                }
                return count > 1;
            });
            return list;
        }

        /// <summary>
        /// Получить случайный элемент из списка
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="list">Список</param>
        /// <returns>Случайный элемент из списка. null, если список пуст</returns>
        public static T GetRandom<T>(T[] list)
        {
            return GetRandom(list.ToList());
        }

        /// <summary>
        /// Получить случайный элемент из списка
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="list">Список</param>
        /// <returns>Случайный элемент из списка. null, если список пуст</returns>
        public static T GetRandom<T>(List<T> list)
        {
            if (list.Count == 0) return default;
            var random = new Random();
            return list[random.Next(list.Count)];
        }

        /// <summary>
        /// Перевернуть список
        /// </summary>
        /// <typeparam name="T">Тип списка</typeparam>
        /// <param name="arr">Список</param>
        public static void Reverse<T>(T[] arr)
        {
            int start = 0;

            for (int end = arr.Length - 1; start < end; --end)
            {
                T temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                ++start;
            }
        }

        /// <summary>
        /// Получить сумму списка float
        /// </summary>
        /// <param name="floatCollection">Список float</param>
        /// <returns>Сумма</returns>
        public static float GetSum(IEnumerable<float> floatCollection)
        {
            float outValue = 0;
            foreach (var floatValue in floatCollection)
            {
                outValue += floatValue;
            }
            return outValue;
        }

        /// <summary>
        /// Получить последний элемент из списка
        /// </summary>
        /// <typeparam name="T">Тип списка</typeparam>
        /// <param name="s">Список</param>
        /// <returns>Последний элемент из списка</returns>
        public static T GetLastItem<T>(T[] s)
        {
            if (s.Length == 0) return default;
            return s[s.Length - 1];
        }

        /// <summary>
        /// Получить последний элемент из списка
        /// </summary>
        /// <typeparam name="T">Тип списка</typeparam>
        /// <param name="s">Список</param>
        /// <returns>Последний элемент из списка</returns>
        public static T GetLastItem<T>(List<T> s)
        {
            if (s.Count == 0) return default;
            return s[s.Count - 1];
        }

        /// <summary>
        /// Добавляет значение в список, ограничивая размер списка.
        /// </summary>
        /// <typeparam name="T">Тип элементов в списке</typeparam>
        /// <param name="list">Список, в который будет добавлено значение</param>
        /// <param name="limit">Максимальный предел размера списка</param>
        /// <param name="value">Добавляемое значение в список</param>
        public static void AddLimited<T>(List<T> list, int limit, T value)
        {
            if (limit < 1)
            {
                return;
            }
            list.Add(value);
            while (list.Count > limit)
            {
                list.RemoveAt(0);
            }
        }

        public enum ComparingMode
        {
            Equality, Class, HashCode
        }
    }
}
