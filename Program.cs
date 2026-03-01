using System;
using System.IO;

namespace SolidPractice
{

    public interface ICanWork { void Work(); }

    public interface ICanEat { void Eat(); }

    public interface IHaveBonus { void CalculateBonus(); }

    public interface ILogger { void LogError(string message); }

    public class HumanWorker : ICanWork, ICanEat, IHaveBonus
    {
        public void Work() => Console.WriteLine("Working hard.");

        public void Eat() => Console.WriteLine("Eating lunch in the breakroom.");

        public void CalculateBonus() => Console.WriteLine("Bonus calculated for human.");
    }

    public class RobotWorker : ICanWork
    {
        public void Work() => Console.WriteLine("Working at 100% efficiency.");
    }

    public class Intern : ICanEat, ICanWork
    {
        public void Work() => System.Console.WriteLine("Working as an Intern");

        public void Eat() => System.Console.WriteLine("Food here is great");
    }

    public class FileLogger : ILogger
    {
        public void LogError(string message)
        {
            File.AppendAllText("error_log.txt", message + Environment.NewLine);
        }
    }

    public class EmployeeManager
    {
        private readonly ILogger _logger;

        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }

        public void ManageWorker(ICanWork worker)
        {
            Console.WriteLine("Starting management process...");

            try
            {
                worker.Work();

                if (worker is ICanEat canEat)
                {
                    canEat.Eat();
                }

                if (worker is IHaveBonus haveBonus)
                {
                    haveBonus.CalculateBonus();
                }
            }

            catch (Exception ex)
            {
                _logger.LogError("System failure: " + ex.Message);
            }

            Console.WriteLine("Management process is finished!");
        }
    }
}