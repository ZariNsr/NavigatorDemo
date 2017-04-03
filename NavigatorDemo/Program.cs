using Microsoft.Practices.Unity;
using NavigatorDemo.Application;
using NavigatorDemo.Interfaces;
using NavigatorDemo.Repositories;
using System;
namespace NavigatorDemo
{
    class Program
    {
        private static readonly log4net.ILog _loger = log4net.LogManager.GetLogger(typeof(Program));
        private static string _inputPath = "Input.txt";

        static void Main(string[] args)
        {   
            _loger.Debug("Application loading...");
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            var container = new UnityContainer();
            UnityMapping.RegisterElements(container);
            IInputOutput io = container.Resolve<IInputOutput>(new ParameterOverride("path", _inputPath));          
            IGameInitializer gameInitializer = container.Resolve<IGameInitializer>();   
            gameInitializer.Initialize();
            _loger.Debug("Application loaded.");
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Exception arg = (Exception)e.ExceptionObject;
            _loger.Error(string.Format("Error message: {0}, StackTrace: {1}", arg.Message, arg.StackTrace));
            Console.WriteLine("Hello " );
            Console.WriteLine("NavigatorDemo caught : " + arg.Message);
            Console.WriteLine("Application will be closed.");   
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
