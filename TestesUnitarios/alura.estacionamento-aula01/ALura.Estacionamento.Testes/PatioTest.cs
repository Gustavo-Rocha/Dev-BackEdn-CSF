using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ALura.Estacionamento.Testes
{
    public class PatioTest : IDisposable
    {

        private Veiculo veiculo;
        public ITestOutputHelper _testOutputHelper;

        public PatioTest(ITestOutputHelper testOutputHelper)
        {
            veiculo = new Veiculo();
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("Invoca Construtor");
        }

        [Fact]
        public void ValidaFaturamento()
        {
            var estaciomento = new Patio();
            veiculo.Proprietario = "gustavo";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "verde";
            veiculo.Modelo = "gol";
            veiculo.Placa = "abc-1234";

            estaciomento.RegistrarEntradaVeiculo(veiculo);
            estaciomento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estaciomento.TotalFaturado();

            //Assert

            Assert.Equal(2,faturamento);
        }

        [Theory]
        [InlineData("andre silva", "abc-1234", "preto","gol")]
        [InlineData("Cleide silva", "ccc-1234", "roxo", "lamborghini")]
        [InlineData("zuleica silva", "bbb-1234", "amarelo", "variant")]

        public void ValidaFaturamentoComVariosVeiculos(string nome, string placa, string cor, string modelo)
        {
            var estaciomento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = nome;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estaciomento.RegistrarEntradaVeiculo(veiculo);
            estaciomento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estaciomento.TotalFaturado();

            //Assert

            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("andre silva", "abc-1234", "preto", "gol")]
        public void LocalizaVeiculosComBAseNoIdTicket(string nome, string placa, string cor, string modelo)
        {
            var estaciomento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = nome;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estaciomento.RegistrarEntradaVeiculo(veiculo);
           

            //Act
            var consultado = estaciomento.PesquisaVeiculo(veiculo._idTicket);

            //Assert

            Assert.Contains("### Ticket MIlGrau##", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            var estaciomento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "jao";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "black";
            veiculo.Modelo = "GOl";
            veiculo.Placa = "abc-1234";

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "irineu";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "amarelo";
            veiculoAlterado.Modelo = "GOl";
            veiculoAlterado.Placa = "abc-1234";

            estaciomento.RegistrarEntradaVeiculo(veiculo);


            //Act
            var alterado = estaciomento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert

            Assert.Equal(alterado.Placa, veiculo.Placa);
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("Invoca Construtor");
        }
    }
}
