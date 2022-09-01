using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        private Veiculo veiculo;

        public VeiculoTestes()
        {
            veiculo = new Veiculo();
        }

        [Fact]
        public void AcelerarVeiculoTeste()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Action
            veiculo.Acelerar(15);

            //Assert
            Assert.Equal(150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FrearVeiculoTeste()
        {
            veiculo.Frear(20);
            Assert.Equal(-300, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TipoVeiculoTeste()
        {
            veiculo.Tipo = TipoVeiculo.Automovel;

            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void NomeProprietarioTeste()
        {

        }

        [Fact]
        public void DadosVeiculoTeste()
        {
            veiculo.Proprietario = "Kau Farias";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "AAA-0001";
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Gol";

            string dados = veiculo.ToString();

            Assert.Contains("Ficha do Veículo:", dados);

        }

        [Fact]
        public void NomeProprietarioComQuantidadeCaracteres()
        {
            string nomeProprietario = "Ab";

            Assert.Throws<FormatException>(
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaQuantidadeCaracteresPlacaVeiculo()
        {
            string placa = "Cd";

            var mensagem = Assert.Throws<FormatException>(

                () => new Veiculo().Placa = placa
            );
            Assert.Equal("A placa deve possuir 8 caracteres", mensagem.Message);
        }

    }
}
