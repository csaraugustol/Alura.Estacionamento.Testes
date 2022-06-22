using Xunit;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class TipoVeiculoTestes
    {
        [Fact]
        public void TestaTipoDeVeiculoEhAutomovel()
        {
            var veiculo = new Veiculo();

            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }
    }
}
