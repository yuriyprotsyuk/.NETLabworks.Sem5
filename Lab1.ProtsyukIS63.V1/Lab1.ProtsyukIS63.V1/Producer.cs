using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ProtsyukIS63.V1
{
    /// <summary>
    /// Виробник смартфонів є єдиним, тому у його реалізації використано патерн Singleton
    /// </summary>
    class Producer
    {
        private static Producer instance;

        private static object syncRoot = new Object();

        protected Producer()
        {
        }

        public static Producer getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new Producer();
                }
            }
            return instance;
        }
        public Smartphone Create(PhoneBuilder phoneBuilder)
        {
            phoneBuilder.makeSmartphone();
            phoneBuilder.SetName();
            phoneBuilder.SetBattery();
            phoneBuilder.SetBuiltInMemory();
            phoneBuilder.SetCamera();
            phoneBuilder.SetRAM();
            phoneBuilder.SetProcessor();
            phoneBuilder.SetOS();
            return phoneBuilder.Smartphone;
        }
    }
    
}
