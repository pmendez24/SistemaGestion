using SistemaGestionEntities;
using SistemaGestionBussiness;
using SistemaGestion;
using SistemaGestionEntities.Responses;

namespace SistemaGestionUI
{
    public partial class frmAltaUsuario : Form
    {
        public frmAltaUsuario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioResponse response = new UsuarioResponse();
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = textApellido.Text;
            usuario.NombreUsuario = textNombreUsuario.Text;
            usuario.Mail = txtMail.Text;
            usuario.Contraseña = textPass.Text;

            response = UsuarioBussiness.CrearUsuario(usuario);

            if (response.Mensaje == "OK")
            {
                MessageBox.Show("Se grabo Correctamente");
            }
            else
            {
                MessageBox.Show("Ocurrio un error: " + response.Mensaje);
            }
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMail_Click(object sender, EventArgs e)
        {

        }
    }
}
