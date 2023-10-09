using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SistemaGestionEntities;
using SistemaGestionBussiness;
using SistemaGestionEntities.Responses;

namespace SistemaGestionUI
{
    public partial class frmAltaProducto : Form
    {
        public frmAltaProducto()
        {
            InitializeComponent();
        }

        private void FormAltaProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            ProductoResponse response = new ProductoResponse();

            producto.Descripciones = txtDescripcion.Text;
            producto.Costo = numCosto.Value;
            producto.PrecioVenta = numPrecio.Value;
            producto.Stock = (int)numStock.Value;
            producto.IdUsuario = int.Parse(txtIdUsuario.Text);

            response = ProductoBussiness.CrearProducto(producto);

            if (response.Mensaje == "OK")
            {
                MessageBox.Show("Se grabo Correctamente");
            }
            else
            {
                MessageBox.Show("Ocurrio un error: " + response.Mensaje);
            }
        }
    }
}
