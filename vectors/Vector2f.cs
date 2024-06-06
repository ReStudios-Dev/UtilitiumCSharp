using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace org.ReStudios.utitlitium.vectors
{
    public class Vector2f
    {
        /// <summary>
        /// Значения X и Y
        /// </summary>
        public float x, y;

        /// <summary>
        /// Конструктор с значениями по умолчанию
        /// </summary>
        public Vector2f()
        {
            x = 0;
            y = 0;
        }

        /// <summary>
        /// Конструктор с пользовательскими значениями
        /// </summary>
        /// <param name="x">Значение X</param>
        /// <param name="y">Значение Y</param>
        public Vector2f(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Получить значение X
        /// </summary>
        /// <returns>Значение X</returns>
        public float GetX()
        {
            return x;
        }

        /// <summary>
        /// Установить пользовательское значение X
        /// </summary>
        /// <param name="x">Новое значение X</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f SetX(float x)
        {
            this.x = x;
            return this;
        }

        /// <summary>
        /// Получить значение Y
        /// </summary>
        /// <returns>Значение Y</returns>
        public float GetY()
        {
            return y;
        }

        /// <summary>
        /// Установить пользовательское значение Y
        /// </summary>
        /// <param name="y">Новое значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f SetY(float y)
        {
            this.y = y;
            return this;
        }

        /// <summary>
        /// Добавить значения из другого вектора
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Add(Vector2f v)
        {
            this.x += v.GetX();
            this.y += v.GetY();
            return this;
        }

        /// <summary>
        /// Добавить значения из прямых значений
        /// </summary>
        /// <param name="x">Добавить значение X</param>
        /// <param name="y">Добавить значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Add(float x, float y)
        {
            return Add(new Vector2f(x, y));
        }

        /// <summary>
        /// Добавить значения из 1 значения.
        /// Добавить значение ко всем значениям вектора.
        /// Например: Представим, что у нас есть вектор со значениями 5 и 8,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 7 и 10
        /// </summary>
        /// <param name="add">Значение для добавления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Add(float add)
        {
            return Add(add, add);
        }

        /// <summary>
        /// Вычесть значения из другого вектора
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Sub(Vector2f v)
        {
            this.x -= v.GetX();
            this.y -= v.GetY();
            return this;
        }

        /// <summary>
        /// Вычесть значения из прямых значений
        /// </summary>
        /// <param name="x">Вычесть значение X</param>
        /// <param name="y">Вычесть значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Sub(float x, float y)
        {
            return Sub(new Vector2f(x, y));
        }

        /// <summary>
        /// Вычесть значения из 1 значения.
        /// Вычесть значение из всех значений вектора.
        /// Например: Представим, что у нас есть вектор со значениями 5 и 8,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 3 и 6
        /// </summary>
        /// <param name="sub">Значение для вычитания</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Sub(float sub)
        {
            return Sub(sub, sub);
        }

        /// <summary>
        /// Умножить значения на другой вектор
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Mul(Vector2f v)
        {
            this.x *= v.GetX();
            this.y *= v.GetY();
            return this;
        }

        /// <summary>
        /// Умножить значения на прямые значения
        /// </summary>
        /// <param name="x">Умножить значение X</param>
        /// <param name="y">Умножить значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Mul(float x, float y)
        {
            return Mul(new Vector2f(x, y));
        }

        /// <summary>
        /// Умножить значения на 1 значение.
        /// Умножить значение на все значения вектора.
        /// Например: Представим, что у нас есть вектор со значениями 5 и 8,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 10 и 16
        /// </summary>
        /// <param name="mul">Значение для умножения</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Mul(float mul)
        {
            return Mul(mul, mul);
        }

        /// <summary>
        /// Разделить значения на другой вектор
        /// </summary>
        /// <param name="v">Другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Div(Vector2f v)
        {
            if (v.GetX() != 0) this.x /= v.GetX();
            if (v.GetY() != 0) this.y /= v.GetY();
            return this;
        }

        /// <summary>
        /// Разделить значения на прямые значения
        /// </summary>
        /// <param name="x">Разделить значение X</param>
        /// <param name="y">Разделить значение Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Div(float x, float y)
        {
            return Div(new Vector2f(x, y));
        }

        /// <summary>
        /// Разделить значения на 1 значение.
        /// Разделить значение на все значения вектора.
        /// Например: Представим, что у нас есть вектор со значениями 4 и 8,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 2 и 4
        /// </summary>
        /// <param name="div">Значение для деления</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Div(float div)
        {
            return Div(div, div);
        }

        /// <summary>
        /// Возвести в степень текущий вектор к значениям другого вектора
        /// (X текущего вектора возводится в степень значения X другого вектора,
        /// и так далее с остальными значениями)
        /// </summary>
        /// <param name="v">другой вектор</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Pow(Vector2f v)
        {
            this.x = (float)Math.Pow(this.x, v.GetX());
            this.y = (float)Math.Pow(this.y, v.GetY());
            return this;
        }

        /// <summary>
        /// Возвести в степень из прямых значений
        /// </summary>
        /// <param name="x">степень значения X</param>
        /// <param name="y">степень значения Y</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Pow(float x, float y)
        {
            return Pow(new Vector2f(x, y));
        }

        /// <summary>
        /// Возвести в степень значения 1.
        /// Возвести в степень значение ко всем значениям вектора.
        /// Например: Представим, что у нас есть вектор со значениями 4 и 8,
        /// если мы вызовем этот метод с значением 2,
        /// то на выходе мы получим вектор со значениями 16 и 64
        /// *Другими словами: x = x^pow*
        /// </summary>
        /// <param name="pow">Значение для возведения в степень</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Pow(float pow)
        {
            return Pow(pow, pow);
        }

        /// <summary>
        /// Клонировать текущий вектор
        /// Создаст точно такой же вектор, но как отдельный объект.
        /// Это полезно, если вам нужно сохранить значения, если вы их позже измените (например).
        /// </summary>
        /// <returns>Экземпляр скопированного вектора</returns>
        public Vector2f Clone()
        {
            return new Vector2f(x, y);
        }

        /// <summary>
        /// Любой вектор, нормализованный, изменяет только свою величину, а не направление.
        /// Кроме того, каждый вектор, указывающий в том же направлении, нормализуется до того же вектора
        /// (потому что величина и направление уникально определяют вектор).
        /// Другими словами, делит вектор на минимальные значения, которые приводят вектор к "направлению"
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f Normalize()
        {
            float i = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return Clone().Div(i);
        }

        /// <summary>
        /// Преобразовать вектор в строку
        /// Например, полезно для отладки
        /// </summary>
        /// <returns>Строковый вектор</returns>
        public override string ToString()
        {
            return "{" + x + ";" + y + "}";
        }

        /// <summary>
        /// Преобразовать вектор в сериализованную строку
        /// Например, для хранения за пределами приложения
        /// </summary>
        /// <returns>Сериализованный вектор</returns>
        public string SerializeToString()
        {
            return x + "!" + y;
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
                { "y", y }
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
        /// <exception cref="DeserializeException">Недопустимое или неправильное значение списка байтов</exception>
        public static Vector2f DeserializeFromBytes(byte[] bytes)
        {
            return DeserializeFromString(Encoding.UTF8.GetString(bytes));
        }

        /// <summary>
        /// Десериализовать список карт в класс Vector
        /// </summary>
        /// <returns>Экземпляр вектора</returns>
        /// <exception cref="DeserializeException">Недопустимый или неправильный словарь или его значения</exception>
        public static Vector2f DeserializeFromMap(Dictionary<string, object> map)
        {
            if (!map.ContainsKey("x") || !map.ContainsKey("y"))
            {
                throw new DeserializeException("Карта не содержит ключи 'x' или 'y'");
            }
            if (!(map["x"] is float) || !(map["y"] is float))
            {
                throw new DeserializeException("Значения карты не являются экземплярами float");
            }
            float x = (float)map["x"];
            float y = (float)map["y"];
            return new Vector2f(x, y);
        }

        /// <summary>
        /// Десериализовать строку в класс Vector
        /// </summary>
        /// <param name="str">Строковое значение</param>
        /// <returns>Экземпляр вектора</returns>
        /// <exception cref="DeserializeException">Недопустимое или неправильное строковое значение</exception>
        public static Vector2f DeserializeFromString(string str)
        {
            if (str.Length < 3) throw new DeserializeException("Минимальная длина - 3 символа (число, \"!\", число)");
            int dl = float.MaxValue.ToString().Length;
            if (str.Length > dl + 1 + dl) throw new DeserializeException("Максимальная длина - " + (dl + 1 + dl) + " символов (максимальное число, \"!\", максимальное число)");
            if (!str.Contains("!")) throw new DeserializeException("Неверный формат (число!число)");
            if (!System.Text.RegularExpressions.Regex.IsMatch(str, "^\\d+\\!\\d+$")) throw new DeserializeException("Неверный формат (число!число)");
            string x = str.Split('!')[0];
            string y = str.Split('!')[1];
            return new Vector2f(StringUtils.ParseFloat(x), StringUtils.ParseFloat(y));
        }

        /// <summary>
        /// Преобразовать вектор в java Point2D
        /// </summary>
        /// <returns>Java Point</returns>
        public Point AsJavaPoint()
        {
            return new Point((int)x, (int)y);
        }

        /// <summary>
        /// Получить угол относительно этого вектора
        /// где 3 часа - 0, а 12 часов - 270 градусов
        /// </summary>
        /// <param name="to">Вектор для вращения</param>
        /// <returns>Угол в градусах от 0 до 360.</returns>
        public double GetAngle(Vector2f to)
        {
            double dx = to.x - x;
            // Минус для коррекции переназначения координат
            double dy = -(to.y - y);

            double inRads = Math.Atan2(dy, dx);

            // Нам нужно отображать в системе координат, где 0 градусов находится в 3 часа, а 270 градусов в 12 часов
            if (inRads < 0)
                inRads = Math.Abs(inRads);
            else
                inRads = 2 * Math.PI - inRads;

            return MathUtils.RadianToDegree(inRads);
        }

        public Vector2 AsVector2()
        {
            return new Vector2((int)Math.Round(x), (int)Math.Round(y));
        }

        /// <summary>
        /// Эта функция принимает набор координат XY, расстояние и аргумент поворота.
        /// Он возвращает XY-координаты точки, которая находится на заданном расстоянии
        /// от заданной точки, в заданном направлении.
        /// </summary>
        /// <param name="distance">Расстояние до позиции вывода</param>
        /// <param name="angle">направление к позиции вывода</param>
        /// <returns>Экземпляр вектора</returns>
        public Vector2f GetPositionFromDistanceRotation(float distance, float angle)
        {
            float a = (float)MathUtils.DegreeToRadian(90 - angle);
            float dx = (float)(Math.Cos(a) * distance);
            float dy = (float)(Math.Sin(a) * distance);
            return new Vector2f(x + dx, y + dy);
        }

        /// <summary>
        /// Получить расстояние между 2 векторами
        /// </summary>
        /// <param name="vector">Другой вектор</param>
        /// <returns>Расстояние</returns>
        public double Distance(Vector2f vector)
        {
            if (vector == null) return -1;
            float v1x = this.x;
            float v1y = this.y;
            float v2x = vector.x;
            float v2y = vector.y;
            return Math.Sqrt(Math.Pow((v2x - v1x), 2) + Math.Pow((v2y - v1y), 2));
        }

        /// <summary>
        /// Получить длину вектора (расстояние от начала координат)
        /// </summary>
        /// <returns>Длина</returns>
        public double Length()
        {
            return Distance(new Vector2f(0.0f, 0.0f));
        }
    }
}
