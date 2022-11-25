using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colegio
{
    public partial class frmProfesores : Form
    {
        private ProfesoresBL _oProfesoresBL = new ProfesoresBL();
        public frmProfesores()
        {
            InitializeComponent();
            _oProfesoresBL = new ProfesoresBL();
        }
        public async Task cargarGrid()
        {
            dgvProfesores.DataSource = await _oProfesoresBL.listarProfesores();

            dgvProfesores.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProfesores.Columns[3].Visible = false;
            dgvProfesores.ScrollBars = ScrollBars.Both;
        }

        public async void frmProfesores_Load(object sender, EventArgs e)
        {
            await cargarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDetProfesores det = new frmDetProfesores(this);
            det.Show();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int dataIndex;
            if (dgvProfesores.SelectedRows.Count > 0 && dgvProfesores.CurrentRow != null)
            {
                dataIndex = dgvProfesores.CurrentRow.Index;
                int id = Convert.ToInt32(dgvProfesores.Rows[dataIndex].Cells[0].Value.ToString());
                var profesor = await _oProfesoresBL.recuperarProfesores(id);
                if (profesor is null)
                {
                    MessageBox.Show("Sistema de Colegio", "No se ha encontrado registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                profesor.radios = new List<string> { "Hombre", "Mujer" };
                frmDetProfesores det = new frmDetProfesores(this, profesor);
                det.Show();
            }
        }

        private async void dgvProfesores_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                await Eliminar();
            }
        }
        private async Task Eliminar()
        {
            if (dgvProfesores.SelectedRows.Count > 0)
            {
                List<int> id = new List<int>();
                if (MessageBox.Show("Esta seguro de eliminar este registro ?", "Eliminacion Profesores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow r in dgvProfesores.SelectedRows)
                    {
                        id.Add(Convert.ToInt32(dgvProfesores[0, r.Index].Value.ToString()));
                    }
                    var response = await _oProfesoresBL.eliminarProfesores(id);
                    if (response == 1)
                    {
                        await cargarGrid();
                        MessageBox.Show("Se ha eliminado con éxito", "Correcto", MessageBoxButtons.OK);
                    }

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
