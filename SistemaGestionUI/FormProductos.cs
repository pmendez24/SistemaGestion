using SistemaGestionEntities;
using SistemaGestionBussiness;
using SistemaGestionEntities.Responses;

namespace SistemaGestionUI
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            ProductoResponse response = new ProductoResponse();
            
            response = ProductoBussiness.ListaProductos();
           
            dataGridView1.AutoGenerateColumns = false;
            if (response.Mensaje == "OK")
            {
                dataGridView1.DataSource = response.Productos;
            }
            else
            {
                MessageBox.Show("Ocurrio un error: " + response.Mensaje);
            }
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAltaProducto frmAltaProducto = new frmAltaProducto();
            frmAltaProducto.FormClosed += FrmAltaProducto_FormClosed;
            frmAltaProducto.ShowDialog();
        }
        private void FrmAltaProducto_FormClosed(object? sender, FormClosedEventArgs e)
        {
            CargarProductos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            int Id = (int)this.dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            ProductoResponse response = new ProductoResponse();
           
            response = ProductoBussiness.ObtenerProducto(Id);
            if (response.Mensaje == "OK")
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    frmModificarProducto modificar = new frmModificarProducto(response.Producto);
                    modificar.FormClosed += FrmAltaProducto_FormClosed;
                    modificar.ShowDialog();
                }
                else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    frmEliminarProducto eliminar = new frmEliminarProducto(response.Producto);
                    eliminar.FormClosed += FrmAltaProducto_FormClosed;
                    eliminar.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Ocurrio un error: " + response.Mensaje);
            }
        }
    }
}