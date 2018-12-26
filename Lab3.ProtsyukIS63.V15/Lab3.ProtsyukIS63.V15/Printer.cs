using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ProtsyukIS63.V15
{

    /// <summary>
    /// Інтерфейс принтера
    /// </summary>
    interface IPrinter
    {
        void Accept(IVisitor vistor);
    }
    /// <summary>
    /// Кольоровий принтер
    /// </summary>
    class ColorPrinter : IPrinter
    {
        public string Type { get; set; }
        public string Firm { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitColorPrin(this);
        }
        public void ColorPrinting()
        {
            string result = "Тип: " + this.Type + "\nФiрма-виробник: " + this.Firm + "\n" + "1.Налаштування параметрiв друку\n" + "2.Приготування друку\n" + "3.Друк";
            Console.WriteLine(result);
            Console.WriteLine();

        }

    }
    /// <summary>
    /// Чорно-білий принтер
    /// </summary>
    class BlackPrinter : IPrinter
    {
        public string Type { get; set; }
        public string Firm { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitBlackPrin(this);
        }
        public void BlackPrintColor()
        {
            string result = "Тип: " + this.Type + "\nФiрма-виробник: " + this.Firm + "\n" + "1.Налаштування параметрiв друку\n"
    + "2.Можливий лише чорно-бiлий друк\n" + "3.Друкувати?\n";
            Console.WriteLine(result);
            Console.WriteLine("1.Так\n2.Нi\n");
            string s = Console.ReadLine();
            string res2;
            if (s == "1")
                res2 = "4.Приготування чорно-бiлого друку\n" + "5.Друк\n";
            else
                res2 = "4.Скасування друку\n";
            Console.WriteLine(res2);
            Console.WriteLine();

        }
        public void BlackPrintBlack()
        {
            string result = "Тип: " + this.Type + "\nФiрма-виробник: " + this.Firm + "\n" + "1.Налаштування параметрiв друку\n" + "2.Приготування друку\n" + "3.Друк";
            Console.WriteLine(result);
            Console.WriteLine();

        }
    }
}
