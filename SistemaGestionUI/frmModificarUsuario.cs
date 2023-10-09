using SistemaGestionEntities;
using SistemaGestionBussiness;
using SistemaGestionEntities.Responses;

namespace SistemaGestionUI
{
    public partial class frmModificarUsuario : Form
    {
        public frmModificarUsuario()
        {
            InitializeComponent();
        }

        private Usuario _usuario;
        public frmModificarUsuario(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            UsuarioResponse response = new UsuarioResponse();
            _usuario.Nombre = txtNombre.Text;
            _usuario.Apellido = textApellido.Text;
            _usuario.NombreUsuario = textNombreUsuario.Text;
            _usuario.Contraseña = textPass.Text;
            _usuario.Mail = txtMail.Text;

            response = UsuarioBussiness.ModificarUsuario(_usuario);

            if (response.Mensaje == "OK")
            {
                MessageBox.Show("Se modifico Correctamente");
            }
            else
            {
                MessageBox.Show("Ocurrio un error: " + response.Mensaje);
            }
        }

        private void frmModificarUsuario_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = _usuario.Nombre.ToString();
            this.textApellido.Text = _usuario.Apellido.ToString();
            this.textNombreUsuario.Text = _usuario.NombreUsuario.ToString();
            this.textPass.Text = _usuario.Contraseña.ToString();
            this.txtMail.Text = _usuario.Mail.ToString();
        }
    } 
}
