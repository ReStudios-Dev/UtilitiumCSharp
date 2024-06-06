using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace org.ReStudios.utitlitium.vectors
{
    /// <summary>
    /// Класс, представляющий трехмерный вектор
    /// </summary>
    public class Vector3
    {
        /// <summary>
        /// Значения X, Y и Z
        /// </summary>
        public int x, y, z;

        /// <summary>
        /// Конструктор с значениями по умолчанию
        /// </summary>
        public Vector3()
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
        public Vector3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Получить значение X
        /// </summary>
        /// <returns>Значение X</returns>
        public int GetX()
        {
            return x;
        }

        /// <summary>
        /// Установить пользовательское значение X
        /// </summary>
        /// <param name="x">Новое значение X</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 SetX(int x)
        {
            this.x = x;
            return this;
        }

        /// <summary>
        /// Получить значение Y
        /// </summary>
        /// <returns>Значение Y</returns>
        public int GetY()
        {
            return y;
        }

        /// <summary>
        /// Установить пользовательское значение Y
        /// </summary>
        /// <param name="y">Новое значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 SetY(int y)
        {
            this.y = y;
            return this;
        }

        /// <summary>
        /// Получить значение Z
        /// </summary>
        /// <returns>Значение Z</returns>
        public int GetZ()
        {
            return z;
        }

        /// <summary>
        /// Установить пользовательское значение Z
        /// </summary>
        /// <param name="z">Новое значение Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 SetZ(int z)
        {
            this.z = z;
            return this;
        }

        /// <summary>
        /// Сложить значения с другим вектором
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 Add(Vector3 v)
        {
            this.x += v.GetX();
            this.y += v.GetY();
            this.z += v.GetZ();
            return this;
        }

        /// <summary>
        /// Сложить значения с прямыми значениями
        /// </summary>
        /// <param name="x">Добавить значение X</param>
        /// <param name="y">Добавить значение Y</param>
        /// <param name="z">Добавить значение Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 Add(int x, int y, int z)
        {
            return Add(new Vector3(x, y, z));
        }

        /// <summary>
        /// Сложить значения с 1 значением.
        /// Добавить значение ко всем значениям вектора.
        /// Например: Представим, что у нас есть вектор со значениями 5, 8 и 10,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 7, 10 и 12
        /// </summary>
        /// <param name="add">Значение для добавления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 Add(int add)
        {
            return Add(add, add, add);
        }

        /// <summary>
        /// Вычесть значения из другого вектора
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 Sub(Vector3 v)
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
        public Vector3 Sub(int x, int y, int z)
        {
            return Sub(new Vector3(x, y, z));
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
        public Vector3 Sub(int sub)
        {
            return Sub(sub, sub, sub);
        }

        /// <summary>
        /// Умножить значения на другой вектор
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 Mul(Vector3 v)
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
        public Vector3 Mul(int x, int y, int z)
        {
            return Mul(new Vector3(x, y, z));
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
        public Vector3 Mul(int mul)
        {
            return Mul(mul, mul, mul);
        }

        /// <summary>
        /// Разделить значения на другой вектор
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 Div(Vector3 v)
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
        public Vector3 Div(int x, int y, int z)
        {
            return Div(new Vector3(x, y, z));
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
        public Vector3 Div(int div)
        {
            return Div(div, div, div);
        }

        /// <summary>
        /// Возвести в степень текущий вектор до значений другого вектора
        /// (X текущего вектора возводится в степень X значения другого вектора,
        /// и так далее с остальными значениями)
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 Pow(Vector3 v)
        {
            this.x = (int)Math.Pow(this.x, v.GetX());
            this.y = (int)Math.Pow(this.y, v.GetY());
            this.z = (int)Math.Pow(this.z, v.GetZ());
            return this;
        }

        /// <summary>
        /// Возвести в степень от прямых значений
        /// </summary>
        /// <param name="x">Степень X</param>
        /// <param name="y">Степень Y</param>
        /// <param name="z">Степень Z</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 Pow(int x, int y, int z)
        {
            return Pow(new Vector3(x, y, z));
        }

        /// <summary>
        /// Возвести в степень значения 1.
        /// Возвести в степень значение для всех значений вектора.
        /// Например: Представим, что у нас есть вектор со значениями 4, 8 и 10,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 16, 64 и 100
        /// *Другими словами: x = x^pow*
        /// </summary>
        /// <param name="pow">Значение для возведения в степень</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 Pow(int pow)
        {
            return Pow(pow, pow, pow);
        }

        /// <summary>
        /// Клонировать текущий вектор
        /// Создаст точно такой же вектор, но как отдельный объект.
        /// Это полезно, если вам нужно сохранить значения, если вы их позже измените (например).
        /// </summary>
        /// <returns>Экземпляр скопированного вектора</returns>
        public Vector3 Clone()
        {
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Любой вектор, нормализованный, изменяет только его величину, а не направление.
        /// Кроме того, каждый вектор, указывающий в том же направлении, нормализуется к одному и тому же вектору
        /// (потому что величина и направление уникальным образом определяют вектор).
        /// Другими словами, делит вектор на минимальные значения, которые приводят вектор к "направлению"
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        public Vector3 Normalize()
        {
            int i = (int)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            return Clone().Div(i);
        }

        /// <summary>
        /// Преобразовать вектор в строку
        /// Полезно для отладки
        /// </summary>
        /// <returns>Преобразованный в строку вектор</returns>
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
        /// Преобразовать вектор в массив байтов
        /// Например, для хранения за пределами приложения
        /// </summary>
        /// <param name="charset">Пользовательская кодировка</param>
        /// <returns>Сериализованный вектор</returns>
        public byte[] SerializeToBytes(Encoding charset)
        {
            return charset.GetBytes(SerializeToString());
        }

        /// <summary>
        /// Преобразовать вектор в массив байтов с кодировкой по умолчанию (UTF-8)
        /// Например, для хранения за пределами приложения
        /// </summary>
        /// <returns>Сериализованный вектор</returns>
        public byte[] SerializeToBytes()
        {
            return SerializeToBytes(Encoding.UTF8);
        }

        /// <summary>
        /// Десериализовать массив байтов в класс Vector
        /// </summary>
        /// <param name="bytes">Массив байтов</param>
        /// <returns>Экземпляр вектора</returns>
        /// <exception cref="DeserializeException">Недопустимое или неправильное значение массива байтов</exception>
        public static Vector3 DeserializeFromBytes(byte[] bytes)
        {
            return DeserializeFromString(Encoding.UTF8.GetString(bytes));
        }

        /// <summary>
        /// Десериализовать список карт в класс Vector
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        /// <exception cref="DeserializeException">Недопустимое или неправильное значение карты или ее значений</exception>
        public static Vector3 DeserializeFromMap(Dictionary<string, object> map)
        {
            if (!map.ContainsKey("x") || !map.ContainsKey("y") || !map.ContainsKey("z"))
            {
                throw new DeserializeException("Карта не содержит ключей x, y или z");
            }
            if (!(map["x"] is int) || !(map["y"] is int) || !(map["z"] is int))
            {
                throw new DeserializeException("Значения карты не являются экземплярами int");
            }
            int x = (int)map["x"];
            int y = (int)map["y"];
            int z = (int)map["z"];
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Десериализовать строку в класс Vector
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        /// <exception cref="DeserializeException">Недопустимое или неправильное строковое значение</exception>
        public static Vector3 DeserializeFromString(string str)
        {
            if (str.Length < 5)
            {
                throw new DeserializeException("Минимальная длина - 5 символов (num, \"!\", num, \"!\", num)");
            }
            int dl = $"{int.MaxValue}".Length;
            if (str.Length > dl + 1 + dl + 1 + dl)
            {
                throw new DeserializeException($"Максимальная длина - {dl + 1 + dl + 1 + dl} символов (максимальное число, \"!\", максимальное число, \"!\", максимальное число)");
            }
            if (!str.Contains("!"))
            {
                throw new DeserializeException("Неверный формат (num!num!num)");
            }
            if (!Regex.IsMatch(str, "^\\d+\\!\\d+$"))
            {
                throw new DeserializeException("Неверный формат (num!num!num)");
            }
            string[] split = str.Split('!');
            string x = split[0];
            string y = split[1];
            string z = split[2];
            return new Vector3(StringUtils.ParseInteger(x), StringUtils.ParseInteger(y), StringUtils.ParseInteger(z));
        }

        /// <summary>
        /// Получить расстояние между 2 векторами
        /// </summary>
        /// <param name="vector">Другой вектор</param>
        /// <returns>Расстояние</returns>
        public double Distance(Vector3 vector)
        {
            if (vector == null) return -1;
            int v1x = this.x;
            int v1y = this.y;
            int v1z = this.z;
            int v2x = vector.x;
            int v2y = vector.y;
            int v2z = vector.z;
            return Math.Sqrt(Math.Pow(v2x - v1x, 2) + Math.Pow(v2y - v1y, 2) + Math.Pow(v2z - v1z, 2));
        }

        /// <summary>
        /// Получить длину вектора (Расстояние от начала координат)
        /// </summary>
        /// <returns>Длина</returns>
        public double Length()
        {
            return Distance(new Vector3(0, 0, 0));
        }
    }
}
