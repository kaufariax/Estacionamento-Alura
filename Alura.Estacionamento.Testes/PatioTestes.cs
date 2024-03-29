﻿using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        private Operador operador;

        public PatioTestes()
        {
            veiculo = new Veiculo();
            estacionamento = new Patio();
            operador = new Operador();
            operador.Nome = "Mathias Fagundes";
        }
        [Fact]
        public void FaturamentoTeste()
        {
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = "Kau Farias";
            veiculo.Placa = "ABC-0101";
            veiculo.Modelo = "Toyota";
            veiculo.Acelerar(10);
            veiculo.Frear(5);

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Kau Farias", "AAA-0001", "Preto", "Gol")]
        [InlineData("Julio Cesar", "BBB-0002", "Cinza", "Toyota")]
        [InlineData("Gugu Carvalho", "CCC-0003", "Azul", "Opala")]
        [InlineData("Richard Santos", "DDD-0004", "Vermelho", "Corsa")]
        public void FaturamentoComVariosVeiculosTeste(string proprietario, string placa, string cor, string modelo)
        {
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Kau Farias", "AAA-0001", "Preto", "Gol")]
        public void VeiculoNoPatioTeste(string proprietario,
                                           string placa,
                                           string cor,
                                           string modelo)
        {
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            Assert.Contains("Ticket Estacionamento da Kau", consultado.Ticket);

        }

        [Fact]
        public void AlteracaoDadosVeiculoTeste()
        {
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = "Kau Farias";
            veiculo.Placa = "AAA-0001";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Gol";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Kau Farias";
            veiculoAlterado.Placa = "AAA-0001";
            veiculoAlterado.Cor = "Vermelho"; //Alterado
            veiculoAlterado.Modelo = "Gol";

            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }



    }
}
