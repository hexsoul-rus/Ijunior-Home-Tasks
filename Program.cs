using System;

namespace Task7Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte receptionMinutesTime = 10;
            byte hour = 60;
            uint queueCount;
            uint queueHoursTime;
            uint queueMinutesTime;

            Console.Write("Введите кол-во старушек: ");
            queueCount = Convert.ToUInt32(Console.ReadLine());
            queueHoursTime = queueCount * receptionMinutesTime / hour;
            queueMinutesTime = queueCount * receptionMinutesTime % hour;
            Console.WriteLine("Вы должны отстоять в очереди " + queueHoursTime + " часа и " + queueMinutesTime + " минут.");
        }
    }
}
