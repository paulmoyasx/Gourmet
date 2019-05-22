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

        private void FrmGourmet_Load(object sender, EventArgs e)
        {
            ToolTip tTip = new ToolTip();
            tTip.SetToolTip(ResetarListaPic, "Resetar Lista...");

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
            MessageBox.Show("Acertei! : ) " + prato.Nome, "Informação", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AprenderPrato(PratoModel prato)
        {
            string novoPrato = Interaction.InputBox("Qual prato você pensou ?", "Desisto");
            string validacao = ValidarPrato(prato, novoPrato);
            if (validacao == "")
            {
                string novoPai = Interaction.InputBox($"{ novoPrato} é ____________ mas { prato.Nome} não.", "Complete");
                validacao = ValidarPrato(prato, novoPai);
                if (validacao == "")
                {
                    prato = PratoService.Adicionar(new PratoModel { Nome = novoPai, Pai = prato.Pai });
                    PratoService.Adicionar(new PratoModel { Nome = novoPrato, Pai = prato.Id });
                }
                else
                {
                    MessageBox.Show(validacao, "Atencão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(validacao, "Atencão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ValidarPrato(PratoModel prato, string nome)
        {
            StringBuilder retorno = new StringBuilder("");
            if (string.IsNullOrEmpty(nome))
            {
                retorno.AppendLine("Não foi especificado um nome.");
            }
            else
            {
                if ((prato != null) && prato.Nome.ToUpper().Trim() == nome.ToUpper().Trim()) retorno.AppendLine($" {nome} já existe na úitima opção.");

                PratoModel pai = PratoService.Consutlar(prato.Pai);
                if ((pai!=null) && pai.Nome.ToUpper().Trim() == nome.ToUpper().Trim()) retorno.AppendLine($" {nome} já existe na úitima opção.");
            }
            return retorno.ToString();
        }
               
        private PratoModel PerguntarPrato(List<PratoModel> pratos)
        {
            PratoModel retorno = null;
            foreach (PratoModel p in pratos)
            {
                retorno = p;
                p.Pensou = false;
                if (MessageBox.Show($"O prato que você pensou é {p.Nome} ?", 
                    "Confirmar",   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    p.Pensou = true;
                    retorno = PerguntarPrato(PratoService.Listar(p.Id));
                    if (retorno == null) retorno = p;
                    break;
                }
                if (p.Pensou) break;
            }
            return retorno;
        }


        private void ResetarListaPic_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(PratoService.Conteudo(), "Deseja Resetar a lista de pratos ?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
            {
                PratoService.Resetar();
                MessageBox.Show("Lista Resetada!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
