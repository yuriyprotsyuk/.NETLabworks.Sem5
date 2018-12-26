using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.ProtsyukIS63.V15
{
    /// <summary>
    /// Система принтерів, що складається з принтерів
    /// </summary>
    class PrintSystem
    {
        /// <summary>
        /// Список наявних принтерів
        /// </summary>
        List<IPrinter> printers = new List<IPrinter>();
        public void Add(IPrinter prin)
        {
            printers.Add(prin);
        }
        public void Remove(IPrinter prin)
        {
            printers.Remove(prin);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (IPrinter prin in printers)
                prin.Accept(visitor);
        }


    }
}
