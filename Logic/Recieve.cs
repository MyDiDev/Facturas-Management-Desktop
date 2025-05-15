using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Recieve
    {
        public int Id;
        public string Descripcion;
        public string Categoria;
        public int Cantidad;
        public decimal PrecioUnitario;
        public decimal Itebis;
        public decimal Descuento;
        public decimal TotalGeneral;

        public Recieve(int id, string descripcion, string categoria, int cantidad, decimal precioUnitario, decimal itebis, decimal descuento, decimal totalGeneral)
        {
            Id = id;
            Descripcion = descripcion;
            Categoria = categoria;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Itebis = itebis;
            Descuento = descuento;
            TotalGeneral = totalGeneral;
        }

        public Recieve(int id)
        {
            Id = id;
        }

        Conn conn = new Conn();

        public void RegisterFactura() => conn.addFactura(Descripcion, Categoria, Cantidad, PrecioUnitario, Itebis, Descuento, TotalGeneral);
        public void DeleteFactura() => conn.delFactura(Id);
        public void UpdateFactura() => conn.updateFactura(Id, Descripcion, Categoria, Cantidad, PrecioUnitario, Itebis, Descuento, TotalGeneral);
        public DataTable ReadFacturas() => conn.getFacturas();
        public DataTable ReadFacturasById() => conn.getFacturas(Id);
    }
}
