using System;

namespace Task7Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte receptionTimeInMinutes = 10;
            byte minutesInHour = 60;
            uint queueSize;
            uint queueTimeInMinutes;
            uint waitingHours;
            uint waitingMinutes;

            Console.Write("Введите кол-во старушек: ");
            queueSize = Convert.ToUInt32(Console.ReadLine());
            queueTimeInMinutes = queueSize * receptionTimeInMinutes;
            waitingHours = queueTimeInMinutes / minutesInHour;
            waitingMinutes = queueTimeInMinutes % minutesInHour;
            Console.WriteLine("Вы должны отстоять в очереди " + waitingHours + " часа и " + waitingMinutes + " минут.");
        }
    }
}
