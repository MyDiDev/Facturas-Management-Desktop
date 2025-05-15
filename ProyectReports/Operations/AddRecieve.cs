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
    public partial class AddRecieve : Form
    {
        public AddRecieve()
        {
            InitializeComponent();
        }

        private void AddRecieve_Load(object sender, EventArgs e)
        {

        }

        private void ClearFields()
        {
            descBox.Text = "";
            categoryBox.Text = "";
            amountValue.Value = 0;
            unitaryPrice.Value = 0;
            itbisValue.Value = 0;
            discValue.Value = 0;
            totalValue.Value = 0;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(categoryBox.Text) || string.IsNullOrEmpty(descBox.Text))
            {
                MessageBox.Show("Llene las Entradas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (unitaryPrice.Value == 0 && itbisValue.Value == 0 && discValue.Value == 0
                && totalValue.Value == 0 && amountValue.Value == 0)
            {
                DialogResult result = MessageBox.Show("Seguro que Dejara los Campos Financiados por 0?", "ERROR", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            Recieve recieve = new Recieve(0, descBox.Text, categoryBox.Text, (int)amountValue.Value, unitaryPrice.Value, itbisValue.Value, discValue.Value, totalValue.Value);
            recieve.RegisterFactura();
            ClearFields();
            MessageBox.Show("Factura Registrada Exitosamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
