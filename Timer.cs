using System;
using System.Collections.Generic;
using System.Linq;

namespace org.ReStudios.utitlitium
{
    /// <summary>
    /// Представляет таймер для измерения времени выполнения задач.
    /// </summary>
    public class Timer
    {
        private long startTime; // Время начала таймера
        private List<StepData> steps; // Список шагов таймера

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Timer"/>.
        /// </summary>
        public Timer()
        {
            startTime = 0;
            steps = new List<StepData>();
        }

        /// <summary>
        /// Запускает таймер.
        /// </summary>
        public void Run()
        {
            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds(); // Запоминаем текущее время в миллисекундах
        }

        /// <summary>
        /// Добавляет новый шаг в таймер.
        /// </summary>
        /// <returns>Объект <see cref="StepData"/>, представляющий информацию о шаге таймера.</returns>
        public StepData Step()
        {
            StepData before = steps.LastOrDefault(); // Получаем последний добавленный шаг
            StepData newData = new StepData(startTime, before == null ? startTime : before.finishTime, DateTimeOffset.Now.ToUnixTimeMilliseconds()); // Создаем новый шаг
            steps.Add(newData); // Добавляем новый шаг в список
            return newData; // Возвращаем созданный шаг
        }

        /// <summary>
        /// Возвращает общее время работы таймера.
        /// </summary>
        /// <returns>Общее время работы таймера в миллисекундах.</returns>
        public long Total()
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds() - startTime; // Вычисляем общее время работы таймера
        }

        /// <summary>
        /// Представляет информацию о шаге таймера.
        /// </summary>
        public class StepData
        {
            private long startTime; // Время начала шага
            private long stepBefore; // Время начала предыдущего шага
            public long finishTime; // Время окончания шага

            /// <summary>
            /// Инициализирует новый экземпляр класса <see cref="StepData"/>.
            /// </summary>
            /// <param name="startTime">Время начала шага в миллисекундах.</param>
            /// <param name="stepBefore">Время начала предыдущего шага в миллисекундах.</param>
            /// <param name="finishTime">Время окончания шага в миллисекундах.</param>
            public StepData(long startTime, long stepBefore, long finishTime)
            {
                this.startTime = startTime;
                this.stepBefore = stepBefore;
                this.finishTime = finishTime;
            }

            /// <summary>
            /// Возвращает относительное время выполнения шага.
            /// </summary>
            /// <returns>Относительное время выполнения шага в миллисекундах.</returns>
            public long Relative()
            {
                return finishTime - stepBefore; // Рассчитываем относительное время выполнения шага
            }

            /// <summary>
            /// Возвращает абсолютное время выполнения шага.
            /// </summary>
            /// <returns>Абсолютное время выполнения шага в миллисекундах.</returns>
            public long Absolute()
            {
                return finishTime - startTime; // Рассчитываем абсолютное время выполнения шага
            }

            /// <summary>
            /// Определяет, равен ли указанный объект текущему объекту.
            /// </summary>
            /// <param name="obj">Объект для сравнения.</param>
            /// <returns>Значение true, если указанный объект равен текущему объекту; в противном случае — значение false.</returns>
            public override bool Equals(object obj)
            {
                if (this == obj) return true; // Если ссылка на объект та же, что и ссылка на текущий объект, возвращаем true
                if (obj == null || GetType() != obj.GetType()) return false; // Если объект null или типы объектов не совпадают, возвращаем false
                StepData stepData = (StepData)obj; // Приводим объект к типу StepData
                return startTime == stepData.startTime && stepBefore == stepData.stepBefore && finishTime == stepData.finishTime; // Сравниваем поля объектов
            }

            /// <summary>
            /// Возвращает хэш-код для текущего объекта.
            /// </summary>
            /// <returns>Хэш-код для текущего объекта.</returns>
            public override int GetHashCode()
            {
                return HashCode.Combine(startTime, stepBefore, finishTime); // Генерируем хэш-код на основе значений полей объекта
            }

            /// <summary>
            /// Возвращает строковое представление объекта.
            /// </summary>
            /// <returns>Строковое представление объекта.</returns>
            public override string ToString()
            {
                return $"StepData{{relative={Relative()}ms,absolute={Absolute()}ms}}"; // Возвращаем строковое представление объекта
            }
        }
    }
}
