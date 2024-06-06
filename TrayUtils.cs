using System;
using System.Drawing;
using System.Windows.Forms;

namespace org.ReStudios.utitlitium
{
    public class TrayUtils
    {
        private NotifyIcon trayIcon;

        /// <summary>
        /// Проверяет, поддерживается ли системный трей.
        /// </summary>
        /// <returns>true, если трей поддерживается</returns>
        public static bool IsSupported()
        {
            return true; // Здесь всегда возвращается true, так как мы не проверяем реальную поддержку трея
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="title">Заголовок приложения в трее</param>
        public TrayUtils(string title)
        {
            if (!IsSupported()) return; // Если трей не поддерживается, выходим из конструктора
            trayIcon = new NotifyIcon(); // Создаем новый элемент уведомления
            trayIcon.Icon = new Icon(SystemIcons.Application, 16, 16); // Устанавливаем иконку приложения
            trayIcon.Text = title; // Устанавливаем текст приложения
            trayIcon.Visible = true; // Делаем иконку видимой
        }

        /// <summary>
        /// Конструктор с изображением приложения
        /// </summary>
        /// <param name="title">Заголовок приложения</param>
        /// <param name="icon">Иконка приложения</param>
        public TrayUtils(string title, Icon icon) : this(title)
        {
            SetIcon(icon); // Устанавливаем иконку
        }

        /// <summary>
        /// Создает уведомление в системном трее
        /// </summary>
        /// <param name="title">Заголовок уведомления</param>
        /// <param name="message">Тело уведомления</param>
        /// <param name="msgType">Тип уведомления</param>
        public void Notification(string title, string message, ToolTipIcon msgType)
        {
            trayIcon.ShowBalloonTip(0, title, message, msgType); // Показываем всплывающее уведомление
        }

        /// <summary>
        /// Изменяет иконку во время выполнения
        /// </summary>
        /// <param name="image">Новая иконка</param>
        public void SetIcon(Icon image)
        {
            trayIcon.Icon = new Icon(image, 16, 16); // Устанавливаем новую иконку
        }

        /// <summary>
        /// Изменяет заголовок во время выполнения
        /// </summary>
        /// <param name="ttt">Новый заголовок</param>
        public void SetTooltipText(string ttt)
        {
            trayIcon.Text = ttt; // Устанавливаем новый текст
        }

        /// <summary>
        /// Устанавливает пользовательское контекстное меню
        /// </summary>
        /// <param name="menu">Меню</param>
        public void SetPopupMenu(ContextMenuStrip menu)
        {
            trayIcon.ContextMenuStrip = menu; // Устанавливаем контекстное меню
        }

        /// <summary>
        /// Обработчик двойного щелчка ¯\_(ツ)_/¯
        /// </summary>
        /// <param name="lis">Обработчик события</param>
        public void AddDoubleClickListener(EventHandler lis)
        {
            trayIcon.DoubleClick += lis; // Добавляем обработчик события двойного щелчка
        }
    }
}
