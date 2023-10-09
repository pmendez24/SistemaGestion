using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGestionUI
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void tabProductos_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.ShowDialog();
            
        }

        private void tabControlSistemaGestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Acciones basadas en la pestaña seleccionada
            if (tabControlSistemaGestion.SelectedTab == tabProductos)
            {
                FormProductos formProductos = new FormProductos();
                formProductos.ShowDialog();
            }
            else if (tabControlSistemaGestion.SelectedTab == tabUsuarios)
            {
                FormUsuario formUsuarios = new FormUsuario();
                formUsuarios.ShowDialog();
            }
            else if (tabControlSistemaGestion.SelectedTab == tabVentas)
            {
                FormVentas formVentas = new FormVentas();
                formVentas.ShowDialog();
            }
        }
    }
}
