using System;

namespace SimpleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger;

            string loggerType = "database";

            switch(loggerType)
            {
                case "database":
                    logger = new DatabaseLogger();
                    break;
                default:
                    logger = new TextLogger();
                    break;

            }

            LoggerManager loggerManager = new LoggerManager(logger);

            try
            {
                throw new DivideByZeroException();
            }
            catch(Exception e)
            {
                loggerManager.Log(e.Message);
                Console.ReadLine();
            }
         
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class LoggerManager
    {
        private ILogger _logger;

        public LoggerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }
    }

    class TextLogger :ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Log to a text file: " + message);
        }
    }
    class DatabaseLogger : ILogger
    {
        public void Log(string messaage)
        {
            Console.WriteLine("Log to a database :" + messaage);
        }
    }
}
