using System;
using System.Collections.Generic;
using System.Linq; // Necessário para o método .Any()

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        // Preço inicial para estacionar o veículo
        private decimal precoInicial = 0;
        // Preço por hora adicional
        private decimal precoPorHora = 0;
        // Lista para armazenar as placas dos veículos estacionados
        private List<string> veiculos = new List<string>();

        /// <summary>
        /// Construtor da classe Estacionamento.
        /// Inicializa o estacionamento com um preço inicial e um preço por hora.
        /// </summary>
        /// <param name="precoInicial">O preço inicial para o estacionamento.</param>
        /// <param name="precoPorHora">O preço cobrado por cada hora adicional.</param>
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        /// <summary>
        /// Adiciona um veículo ao estacionamento.
        /// Solicita a placa do veículo ao usuário e a adiciona à lista de veículos.
        /// </summary>
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            // Verifica se a placa não é nula ou vazia antes de adicionar
            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa.ToUpper()); // Armazena em maiúsculas para facilitar a comparação
                Console.WriteLine($"Veículo '{placa.ToUpper()}' adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("A placa não pode ser vazia. Por favor, digite uma placa válida.");
            }
        }

        /// <summary>
        /// Remove um veículo do estacionamento e calcula o valor total a ser pago.
        /// Solicita a placa e a quantidade de horas que o veículo permaneceu.
        /// </summary>
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placaParaRemover = Console.ReadLine();

            // Verifica se o veículo existe na lista (comparando sem distinção de maiúsculas/minúsculas)
            // Usamos .ToList() para evitar modificação da coleção enquanto a iteramos (se RemoveAll fosse usado diretamente no Any())
            if (veiculos.Any(x => x.ToUpper() == placaParaRemover.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = 0;

                // Tenta converter a entrada do usuário para um número inteiro de forma segura
                if (int.TryParse(Console.ReadLine(), out horas))
                {
                    // Calcula o valor total a ser pago
                    decimal valorTotal = precoInicial + (precoPorHora * horas);

                    // Remove o veículo da lista (remove todas as ocorrências que correspondem à placa)
                    // Usamos RemoveAll para garantir que todas as variações de caixa da mesma placa sejam removidas.
                    veiculos.RemoveAll(x => x.ToUpper() == placaParaRemover.ToUpper());

                    Console.WriteLine($"O veículo '{placaParaRemover.ToUpper()}' foi removido e o preço total foi de: R$ {valorTotal:F2}"); // :F2 formata para 2 casas decimais
                }
                else
                {
                    Console.WriteLine("Entrada inválida para horas. Por favor, digite um número inteiro.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        /// <summary>
        /// Lista todos os veículos que estão atualmente estacionados.
        /// </summary>
        public void ListarVeiculos()
        {
            // Verifica se há veículos na lista
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Itera sobre a lista e imprime cada placa
                foreach (var placa in veiculos)
                {
                    Console.WriteLine($"- {placa}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
            // Não há "return null;" porque o método é "void" e não retorna nada.
        }
    }
}
