using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListaTelefonica.Models;

namespace ListaTelefonica
{
    public partial class Form1 : Form
    {
        List<contato> list;
        public Form1()
        {
            InitializeComponent();
            list = new List<contato>();

        }
        int Length(string[] e)
        {
            int itens = 0;
            for (int i = 0; i < e.Length; i++)
            {
                if (e[i] != null)
                {
                    itens++;
                }
            }
            return itens;
        }
        int Length(string[][] e)
        {
            int items = 0;
            for (int i = 0; i < e.Length; i++)
            {
                if (e[i] != null)
                {
                    items++;
                }
            }
            return items;
        }
        void Atualizar()
        {
            TelTable.Rows.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(TelTable);
                row.Cells[0].Value list[i].Id;
                row.Cells[1].Value = list[i].nome;
                row.Cells[2].Value = list[i].telefone;
                TelTable.Rows.Add(row);
            }
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(NameTextBox.Text) || !TelTextBox.MaskFull)
            {
                MessageBox.Show("insira nome e telefone");
                return;
            }
            int id = 1;
            if(list.Count > 0)
            id = list.Max(c => c.Id) + 1;
            contato Novo = new contato();
            Novo.Id = id;
            Novo.nome = NameTextBox.Text;
            Novo.telefone = TelTextBox.Text;

            list.Add(Novo);

            Atualizar();
            apagarTxt();

        }
        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if(TelTable.SelectedCells.Count == 0)
            {
                MessageBox.Show("selecione uma célula");
                return;
            }

            DataGridViewCell cell = TelTable.SelectedCells[0];
            int linha = cell.RowIndex;
            string id = TelTable.Rows[linha].Cells[0].Value.ToString();
            int index = list.FindIndex(c => c.Id+"" == id);


            DialogResult r = MessageBox.Show($"Deseja mesmo remover {list[index].nome}?", "", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                list.RemoveAt(index);
                Atualizar();
            }
        
        }
        void apagarTxt()
        {
            NameTextBox.Text = "";
            TelTextBox.Text = "";
            lblid.Text = "";
            idAtual = null;
        }

        private void TelTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || TelTable.SelectedCells.Count == 0) {
                return;
            }
            int linha = TelTable.SelectedCells[0].RowIndex;
            if (TelTable.Rows[linha].Cells[0].Value.ToString() == idAtual)
            {
                TelTable.ClearSelection();
                AddBtn.Text = "Adicionar";
                apagarTxt();
                return;
            }
            idAtual = TelTable.Rows[linha].Cells[0].Value.ToString();
            lblid.Text = idAtual;
            AddBtn.Text = "Alterar";
            NameTextBox.Text = TelTable.Rows[TelTable.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            TelTextBox.Text = TelTable.Rows[TelTable.SelectedCells[0].RowIndex].Cells[2].Value.ToString();

        }
    }
}
