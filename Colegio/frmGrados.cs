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
    public partial class frmGrados : Form
    {
        private GradosBL _oGradosBL = new GradosBL();
        public frmGrados()
        {
            InitializeComponent();
            _oGradosBL = new GradosBL();
        }
        public async Task cargarGrid()
        {
            dgvGrados.DataSource = await _oGradosBL.listarGrados();

            dgvGrados.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGrados.Columns[2].Visible = false;
            dgvGrados.ScrollBars = ScrollBars.Both;
        }

        public async void frmGrados_Load(object sender, EventArgs e)
        {
            await cargarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDetGrados det = new frmDetGrados(this);
            det.Show();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int dataIndex;
            if (dgvGrados.SelectedRows.Count > 0 && dgvGrados.CurrentRow != null)
            {
                dataIndex = dgvGrados.CurrentRow.Index;
                int id = Convert.ToInt32(dgvGrados.Rows[dataIndex].Cells[0].Value.ToString());
                var grado = await _oGradosBL.recuperarGrados(id);
                if (grado is null)
                {
                    MessageBox.Show("Sistema de Colegio", "No se ha encontrado registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmDetGrados det = new frmDetGrados(this, grado);
                det.Show();
            }
        }

        private async void dgvGrados_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                await Eliminar();
            }
        }
        private async Task Eliminar()
        {
            if (dgvGrados.SelectedRows.Count > 0)
            {
                List<int> id = new List<int>();
                if (MessageBox.Show("Esta seguro de eliminar este registro ?", "Eliminacion Grados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow r in dgvGrados.SelectedRows)
                    {
                        id.Add(Convert.ToInt32(dgvGrados[0, r.Index].Value.ToString()));
                    }
                    var response = await _oGradosBL.eliminarGrados(id);
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
