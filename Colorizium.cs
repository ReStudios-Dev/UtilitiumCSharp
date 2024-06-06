using System;
using System.Collections.Generic;
using System.Drawing;

namespace org.ReStudios.utitlitium
{
    public static class Colorizium
    {

        /// <summary>
        /// Применяет цветовой провайдер к строке и возвращает ее
        /// </summary>
        /// <param name="str">Входная обычная строка</param>
        /// <param name="prefix">Префикс для селекторов</param>
        /// <param name="provider">Провайдер. Null для использования по умолчанию</param>
        /// <param name="suffix">Суффикс для селекторов</param>
        /// <returns>Цветизированная и стилизованная строка</returns>
        public static string Apply(string str, string prefix, AColorProvider provider, string suffix)
        {
            if (provider == null)
                provider = new ColorProvider();

            List<Line> colors = provider.GetColors();

            foreach (Line color in colors)
            {
                string find = prefix + color.String + suffix;
                string replacement = "";

                if (color is ColorLine)
                {
                    ColorLine line = (ColorLine)color;
                    Color c = line.Color;
                    replacement = Rgb(line.Foreground, c.R, c.G, c.B);
                }
                else if (color is StyleLine)
                {
                    StyleLine line = (StyleLine)color;
                    Style style = line.Style;

                    switch (style)
                    {
                        case Style.Bold:
                            replacement = Bold();
                            break;
                        case Style.Italic:
                            replacement = Italic();
                            break;
                        case Style.Underline:
                            replacement = Underline();
                            break;
                        case Style.Strikethrough:
                            replacement = Strikethrough();
                            break;
                        case Style.Framed:
                            replacement = Framed();
                            break;
                    }
                }
                else if (color is ResetLine)
                {
                    replacement = Reset();
                }

                str = str.Replace(find, replacement);
            }

            return str;
        }

        /// <summary>
        /// RGB в ANSI код цвета ТЕКСТА (24 бит)
        /// </summary>
        /// <param name="r">Красный цвет (0-255)</param>
        /// <param name="g">Зеленый цвет (0-255)</param>
        /// <param name="b">Синий цвет (0-255)</param>
        /// <returns>Код цвета ANSI</returns>
        public static string Rgb(int r, int g, int b)
        {
            return Rgb(true, r, g, b);
        }

        /// <summary>
        /// RGB в ANSI код цвета ФОНА (24 бит)
        /// </summary>
        /// <param name="r">Красный цвет (0-255)</param>
        /// <param name="g">Зеленый цвет (0-255)</param>
        /// <param name="b">Синий цвет (0-255)</param>
        /// <returns>Код цвета ANSI</returns>
        public static string BgRgb(int r, int g, int b)
        {
            return Rgb(false, r, g, b);
        }

        /// <summary>
        /// RGB в ANSI код цвета (24 бит)
        /// </summary>
        /// <param name="foreground">Это передний план (цвет текста или цвет фона)</param>
        /// <param name="r">Красный цвет (0-255)</param>
        /// <param name="g">Зеленый цвет (0-255)</param>
        /// <param name="b">Синий цвет (0-255)</param>
        /// <returns>Код цвета ANSI</returns>
        public static string Rgb(bool foreground, int r, int g, int b)
        {
            r = Math.Clamp(r, 0, 255);
            g = Math.Clamp(g, 0, 255);
            b = Math.Clamp(b, 0, 255);

            return $"\u001B[{(foreground ? "3" : "4")}8;2;{r};{g};{b}m";
        }

        /// <summary>
        /// ANSI код сброса цвета
        /// </summary>
        /// <returns>ANSI код</returns>
        public static string Reset()
        {
            return "\u001B[0m";
        }

        /// <summary>
        /// ANSI код стиля жирного текста
        /// </summary>
        /// <returns>ANSI код</returns>
        public static string Bold()
        {
            return "\u001B[1m";
        }

        /// <summary>
        /// ANSI код стиля курсивного текста
        /// </summary>
        /// <returns>ANSI код</returns>
        public static string Italic()
        {
            return "\u001B[3m";
        }

        /// <summary>
        /// ANSI код стиля подчеркнутого текста
        /// </summary>
        /// <returns>ANSI код</returns>
        public static string Underline()
        {
            return "\u001B[4m";
        }

        /// <summary>
        /// ANSI код стиля зачеркнутого текста
        /// </summary>
        /// <returns>ANSI код</returns>
        public static string Strikethrough()
        {
            return "\u001B[9m";
        }

        /// <summary>
        /// ANSI код стиля рамки вокруг текста
        /// </summary>
        /// <returns>ANSI код</returns>
        public static string Framed()
        {
            return "\u001B[51m";
        }

        /// <summary>
        /// Абстрактный цветовой провайдер
        /// </summary>
        public abstract class AColorProvider
        {
            /// <summary>
            /// Получить список строк цвета.
            /// </summary>
            /// <returns>Список строк цвета</returns>
            public abstract List<Line> GetColors();
        }

        /// <summary>
        /// Перечисление стилей
        /// </summary>
        public enum Style
        {
            Bold, Italic, Underline, Strikethrough, Framed
        }

        /// <summary>
        /// Абстрактный элемент для списка цветового провайдера
        /// </summary>
        public abstract class Line
        {
            /// <summary>
            /// Селектор.
            /// </summary>
            public readonly string String;

            public Line(string str)
            {
                String = str;
            }
        }

        /// <summary>
        /// Сброс всех цветов и стилей. Текст после этой строки будет по умолчанию (обычно обычный белый)
        /// </summary>
        public class ResetLine : Line
        {
            public ResetLine(string str) : base(str) { }
        }

        /// <summary>
        /// Сделать все следующие символы специальным цветом переднего или заднего плана
        /// </summary>
        public class ColorLine : Line
        {
            public readonly bool Foreground;
            public readonly Color Color;

            public ColorLine(string str, bool foreground, Color color) : base(str)
            {
                Foreground = foreground;
                Color = color;
            }
        }

        /// <summary>
        /// Сделать все следующие символы специальным стилем: жирный, курсив, подчеркнутый, зачеркнутый или рамочный
        /// </summary>
        public class StyleLine : Line
        {
            public readonly Style Style;

            public StyleLine(string str, Style style) : base(str)
            {
                Style = style;
            }
        }

        /// <summary>
        /// Провайдер цвета. Содержит пары селекторов и строк (замена для селектора)
        /// </summary>
        public class ColorProvider : AColorProvider
        {
            private readonly List<Line> colors;

            public ColorProvider()
            {
                colors = new List<Line>
                {
                    new ColorLine("0", true, ColorTranslator.FromHtml("#000000")), // черный
                    new ColorLine("1", true, ColorTranslator.FromHtml("#0000AA")), // темно-синий
                    new ColorLine("2", true, ColorTranslator.FromHtml("#00AA00")), // темно-зеленый
                    new ColorLine("3", true, ColorTranslator.FromHtml("#00AAAA")), // темно-аквамариновый
                    new ColorLine("4", true, ColorTranslator.FromHtml("#AA0000")), // темно-красный
                    new ColorLine("5", true, ColorTranslator.FromHtml("#AA00AA")), // темно-пурпурный
                    new ColorLine("6", true, ColorTranslator.FromHtml("#FFAA00")), // темно-желтый (золотой)
                    new ColorLine("7", true, ColorTranslator.FromHtml("#AAAAAA")), // серый
                    new ColorLine("8", true, ColorTranslator.FromHtml("#555555")), // темно-серый
                    new ColorLine("9", true, ColorTranslator.FromHtml("#5555FF")), // синий
                    new ColorLine("a", true, ColorTranslator.FromHtml("#55FF55")), // зеленый
                    new ColorLine("b", true, ColorTranslator.FromHtml("#55FFFF")), // аквамариновый
                    new ColorLine("c", true, ColorTranslator.FromHtml("#FF5555")), // красный
                    new ColorLine("d", true, ColorTranslator.FromHtml("#FF55FF")), // пурпурный
                    new ColorLine("e", true, ColorTranslator.FromHtml("#FF55FF")), // желтый
                    new ColorLine("f", true, ColorTranslator.FromHtml("#FFFFFF")), // белый

                    new StyleLine("l", Style.Bold), // жирный
                    new StyleLine("o", Style.Italic), // курсив
                    new StyleLine("n", Style.Underline), // подчеркнутый
                    new StyleLine("m", Style.Strikethrough), // зачеркнутый
                    new StyleLine("k", Style.Framed), // рамочный

                    new ResetLine("r") // сброс
                };
            }

            public override List<Line> GetColors()
            {
                return colors;
            }
        }
    }
}
