using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public Form2 Form2 { get; set; }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Name = textBox1.Text,
                Description = textBox2.Text,
                Price = double.Parse(textBox3.Text)
            };
            Products.Add(product);

            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;

            Form2 = new Form2(Products);
            if (Form2.ShowDialog() == DialogResult.Cancel)
            {
                if (Form2.SelectedProduct != null)
                {
                    textBox1.Text = Form2.SelectedProduct.Name;
                    textBox2.Text = Form2.SelectedProduct.Description;
                    textBox3.Text = Form2.SelectedProduct.Price.ToString();
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            var currentProduct = Form2.SelectedProduct;
            if (currentProduct != null)
            {
                var product = Products.FirstOrDefault(p => p.Id == currentProduct.Id);

                product.Name = textBox1.Text;
                product.Description = textBox2.Text;
                product.Price = double.Parse(textBox3.Text);

                Form2 = new Form2(Products);
                if (Form2.ShowDialog() == DialogResult.Cancel)
                {
                    if (Form2.SelectedProduct != null)
                    {
                        textBox1.Text = Form2.SelectedProduct.Name;
                        textBox2.Text = Form2.SelectedProduct.Description;
                        textBox3.Text = Form2.SelectedProduct.Price.ToString();
                    }
                }
            }
        }
    }
}
