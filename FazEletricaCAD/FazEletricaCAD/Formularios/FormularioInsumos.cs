using FazEletricaCAD.Funcoes;
using Microsoft.WindowsAPICodePack.Shell;
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
    public partial class FormularioInsumos : Form
    {
        LeituraPastasArquivos folders = new LeituraPastasArquivos();
        ComandosCAD cad = new ComandosCAD();
        List<string> listaPastasCategorias = new List<string>();
        List<string> listaBlocosPorCategoria = new List<string>();

        public FormularioInsumos()
        {
            InitializeComponent();
        }

        private void FormularioInsumos_Load(object sender, EventArgs e)
        {
            listaPastasCategorias = folders.LerPastasCategorias();
            CarregarCategorias(listaPastasCategorias);
        }

        private void CarregarCategorias(List<string> lista)
        {
            ComboBoxInsumosE.Items.Clear();
            if (lista != null)
            {
                foreach (string categoria in lista)
                {
                    ComboBoxInsumosE.Items.Add(categoria);
                }
            }
        }

        private void ComboBoxInsumosE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string categoria = ComboBoxInsumosE.SelectedItem.ToString();
                listaBlocosPorCategoria = folders.LerBlocosPorCategoria(categoria);
                CarregarBlocos(listaBlocosPorCategoria);
            }
            catch { }
        }

        private void CarregarBlocos(List<string> lista)
        {
            ListBoxInsumosE.Items.Clear();
            foreach(string bloco in lista)
            {
                ListBoxInsumosE.Items.Add(bloco);
            }
        }

        private void GerarThumbnailDoArquivo(string caminhoArquivo)
        {
            //Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            //Image image = new Bitmap(caminhoArquivo);
            //Image image = Image.FromFile(caminhoArquivo);
            //Image pThumbnail = image.GetThumbnailImage(200, 160, callback, IntPtr.Zero);
            ShellFile shellFile = ShellFile.FromFilePath(caminhoArquivo);
            ShellThumbnail thumbnail = shellFile.Thumbnail;
            Image image = thumbnail.Bitmap;
            PictureBoxEletrica.Image = image;
            PictureBoxEletrica.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void ListBoxInsumosE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("Entrou aqui");
                string nomeCategoria = ComboBoxInsumosE.SelectedItem.ToString();
                string nomeBloco = ListBoxInsumosE.SelectedItem.ToString();
                string caminho = folders.RetornaCaminhoCompletoArquivo(nomeCategoria, nomeBloco);
                GerarThumbnailDoArquivo(caminho);
            }
            catch { }
        }

        private void BtInserirInsumosE_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeCategoria = ComboBoxInsumosE.SelectedItem.ToString();
                string nomeBloco = ListBoxInsumosE.SelectedItem.ToString();
                string caminho = folders.RetornaCaminhoCompletoArquivo(nomeCategoria, nomeBloco);
                this.Hide();
                cad.InserirBlocoNoDesenho(caminho);
                this.Show();
            }
            catch { }
            
        }
    }
}
