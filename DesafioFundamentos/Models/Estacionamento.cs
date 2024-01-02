using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using DesafioFundamentos;
using System.Globalization;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial;
        private decimal _precoPorHora;

        private List<string> veiculos = new List<string>();
        
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            bool Validation = true;
            do{
                Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                                "Digite o preço inicial:");
                precoInicial = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Agora digite o preço por hora:");
                precoPorHora = Convert.ToDecimal(Console.ReadLine());

                if((precoInicial >= 0) && (precoPorHora > 0))
                {
                    this._precoInicial = precoInicial;
                    this._precoPorHora = precoPorHora;
                    Validation = false; 
                }
                else
                {
                    Console.WriteLine("valor invalido!");
                }
            }while(Validation);
        }

        public void AdicionarVeiculo()
        {

            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // IMPLEMENTADO
            Console.WriteLine("Digite a placa do veículo para estacionar:");           
            string VeiculoAdicionado = Console.ReadLine();
            
            if(VeiculoAdicionado.Length == 7)
            {
                veiculos.Add(VeiculoAdicionado);
            }
            else
            {
                Console.WriteLine("Placa Inválida!");
            }
        
        }

        public void RemoverVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // IMPLEMENTADO
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // IMPLEMENTADO
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = (_precoInicial + (horas*_precoPorHora)); 
                // TODO: Remover a placa digitada da lista de veículos
                // IMPLEMENTADO
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("c2")}");
            }
            else
            {
                Console.WriteLine($"\nDesculpe, veículo {placa} não encontrado. Confira se digitou a placa corretamente\n");
                Console.WriteLine("\nOs veículos estacionados são:");
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"Nº - {i+1} - PLACA: {veiculos[i].ToUpper()}");
                }               
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // IMPLEMENTADO
                Console.WriteLine("Lista de Carros:");
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"Nº - {i+1} - PLACA: {veiculos[i].ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
                    
            }
        }
    }
}
