using Xunit;
using System;
using Xunit.Abstractions;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes: IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor Invocado");
            veiculo = new Veiculo();
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            veiculo.Acelerar(10);

            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFreiarComParametro10()
        {
            veiculo.Frear(10);

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TesteRetornaOsDadosVeiculo()
        {
            veiculo.Proprietario = "Cesar";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Prata";
            veiculo.Modelo = "Jeep Compass";
            veiculo.Placa = "JEE-7121";

            string dados = veiculo.ToString();

            Assert.Contains("Ficha do Veículo:", dados);
        }

        [Fact]
        public void TesteLancandoUmaExcecaoQuandoInformarUmaPlacaComTamanhoMenorQueOito()
        {
            string placa = "ABC";

            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );

            Assert.Equal("A placa deve possuir 8 caracteres", mensagem.Message);
        }

        [Fact]
        public void TesteLancandoUmaExcecaoQuandoVerificaQuartoCaractereDaPlacaNaoEhHifen()
        {
            string placa = "ABCD1234";

            var mensagem =  Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose Invocado");
        }
    }
}
