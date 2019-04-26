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
    public partial class FormularioSobre : Form
    {
        public FormularioSobre()
        {
            InitializeComponent();
        }

        private void linkSiteSeabra_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkSiteSeabra.LinkVisited = true;

            System.Diagnostics.Process.Start("http://www.seabrasolucoes.com.br/");
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
