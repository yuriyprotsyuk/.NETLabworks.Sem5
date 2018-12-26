using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ProtsyukIS63.V15
{
    /// <summary>
    /// Середовище проживання
    /// </summary>
    interface IHabitat
    {
        void Live();
        void Breathe();
    }
    /// <summary>
    /// Водне середовище
    /// </summary>
    class WaterEnvironment : IHabitat
    {
        public void Live()
        {
            Console.WriteLine("Проживає у водному середовищi");
        }
        public void Breathe()
        {
            Console.WriteLine("Дихає киснем розчиненим у водi");
        }
    }
    /// <summary>
    /// Повітряне середовище
    /// </summary>
    class AirEnviroment : IHabitat
    {
        public void Live()
        {
            Console.WriteLine("Проживає у повiтряному середовищi");
        }
        public void Breathe()
        {
            Console.WriteLine("Дихає киснем з повiтря");
        }

    }
    /// <summary>
    /// Підземне середовище
    /// </summary>
    class Underground : IHabitat
    {
        public void Live()
        {
            Console.WriteLine("Проживає у пiдземному середовищi");
        }
        public void Breathe()
        {
            Console.WriteLine("Дихає киснем, що є в грунтi");
        }
    }
}
