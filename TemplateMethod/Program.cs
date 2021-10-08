using System;

namespace TemplateMethod
{
    abstract class Hardware
    {
        // Propriedades básicas de um hardware
        protected string Tipo { get; set; }
        protected string Nome { get; set; }
        protected string Fabricante { get; set; }

        // Esqueleto do algoritmo
        public void TemplateMethod(string tipo)
        {
            Tipo = tipo;

            PrepararWMI(Tipo);
            Hook1();
            ColetarDados();
            ProcessarDadosColetados();
            Hook2();
            MontarRelatorio();
            
        }

        // Esse método prepara o Windows Management Instrumentation de acordo com a classe a ser lida
        protected void PrepararWMI(string hardware)
        {
            Console.WriteLine("Preparando a query de busca de acordo com o hardware...");
            switch (hardware)
            {
                // Processador
                case "CPU":
                    Console.WriteLine("Query de busca WMI configurada para a classe Win32_Processor");
                    break;

                // Placa de vídeo
                case "GPU":
                    Console.WriteLine("Query de busca WMI configurada para a classe Win32_VideoController");
                    break;

                default:
                    Console.WriteLine("Hardware não configurado para busca");
                    break;
            }
        }

        // Esse método monta como o relatório será exibido
        protected void MontarRelatorio()
        {
            Console.WriteLine("Montando relatório com os dados coletados...");
            Console.WriteLine("Tipo: {0}\nNome: {1}\nFabricante: {2}", Tipo, Nome, Fabricante);

        }

        // Esse método coleta os dados de acordo com as necessidades de cada tipo de hardware
        protected abstract void ColetarDados();

        // Esse método processa os dados coletados de acordo com as necessidade de cada tipo de hardware
        protected abstract void ProcessarDadosColetados();


        // Método gancho para extensão
        protected virtual void Hook1() { }

        // Método gancho para extensão
        protected virtual void Hook2() { }
    }

    class CPU : Hardware
    {
        protected override void ColetarDados()
        {
            Console.WriteLine("Buscando dados do processador na classe do WMI...");
            Nome = "AMD Ryzen 7 2700X";
            Fabricante = "Advanced Micro Devices, Inc.";
        }

        protected override void ProcessarDadosColetados()
        {
            Console.WriteLine("Processando dados coletados do processador...");
        }
    }

    class GPU : Hardware
    {
        protected override void ColetarDados()
        {
            Console.WriteLine("Buscando dados da placa de vídeo na classe do WMI...");
            Nome = "NVIDIA GTX 1060 6GB";
            Fabricante = "Nvidia Corporation";
        }

        protected override void ProcessarDadosColetados()
        {
            Console.WriteLine("Processando dados coletados da placa de vídeo...");
        }
    }

    class Client
    {
        public static void CodigoCliente(Hardware hardware, string tipo)
        {
            // Código cliente...
            hardware.TemplateMethod(tipo);
            // Código cliente..
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client.CodigoCliente(new CPU(), "CPU");

            Console.Write("\n");

            Client.CodigoCliente(new GPU(), "GPU");
        }
    }
}
