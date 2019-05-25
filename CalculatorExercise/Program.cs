using CalculatorExercise.Contracts;
using CalculatorExercise.Models;
using System;
using System.Windows.Forms;
using Unity;

namespace CalculatorExercise
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<CalculatorForm>());
        }

        /// <summary>
        /// This method is used for building Unity Container for resolving DI
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ICalculator, Calculator>();           
            return container;
        }
    }
}
