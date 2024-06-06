using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace org.ReStudios.utitlitium.vectors
{
    public class Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2 SetX(int x)
        {
            X = x;
            return this;
        }

        public Vector2 SetY(int y)
        {
            Y = y;
            return this;
        }

        public Vector2 Add(Vector2 v)
        {
            X += v.X;
            Y += v.Y;
            return this;
        }

        public Vector2 Add(int x, int y)
        {
            return Add(new Vector2(x, y));
        }

        public Vector2 Add(int add)
        {
            return Add(add, add);
        }

        public Vector2 Sub(Vector2 v)
        {
            X -= v.X;
            Y -= v.Y;
            return this;
        }

        public Vector2 Sub(int x, int y)
        {
            return Sub(new Vector2(x, y));
        }

        public Vector2 Sub(int sub)
        {
            return Sub(sub, sub);
        }

        public Vector2 Mul(Vector2 v)
        {
            X *= v.X;
            Y *= v.Y;
            return this;
        }

        public Vector2 Mul(int x, int y)
        {
            return Mul(new Vector2(x, y));
        }

        public Vector2 Mul(int mul)
        {
            return Mul(mul, mul);
        }

        public Vector2 Div(Vector2 v)
        {
            if (v.X != 0) X /= v.X;
            if (v.Y != 0) Y /= v.Y;
            return this;
        }

        public Vector2 Div(int x, int y)
        {
            return Div(new Vector2(x, y));
        }

        public Vector2 Div(int div)
        {
            return Div(div, div);
        }

        public Vector2 Pow(Vector2 v)
        {
            X = (int)Math.Pow(X, v.X);
            Y = (int)Math.Pow(Y, v.Y);
            return this;
        }

        public Vector2 Pow(int x, int y)
        {
            return Pow(new Vector2(x, y));
        }

        public Vector2 Pow(int pow)
        {
            return Pow(pow, pow);
        }

        public Vector2 Clone()
        {
            return new Vector2(X, Y);
        }

        public Vector2 Normalize()
        {
            int i = (int)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            return Clone().Div(i);
        }

        public override string ToString()
        {
            return "{" + X + ";" + Y + "}";
        }

        public string SerializeToString()
        {
            return X + "!" + Y;
        }

        public Dictionary<string, object> SerializeToMap()
        {
            return ArrayUtils.CreateMap(
                "x", X,
                "y", Y
            );
        }

        public byte[] SerializeToBytes(Encoding charset)
        {
            return charset.GetBytes(SerializeToString());
        }

        public byte[] SerializeToBytes()
        {
            return SerializeToBytes(Encoding.UTF8);
        }

        public static Vector2 DeserializeFromBytes(byte[] bytes)
        {
            return DeserializeFromString(Encoding.UTF8.GetString(bytes));
        }

        public static Vector2 DeserializeFromMap(Dictionary<string, object> map)
        {
            if (!map.ContainsKey("x") || !map.ContainsKey("y"))
            {
                throw new DeserializeException("Map doesn't contain x or y keys");
            }

            if (!(map["x"] is int) || !(map["y"] is int))
            {
                throw new DeserializeException("Map values are not of type int");
            }

            int x = (int)map["x"];
            int y = (int)map["y"];
            return new Vector2(x, y);
        }

        public static Vector2 DeserializeFromString(string str)
        {
            if (str.Length < 3) throw new DeserializeException("Minimum length - 3 characters (num, \"!\", num)");
            int dl = int.MaxValue.ToString().Length;
            if (str.Length > dl + 1 + dl) throw new DeserializeException("Maximum length - " + (dl + 1 + dl) + " characters (max number, \"!\", max number)");
            if (!str.Contains("!")) throw new DeserializeException("Incorrect format (num!num)");
            if (!System.Text.RegularExpressions.Regex.IsMatch(str, "^\\d+\\!\\d+$")) throw new DeserializeException("Incorrect format (num!num)");
            string[] parts = str.Split('!');
            int x = StringUtils.ParseInteger(parts[0]);
            int y = StringUtils.ParseInteger(parts[1]);
            return new Vector2(x, y);
        }

        public Point asJavaPoint()
        {
            return new Point(X, Y);
        }

        public double GetAngle(Vector2 to)
        {
            double dx = to.X - X;
            double dy = -(to.Y - Y);
            double inRads = Math.Atan2(dy, dx);
            if (inRads < 0) inRads = Math.Abs(inRads);
            else inRads = 2 * Math.PI - inRads;
            return Math.Round(MathUtils.RadianToDegree(inRads), 2);
        }

        public Vector2 GetPositionFromDistanceRotation(float distance, float angle)
        {
            float a = (float)MathUtils.DegreeToRadian(90 - angle);
            float dx = (float)(Math.Cos(a) * distance);
            float dy = (float)(Math.Sin(a) * distance);
            return new Vector2((int)Math.Round(X + dx), (int)Math.Round(Y + dy));
        }

        public double Distance(Vector2 vector)
        {
            if (vector == null) return -1;
            int v1x = X;
            int v1y = Y;
            int v2x = vector.X;
            int v2y = vector.Y;
            return Math.Sqrt(Math.Pow((v2x - v1x), 2) + Math.Pow((v2y - v1y), 2));
        }

        public double Length()
        {
            return Distance(new Vector2(0, 0));
        }
    }
}
