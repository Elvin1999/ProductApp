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
    public partial class Form2 : Form
    {


        public ListBox MyListbox
        {
            get { return listBox1 ; }
            set { listBox1 = value; }
        }

        public Form2(List<Product> products)
        {
            InitializeComponent();
            MyListbox.Items.AddRange(products.ToArray());
        }

        public Product SelectedProduct { get; set; }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SelectedProduct = MyListbox.SelectedItem as Product;
            this.Close();
        }
    }
}
