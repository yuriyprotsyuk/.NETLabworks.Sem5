using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ProtsyukIS63.V1
{
    /// <summary>
    /// Камера
    /// </summary>
    class Camera
    {
        /// <summary>
        ///Тип камери
        /// </summary>
        public int Type { get; set; }
    }
    /// <summary>
    /// Пам`ять вбудована
    /// </summary>
    class BuiltInMemory
    {
        /// <summary>
        /// Розмір пам'яті
        /// </summary>
        public int Size { get; set; }
    }
    /// <summary>
    /// Оперативна пам`ять
    /// </summary>
    class RAM
    {
        /// <summary>
        /// Розмір оперативної пам'яті
        /// </summary>
        public int Size { get; set; }
    }
    /// <summary>
    /// Акумулятор
    /// </summary>
    class Battery
    {
        /// <summary>
        /// Ємність акумулятора
        /// </summary>
        public int Capacity { get; set; }
    }
    /// <summary>
    /// Процесор
    /// </summary>
    class Processor
    {
        /// <summary>
        /// Частота
        /// </summary>
        public double Frequency { get; set; }
    }
    /// <summary>
    /// Операційна система
    /// </summary>
    class OS
    {
    }
    /// <summary>
    /// Смартфон
    /// </summary>
    class Smartphone
    {
        /// <summary>
        /// Назва смартфона
        /// </summary>
        public string name;
        /// <summary>
        /// Камера
        /// </summary>
        public Camera Camera { get; set; }
        /// <summary>
        /// Вбудована пам"ять
        /// </summary>
        public BuiltInMemory BuiltInMemory { get; set; }
        /// <summary>
        /// Оперативна пам"ять
        /// </summary>
        public RAM RAM { get; set; }
        /// <summary>
        /// Акумулятор
        /// </summary>
        public Battery Battery { get; set; }
        /// <summary>
        /// Процесор
        /// </summary>
        public Processor Processor { get; set; }
        /// <summary>
        /// Операційна система
        /// </summary>
        public OS OS { get; set; }
        /// <summary>
        /// Перезадання функції приведення до рядка
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            ///Будова рядка
            StringBuilder sb = new StringBuilder();
            ///Якщо атрибут не нульовий, то додати його у рядок
            if (name != null)
                sb.Append("Назва моделi: " + name + "\n");
            if (Camera != null)
                sb.Append("Камера: " + Camera.Type.ToString() + " МП\n");
            if (BuiltInMemory != null)
                sb.Append("Вбудована пам`ять: " + BuiltInMemory.Size.ToString() + " Гб\n");
            if (RAM != null)
                sb.Append("Оперативна пам`ять: " + RAM.Size.ToString() + " Гб\n");
            if (Battery != null)
                sb.Append("Ємнiсть акумулятора: " + Battery.Capacity.ToString() + " мАмп\n");
            if (Processor != null)
                sb.Append("Частота процесора: " + Processor.Frequency.ToString() + " ГГц\n");
            if (OS != null)
                sb.Append("Операцiйна система: Android\n");
            ///Повернути рядок
            return sb.ToString();
        }

    }
}
