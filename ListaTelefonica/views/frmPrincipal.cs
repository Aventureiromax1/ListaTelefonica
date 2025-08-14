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
        public frmPrincipal()
        {
            InitializeComponent();
            presenter = new ContatoPresenter();
        }
        private void btAdicionar_Click_1(object sender, EventArgs e)
        {
            frmNovoContato frm = new frmNovoContato(presenter);
            frm.ShowDialog();

        }
    }
}
