using SistemaGestionEntities;
using SistemaGestionBussiness;

namespace SistemaGestionUI
{
    public partial class frmElimiarVenta : Form
    {
        public frmElimiarVenta()
        {
            InitializeComponent();
        }

        private Venta _venta;
        public frmElimiarVenta(Venta venta) 
        {
            InitializeComponent();
            _venta = venta;
        }
        private void frmElimiarVenta_Load(object sender, EventArgs e)
        {
            this.txtComentarios.Text = _venta.Comentarios;
            this.txtIdUsuario.Text = _venta.IdUsuario.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            VentaBussiness.EliminarVenta(_venta);
            MessageBox.Show("Se elimino Correctamente");
        }
    }
}
