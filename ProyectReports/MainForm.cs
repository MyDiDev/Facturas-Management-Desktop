using Logic;
using ProyectReports.Operations;
using ProyectReports.ReportsF.ReportsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace ProyectReports
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Recieve recieve = new Recieve(0);
        private void regiterBtn_Click(object sender, EventArgs e)
        {
            AddRecieve f = new AddRecieve();
            f.ShowDialog();
            LoadData();
        }

        private void genReportBtn_Click(object sender, EventArgs e)
        {
            ReportForm1 f = new ReportForm1();
            f.ShowDialog();
            LoadData();
        }

        private void LoadData()
        {
            dataView.DataSource = recieve.ReadFacturas().Rows.Count > 0 ? recieve.ReadFacturas() : null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seguro quieres Eliminar estos Registros", "WARNING", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                    return;


                if (dataView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataView.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value?.ToString());

                        Recieve recieve = new Recieve(id);
                        recieve.DeleteFactura();
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione Un Registro Valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (dataView.SelectedRows.Count > 0 && dataView.SelectedRows.Count == 1)
            {
                UpdateRecieve updateRecieve = new UpdateRecieve();
                
                int id= Convert.ToInt32(dataView.SelectedRows[0].Cells["id"].Value?.ToString());
                string description = dataView.SelectedRows[0].Cells["descripcion"].Value?.ToString();
                string categoria = dataView.SelectedRows[0].Cells["categoria"].Value?.ToString();
                int cantidad = Convert.ToInt32(dataView.SelectedRows[0].Cells["cantidad"].Value?.ToString());
                decimal precioUnitario = Convert.ToDecimal(dataView.SelectedRows[0].Cells["precio_untario"].Value?.ToString());
                decimal itbis= Convert.ToDecimal(dataView.SelectedRows[0].Cells["itebis"].Value?.ToString());
                decimal descuento = Convert.ToDecimal(dataView.SelectedRows[0].Cells["descuento"].Value?.ToString());
                decimal totalGeneral = Convert.ToDecimal(dataView.SelectedRows[0].Cells["total_general"].Value?.ToString());

                updateRecieve.Id = id;
                updateRecieve.Descripcion = description;
                updateRecieve.Categoria = categoria;
                updateRecieve.Cantidad = cantidad;
                updateRecieve.PrecioUnitario = precioUnitario;
                updateRecieve.Itbis = itbis;
                updateRecieve.Descuento = descuento;
                updateRecieve.TotalGeneral = totalGeneral;

                updateRecieve.ShowDialog();
                LoadData();
                return;
            }

            MessageBox.Show("Seleccione Un Registro Valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
}
