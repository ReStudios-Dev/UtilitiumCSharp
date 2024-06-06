using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace org.ReStudios.utitlitium
{
    /// <summary>
    /// Класс для логирования
    /// </summary>
    public class Logger : TextWriter
    {
        /// <summary>
        /// Флаг, указывающий на поток ошибок
        /// </summary>
        public bool isErrorStream = false;
        private readonly TextWriter originalTextWriter;
        int reflectionMethodCallDepthOffset = 0;
        Colorizium.AColorProvider colorProvider;
        string colorPrefix, colorSuffix;
        bool colors;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Logger"/>
        /// </summary>
        /// <param name="writer">Исходный поток</param>
        public Logger(TextWriter writer) : base(writer.FormatProvider)
        {
            this.originalTextWriter = writer;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Logger"/> с поддержкой цветов
        /// </summary>
        /// <param name="writer">Исходный поток</param>
        /// <param name="colorProvider">Провайдер цветов</param>
        /// <param name="colorPrefix">Префикс цвета</param>
        /// <param name="colorSuffix">Суффикс цвета</param>
        public Logger(TextWriter writer, Colorizium.AColorProvider colorProvider, string colorPrefix, string colorSuffix) : base(writer.FormatProvider)
        {
            this.originalTextWriter = writer;
            this.colorProvider = colorProvider;
            this.colorPrefix = colorPrefix;
            this.colorSuffix = colorSuffix;
            colors = true;
        }

        /// <summary>
        /// Записывает строку в поток вывода
        /// </summary>
        /// <param name="value">Строка для записи</param>
        public override void Write(string value)
        {
            MethodBase traceElement = Utilitium.GetCaller(2 + this.reflectionMethodCallDepthOffset);
            string className = traceElement.Name;
            string clazz = className + ":" + traceElement.Module;
            if (colors)
            {
                value = Colorizium.Apply(value, colorPrefix, colorProvider, colorSuffix);
            }
            this.originalTextWriter.WriteLine($"[{Thread.CurrentThread.Name} {(this.isErrorStream ? "ERROR" : "INFO")} {clazz}] {value}");
        }

        // Далее перегруженные методы Write, которые вызывают Write(string value) с преобразованием входного значения в строку

        /// <summary>
        /// Записывает значение int в поток вывода
        /// </summary>
        /// <param name="value">Значение для записи</param>
        public override void Write(int value)
        {
            this.reflectionMethodCallDepthOffset = 1;
            this.Write(value.ToString());
            this.reflectionMethodCallDepthOffset = 0;
        }

        /// <summary>
        /// Записывает значение double в поток вывода
        /// </summary>
        /// <param name="value">Значение для записи</param>
        public override void Write(double value)
        {
            this.reflectionMethodCallDepthOffset = 1;
            this.Write(value.ToString());
            this.reflectionMethodCallDepthOffset = 0;
        }

        /// <summary>
        /// Записывает символ в поток вывода
        /// </summary>
        /// <param name="value">Символ для записи</param>
        public override void Write(char value)
        {
            this.reflectionMethodCallDepthOffset = 1;
            this.Write(value.ToString());
            this.reflectionMethodCallDepthOffset = 0;
        }

        /// <summary>
        /// Записывает значение long в поток вывода
        /// </summary>
        /// <param name="value">Значение для записи</param>
        public override void Write(long value)
        {
            this.reflectionMethodCallDepthOffset = 1;
            this.Write(value.ToString());
            this.reflectionMethodCallDepthOffset = 0;
        }

        /// <summary>
        /// Записывает значение float в поток вывода
        /// </summary>
        /// <param name="value">Значение для записи</param>
        public override void Write(float value)
        {
            this.reflectionMethodCallDepthOffset = 1;
            this.Write(value.ToString());
            this.reflectionMethodCallDepthOffset = 0;
        }

        /// <summary>
        /// Записывает значение bool в поток вывода
        /// </summary>
        /// <param name="value">Значение для записи</param>
        public override void Write(bool value)
        {
            this.reflectionMethodCallDepthOffset = 1;
            this.Write(value.ToString());
            this.reflectionMethodCallDepthOffset = 0;
        }

        /// <summary>
        /// Записывает объект в поток вывода
        /// </summary>
        /// <param name="value">Объект для записи</param>
        public override void Write(object value)
        {
            this.reflectionMethodCallDepthOffset = 1;
            this.Write(value.ToString());
            this.reflectionMethodCallDepthOffset = 0;
        }

        /// <summary>
        /// Записывает массив символов в поток вывода
        /// </summary>
        /// <param name="buffer">Массив символов для записи</param>
        public override void Write(char[] buffer)
        {
            this.reflectionMethodCallDepthOffset = 1;
            this.Write(new string(buffer));
            this.reflectionMethodCallDepthOffset = 0;
        }

        /// <summary>
        /// Настраивает цветной вывод
        /// </summary>
        /// <param name="colorPrefix">Префикс цвета</param>
        /// <param name="provider">Провайдер цвета (может быть null для использования по умолчанию)</param>
        /// <param name="colorSuffix">Суффикс цвета</param>
        public static void SetupPrints(string colorPrefix, Colorizium.AColorProvider provider, string colorSuffix)
        {
            Console.SetOut(new Logger(Console.Out, provider, colorPrefix, colorSuffix));
            Logger customErrorLoggerStream = new Logger(Console.Error, provider, colorPrefix, colorSuffix);
            customErrorLoggerStream.isErrorStream = true;
            Console.SetError(customErrorLoggerStream);
            AppDomain.CurrentDomain.UnhandledException += customErrorLoggerStream.UnhandledException;
        }

        /// <summary>
        /// Настраивает обычный вывод
        /// </summary>
        public static void SetupPrints()
        {
            Console.SetOut(new Logger(Console.Out));
            Logger customErrorLoggerStream = new Logger(Console.Error);
            customErrorLoggerStream.isErrorStream = true;
            Console.SetError(customErrorLoggerStream);
            AppDomain.CurrentDomain.UnhandledException += customErrorLoggerStream.UnhandledException;
        }

        /// <summary>
        /// Обработчик необработанных исключений
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Аргументы исключения</param>
        public void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                this.originalTextWriter.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Кодировка потока
        /// </summary>
        public override System.Text.Encoding Encoding => throw new NotImplementedException();
    }
}
