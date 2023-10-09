using SistemaGestionEntities;
using SistemaGestionBussiness;
using SistemaGestionEntities.Responses;

namespace SistemaGestionUI
{
    public partial class frmEliminarUsuario : Form
    {
        public frmEliminarUsuario()
        {
            InitializeComponent();
        }

        Usuario _usuario;

        public frmEliminarUsuario( Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }
        private void frmEliminarUsuario_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = _usuario.Nombre.ToString();
            this.textApellido.Text = _usuario.Apellido.ToString();
            this.textNombreUsuario.Text = _usuario.NombreUsuario.ToString();
            this.textPass.Text = _usuario.Contraseña.ToString();
            this.txtMail.Text = _usuario.Mail.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            UsuarioResponse response = new UsuarioResponse();
            response = UsuarioBussiness.EliminarUsuario(_usuario);
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
