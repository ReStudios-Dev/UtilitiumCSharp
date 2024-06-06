using System;
using System.Security.Cryptography;
using System.Text;

namespace org.ReStudios.utitlitium
{
    public class StringUtils
    {
        /// <summary>
        /// Проверяет, является ли строка числом с плавающей запятой.
        /// </summary>
        /// <param name="s">Потенциальная строка с числом с плавающей запятой</param>
        /// <returns>true, если строка является числом с плавающей запятой</returns>
        public static bool IsFloat(string s)
        {
            return float.TryParse(s, out _);
        }

        /// <summary>
        /// Проверяет, является ли строка целым числом.
        /// </summary>
        /// <param name="s">Потенциальная строка с целым числом</param>
        /// <returns>true, если строка является целым числом</returns>
        public static bool IsInteger(string s)
        {
            return int.TryParse(s, out _);
        }

        /// <summary>
        /// Безопасное преобразование строки в целое число.
        /// </summary>
        /// <param name="s">Строка, содержащая целое число</param>
        /// <returns>Преобразованное целое число из строки или 0</returns>
        public static int ParseInteger(string s)
        {
            return int.TryParse(s, out int result) ? result : 0;
        }

        /// <summary>
        /// Безопасное преобразование строки в число с плавающей запятой.
        /// </summary>
        /// <param name="s">Строка, содержащая число с плавающей запятой</param>
        /// <returns>Преобразованное число с плавающей запятой из строки или 0.0d</returns>
        public static double ParseDouble(string s)
        {
            return double.TryParse(s, out double result) ? result : 0.0;
        }

        /// <summary>
        /// Безопасное преобразование строки в число с плавающей запятой.
        /// </summary>
        /// <param name="s">Строка, содержащая число с плавающей запятой</param>
        /// <returns>Преобразованное число с плавающей запятой из строки или 0</returns>
        public static float ParseFloat(string s)
        {
            return float.TryParse(s, out float result) ? result : 0.0F;
        }

        /// <summary>
        /// Безопасное преобразование строки в целое число с указанием значения по умолчанию.
        /// </summary>
        /// <param name="s">Строка, содержащая целое число</param>
        /// <param name="defaultValue">Значение по умолчанию, если строка содержит недопустимое целое число</param>
        /// <returns>Преобразованное целое число из строки или значение по умолчанию</returns>
        public static int ParseInteger(string s, int defaultValue)
        {
            return int.TryParse(s, out int result) ? result : defaultValue;
        }

        /// <summary>
        /// Безопасное преобразование строки в число с плавающей запятой с указанием значения по умолчанию.
        /// </summary>
        /// <param name="s">Строка, содержащая число с плавающей запятой</param>
        /// <param name="defaultValue">Значение по умолчанию, если строка содержит недопустимое число с плавающей запятой</param>
        /// <returns>Преобразованное число с плавающей запятой из строки или значение по умолчанию</returns>
        public static double ParseDouble(string s, double defaultValue)
        {
            return double.TryParse(s, out double result) ? result : defaultValue;
        }

        /// <summary>
        /// Безопасное преобразование строки в число с плавающей запятой с указанием значения по умолчанию.
        /// </summary>
        /// <param name="s">Строка, содержащая число с плавающей запятой</param>
        /// <param name="defaultValue">Значение по умолчанию, если строка содержит недопустимое число с плавающей запятой</param>
        /// <returns>Преобразованное число с плавающей запятой из строки или значение по умолчанию</returns>
        public static float ParseFloat(string s, float defaultValue)
        {
            return float.TryParse(s, out float result) ? result : defaultValue;
        }

        /// <summary>
        /// Переворачивает предоставленную строку.
        /// </summary>
        /// <param name="s">Строка для переворачивания</param>
        /// <returns>Перевернутая строка</returns>
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Устанавливает символ в указанной позиции в верхний регистр.
        /// </summary>
        /// <param name="index">Индекс символа</param>
        /// <param name="s">Строка</param>
        /// <returns>Строка с примененными изменениями</returns>
        public static string CharacterUp(int index, string s)
        {
            if (index >= 0 && index < s.Length)
            {
                StringBuilder sb = new StringBuilder(s);
                sb[index] = char.ToUpper(s[index]);
                return sb.ToString();
            }
            else
            {
                throw new IndexOutOfRangeException($"Индекс {index}, длина {s.Length}, строка: {s}");
            }
        }

        /// <summary>
        /// Устанавливает все символы из массива индексов в верхний регистр.
        /// </summary>
        /// <param name="s">Строка для применения изменений</param>
        /// <param name="ints">Индексы</param>
        /// <returns>Строка с примененными изменениями</returns>
        public static string CharsUp(string s, params int[] ints)
        {
            foreach (int i in ints)
            {
                s = CharacterUp(i, s);
            }
            return s;
        }

        /// <summary>
        /// Хеширует строку с использованием алгоритма MD5.
        /// </summary>
        /// <param name="str">Строка для хеширования</param>
        /// <returns>Хешированная строка</returns>
        public static string Md5(string str)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(str);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Устанавливает первый символ строки в верхний регистр.
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns>Строка, но первый символ в верхнем регистре</returns>
        public static string FirstCharUp(string s)
        {
            return CharacterUp(0, s);
        }
    }
}
