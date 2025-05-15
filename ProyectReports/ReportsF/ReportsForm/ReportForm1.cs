using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectReports.ReportsF.ReportsForm
{
    public partial class ReportForm1 : Form
    {
        public ReportForm1()
        {
            InitializeComponent();
        }

        private void ReportForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.factura' table. You can move, or remove it, as needed.
            this.facturaTableAdapter.Fill(this.dataSet1.factura);

            this.reportViewer1.RefreshReport();
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
        }
    }
}
