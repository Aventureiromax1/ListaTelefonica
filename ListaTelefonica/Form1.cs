﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaTelefonica
{
    public partial class Form1 : Form
    {
        string[,] list;
        readonly int max = 100;
        int items = 0;

        public Form1()
        {
            InitializeComponent();
            list = new string[max, 2];
        }
        void Atualizar()
        {
            TelTable.Rows.Clear();
            for (int i = 0; i < items; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(TelTable);
                for (int j = 0; j < 2; j++)
                {
                    row.Cells[j].Value = list[i, j];
                }
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
            list[items, 0] = NameTextBox.Text;
            list[items, 1] = TelTextBox.Text;
            items++;

            Atualizar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = TelTable.SelectedCells[0];
            int index = cell.RowIndex;
        }
    }
}
