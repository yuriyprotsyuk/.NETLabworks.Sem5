using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ProtsyukIS63.V15
{
    /// <summary>
    /// Інтерфейс відвідувача
    /// </summary>
    interface IVisitor
    {
        void VisitColorPrin(ColorPrinter prin);
        void VisitBlackPrin(BlackPrinter prin);
    }
    /// <summary>
    /// Відвідувач для кольорового друку
    /// </summary>
    class ColorVisitor : IVisitor
    {
        /// <summary>
        /// Тип друку
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Відвідування кольорового принтера
        /// </summary>
        /// <param name="prin"></param>
        public void VisitColorPrin(ColorPrinter prin)
        {
            Console.WriteLine("Задача: " + Type);
            prin.ColorPrinting();
        }
        /// <summary>
        /// Відвідування чорно-білого принтера
        /// </summary>
        /// <param name="prin"></param>
        public void VisitBlackPrin(BlackPrinter prin)
        {
            Console.WriteLine("Задача: " + Type);
            prin.BlackPrintColor();

        }
    }
    /// <summary>
    /// Відвідувач чорно-білого друку
    /// </summary>
    class BlackVisitor : IVisitor
    {
        /// <summary>
        /// Тип друку
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Відвідування кольорового принтера
        /// </summary>
        /// <param name="prin"></param>
        public void VisitColorPrin(ColorPrinter prin)
        {
            Console.WriteLine("Задача: " + Type);
            prin.ColorPrinting();

        }
        /// <summary>
        /// Відвідування чорно-білого принтера
        /// </summary>
        /// <param name="prin"></param>
        public void VisitBlackPrin(BlackPrinter prin)
        {
            Console.WriteLine("Задача: " + Type);
            prin.BlackPrintBlack();
        }
    }
}
