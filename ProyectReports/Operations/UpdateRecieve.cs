using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectReports.Operations
{
    public partial class UpdateRecieve : Form
    {
        public UpdateRecieve()
        {
            InitializeComponent();
        }

        public int Id;
        public string Descripcion;
        public string Categoria;
        public int Cantidad;
        public decimal PrecioUnitario;
        public decimal Itbis;
        public decimal Descuento;
        public decimal TotalGeneral;



        private void UpdateRecieve_Load(object sender, EventArgs e)
        {
            descBox.Text = Descripcion;
            categoryBox.Text = Categoria;
            amountValue.Value = Cantidad;
            unitaryPrice.Value = PrecioUnitario;
            itbisValue.Value = Itbis;
            discValue.Value = Descuento;
            totalValue.Value = TotalGeneral;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(descBox.Text) || string.IsNullOrEmpty(categoryBox.Text))
            {
                MessageBox.Show("Llene las Entradas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (amountValue.Value == 0 && unitaryPrice.Value == 0 && itbisValue.Value == 0
                && discValue.Value == 0 && totalValue.Value == 0)
            {
                DialogResult result = MessageBox.Show("Seguro que Dejara los Campos Financiados por 0?", "ERROR", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            Recieve recieve = new Recieve(Id, descBox.Text, categoryBox.Text, (int)amountValue.Value, unitaryPrice.Value, itbisValue.Value, discValue.Value, totalValue.Value);
            recieve.UpdateFactura();
            MessageBox.Show("Factura Actualizada", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
