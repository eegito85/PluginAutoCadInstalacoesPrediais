using FazEletricaCAD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FazEletricaCAD.Funcoes
{
    public class ManipularListasElementos
    {

        public List<BlocoComAtributo> MontarListaDeBlocos(List<Elemento> listaElementos)
        {
            List<BlocoComAtributo> listaBlocos = new List<BlocoComAtributo>();
            List<BlocoComAtributo> listaBlocosCorrigida = new List<BlocoComAtributo>();
            try
            {
                foreach (Elemento elem in listaElementos)
                {
                    if (elem.Tipo == "bloco")
                    {
                        BlocoComAtributo bloco = new BlocoComAtributo();
                        bloco.ID = elem.ID;
                        bloco.Nome = elem.Nome;
                        bloco.Especificacao = elem.Especificacao;
                        bloco.Quantidade = elem.Quantificacao;
                        listaBlocos.Add(bloco);
                    }
                }
            }
            catch { }
            listaBlocosCorrigida = CorrigirListaDeBlocos(listaBlocos);
            return listaBlocosCorrigida;
        }

        public List<LinhaComAtributo> MontarListaDeDutos(List<Elemento> listaElementos)
        {
            List<LinhaComAtributo> listaDutos = new List<LinhaComAtributo>();
            List<LinhaComAtributo> listaBlocosCorrigida = new List<LinhaComAtributo>();
            try
            {
                foreach (Elemento elem in listaElementos)
                {
                    if (elem.Tipo == "duto")
                    {
                        LinhaComAtributo duto = new LinhaComAtributo();
                        duto.ID = elem.ID;
                        duto.Nome = elem.Nome;
                        duto.Descricao = elem.Especificacao;
                        duto.Comprimento = elem.Quantificacao;
                        listaDutos.Add(duto);
                    }
                }
            }
            catch { }
            listaBlocosCorrigida = CorrigirListaDeDutos(listaDutos);
            return listaDutos;
        }

        //ESSA FUNÇÃO ELIMINA ELEMENTOS REPETIDOS E COLOCA A QUANTIDADE CERTA DE BLOCOS
        private List<BlocoComAtributo> CorrigirListaDeBlocos(List<BlocoComAtributo> listaOriginal)
        {
            int num = listaOriginal.Count();
            List<BlocoComAtributo> listaAtualizada = new List<BlocoComAtributo>();
            int contador = 1;

            for (int i = 0; i < num - 1; i++)
            {
                contador = 1;
                for (int j = i + 1; j < num; j++)
                {
                    if (listaOriginal[i].Nome == listaOriginal[j].Nome && listaOriginal[i].Nome != "nulo")
                    {
                        listaOriginal[j].Nome = "nulo";
                        contador++;
                    }
                }
                listaOriginal[i].Quantidade = contador.ToString();
            }
            if (listaOriginal[num - 1].Nome != "nulo")
            {
                listaOriginal[num - 1].Quantidade = "1";
            }
            foreach (BlocoComAtributo bloco in listaOriginal)
            {
                if (bloco.Nome != "nulo") { listaAtualizada.Add(bloco); }
            }


            return listaAtualizada;
        }

        //IMPLEMENTAR MÉTODO
        public List<LinhaComAtributo> CorrigirListaDeDutos(List<LinhaComAtributo> listaOriginal)
        {
            int num = listaOriginal.Count();
            List<LinhaComAtributo> listaAtualizada = new List<LinhaComAtributo>();
            int contador = 1;
            double L1 = 0;
            double L2 = 0;
            double L = 0;

            for (int i = 0; i < num - 1; i++)
            {
                contador = 1;
                for (int j = i + 1; j < num; j++)
                {
                    if (listaOriginal[i].Nome == listaOriginal[j].Nome && listaOriginal[i].Nome != "nulo")
                    {
                        L1 = Convert.ToDouble(listaOriginal[i].Comprimento);
                        L2 = Convert.ToDouble(listaOriginal[j].Comprimento);
                        L = L1 + L2;
                        listaOriginal[j].Nome = "nulo";
                        listaOriginal[i].Comprimento = Convert.ToString(L);
                        contador++;
                    }
                }

            }

            foreach (LinhaComAtributo duto in listaOriginal)
            {
                if (duto.Nome != "nulo") { listaAtualizada.Add(duto); }
            }
            return listaAtualizada;
        }
    }
}
