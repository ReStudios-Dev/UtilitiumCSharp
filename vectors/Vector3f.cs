using System;
using System.Collections.Generic;
using System.Text;

namespace org.ReStudios.utitlitium.vectors
{
    public class Vector3f
    {
        /// <summary>
        /// Значения X, Y и Z
        /// </summary>
        public float x, y, z;

        /// <summary>
        /// Конструктор с значениями по умолчанию
        /// </summary>
        public Vector3f()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        /// <summary>
        /// Конструктор с пользовательскими значениями
        /// </summary>
        /// <param name="x">Значение X</param>
        /// <param name="y">Значение Y</param>
        /// <param name="z">Значение Z</param>
        public Vector3f(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Получить значение X
        /// </summary>
        /// <returns>X значение</returns>
        public float GetX()
        {
            return x;
        }

        /// <summary>
        /// Установить пользовательское значение X
        /// </summary>
        /// <param name="x">Новое значение X</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f SetX(float x)
        {
            this.x = x;
            return this;
        }

        /// <summary>
        /// Получить значение Y
        /// </summary>
        /// <returns>Y значение</returns>
        public float GetY()
        {
            return y;
        }

        /// <summary>
        /// Установить пользовательское значение Y
        /// </summary>
        /// <param name="y">Новое значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f SetY(float y)
        {
            this.y = y;
            return this;
        }

        /// <summary>
        /// Получить значение Z
        /// </summary>
        /// <returns>Z значение</returns>
        public float GetZ()
        {
            return z;
        }

        /// <summary>
        /// Установить пользовательское значение Z
        /// </summary>
        /// <param name="z">Новое значение Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f SetZ(float z)
        {
            this.z = z;
            return this;
        }

        /// <summary>
        /// Добавить значения из другого вектора
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Add(Vector3f v)
        {
            this.x += v.GetX();
            this.y += v.GetY();
            this.z += v.GetZ();
            return this;
        }

        /// <summary>
        /// Добавить значения из прямых значений
        /// </summary>
        /// <param name="x">Добавить значение X</param>
        /// <param name="y">Добавить значение Y</param>
        /// <param name="z">Добавить значение Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Add(float x, float y, float z)
        {
            return Add(new Vector3f(x, y, z));
        }

        /// <summary>
        /// Добавить значения из 1 значения.
        /// Добавить значение ко всем значениям вектора.
        /// Например: Представим, что у нас есть вектор со значениями 5, 8 и 10
        /// если мы вызовем этот метод со значением 2,
        /// то на выходе мы получим вектор со значениями 7, 10 и 12
        /// </summary>
        /// <param name="add">Значение для добавления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Add(float add)
        {
            return Add(add, add, add);
        }

        /// <summary>
        /// Вычесть значения из другого вектора
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Sub(Vector3f v)
        {
            this.x -= v.GetX();
            this.y -= v.GetY();
            this.z -= v.GetZ();
            return this;
        }

        /// <summary>
        /// Вычесть значения из прямых значений
        /// </summary>
        /// <param name="x">Вычесть значение X</param>
        /// <param name="y">Вычесть значение Y</param>
        /// <param name="z">Вычесть значение Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Sub(float x, float y, float z)
        {
            return Sub(new Vector3f(x, y, z));
        }

        /// <summary>
        /// Вычесть значения из 1 значения.
        /// Вычесть значение из всех значений вектора.
        /// Например: Представим, что у нас есть вектор со значениями 5, 8 и 10
        /// если мы вызовем этот метод со значением 2,
        /// то на выходе мы получим вектор со значениями 3, 6 и 8
        /// </summary>
        /// <param name="sub">Значение для вычитания</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Sub(float sub)
        {
            return Sub(sub, sub, sub);
        }

        /// <summary>
        /// Умножить значения на другой вектор
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Mul(Vector3f v)
        {
            this.x *= v.GetX();
            this.y *= v.GetY();
            this.z *= v.GetZ();
            return this;
        }

        /// <summary>
        /// Умножить значения на прямые значения
        /// </summary>
        /// <param name="x">Умножить значение X</param>
        /// <param name="y">Умножить значение Y</param>
        /// <param name="z">Умножить значение Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Mul(float x, float y, float z)
        {
            return Mul(new Vector3f(x, y, z));
        }

        /// <summary>
        /// Умножить значения на 1 значение.
        /// Умножить значение на все значения вектора.
        /// Например: Представим, что у нас есть вектор со значениями 5, 8 и 10
        /// если мы вызовем этот метод со значением 2,
        /// то на выходе мы получим вектор со значениями 10, 16 и 20
        /// </summary>
        /// <param name="mul">Значение для умножения</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Mul(float mul)
        {
            return Mul(mul, mul, mul);
        }

        /// <summary>
        /// Разделить значения на другой вектор
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Div(Vector3f v)
        {
            if (v.GetX() != 0) this.x /= v.GetX();
            if (v.GetY() != 0) this.y /= v.GetY();
            if (v.GetZ() != 0) this.z /= v.GetZ();
            return this;
        }

        /// <summary>
        /// Разделить значения на прямые значения
        /// </summary>
        /// <param name="x">Разделить значение X</param>
        /// <param name="y">Разделить значение Y</param>
        /// <param name="z">Разделить значение Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Div(float x, float y, float z)
        {
            return Div(new Vector3f(x, y, z));
        }

        /// <summary>
        /// Разделить значения на 1 значение.
        /// Разделить значение на все значения вектора.
        /// Например: Представим, что у нас есть вектор со значениями 4, 8 и 10
        /// если мы вызовем этот метод со значением 2,
        /// то на выходе мы получим вектор со значениями 2, 4 и 5
        /// </summary>
        /// <param name="div">Значение для деления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Div(float div)
        {
            return Div(div, div, div);
        }

        /// <summary>
        /// Возвести текущий вектор в степень значений другого вектора
        /// (X текущего вектора возводится в степень значения X другого вектора,
        /// и так далее с остальными значениями)
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Pow(Vector3f v)
        {
            this.x = (float)Math.Pow(this.x, v.GetX());
            this.y = (float)Math.Pow(this.y, v.GetY());
            this.z = (float)Math.Pow(this.z, v.GetZ());
            return this;
        }

        /// <summary>
        /// Возвести в степень прямые значения
        /// </summary>
        /// <param name="x">Степень значения X</param>
        /// <param name="y">Степень значения Y</param>
        /// <param name="z">Степень значения Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Pow(float x, float y, float z)
        {
            return Pow(new Vector3f(x, y, z));
        }

        /// <summary>
        /// Возвести значения в степень 1 значения.
        /// Возвести значение в степень ко всем значениям вектора.
        /// Например: Представим, что у нас есть вектор со значениями 4, 8 и 10
        /// если мы вызовем этот метод со значением 2,
        /// то на выходе мы получим вектор со значениями 16, 64 и 100
        /// *Другими словами: x = x^pow*
        /// </summary>
        /// <param name="pow">Значение для деления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Pow(float pow)
        {
            return Pow(pow, pow, pow);
        }

        /// <summary>
        /// Клонировать текущий вектор
        /// Будет создан точно такой же вектор, но как отдельный объект.
        /// Это полезно, если вам нужно сохранить значения, если вы их позже измените (например).
        /// </summary>
        /// <returns>Экземпляр скопированного вектора</returns>
        public Vector3f Clone()
        {
            return new Vector3f(x, y, z);
        }

        /// <summary>
        /// Любой вектор, когда он нормализуется, изменяет только свою величину, а не направление.
        /// Кроме того, каждый вектор, указывающий в том же направлении, нормализуется до одного и того же вектора
        /// (потому что величина и направление уникальным образом определяют вектор).
        /// Другими словами, делит вектор на минимальные значения, которые приводят вектор к "направлению"
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        public Vector3f Normalize()
        {
            float i = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return Clone().Div(i);
        }

        /// <summary>
        /// Преобразовать вектор в строку
        /// Полезно для отладки
        /// </summary>
        /// <returns>Строковое представление вектора</returns>
        public override string ToString()
        {
            return "{" + x + ";" + y + ";" + z + "}";
        }

        /// <summary>
        /// Преобразовать вектор в сериализованную строку
        /// Например, для хранения за пределами приложения
        /// </summary>
        /// <returns>Сериализованный вектор</returns>
        public string SerializeToString()
        {
            return x + "!" + y + "!" + z;
        }

        /// <summary>
        /// Преобразовать вектор в словарь
        /// Например, для хранения за пределами приложения
        /// </summary>
        /// <returns>Сериализованный вектор</returns>
        public Dictionary<string, object> SerializeToMap()
        {
            return new Dictionary<string, object>
            {
                { "x", x },
                { "y", y },
                { "z", z }
            };
        }

        /// <summary>
        /// Преобразовать вектор в список байтов
        /// Например, для хранения за пределами приложения
        /// </summary>
        /// <param name="charset">Пользовательский набор символов</param>
        /// <returns>Сериализованный вектор</returns>
        public byte[] SerializeToBytes(Encoding charset)
        {
            return charset.GetBytes(SerializeToString());
        }

        /// <summary>
        /// Преобразовать вектор в список байтов с использованием кодировки по умолчанию (UTF-8)
        /// Например, для хранения за пределами приложения
        /// </summary>
        /// <returns>Сериализованный вектор</returns>
        public byte[] SerializeToBytes()
        {
            return SerializeToBytes(Encoding.UTF8);
        }

        /// <summary>
        /// Десериализовать список байтов в класс Vector
        /// </summary>
        /// <param name="bytes">Список байтов</param>
        /// <returns>Экземпляр вектора</returns>
        /// <exception cref="DeserializeException">Недопустимое или неверное значение списка байтов</exception>
        public static Vector3f DeserializeFromBytes(byte[] bytes)
        {
            return EserializeFromString(Encoding.UTF8.GetString(bytes));
        }

        /// <summary>
        /// Десериализовать список словарей в класс Vector
        /// </summary>
        /// <param name="map">Список словарей</param>
        /// <returns>Экземпляр вектора</returns>
        /// <exception cref="DeserializeException">Недопустимое или неверное значение словаря или его значений</exception>
        public static Vector3f DeserializeFromMap(Dictionary<string, object> map)
        {
            if (!map.ContainsKey("x") || !map.ContainsKey("y") || !map.ContainsKey("z"))
            {
                throw new DeserializeException("Map не содержит ключей x, y или z");
            }
            if (!(map["x"] is float) || !(map["y"] is float) || !(map["z"] is float))
            {
                throw new DeserializeException("Значения в словаре не являются экземплярами чисел float");
            }
            float x = (float)map["x"];
            float y = (float)map["y"];
            float z = (float)map["z"];
            return new Vector3f(x, y, z);
        }

        /// <summary>
        /// Десериализовать строку в класс Vector
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>Экземпляр вектора</returns>
        /// <exception cref="DeserializeException">Недопустимое или неверное значение строки</exception>
        public static Vector3f EserializeFromString(string str)
        {
            if (str.Length < 5) throw new DeserializeException("Минимальная длина - 5 символов (число, \"!\", число, \"!\", число)");
            int dl = float.MaxValue.ToString().Length;
            if (str.Length > dl + 1 + dl + 1 + dl) throw new DeserializeException("Максимальная длина - " + (dl + 1 + dl + 1 + dl) + " символов (максимальное число, \"!\", максимальное число, \"!\", максимальное число)");
            if (!str.Contains("!"))
            {
                throw new DeserializeException("Неверный формат (число!число!число)");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(str, "^\\d+\\!\\d+$"))
            {
                throw new DeserializeException("Неверный формат (число!число!число)");
            }
            string[] parts = str.Split('!');
            string x = parts[0];
            string y = parts[1];
            string z = parts[2];
            return new Vector3f(StringUtils.ParseFloat(x), StringUtils.ParseFloat(y), StringUtils.ParseFloat(z));
        }

        /// <summary>
        /// Получить вектор3
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 asVector3()
        {
            return new Vector3((int)MathF.Round(x), (int)MathF.Round(y), (int)MathF.Round(z));
        }

        /// <summary>
        /// Получить расстояние между 2 векторами
        /// </summary>
        /// <param name="vector">Другой вектор</param>
        /// <returns>Расстояние</returns>
        public double Distance(Vector3f vector)
        {
            if (vector == null) return -1;
            float v1x = this.x;
            float v1y = this.y;
            float v1z = this.z;
            float v2x = vector.x;
            float v2y = vector.y;
            float v2z = vector.z;
            return Math.Sqrt(Math.Pow(v2x - v1x, 2) + Math.Pow(v2y - v1y, 2) + Math.Pow(v2z - v1z, 2));
        }

        /// <summary>
        /// Получить длину вектора (Расстояние от начала координат)
        /// </summary>
        /// <returns>Длина</returns>
        public double Length()
        {
            return Distance(new Vector3f(0.0f, 0.0f, 0.0f));
        }
    }
}
