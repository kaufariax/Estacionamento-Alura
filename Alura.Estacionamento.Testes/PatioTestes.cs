using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void FaturamentoTeste()
        {
            Patio estacionamento = new Patio();

            var veiculo = new Veiculo();
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
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);
        }

    }
}
