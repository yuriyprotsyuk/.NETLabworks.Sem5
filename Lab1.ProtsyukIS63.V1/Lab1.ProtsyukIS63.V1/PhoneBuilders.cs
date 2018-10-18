using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ProtsyukIS63.V1
{
    /// <summary>
    /// Абстрактний клас будівельника сматрфонів
    /// </summary>
    abstract class PhoneBuilder
    {
        /// <summary>
        /// Смартфон
        /// </summary>
        public Smartphone Smartphone { get; private set; }
        /// <summary>
        /// Виклик конструктора смартфона
        /// </summary>
        public void makeSmartphone()
        {
            Smartphone = new Smartphone();
        }
        /// <summary>
        /// Встановлення атрибутів смартфона
        /// </summary>
        public abstract void SetName();
        public abstract void SetCamera();
        public abstract void SetBuiltInMemory();
        public abstract void SetRAM();
        public abstract void SetBattery();
        public abstract void SetProcessor();
        public abstract void SetOS();

    }
    /// <summary>
    /// Клас будівельника бюджетного смартфона, що успадковується від абстрактного будівельника
    /// </summary>
    class CheapPhoneBuilder : PhoneBuilder
    {
        /// <summary>
        /// Перезадання функції встановлення значення поля назва смартфона
        /// </summary>
        public override void SetName()
        {
            this.Smartphone.name = "EconomPhone";
        }

        public override void SetCamera()
        {
            this.Smartphone.Camera = new Camera { Type = 12 };
        }
        public override void SetBuiltInMemory()
        {
            this.Smartphone.BuiltInMemory = new BuiltInMemory { Size = 16 };
        }
        public override void SetRAM()
        {
            this.Smartphone.RAM = new RAM { Size = 2 };
        }
        public override void SetBattery()
        {
            this.Smartphone.Battery = new Battery { Capacity = 3000 };
        }
        public override void SetProcessor()
        {
            this.Smartphone.Processor = new Processor { Frequency = 1.7 };
        }
        public override void SetOS()
        {
            this.Smartphone.OS = new OS { };
        }
    }
    /// <summary>
    /// Клас будівельника смартфона середнього класу, що успадковується від абстрактного будівельника
    /// </summary>
    class MidlePhoneBuilder : PhoneBuilder
    {
        public override void SetName()
        {
            this.Smartphone.name = "MidlePhone";
        }
        public override void SetCamera()
        {
            this.Smartphone.Camera = new Camera { Type = 18 };
        }
        public override void SetBuiltInMemory()
        {
            this.Smartphone.BuiltInMemory = new BuiltInMemory { Size = 32 };
        }
        public override void SetRAM()
        {
            this.Smartphone.RAM = new RAM { Size = 4 };
        }
        public override void SetBattery()
        {
            this.Smartphone.Battery = new Battery { Capacity = 3500 };
        }
        public override void SetProcessor()
        {
            this.Smartphone.Processor = new Processor { Frequency = 2.5 };
        }
        public override void SetOS()
        {
            this.Smartphone.OS = new OS { };
        }
    }
    /// <summary>
    /// Клас будівельника преміум-смартфона, що успадковується від абстрактного будівельника
    /// </summary>
    class ExtraPhoneBuilder : PhoneBuilder
    {
        public override void SetName()
        {
            this.Smartphone.name = "ExtraPhone";
        }
        public override void SetCamera()
        {
            this.Smartphone.Camera = new Camera { Type = 24 };
        }
        public override void SetBuiltInMemory()
        {
            this.Smartphone.BuiltInMemory = new BuiltInMemory { Size = 128 };
        }
        public override void SetRAM()
        {
            this.Smartphone.RAM = new RAM { Size = 8 };
        }
        public override void SetBattery()
        {
            this.Smartphone.Battery = new Battery { Capacity = 4000 };
        }
        public override void SetProcessor()
        {
            this.Smartphone.Processor = new Processor { Frequency = 3.3 };
        }
        public override void SetOS()
        {
            this.Smartphone.OS = new OS { };
        }
    }

}
