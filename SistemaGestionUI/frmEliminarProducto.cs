using SistemaGestionEntities;
using SistemaGestionBussiness;
using SistemaGestionEntities.Responses;

namespace SistemaGestionUI
{
    public partial class frmEliminarProducto : Form
    {
        public frmEliminarProducto()
        {
            InitializeComponent();
        }

        private Producto _producto;
        public frmEliminarProducto(Producto producto)
        {
            InitializeComponent();
            _producto = producto;
        }
        private void frmEliminarProducto_Load(object sender, EventArgs e)
        {
            this.txtIdUsuario.Text = _producto.IdUsuario.ToString();
            this.txtDescripcion.Text = _producto.Descripciones;
            this.numCosto.Value = _producto.Costo;
            this.numPrecio.Value = _producto.PrecioVenta;
            this.numStock.Value = _producto.Stock;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ProductoResponse response = new ProductoResponse();
            response =  ProductoBussiness.EliminarProducto(_producto);

            if (response.Mensaje == "OK")
            {
                MessageBox.Show("Se elimino Correctamente");
            }
            else
            {
                MessageBox.Show("Ocurrio un error: " + response.Mensaje);
            }
        }
    }
}
