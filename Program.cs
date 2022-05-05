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
            uint queueWaitingTimeInMinutes;
            uint waitingHours;
            uint waitingMinutes;

            Console.Write("Введите кол-во старушек: ");
            queueSize = Convert.ToUInt32(Console.ReadLine());
            queueWaitingTimeInMinutes = queueSize * receptionTimeInMinutes;
            waitingHours = queueWaitingTimeInMinutes / minutesInHour;
            waitingMinutes = queueWaitingTimeInMinutes % minutesInHour;
            Console.WriteLine("Вы должны отстоять в очереди " + waitingHours + " часа и " + waitingMinutes + " минут.");
        }
    }
}
