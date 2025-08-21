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
    public partial class frmNovoContato : Form
    {
        private ContatoPresenter presenter;
        public frmNovoContato(ContatoPresenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string telefone = txtTel.Text;

            if (nome.Length == 0 || !txtTel.MaskCompleted)
            {
                MessageBox.Show("Preencha os campos corretamente!",
                    "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Contato novo = new Contato()
            {
                Nome = nome,
                Telefone = telefone
            };
            if (presenter.AdicionarContato(novo))
                this.Close();
            else
                MessageBox.Show("Erro ao adicionar contato!",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
