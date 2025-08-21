using ListaTelefonica.Models;
using ListaTelefonica.presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaTelefonica.views
{
    public partial class frmEditarContato : Form
    {
        ContatoPresenter Presenter;
        Contato edicao;

        public frmEditarContato(ContatoPresenter presenter, Contato edicao)
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string telefone = txtTel.Text;
            if(nome.Length == 0 || !txtTel.MaskCompleted)
            {
                MessageBox.Show("Preencha os campos corretamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            edicao.Nome = nome;
            edicao.Telefone = telefone;
            Presenter.EditarContato(edicao);
            this.Close();
        }
    }
}
