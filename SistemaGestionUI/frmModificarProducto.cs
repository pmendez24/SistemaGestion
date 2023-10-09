using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SistemaGestionEntities;
using SistemaGestionBussiness;
using SistemaGestionEntities.Responses;

namespace SistemaGestionUI
{
    public partial class frmModificarProducto : Form
    {
        public frmModificarProducto()
        {
            InitializeComponent();
        }

        private Producto _producto;
        public frmModificarProducto(Producto producto)
        {
            InitializeComponent();
            _producto = producto;
        }

        private void lblPrecioVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ProductoResponse response = new ProductoResponse();

            _producto.Descripciones = txtDescripcion.Text;
            _producto.Costo = numCosto.Value;
            _producto.PrecioVenta = numPrecio.Value;
            _producto.Stock = (int)numStock.Value;
            _producto.IdUsuario = int.Parse(txtIdUsuario.Text);

            response = ProductoBussiness.ModificarProducto(_producto);
            if (response.Mensaje == "OK")
            {
                MessageBox.Show("Se modifico Correctamente");
            }
            else
            {
                MessageBox.Show("Ocurrio un error: " + response.Mensaje);
            }
        }

        private void frmModificarProducto_Load(object sender, EventArgs e)
        {
            this.txtIdUsuario.Text = _producto.IdUsuario.ToString();
            this.txtDescripcion.Text = _producto.Descripciones;
            this.numCosto.Value = _producto.Costo;
            this.numPrecio.Value = _producto.PrecioVenta;
            this.numStock.Value = _producto.Stock;
        }
    }
}
