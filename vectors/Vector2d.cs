using System;
using System.Collections.Generic;
using System.Drawing;

namespace org.ReStudios.utitlitium.vectors
{
    public class Vector2d
    {
        /// <summary>
        /// X и Y значения
        /// </summary>
        public double x, y;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Vector2d()
        {
            x = 0;
            y = 0;
        }

        /// <summary>
        /// Конструктор с пользовательскими значениями
        /// </summary>
        /// <param name="x">X значение</param>
        /// <param name="y">Y значение</param>
        public Vector2d(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Получить X значение
        /// </summary>
        /// <returns>X значение</returns>
        public double GetX()
        {
            return x;
        }

        /// <summary>
        /// Установить пользовательское значение X
        /// </summary>
        /// <param name="x">новое значение X</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d SetX(double x)
        {
            this.x = x;
            return this;
        }

        /// <summary>
        /// Получить Y значение
        /// </summary>
        /// <returns>Y значение</returns>
        public double GetY()
        {
            return y;
        }

        /// <summary>
        /// Установить пользовательское значение Y
        /// </summary>
        /// <param name="y">новое значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d SetY(double y)
        {
            this.y = y;
            return this;
        }

        /// <summary>
        /// Добавить значения из другого вектора
        /// </summary>
        /// <param name="v">другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Add(Vector2d v)
        {
            this.x += v.GetX();
            this.y += v.GetY();
            return this;
        }

        /// <summary>
        /// Добавить значения из прямых значений
        /// </summary>
        /// <param name="x">добавить значение X</param>
        /// <param name="y">добавить значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Add(double x, double y)
        {
            return Add(new Vector2d(x, y));
        }

        /// <summary>
        /// Добавить значение ко всем значениям вектора
        /// </summary>
        /// <param name="add">значение для добавления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Add(double add)
        {
            return Add(add, add);
        }

        /// <summary>
        /// Вычесть значения из другого вектора
        /// </summary>
        /// <param name="v">другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Sub(Vector2d v)
        {
            this.x -= v.GetX();
            this.y -= v.GetY();
            return this;
        }

        /// <summary>
        /// Вычесть значения из прямых значений
        /// </summary>
        /// <param name="x">вычесть значение X</param>
        /// <param name="y">вычесть значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Sub(double x, double y)
        {
            return Sub(new Vector2d(x, y));
        }

        /// <summary>
        /// Вычесть значение из всех значений вектора
        /// </summary>
        /// <param name="sub">значение для вычитания</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Sub(double sub)
        {
            return Sub(sub, sub);
        }

        /// <summary>
        /// Умножить значения на другой вектор
        /// </summary>
        /// <param name="v">другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Mul(Vector2d v)
        {
            this.x *= v.GetX();
            this.y *= v.GetY();
            return this;
        }

        /// <summary>
        /// Умножить значения на прямые значения
        /// </summary>
        /// <param name="x">умножить значение X</param>
        /// <param name="y">умножить значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Mul(double x, double y)
        {
            return Mul(new Vector2d(x, y));
        }

        /// <summary>
        /// Умножить значения на одно значение
        /// </summary>
        /// <param name="mul">значение для умножения</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Mul(double mul)
        {
            return Mul(mul, mul);
        }

        /// <summary>
        /// Разделить значения на другой вектор
        /// </summary>
        /// <param name="v">другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Div(Vector2d v)
        {
            if (v.GetX() != 0) this.x /= v.GetX();
            if (v.GetY() != 0) this.y /= v.GetY();
            return this;
        }

        /// <summary>
        /// Разделить значения на прямые значения
        /// </summary>
        /// <param name="x">разделить значение X</param>
        /// <param name="y">разделить значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Div(double x, double y)
        {
            return Div(new Vector2d(x, y));
        }

        /// <summary>
        /// Разделить значения на одно значение
        /// </summary>
        /// <param name="div">значение для деления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Div(double div)
        {
            return Div(div, div);
        }

        /// <summary>
        /// Возвести в степень текущий вектор значения из другого вектора
        /// </summary>
        /// <param name="v">другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Pow(Vector2d v)
        {
            this.x = Math.Pow(this.x, v.GetX());
            this.y = Math.Pow(this.y, v.GetY());
            return this;
        }

        /// <summary>
        /// Возвести в степень значения из прямых значений
        /// </summary>
        /// <param name="x">возвести в степень значение X</param>
        /// <param name="y">возвести в степень значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Pow(double x, double y)
        {
            return Pow(new Vector2d(x, y));
        }

        /// <summary>
        /// Возвести в степень значения из одного значения
        /// </summary>
        /// <param name="pow">значение для возведения в степень</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Pow(double pow)
        {
            return Pow(pow, pow);
        }

        /// <summary>
        /// Клонировать текущий вектор
        /// </summary>
        /// <returns>Экземпляр скопированного вектора</returns>
        public Vector2d Clone()
        {
            return new Vector2d(x, y);
        }

        /// <summary>
        /// Нормализовать вектор
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d Normalize()
        {
            double i = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return Clone().Div(i);
        }

        /// <summary>
        /// Преобразовать вектор в строку
        /// </summary>
        /// <returns>Строковое представление вектора</returns>
        public override string ToString()
        {
            return "{" + x + ";" + y + "}";
        }

        /// <summary>
        /// Сериализовать вектор в строку
        /// </summary>
        /// <returns>Сериализованный вектор</returns>
        public string SerializeToString()
        {
            return x + "!" + y;
        }

        /// <summary>
        /// Сериализовать вектор в словарь
        /// </summary>
        /// <returns>Сериализованный вектор</returns>
        public Dictionary<string, object> SerializeToMap()
        {
            return new Dictionary<string, object>
            {
                { "x", x },
                { "y", y }
            };
        }

        /// <summary>
        /// Сериализовать вектор в список байт
        /// </summary>
        /// <param name="charset">Пользовательская кодировка</param>
        /// <returns>Сериализованный вектор</returns>
        public byte[] SerializeToBytes(System.Text.Encoding charset)
        {
            return charset.GetBytes(SerializeToString());
        }

        /// <summary>
        /// Сериализовать вектор в список байт с кодировкой по умолчанию (UTF-8)
        /// </summary>
        /// <returns>Сериализованный вектор</returns>
        public byte[] SerializeToBytes()
        {
            return SerializeToBytes(System.Text.Encoding.UTF8);
        }

        /// <summary>
        /// Десериализовать список байт в класс Vector
        /// </summary>
        /// <param name="bytes">список байт</param>
        /// <returns>Экземпляр вектора</returns>
        public static Vector2d DeserializeFromBytes(byte[] bytes)
        {
            return DeserializeFromString(System.Text.Encoding.UTF8.GetString(bytes));
        }

        /// <summary>
        /// Десериализовать словарь в класс Vector
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        public static Vector2d DeserializeFromMap(Dictionary<string, object> map)
        {
            if (!map.ContainsKey("x") || !map.ContainsKey("y"))
            {
                throw new DeserializeException("Map doesn't contains x or y keys");
            }
            if (!(map["x"] is double) || !(map["y"] is double))
            {
                throw new DeserializeException("Map values doesn't instance of double value");
            }
            double x = (double)map["x"];
            double y = (double)map["y"];
            return new Vector2d(x, y);
        }

        /// <summary>
        /// Десериализовать строку в класс Vector
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        public static Vector2d DeserializeFromString(string str)
        {
            if (str.Length < 3) { throw new DeserializeException("Minimum length - 3 characters (num, \"!\", num)"); }
            double dl = Math.Log10(double.MaxValue);
            if (str.Length > dl + 1 + dl) { throw new DeserializeException("Maximum length - " + (dl + 1 + dl) + " characters (max number, \"!\", max number)"); }
            if (!str.Contains("!"))
            {
                throw new DeserializeException("Incorrect format (num!num)");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(str, "^\\d+\\!\\d+$"))
            {
                throw new DeserializeException("Incorrect format (num!num)");
            }
            string x = str.Split('!')[0];
            string y = str.Split('!')[1];
            return new Vector2d(StringUtils.ParseDouble(x), StringUtils.ParseDouble(y));
        }

        /// <summary>
        /// Преобразовать вектор в объект Point2D Java
        /// </summary>
        /// <returns>Java Point</returns>
        public Point asJavaPoint()
        {
            return new Point((int)x, (int)y);
        }

        /// <summary>
        /// Получить угол относительно этого вектора,
        /// где 3 часа - это 0, а 12 часов - 270 градусов
        /// </summary>
        /// <param name="to">Вектор для поворота</param>
        /// <returns>угол в градусах от 0 до 360.</returns>
        public double GetAngle(Vector2d to)
        {
            double dx = to.x - x;
            // Минус для коррекции повторного отображения координат
            double dy = -(to.y - y);

            double inRads = Math.Atan2(dy, dx);

            // Нам нужно отобразить систему координат, когда 0 градусов находится в 3 часа, 270 в 12 часов
            if (inRads < 0)
                inRads = Math.Abs(inRads);
            else
                inRads = 2 * Math.PI - inRads;

            return MathUtils.RadianToDegree(inRads);
        }

        public Vector2 asVector2()
        {
            return new Vector2((int)Math.Round(x), (int)Math.Round(y));
        }

        /// <summary>
        /// Эта функция принимает набор XY-координат, расстояние и аргумент вращения.
        /// Она возвращает XY-координаты точки, которая находится на заданном расстоянии
        /// от данной точки в заданном направлении.
        /// </summary>
        /// <param name="distance">Расстояние до выходной позиции</param>
        /// <param name="angle">направление к выходной позиции</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2d GetPositionFromDistanceRotation(float distance, float angle)
        {
            double a = MathUtils.DegreeToRadian(90 - angle);
            double dx = (Math.Cos(a) * distance);
            double dy = (Math.Sin(a) * distance);
            return new Vector2d(x + dx, y + dy);
        }

        /// <summary>
        /// Получить расстояние между 2 векторами
        /// </summary>
        /// <param name="vector">Другой вектор</param>
        /// <returns>Расстояние</returns>
        public double Distance(Vector2d vector)
        {
            if (vector == null) return -1;
            double v1x = this.x;
            double v1y = this.y;
            double v2x = vector.x;
            double v2y = vector.y;
            return Math.Sqrt(Math.Pow((v2x - v1x), 2) + Math.Pow((v2y - v1y), 2));
        }

        /// <summary>
        /// Получить длину вектора (расстояние от начала координат)
        /// </summary>
        /// <returns>Длина</returns>
        public double Length()
        {
            return Distance(new Vector2d(0.0d, 0.0d));
        }
    }
}
