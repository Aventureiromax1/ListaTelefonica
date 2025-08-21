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
    public partial class frmPrincipal : Form
    {
        private ContatoPresenter presenter;
        Contato edicao;
        public frmPrincipal()
        {
            InitializeComponent();
            presenter = new ContatoPresenter();
            Atualizar();
        }
        private void btAdicionar_Click_1(object sender, EventArgs e)
        {
            frmNovoContato frm = new frmNovoContato(presenter);
            frm.ShowDialog();

        }
        private void Atualizar()
        {
            dgvLista.DataSource = presenter.BuscarContatos(txtBusca.Text.Trim());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgvLista.SelectedCells[0].RowIndex;
            int id = (int)dgvLista.Rows[linha].Cells[0].Value;

            edicao = presenter.selecionarContato(id);
            
            btEditar.Enabled = true;
            btRemover.Enabled = true;
        }
        private void Limpar()
        {
            edicao = null;
            btEditar.Enabled = false;
            btRemover.Enabled = false;
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            frmEditarContato frm = new frmEditarContato(presenter, edicao);
            frm.ShowDialog();
            Atualizar();
            Limpar();
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Deseja realmente remover este contato?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                presenter.RemoverContato(edicao);
                Atualizar();
                Limpar();
            }
        }
    }
}
