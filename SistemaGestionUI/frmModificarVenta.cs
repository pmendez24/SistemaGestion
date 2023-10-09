using SistemaGestionEntities;
using SistemaGestionBussiness;

namespace SistemaGestionUI
{
    public partial class frmModificarVenta : Form
    {
        public frmModificarVenta()
        {
            InitializeComponent();
        }

        private Venta _venta;

        public frmModificarVenta(Venta venta) 
        {
            InitializeComponent();
            _venta = venta;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _venta.Comentarios = txtComentarios.Text;
            _venta.IdUsuario = int.Parse(txtIdUsuario.Text);

            VentaBussiness.ModificarVenta(_venta);
            MessageBox.Show("Se modifico Correctamente");
        }

        private void frmModificarVenta_Load(object sender, EventArgs e)
        {
            this.txtComentarios.Text = _venta.Comentarios;
            this.txtIdUsuario.Text = _venta.IdUsuario.ToString();
        }
    }
}
