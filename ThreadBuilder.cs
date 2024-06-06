using System;
using System.Threading;

namespace org.ReStudios.utitlitium
{
    public class ThreadBuilder
    {
        private readonly Thread thread;

        public ThreadBuilder(Action task)
        {
            this.thread = new Thread(() =>
            {
                try
                {
                    task();
                }
                catch (Exception ex)
                {
                    Logger customErrorLoggerStream = new Logger(Console.Error);
                    customErrorLoggerStream.isErrorStream = true;
                    customErrorLoggerStream.Write($"Unhandled exception in thread: {ex}");
                }
            });
        }

        /// <summary>
        /// Устанавливает приоритет потока
        /// </summary>
        /// <param name="priority">Приоритет, который нужно установить</param>
        /// <returns>Экземпляр класса ThreadBuilder</returns>
        public ThreadBuilder SetPriority(int priority)
        {
            this.thread.Priority = (ThreadPriority)priority;
            return this;
        }

        /// <summary>
        /// Устанавливает имя потока
        /// </summary>
        /// <param name="name">Имя, которое нужно установить</param>
        /// <returns>Экземпляр класса ThreadBuilder</returns>
        public ThreadBuilder SetName(string name)
        {
            this.thread.Name = name;
            return this;
        }

        /// <summary>
        /// Строит поток с примененными параметрами и запускает его
        /// </summary>
        /// <returns>Поток с примененными параметрами</returns>
        public Thread BuildAndRun()
        {
            this.thread.Start();
            return this.thread;
        }

        /// <summary>
        /// Настройка вывода в логгер
        /// </summary>
        public static void SetupPrints()
        {
            Console.SetOut(new Logger(Console.Out));
            var customErrorLoggerStream = new Logger(Console.Error);
            customErrorLoggerStream.isErrorStream = true;
            Console.SetError(customErrorLoggerStream);
            AppDomain.CurrentDomain.UnhandledException += customErrorLoggerStream.UnhandledException;
        }
    }
}
    