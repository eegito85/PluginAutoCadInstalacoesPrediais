using FazEletricaCAD.Entidades;
using FazEletricaCAD.Funcoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FazEletricaCAD.Formularios
{
    public partial class FormularioQuantitativo : Form
    {
        ComandosCAD cad = new ComandosCAD();
        Quantitativo planilha = new Quantitativo();
        ManipularListasElementos listas = new ManipularListasElementos();

        List<BlocoComAtributo> listaBlocos = new List<BlocoComAtributo>();
        List<LinhaComAtributo> listaDutos = new List<LinhaComAtributo>();

        List<BlocoComAtributo> listaBlocosAtualizada = new List<BlocoComAtributo>();

        Elemento elemento = new Elemento();
        List<Elemento> listaElementos = new List<Elemento>();

        public FormularioQuantitativo()
        {
            InitializeComponent();
        }

        private void btGerarArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                listaBlocosAtualizada = AtualizarListaBlocos();
                planilha.GerarPlanilhaExcel(listaBlocosAtualizada, listaDutos);
            }
            catch { }
        }

        private void btSelecionarProjeto_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            listaElementos = cad.SelecionarBlocos();

            listaBlocos = listas.MontarListaDeBlocos(listaElementos);
            listaDutos = cad.SelecionarDuto();
            listaDutos = listas.CorrigirListaDeDutos(listaDutos);

            PreencherTabelaBlocos();
            PreencherTabelaDutos();

            this.Show();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioQuantitativo_Load(object sender, EventArgs e)
        {
            //PreencherDataGridView();
        }

        private void PreencherTabelaBlocos()
        {
            foreach(BlocoComAtributo block in listaBlocos)
            {
                DGVQuantitativoBlocos.Rows.Add(false , block.ID, block.Nome, block.Especificacao, block.Quantidade);
            }
        }

        private void PreencherTabelaDutos()
        {
            foreach (LinhaComAtributo dut in listaDutos)
            {
                DGVQuantitativoDutos.Rows.Add(dut.ID, dut.Nome, dut.Descricao, dut.Comprimento);
                //DGVQuantitativoBlocos.Rows.Add(dut.ID, dut.Nome, dut.Comprimento);
            }
        }
        
        private void btExcluirItens_Click(object sender, EventArgs e)
        {
            ExcluirLinhasSelecionadasTabelaBlocos();
        }

        private void ExcluirLinhasSelecionadasTabelaBlocos()
        {
            foreach (DataGridViewRow linha in DGVQuantitativoBlocos.Rows)
            {
                if (bool.Parse(linha.Cells[0].EditedFormattedValue.ToString())) { DGVQuantitativoBlocos.Rows.Remove(linha); }
            }
        }

        private List<BlocoComAtributo> AtualizarListaBlocos()
        {
            foreach (DataGridViewRow linha in DGVQuantitativoBlocos.Rows)
            {
                if (linha.Cells[1].Value != null)
                {
                    BlocoComAtributo bloco = new BlocoComAtributo();
                    bloco.ID = Convert.ToString(linha.Cells[1].Value);
                    bloco.Nome = linha.Cells[2].Value.ToString();
                    bloco.Especificacao = linha.Cells[3].Value.ToString();
                    bloco.Quantidade = linha.Cells[4].Value.ToString();

                    listaBlocosAtualizada.Add(bloco);
                }

            }
            return listaBlocosAtualizada;
        }

    }
}
