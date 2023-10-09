using SistemaGestionEntities;
using SistemaGestionBussiness;
using SistemaGestion;
using SistemaGestionEntities.Responses;

namespace SistemaGestionUI
{
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            UsuarioResponse response = new UsuarioResponse();
            response = UsuarioBussiness.ListarUsuarios();
           
            dataGridView1.AutoGenerateColumns = false;
            if (response.Mensaje == "OK")
            {
                dataGridView1.DataSource = response.Usuarios;
            }
            else
            {
                MessageBox.Show("Ocurrio un error: " + response.Mensaje);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAltaUsuario frmAltaUsuario = new frmAltaUsuario();
            frmAltaUsuario.FormClosed += FrmAltaUsuario_FormClosed;
            frmAltaUsuario.ShowDialog();
        }

        private void FrmAltaUsuario_FormClosed(object? sender, FormClosedEventArgs e)
        {
            CargarUsuarios();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            int Id = (int)this.dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            UsuarioResponse response = new UsuarioResponse();
            response = UsuarioBussiness.ObtenerUsuario(Id);

            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                frmModificarUsuario modificar = new frmModificarUsuario(response.Usuario);
                modificar.FormClosed += FrmAltaUsuario_FormClosed;
                modificar.ShowDialog();
            }
            else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                frmEliminarUsuario eliminar = new frmEliminarUsuario(response.Usuario);
                eliminar.FormClosed += FrmAltaUsuario_FormClosed;
                eliminar.ShowDialog();
            }
        }
    }
}
