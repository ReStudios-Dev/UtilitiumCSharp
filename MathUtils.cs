using org.ReStudios.utitlitium.vectors;
using System;
using System.Collections.Generic;

namespace org.ReStudios.utitlitium
{
    public class MathUtils
    {
        /// <summary>
        /// Ограничивает значение в заданном диапазоне.
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="val">Текущее значение</param>
        /// <returns>Значение в пределах диапазона</returns>
        public static int Clamp(int min, int max, int val)
        {
            return Math.Max(min, Math.Min(val, max));
        }

        /// <summary>
        /// Ограничивает значение в заданном диапазоне.
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="val">Текущее значение</param>
        /// <returns>Значение в пределах диапазона</returns>
        public static float Clamp(float min, float max, float val)
        {
            return Math.Max(min, Math.Min(val, max));
        }

        /// <summary>
        /// Ограничивает значение в заданном диапазоне.
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="val">Текущее значение</param>
        /// <returns>Значение в пределах диапазона</returns>
        public static double Clamp(double min, double max, double val)
        {
            return Math.Max(min, Math.Min(val, max));
        }

        /// <summary>
        /// Преобразует число из одного диапазона в другой (из <a href="https://www.arduino.cc/reference/en/language/functions/math/map">arduino</a>).
        /// </summary>
        /// <param name="x">Текущее значение</param>
        /// <param name="in_min">Минимальное значение входного диапазона</param>
        /// <param name="in_max">Максимальное значение входного диапазона</param>
        /// <param name="out_min">Минимальное значение выходного диапазона</param>
        /// <param name="out_max">Максимальное значение выходного диапазона</param>
        /// <returns>Преобразованное значение</returns>
        public static long Map(long x, long in_min, long in_max, long out_min, long out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        /// <summary>
        /// Преобразует число из одного диапазона в другой (из <a href="https://www.arduino.cc/reference/en/language/functions/math/map">arduino</a>).
        /// </summary>
        /// <param name="x">Текущее значение</param>
        /// <param name="in_min">Минимальное значение входного диапазона</param>
        /// <param name="in_max">Максимальное значение входного диапазона</param>
        /// <param name="out_min">Минимальное значение выходного диапазона</param>
        /// <param name="out_max">Максимальное значение выходного диапазона</param>
        /// <returns>Преобразованное значение</returns>
        public static int Map(int x, int in_min, int in_max, int out_min, int out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        /// <summary>
        /// Преобразует число из одного диапазона в другой (из <a href="https://www.arduino.cc/reference/en/language/functions/math/map">arduino</a>).
        /// </summary>
        /// <param name="x">Текущее значение</param>
        /// <param name="in_min">Минимальное значение входного диапазона</param>
        /// <param name="in_max">Максимальное значение входного диапазона</param>
        /// <param name="out_min">Минимальное значение выходного диапазона</param>
        /// <param name="out_max">Максимальное значение выходного диапазона</param>
        /// <returns>Преобразованное значение</returns>
        public static float Map(float x, float in_min, float in_max, float out_min, float out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        /// <summary>
        /// Преобразует число из одного диапазона в другой (из <a href="https://www.arduino.cc/reference/en/language/functions/math/map">arduino</a>).
        /// </summary>
        /// <param name="x">Текущее значение</param>
        /// <param name="in_min">Минимальное значение входного диапазона</param>
        /// <param name="in_max">Максимальное значение входного диапазона</param>
        /// <param name="out_min">Минимальное значение выходного диапазона</param>
        /// <param name="out_max">Максимальное значение выходного диапазона</param>
        /// <returns>Преобразованное значение</returns>
        public static double Map(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        /// <summary>
        /// Эта функция принимает набор координат XY, расстояние и аргумент поворота.
        /// Она возвращает координаты XY точки, которая находится на заданном расстоянии
        /// от заданной точки, в заданном направлении.
        /// </summary>
        /// <param name="point">Начальная позиция</param>
        /// <param name="distance">Расстояние до выходной позиции</param>
        /// <param name="angle">Направление к выходной позиции</param>
        /// <returns>Экземпляр вектора</returns>
        public static Vector2f GetPositionFromDistanceRotation(Vector2f point, float distance, float angle)
        {
            float a = (float)Math.PI / 2 - (float)Math.PI / 180 * angle;
            float dx = (float)(Math.Cos(a) * distance);
            float dy = (float)(Math.Sin(a) * distance);
            return new Vector2f(point.GetX() + dx, point.GetY() + dy);
        }

        /// <summary>
        /// Получает среднее значение из списка float.
        /// </summary>
        /// <param name="floatValues">Список float</param>
        /// <returns>Среднее значение</returns>
        public static float GetAverageValue(List<float> floatValues)
        {
            float sum = ArrayUtils.GetSum(floatValues);
            return sum / floatValues.Count;
        }

        /// <summary>
        /// Получает факториал числа.
        /// </summary>
        /// <param name="x">Входное число</param>
        /// <returns>Факториал</returns>
        public static int Factorial(int x)
        {
            int result = 1;
            for (int i = 2; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// Функция для вычисления биномиального коэффициента C(n, r).
        /// </summary>
        /// <param name="n">Число n</param>
        /// <param name="r">Число r</param>
        /// <returns>Биномиальный коэффициент C(n, r)</returns>
        public static int C(int n, int r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        /// <summary>
        /// Функция для вычисления точки на кривой Безье.
        /// <a href="https://en.wikipedia.org/wiki/B%C3%A9zier_curve">Кривая Безье</a>
        /// </summary>
        /// <param name="points">Точки</param>
        /// <param name="t">Текущее время (0.0 - 1.0)</param>
        /// <returns>Текущая точка</returns>
        public static Vector2d GetBezierPoint(Vector2d[] points, double t)
        {
            Vector2d retPos = new Vector2d(0, 0);
            int n = points.Length - 1;
            for (int i = 0; i <= n; i++)
            {
                retPos.Add(Math.Pow(1 - t, i) * Math.Pow(t, n - i) * points[i].GetX() * C(n, i),
                           Math.Pow(1 - t, i) * Math.Pow(t, n - i) * points[i].GetY() * C(n, i));
            }
            return retPos;
        }

        /// <summary>
        /// Преобразует угол из радиан в градусы.
        /// </summary>
        /// <param name="inRads">Угол в радианах</param>
        /// <returns>Угол в градусах</returns>
        public static double RadianToDegree(double inRads)
        {
            return inRads * (180.0 / Math.PI);
        }

        /// <summary>
        /// Преобразует угол из градусов в радианы.
        /// </summary>
        /// <param name="v">Угол в градусах</param>
        /// <returns>Угол в радианах</returns>
        public static float DegreeToRadian(float v)
        {
            return v * (float)Math.PI / 180.0f;
        }
    }
}
