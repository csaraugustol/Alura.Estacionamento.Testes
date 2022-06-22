using Xunit;
using System;
using Xunit.Abstractions;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class TipoVeiculoTestes: IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public TipoVeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor Invocado");
            veiculo = new Veiculo();
        }

        [Fact(DisplayName = "Verifica se o tipo do veículo é um automóvel")]
        [Trait("Funcionalidade", "Tipo")]
        public void TestaTipoDeVeiculoEhAutomovel()
        {
            veiculo.Tipo = TipoVeiculo.Automovel;

            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact]
        public void TestaTipoDeVeiculoEhMotocicleta()
        {
            veiculo.Tipo = TipoVeiculo.Motocicleta;

            Assert.Equal(TipoVeiculo.Motocicleta, veiculo.Tipo);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void TesteValidaNomeProprietario()
        {
            //
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose Invocado");
        }
    }
}
