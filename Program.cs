using System;
using System.IO;

namespace SolidPractice
{
    public interface IWorker
    {
        void Work();
        void Eat();
        void CalculateBonus();
    }

    public class HumanWorker : IWorker
    {
        public void Work() => Console.WriteLine("Working hard.");
        public void Eat() => Console.WriteLine("Eating lunch in the breakroom.");
        public void CalculateBonus() => Console.WriteLine("Bonus calculated for human.");
    }

    public class RobotWorker : IWorker
    {
        public void Work() => Console.WriteLine("Working at 100% efficiency.");
        public void Eat() => throw new NotImplementedException("Robots do not eat!");
        public void CalculateBonus() => throw new NotImplementedException("Robots do not get bonuses!");
    }

    public class FileLogger
    {
        public void LogError(string message)
        {
            File.AppendAllText("error_log.txt", message + Environment.NewLine);
        }
    }

    public class EmployeeManager
    {
        private FileLogger _logger;

        public EmployeeManager()
        {
            _logger = new FileLogger();
        }

        public void ManageWorker(IWorker worker, string workerType)
        {
            Console.WriteLine("Starting management process...");

            worker.Work();

            if (workerType == "Human")
            {
                worker.Eat();
                worker.CalculateBonus();
            }
            else if (workerType == "Robot")
            {
                try
                {
                    worker.Eat();
                }
                catch (Exception ex)
                {
                    _logger.LogError("System failure: " + ex.Message);
                }
            }
            else if (workerType == "Intern")
            {
                worker.Eat();
                Console.WriteLine("Interns do not get bonuses yet.");
            }

            Console.WriteLine("Management process finished.");
        }
    }
}