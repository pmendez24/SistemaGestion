using SistemaGestionEntities;
using SistemaGestionBussiness;

namespace SistemaGestionUI
{
    public partial class frmAltaVenta : Form
    {
        public frmAltaVenta()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();

           // venta.Id = int.Parse(txtIdVenta.Text);
            venta.Comentarios = txtComentarios.Text;
            venta.IdUsuario = int.Parse(txtIdUsuario.Text);
           

            VentaBussiness.CrearVenta(venta);
            MessageBox.Show("Se grabo Correctamente");
        }
    }
}
