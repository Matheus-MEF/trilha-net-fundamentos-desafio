namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private Dictionary<string, DateTime> veiculos = new Dictionary<string, DateTime>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            // o this indica que estamos referenciando o atributo da classe
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite a hora de entrada do veículo (formato HH:mm):");

            DateTime horaEntrada;

            while (!DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, System.Globalization.DateTimeStyles.None, out horaEntrada))
            {
            Console.WriteLine(" Formato inválido! Digite novamente no formato HH:mm (ex: 08:30):");
            }

            veiculos.Add(placa, horaEntrada);
            
            Console.WriteLine($"Veículo {placa} adicionado com sucesso ás {horaEntrada}");

            
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            // o metodo contaiskey verifica se a placa existe 
            if (veiculos.ContainsKey(placa))
            {
            Console.WriteLine("Digite a hora de entrada do veículo (formato HH:mm):");

            DateTime horaSaida;

            while (!DateTime.TryParseExact(Console.ReadLine(), "HH:mm", null, System.Globalization.DateTimeStyles.None, out horaSaida))
            {
            Console.WriteLine(" Formato inválido! Digite novamente no formato HH:mm (ex: 08:30):");
            }

                DateTime horaEntrada = veiculos[placa];
                TimeSpan tempoEstacionado = horaSaida - horaEntrada;

                int horas = (int)Math.Ceiling(tempoEstacionado.TotalHours);

                decimal valorTotal = precoInicial + (precoPorHora * horas);
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo.Key}, Hora de Entrada: {veiculo.Value}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
