using Serilog;

namespace GraficoFromCSV
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Inicializa o Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                // Registra tratamento global de exce��es
                Application.ThreadException += (sender, e) =>
                {
                    Log.Error(e.Exception, "Exce��o capturada");
                };

                AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                {
                    Log.Fatal(e.ExceptionObject as Exception, "Exce��o n�o tratada no dom�nio");
                    Application.Exit();
                };

                Application.Run(new FormPrincipal());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erro fatal na inicializa��o");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}