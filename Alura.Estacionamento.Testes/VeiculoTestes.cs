using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact]
        public void AcelerarVeiculoTeste()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Action
            veiculo.Acelerar(15);
            //Assert
            Assert.Equal(150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FrearVeiculoTeste()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(20);
            Assert.Equal(-300, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TipoVeiculoTeste()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Tipo = TipoVeiculo.Automovel;
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }
    }
}
