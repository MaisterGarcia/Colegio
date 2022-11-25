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
    public partial class frmAlumnos : Form
    {
        private AlumnoBL _oAlumnosBL = new AlumnoBL();
        public frmAlumnos()
        {
            InitializeComponent();
            _oAlumnosBL = new AlumnoBL();
        }
        public async Task cargarGrid()
        {
            dgvAumnos.DataSource = await _oAlumnosBL.listarAlumnos();

            dgvAumnos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvAumnos.Columns[3].Visible = false;
            dgvAumnos.Columns[6].Visible = false;
            dgvAumnos.ScrollBars = ScrollBars.Both;
        }

        public async void frmAlumnos_Load(object sender, EventArgs e)
        {
            await cargarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDetAlumnos det = new frmDetAlumnos(this);
            det.Show();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int dataIndex;
            if (dgvAumnos.SelectedRows.Count > 0 && dgvAumnos.CurrentRow != null)
            {
                dataIndex = dgvAumnos.CurrentRow.Index;
                int id = Convert.ToInt32(dgvAumnos.Rows[dataIndex].Cells[0].Value.ToString());
                var alumno = await _oAlumnosBL.recuperarAlumnos(id);
                if (alumno is null)
                {
                    MessageBox.Show("Sistema de Colegio", "No se ha encontrado registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                alumno.radios = new List<string> { "Hombre", "Mujer" };
                frmDetAlumnos det = new frmDetAlumnos(this, alumno);
                det.Show();
            }
        }

        private async void dgvAumnos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                await Eliminar();
            }
        }
        private async Task Eliminar()
        {
            if (dgvAumnos.SelectedRows.Count > 0)
            {
                List<int> id = new List<int>();
                if (MessageBox.Show("Esta seguro de eliminar este registro ?", "Eliminacion Grupos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow r in dgvAumnos.SelectedRows)
                    {
                        id.Add(Convert.ToInt32(dgvAumnos[0, r.Index].Value.ToString()));
                    }
                    var response = await _oAlumnosBL.eliminarAlumno(id);
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
