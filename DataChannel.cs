using System;
using System.IO;
using System.Text;

namespace org.ReStudios.utitlitium
{
    /// <summary>
    /// Класс для работы с каналом данных
    /// </summary>
    public class DataChannel : IDisposable
    {
        private readonly Stream _os; // Выходной поток
        private readonly Stream _isStream; // Входной поток

        /// <summary>
        /// Конструктор для канала данных с выходным и входным потоком
        /// </summary>
        /// <param name="os">Выходной поток</param>
        /// <param name="isStream">Входной поток</param>
        public DataChannel(Stream os, Stream isStream)
        {
            _os = os;
            _isStream = isStream;
        }

        /// <summary>
        /// Конструктор для канала данных с выходным потоком
        /// </summary>
        /// <param name="os">Выходной поток</param>
        public DataChannel(Stream os)
        {
            _os = os;
        }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DataChannel()
        {
        }

        /// <summary>
        /// Чтение входного потока в строку
        /// </summary>
        /// <param name="isStream">Входной поток</param>
        /// <returns>Прочитанная строка</returns>
        public string ReadInputStream(Stream isStream)
        {
            if (isStream == null) return null;
            byte[] buff = new byte[512];
            int len;
            StringBuilder result = new StringBuilder();
            while ((len = isStream.Read(buff, 0, 512)) > 0)
            {
                result.Append(Encoding.UTF8.GetString(buff, 0, len));
            }
            return result.ToString();
        }

        /// <summary>
        /// Получить выходной поток
        /// </summary>
        /// <returns>Выходной поток</returns>
        public Stream GetOutputStream()
        {
            return _os;
        }

        /// <summary>
        /// Получить входной поток
        /// </summary>
        /// <returns>Входной поток</returns>
        public Stream GetInputStream()
        {
            return _isStream;
        }

        /// <summary>
        /// Записать строку в выходной поток
        /// </summary>
        /// <param name="str">Строка для записи</param>
        public void Write(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Записать целое число в выходной поток
        /// </summary>
        /// <param name="b">Целое число для записи</param>
        public void Write(int b)
        {
            _os.WriteByte((byte)b);
        }

        /// <summary>
        /// Записать массив байтов в выходной поток
        /// </summary>
        /// <param name="b">Массив байтов для записи</param>
        public void Write(byte[] b)
        {
            _os.Write(b, 0, b.Length);
        }

        /// <summary>
        /// Записать массив байтов в выходной поток, начиная с определенной позиции и указанной длиной
        /// </summary>
        /// <param name="b">Массив байтов для записи</param>
        /// <param name="off">Начальное смещение в массиве</param>
        /// <param name="len">Количество байтов для записи</param>
        public void Write(byte[] b, int off, int len)
        {
            _os.Write(b, off, len);
        }

        /// <summary>
        /// Промывка выходного потока для приема входящих данных
        /// </summary>
        public void Flush()
        {
            _os.Flush();
        }

        /// <summary>
        /// Прочитать следующий байт из потока
        /// </summary>
        /// <returns>Следующий байт потока, или -1, если поток достиг конца</returns>
        public int Read()
        {
            return _isStream.ReadByte();
        }

        /// <summary>
        /// Прочитать данные и сохранить их непосредственно в массив байтов
        /// </summary>
        /// <param name="b">Массив байтов для сохранения данных</param>
        /// <returns>Количество прочитанных байтов, или -1, если не было прочитано ни одного байта</returns>
        public int Read(byte[] b)
        {
            return _isStream.Read(b, 0, b.Length);
        }

        /// <summary>
        /// Прочитать данные и сохранить их непосредственно в массив байтов, начиная с определенной позиции и указанной длиной
        /// </summary>
        /// <param name="b">Массив байтов для сохранения данных</param>
        /// <param name="off">Начальное смещение в массиве</param>
        /// <param name="len">Максимальное количество байтов для чтения</param>
        /// <returns>Количество прочитанных байтов, или -1, если не было прочитано ни одного байта</returns>
        public int Read(byte[] b, int off, int len)
        {
            return _isStream.Read(b, off, len);
        }

        /// <summary>
        /// Пропустить и отбросить n байтов данных из этого входного потока. Метод Skip может по разным причинам пропустить некоторое меньшее количество байтов, возможно, 0. Это может произойти из-за любого из нескольких условий; достижение конца файла до пропуска n байтов - только одна из возможностей. Фактическое количество пропущенных байтов возвращается. Если n отрицательно, метод Skip для класса InputStream всегда возвращает 0, и ни один байт не пропускается. Подклассы могут обрабатывать отрицательное значение по-разному.
        /// </summary>
        /// <param name="n">Количество байтов для пропуска</param>
        /// <returns>Фактическое количество пропущенных байтов</returns>
        public long Skip(long n)
        {
            return _isStream.Seek(n, SeekOrigin.Current);
        }

        /// <summary>
        /// Получить количество доступных байтов для ввода
        /// </summary>
        /// <returns>Количество доступных байтов для ввода</returns>
        public int AvailableInput()
        {
            return (int)_isStream.Length;
        }

        /// <summary>
        /// Закрыть входной поток
        /// </summary>
        public void CloseInput()
        {
            _isStream.Close();
        }

        /// <summary>
        /// Закрыть выходной поток
        /// </summary>
        public void CloseOutput()
        {
            _os.Close();
        }

        /// <summary>
        /// Закрыть входной и выходной потоки
        /// </summary>
        public void Close()
        {
            CloseInput();
            CloseOutput();
        }

        /// <summary>
        /// Передать данные из входного в выходной поток
        /// </summary>
        public void Transfer()
        {
            byte[] buf = new byte[4096];
            int length;
            while ((length = _isStream.Read(buf, 0, buf.Length)) > 0)
            {
                _os.Write(buf, 0, length);
            }
        }

        /// <summary>
        /// Освобождает неуправляемые ресурсы, используемые объектом DataChannel, и необязательно освобождает управляемые ресурсы.
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
