using FazEletricaCAD.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FazEletricaCAD.Funcoes
{
    public class Quantitativo
    {
        ManipularListasElementos listas = new ManipularListasElementos();

        // ADICIONAR REFERÊNCIA DO OFFICE
        // Na janela Add Reference clique na guia COM e selecione : Microsoft Excel 12.0 Object Library e clique em OK
        public void GerarPlanilhaExcel(List<BlocoComAtributo> listaBlocos, List<LinhaComAtributo> listaDutos)
        {
            try
            {
                //ESCOLHER A PASTA DESTINO
                string diretorio = EscolherPastaDestino();

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Name = "Quantitativo";

                //CRIAR CABEÇALHO

                xlWorkSheet.Cells[1, 1] = "BLOCOS";
                Excel.Range celulas1 = xlWorkSheet.get_Range("A1", "D1");
                celulas1.Merge(Type.Missing);
                celulas1.Font.Bold = true;
                celulas1.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                xlWorkSheet.Cells[2, 1] = "ID";
                xlWorkSheet.Cells[2, 2] = "Nome";
                xlWorkSheet.Cells[2, 3] = "Descrição";
                xlWorkSheet.Cells[2, 4] = "Quantidade";

                Excel.Range celulas;
                celulas = xlWorkSheet.get_Range("A2", "D2");
                //celulas.EntireColumn.AutoFit();
                celulas.ColumnWidth = 16;
                celulas.Font.Bold = true;
                celulas.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                celulas.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                //celulas.Interior.Color = System.Drawing.ColorTranslator.ToWin32(Color.DarkGray);
                //celulas.Font.Color = System.Drawing.ColorTranslator.ToWin32(Color.Red);

                Excel.Range celulas4;
                celulas4 = xlWorkSheet.get_Range("E1", "E1");
                celulas4.ColumnWidth = 3;

                xlWorkSheet.Cells[1, 6] = "LINHAS";
                Excel.Range celulas3 = xlWorkSheet.get_Range("F1", "H1");
                celulas3.Merge(Type.Missing);
                celulas3.Font.Bold = true;
                celulas3.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;

                xlWorkSheet.Cells[2, 6] = "ID";
                xlWorkSheet.Cells[2, 7] = "Nome";
                xlWorkSheet.Cells[2, 8] = "Metros";

                Excel.Range celulas2;
                celulas2 = xlWorkSheet.get_Range("F2", "H2");
                celulas2.ColumnWidth = 16;
                celulas2.Font.Bold = true;
                celulas2.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                celulas2.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //--------------------------------------------------------------------------------------------------
                //PREENCHER COM OS DADOS DOS BLOCOS

                int numeroLinhas = listaBlocos.Count();

                if (numeroLinhas > 0)
                {
                    for (int i = 0; i < numeroLinhas; i++)
                    {
                        xlWorkSheet.Cells[3 + i, 1] = listaBlocos[i].ID;
                        xlWorkSheet.Cells[3 + i, 2] = listaBlocos[i].Nome;
                        xlWorkSheet.Cells[3 + i, 3] = listaBlocos[i].Especificacao;
                        xlWorkSheet.Cells[3 + i, 4] = listaBlocos[i].Quantidade;
                    }
                }
                //FORMATAÇÃO DOS DADOS INSERIDOS
                string celulaInicio = "A3";
                string celulaFim = "D" + (numeroLinhas + 2).ToString();
                Excel.Range celulas5;
                celulas5 = xlWorkSheet.get_Range(celulaInicio, celulaFim);
                celulas5.Font.Size = 9;
                celulas5.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                celulas5.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //--------------------------------------------------------------------------------------------------
                //PREENCHER COM OS DADOS DOS DUTOS

                int numLinhas = listaDutos.Count();

                if (numLinhas > 0)
                {
                    for (int i = 0; i < numLinhas; i++)
                    {
                        xlWorkSheet.Cells[3 + i, 6] = listaDutos[i].ID;
                        xlWorkSheet.Cells[3 + i, 7] = listaDutos[i].Nome;
                        xlWorkSheet.Cells[3 + i, 8] = listaDutos[i].Comprimento;
                    }
                }
                //FORMATAÇÃO DOS DADOS INSERIDOS
                string celulaInicio1 = "F3";
                string celulaFim1 = "H" + (numLinhas + 2).ToString();
                Excel.Range celulas6;
                celulas6 = xlWorkSheet.get_Range(celulaInicio1, celulaFim1);
                celulas6.Font.Size = 9;
                celulas6.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                celulas6.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                //xlWorkBook.SaveAs(@"C:\Users\D001231\Downloads\NomeArquivo.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.SaveAs(diretorio, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                LiberarObjetos(xlWorkSheet);
                LiberarObjetos(xlWorkBook);
                LiberarObjetos(xlApp);

            }
            catch { }

        }

        private void LiberarObjetos(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                System.Windows.Forms.MessageBox.Show("Ocorreu um erro durante a liberação do objeto " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private string EscolherPastaDestino()
        {
            string diretorioSaida = "";

            SaveFileDialog caixaSalvar = new SaveFileDialog();
            caixaSalvar.Title = "Escolher pasta";
            caixaSalvar.Filter = "Planilha Excel|.xls";
            caixaSalvar.FilterIndex = 0;
            caixaSalvar.FileName = "Quantitativo";

            if (caixaSalvar.ShowDialog() == DialogResult.OK)
            {
                diretorioSaida = caixaSalvar.FileName;
            }
            return diretorioSaida;
        }

    }
}
