using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazEletricaCAD.Funcoes
{
    public class LeituraPastasArquivos
    {
        public List<string> LerPastasCategorias()
        {
            List<string> listaDePastas = new List<string>();

            string[] diretorios = Directory.GetDirectories(@"C:\Program Files\FazEletricaCAD\Insumos");
            string nomePasta = "";

            foreach (string dir in diretorios)
            {
                nomePasta = RetornarNomePasta(dir);
                listaDePastas.Add(nomePasta);
            }

            return listaDePastas;
        }

        private string RetornarNomePasta(string diretorio)
        {
            string[] nomes = diretorio.Split('\\');
            int qtd = nomes.Length;
            string nomePasta = nomes[qtd - 1];
            return nomePasta;
        }

        public List<string> LerBlocosPorCategoria(string nomeCategoria)
        {
            List<string> listaDeBlocos = new List<string>();
            nomeCategoria = nomeCategoria.TrimStart();
            nomeCategoria = nomeCategoria.TrimEnd();
            string diretorio = @"C:\Program Files\FazEletricaCAD\Insumos\" + nomeCategoria;
            string[] arquivos = Directory.GetFiles(diretorio);
            string nomeArquivo = "";

            foreach (string arq in arquivos)
            {
                nomeArquivo = RetornarNomeArquivo(arq);
                if (TipoArquivoDwg(nomeArquivo) == true)
                {
                    nomeArquivo = RetornaNomeArquivoSemExtensao(nomeArquivo);
                    listaDeBlocos.Add(nomeArquivo);
                }
            }

            return listaDeBlocos;
        }

        public string RetornarNomeArquivo(string arquivo)
        {
            string[] nomes = arquivo.Split('\\');
            int qtd = nomes.Length;
            string nomeArquivo = nomes[qtd - 1];
            return nomeArquivo;
        }

        //VERIFICA SE O ARQUIVO É DO TIPO DWG
        private bool TipoArquivoDwg(string nomeArquivo)
        {
            bool sentenca = true;
            string[] nomes = nomeArquivo.Split('.');
            string extensaoArquivo = nomes[1];
            extensaoArquivo = extensaoArquivo.ToUpper();
            if (extensaoArquivo == "DWG") { sentenca = true; }
            else if (extensaoArquivo != "DWG") { sentenca = false; }
            return sentenca;
        }

        public string RetornaNomeArquivoSemExtensao(string nomeArquivo)
        {
            string[] nomes = nomeArquivo.Split('.');
            string nome = nomes[0];
            return nome;
        }

        public string RetornaCaminhoCompletoArquivo(string nomeCategoria, string nomeArquivo)
        {
            string caminhoCompleto = @"C:\Program Files\FazEletricaCAD\Insumos\" + nomeCategoria + "\\" + nomeArquivo + ".dwg";
            return caminhoCompleto;
        }

        public void AbrirManual()
        {
            string caminhoCompletoArquivo = @"C:\Program Files\FazEletricaCAD\Manuais\Manual_Instrucoes_FazEletrica.pdf";

            System.Diagnostics.Process.Start(caminhoCompletoArquivo);
        }

    }
}
