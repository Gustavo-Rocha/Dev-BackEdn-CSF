using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace ALura.Estacionamento.Testes
{
    public class VeiculoTests : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper _testOutputHelper; 

        public VeiculoTests(ITestOutputHelper testOutputHelper)
        {
            veiculo = new Veiculo();
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("Invoca Construtor");

        }

        [Fact]
        [Trait("funcionalidade","Acelerar")]
        public void TestaVeliculoAcelerarComParametro10()
        {
            //Arrange
           // var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("funcionalidade", "Frear")]
        public void TestaVeliculoFrearComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip ="pular teste ")]
        public void TestaNomeDoProprietarioDoVeiculo()
        {

        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void ImprimeFichaDeInformacoesDoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "jao";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "black";
            veiculo.Modelo = "GOl";
            veiculo.Placa = "abc-1234";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do veiculo:", dados);
        }

        [Fact(Skip = "codifgo sem implementaçao para essa exception")]
        public void TEstaNomeProprietarioCOmTresCaracteres()
        {
            //arrange
            string nomeProprietario = "ab";

            //assert
            Assert.Throws<FormatException>(
                //act
                () => new Veiculo(nomeProprietario));
        }

        [Fact]
        public void TEstaMensagemDeExceptionDoQuartoCaractereDaPlaca()
        {
            //arrange
            string placa = "asdf1234";

            //assert
            var mensagem = Assert.Throws<FormatException>( () => new Veiculo().Placa = placa);

            //assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("Invoca Construtor");
        }
    }
}
