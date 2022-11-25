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
    public partial class frmAlumnosGrados : Form
    {
        private AlumnoGradoBL _oAlumnoGradoBL = new AlumnoGradoBL();
        public frmAlumnosGrados()
        {
            InitializeComponent();
            _oAlumnoGradoBL = new AlumnoGradoBL();
        }
        public async Task cargarGrid()
        {
            dgvAlumnosGrados.DataSource = await _oAlumnoGradoBL.listarAlumnoGrado();

            dgvAlumnosGrados.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAlumnosGrados.Columns[1].Visible = false;
            dgvAlumnosGrados.Columns[2].Visible = false;
            dgvAlumnosGrados.ScrollBars = ScrollBars.Both;
        }

        public async void frmAlumnosGrados_Load(object sender, EventArgs e)
        {
            await cargarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDetAlumnosGrados det = new frmDetAlumnosGrados(this);
            det.Show();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int dataIndex;
            if (dgvAlumnosGrados.SelectedRows.Count > 0 && dgvAlumnosGrados.CurrentRow != null)
            {
                dataIndex = dgvAlumnosGrados.CurrentRow.Index;
                int id = Convert.ToInt32(dgvAlumnosGrados.Rows[dataIndex].Cells[0].Value.ToString());
                var alumnogrado = await _oAlumnoGradoBL.recuperarAlumnoGrado(id);
                if (alumnogrado is null)
                {
                    MessageBox.Show("No se ha encontrado registro", "Sistema de Colegio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmDetAlumnosGrados det = new frmDetAlumnosGrados(this, alumnogrado);
                det.Show();
            }
        }

        private async void dgvAlumnoGrado_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                await Eliminar();
            }
        }
        private async Task Eliminar()
        {
            if (dgvAlumnosGrados.SelectedRows.Count > 0)
            {
                List<int> id = new List<int>();
                if (MessageBox.Show("Esta seguro de eliminar este registro ?", "Eliminacion AlumnoGrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow r in dgvAlumnosGrados.SelectedRows)
                    {
                        id.Add(Convert.ToInt32(dgvAlumnosGrados[0, r.Index].Value.ToString()));
                    }
                    var response = await _oAlumnoGradoBL.eliminarAlumnoGrado(id);
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
