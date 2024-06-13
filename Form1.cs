using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Form1 : Form
    {
        private List<Produto> estoque = new List<Produto>();
        public Form1()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    
      
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            int quantidade;
            if (int.TryParse(txtQuantidade.Text, out quantidade) && !string.IsNullOrEmpty(nome))
            {
                Produto produto = new Produto { Nome = nome, Quantidade = quantidade };
                estoque.Add(produto);
                MessageBox.Show("Produto adicionado com sucesso!");
                txtNome.Clear();
                txtQuantidade.Clear();
            }
            else
            {
                MessageBox.Show("Dados inválidos.");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            Produto produtoARemover = estoque.FirstOrDefault(p => p.Nome == nome);
            if (produtoARemover != null)
            {
                estoque.Remove(produtoARemover);
                MessageBox.Show("Produto removido com sucesso!");
                txtNome.Clear();
                txtQuantidade.Clear();
            }
            else
            {
                MessageBox.Show("Produto não encontrado.");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            lstEstoque.Items.Clear();
            foreach (Produto produto in estoque)
            {
                lstEstoque.Items.Add(produto);
            }
        }

        
    }
}
