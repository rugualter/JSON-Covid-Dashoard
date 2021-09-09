using System;

using JSONCovidDash.Controllers;


namespace JSONCovidDash
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Controller controller = new Controller();
            controller.IniciarAplicacao();
        }
    }
}
