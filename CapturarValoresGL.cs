using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GraficoFromCSV
{
    internal class CapturarValoresGL
    {
        private static bool _isRunning = false;

        public static void Cancelar()
        {
            _isRunning = false;
        }

        public static void Exec(int frequenciaLeituraEmMilisegundos)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://login.flexscan.com.br/login");

            // Aguarda o login manual do usuário
            Console.WriteLine("Faça o login manualmente na Flexscan e pressione ENTER para continuar.");
            Console.ReadLine();

            string csvFile = $"valores_{DateTime.Now:yyyy-MM-dd}.csv";
            if (!File.Exists(csvFile))
                File.WriteAllText(csvFile, "Hora;Valor\n");

            _isRunning = true;
            try
            {
                while (_isRunning)
                {
                    try
                    {
                        IWebElement element = driver.FindElement(By.XPath("//p[strong[contains(text(),'Financeiro Acumulado')]]/following-sibling::p/strong"));
                        string valor = element.Text.Replace("R$", "").Replace(".", ""); // Extrai o texto (valor monetário) do elemento
                        string dataHora = DateTime.Now.ToString("HH:mm:ss");
                        string linha = $"{dataHora};{valor}\n";
                        File.AppendAllText(csvFile, linha);
                        Console.Write($"Registrado: {linha}");
                    }
                    catch (NoSuchElementException)
                    {
                        Console.WriteLine("Elemento não encontrado.");
                    }
                    Thread.Sleep(frequenciaLeituraEmMilisegundos); // Aguarda X milisegundos antes da próxima leitura
                }
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
