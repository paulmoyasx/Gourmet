using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoGrourmet
{
    public partial class frmGourmet : Form
    {

        public frmGourmet()
        {
            InitializeComponent();
        }

        private void IniciarButton_Click(object sender, EventArgs e)
        {
            try
            {
                PratoModel retorno = PerguntarPrato(PratoService.Listar());
                if (retorno.Pensou)
                {
                    AcertouPrato(retorno);
                }
                else
                {
                    AprenderPrato(retorno);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu algo inesperado!","Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void AcertouPrato(PratoModel prato)
        {
            MessageBox.Show("Acertei! : ) " + prato.Nome, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AprenderPrato(PratoModel prato)
        {
            string novoPrato = Interaction.InputBox("Qual prato você pensou ?", "Desisto");
            if (!string.IsNullOrEmpty(novoPrato))
            {
                string novoPai = Interaction.InputBox($"{ novoPrato} é ____________ mas { prato.Nome} não.", "Complete");
                if (!string.IsNullOrEmpty(novoPai))
                {
                     PratoService.Adicionar(new PratoModel { Nome = novoPrato, Pai = new PratoModel { Nome = novoPai, Pai = prato.Pai }.Id });
                }
            }
        }
               
        private PratoModel PerguntarPrato(List<PratoModel> pratos)
        {
            PratoModel retorno = null;
            foreach (PratoModel p in pratos)
            {
                retorno = p;
                p.Pensou = false;
                if (MessageBox.Show($"O prato que você pensou é {p.Nome} ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    p.Pensou = true;
                    retorno = PerguntarPrato(PratoService.Listar(p.Id));
                    if (retorno == null) retorno = p;
                    break;
                }
            }
            return retorno;
        }

        private void InicioLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PratoService.Analizar());
        }
    }
}
