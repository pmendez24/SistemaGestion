using SistemaGestionEntities;
using SistemaGestionBussiness;

namespace SistemaGestionUI
{
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void CargarVentas() 
        {
            List<Venta> lista = VentaBussiness.ListarVentas();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = lista;
        }

        private void FrmAltaVenta_FormClosed(object? sender, FormClosedEventArgs e)
        {
            CargarVentas();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAltaVenta frmAltaVenta = new frmAltaVenta();
            frmAltaVenta.FormClosed += FrmAltaVenta_FormClosed;
            frmAltaVenta.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            int Id = (int)this.dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
           
            Venta venta = VentaBussiness.ObtenerVenta(Id);

            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                frmModificarVenta modificar = new frmModificarVenta(venta);
                modificar.FormClosed += FrmAltaVenta_FormClosed;
                modificar.ShowDialog();
            }
            else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                frmElimiarVenta eliminar = new frmElimiarVenta(venta);
                eliminar.FormClosed += FrmAltaVenta_FormClosed;
                eliminar.ShowDialog();
            }
        }
    }
}
