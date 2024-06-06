using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace org.ReStudios.utitlitium.vectors
{
    public class Vector3d
    {
        /// <summary>
        /// X, Y & Z значения
        /// </summary>
        public double x, y, z;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Vector3d()
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
        public Vector3d(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Получить значение X
        /// </summary>
        /// <returns>Значение X</returns>
        public double GetX()
        {
            return x;
        }

        /// <summary>
        /// Установить пользовательское значение X
        /// </summary>
        /// <param name="x">Новое значение X</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d SetX(double x)
        {
            this.x = x;
            return this;
        }

        /// <summary>
        /// Получить значение Y
        /// </summary>
        /// <returns>Значение Y</returns>
        public double GetY()
        {
            return y;
        }

        /// <summary>
        /// Установить пользовательское значение Y
        /// </summary>
        /// <param name="y">Новое значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d SetY(double y)
        {
            this.y = y;
            return this;
        }

        /// <summary>
        /// Получить значение Z
        /// </summary>
        /// <returns>Значение Z</returns>
        public double GetZ()
        {
            return z;
        }

        /// <summary>
        /// Установить пользовательское значение Z
        /// </summary>
        /// <param name="z">Новое значение Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d SetZ(double z)
        {
            this.z = z;
            return this;
        }

        /// <summary>
        /// Сложить значения из другого вектора
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Add(Vector3d v)
        {
            this.x += v.GetX();
            this.y += v.GetY();
            this.z += v.GetZ();
            return this;
        }

        /// <summary>
        /// Сложить значения из прямых значений
        /// </summary>
        /// <param name="x">Сложить значение X</param>
        /// <param name="y">Сложить значение Y</param>
        /// <param name="z">Сложить значение Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Add(double x, double y, double z)
        {
            return Add(new Vector3d(x, y, z));
        }

        /// <summary>
        /// Сложить значения из 1 значения.
        /// Добавить значение ко всем значениям вектора.
        /// Например: Представим, что у нас есть вектор со значениями 5, 8 и 10,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 7, 10 и 12
        /// </summary>
        /// <param name="add">Значение для добавления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Add(double add)
        {
            return Add(add, add, add);
        }

        /// <summary>
        /// Вычесть значения из другого вектора
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Sub(Vector3d v)
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
        public Vector3d Sub(double x, double y, double z)
        {
            return Sub(new Vector3d(x, y, z));
        }

        /// <summary>
        /// Вычесть значения из 1 значения.
        /// Вычесть значение из всех значений вектора.
        /// Например: Представим, что у нас есть вектор со значениями 5, 8 и 10,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 3, 6 и 8
        /// </summary>
        /// <param name="sub">Значение для вычитания</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Sub(double sub)
        {
            return Sub(sub, sub, sub);
        }

        /// <summary>
        /// Умножить значения на другой вектор
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Mul(Vector3d v)
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
        public Vector3d Mul(double x, double y, double z)
        {
            return Mul(new Vector3d(x, y, z));
        }

        /// <summary>
        /// Умножить значения на 1 значение.
        /// Умножить значение на все значения вектора.
        /// Например: Представим, что у нас есть вектор со значениями 5, 8 и 10,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 10, 16 и 20
        /// </summary>
        /// <param name="mul">Значение для умножения</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Mul(double mul)
        {
            return Mul(mul, mul, mul);
        }

        /// <summary>
        /// Разделить значения на другой вектор
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Div(Vector3d v)
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
        public Vector3d Div(double x, double y, double z)
        {
            return Div(new Vector3d(x, y, z));
        }

        /// <summary>
        /// Разделить значения на 1 значение.
        /// Разделить значение на все значения вектора.
        /// Например: Представим, что у нас есть вектор со значениями 4, 8 и 10,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 2, 4 и 5
        /// </summary>
        /// <param name="div">Значение для деления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Div(double div)
        {
            return Div(div, div, div);
        }

        /// <summary>
        /// Возвести в степень текущий вектор до значений другого вектора
        /// (X текущего вектора возводится в степень X значения другого вектора,
        /// и так далее со всеми остальными значениями)
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Pow(Vector3d v)
        {
            this.x = Math.Pow(this.x, v.GetX());
            this.y = Math.Pow(this.y, v.GetY());
            this.z = Math.Pow(this.z, v.GetZ());
            return this;
        }

        /// <summary>
        /// Возвести в степень от прямых значений
        /// </summary>
        /// <param name="x">Степень значения X</param>
        /// <param name="y">Степень значения Y</param>
        /// <param name="z">Степень значения Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Pow(double x, double y, double z)
        {
            return Pow(new Vector3d(x, y, z));
        }

        /// <summary>
        /// Возвести значения в степень 1 значения.
        /// Возвести значение во все значения вектора.
        /// Например: Представим, что у нас есть вектор со значениями 4, 8 и 10,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 16, 64 и 100
        /// *Другими словами: x = x^pow*
        /// </summary>
        /// <param name="pow">Значение для деления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Pow(double pow)
        {
            return Pow(pow, pow, pow);
        }

        /// <summary>
        /// Клонировать текущий вектор
        /// Будет создан точно такой же вектор, но как отдельный объект.
        /// Это полезно, если вам нужно сохранить значения, если вы их позже измените (например).
        /// </summary>
        /// <returns>Экземпляр скопированного вектора</returns>
        public Vector3d Clone()
        {
            return new Vector3d(x, y, z);
        }

        /// <summary>
        /// Любой вектор, нормализованный, меняет только свою величину, а не направление.
        /// Кроме того, каждый вектор, указывающий в том же направлении, нормализуется до одного и того же вектора
        /// (потому что величина и направление уникальным образом определяют вектор).
        /// Другими словами, разделяет вектор на минимальные значения, которые приводят вектор к "направлению"
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        public Vector3d Normalize()
        {
            double i = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return Clone().Div(i);
        }

        /// <summary>
        /// Преобразовать вектор в строку
        /// Полезно для отладки
        /// </summary>
        /// <returns>Строковый вектор</returns>
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
            var map = new Dictionary<string, object>();
            map.Add("x", x);
            map.Add("y", y);
            map.Add("z", z);
            return map;
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
        /// <exception cref="DeserializeException">Недопустимое или некорректное значение списка байтов</exception>
        public static Vector3d DeserializeFromBytes(byte[] bytes)
        {
            return DeserializeFromString(Encoding.UTF8.GetString(bytes));
        }

        /// <summary>
        /// Десериализовать список карт в класс Vector
        /// </summary>
        /// <param name="map">Список карт</param>
        /// <returns>Экземпляр вектора</returns>
        /// <exception cref="DeserializeException">Недопустимое или некорректное значение карты или ее значений</exception>
        public static Vector3d DeserializeFromMap(Dictionary<string, object> map)
        {
            if (!map.ContainsKey("x") || !map.ContainsKey("y") || !map.ContainsKey("z"))
            {
                throw new DeserializeException("Карта не содержит ключи x, y или z");
            }
            if (!(map["x"] is double) || !(map["y"] is double) || !(map["z"] is double))
            {
                throw new DeserializeException("Значения карты не являются экземплярами значения double");
            }
            double x = (double)map["x"];
            double y = (double)map["y"];
            double z = (double)map["z"];
            return new Vector3d(x, y, z);
        }

        /// <summary>
        /// Десериализовать строку в класс Vector
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>Экземпляр вектора</returns>
        /// <exception cref="DeserializeException">Недопустимое или некорректное значение строки</exception>
        public static Vector3d DeserializeFromString(string str)
        {
            if (str.Length < 5)
            {
                throw new DeserializeException("Минимальная длина - 5 символов (число, \"!\", число, \"!\", число)");
            }
            int dl = double.MaxValue.ToString().Length;
            if (str.Length > dl + 1 + dl + 1 + dl)
            {
                throw new DeserializeException($"Максимальная длина - {dl + 1 + dl + 1 + dl} символов (максимальное число, \"!\", максимальное число, \"!\", максимальное число)");
            }
            if (!str.Contains("!"))
            {
                throw new DeserializeException("Неправильный формат (num!num!num)");
            }
            if (!Regex.IsMatch(str, "^\\d+\\!\\d+$"))
            {
                throw new DeserializeException("Неправильный формат (num!num!num)");
            }
            string x = str.Split('!')[0];
            string y = str.Split('!')[1];
            string z = str.Split('!')[2];
            return new Vector3d(StringUtils.ParseDouble(x), StringUtils.ParseDouble(y), StringUtils.ParseDouble(z));
        }

        public Vector3 AsVector3()
        {
            return new Vector3((int)Math.Round(x), (int)Math.Round(y), (int)Math.Round(z));
        }

        /// <summary>
        /// Получить расстояние между 2 векторами
        /// </summary>
        /// <param name="vector">Другой вектор</param>
        /// <returns>Расстояние</returns>
        public double Distance(Vector3d vector)
        {
            if (vector == null) return -1;
            double v1x = this.x;
            double v1y = this.y;
            double v1z = this.z;
            double v2x = vector.x;
            double v2y = vector.y;
            double v2z = vector.z;
            return Math.Sqrt(Math.Pow(v2x - v1x, 2) + Math.Pow(v2y - v1y, 2) + Math.Pow(v2z - v1z, 2));
        }

        /// <summary>
        /// Получить длину вектора (Расстояние от начала координат)
        /// </summary>
        /// <returns>Длина</returns>
        public double Length()
        {
            return Distance(new Vector3d(0.0d, 0.0d, 0.0d));
        }
    }
}
