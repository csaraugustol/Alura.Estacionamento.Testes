using Xunit;
using System;
using System.Linq;
using System.Text;
using Xunit.Abstractions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes: IDisposable
    {
        private Veiculo veiculo;
        private Operador operador;
        private Patio estacionamento;

        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor Invocado");
            veiculo = new Veiculo();
            operador = new Operador();
            estacionamento = new Patio();
        }

        [Fact]
        public void TesteValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            veiculo.Proprietario = "Zezim";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Camaro";
            veiculo.Placa = "ABC-1234";

            operador.Nome = "Pedro";

            estacionamento.OpetadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Zezim", "ABC-1234", "Azul", "Camaro")]
        [InlineData("Gustim", "BCD-1234", "Preto", "Ferrari")]
        [InlineData("Pedrim", "CDE-1234", "Vermelho", "Corvette")]
        public void TesteValidaFaturamentoDoEstacionamentoComVariosVeiculos(string propietario, string placa, string cor, string modelo)
        {
            veiculo.Proprietario = propietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            operador.Nome = "Pedro";

            estacionamento.OpetadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            double faturamento = estacionamento.TotalFaturado();

            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Zezim", "ABC-1234", "Branco", "HB20")]
        public void TesteLocalizaVeiculoQueEstaNoPatioPeloIdTicket(string propietario, string placa, string cor, string modelo)
        {
            veiculo.Proprietario = propietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            operador.Nome = "Alfredo";

            estacionamento.OpetadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            Assert.Equal(veiculo.IdTicket, consultado.IdTicket);
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }


        [Fact]
        public void TesteAlteraDadosVeiculoQueEstaNoPatio()
        {
            veiculo.Proprietario = "Carlos";
            veiculo.Tipo = TipoVeiculo.Motocicleta;
            veiculo.Cor = "Preta";
            veiculo.Modelo = "Z-400";
            veiculo.Placa = "ZZZ-4000";

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Carlos";
            veiculoAlterado.Tipo = TipoVeiculo.Motocicleta;
            veiculoAlterado.Cor = "Verde";
            veiculoAlterado.Modelo = "Z-400";
            veiculoAlterado.Placa = "ZZZ-4000";

            operador.Nome = "Zezim";

            estacionamento.OpetadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose Invocado");
        }
    }
}
