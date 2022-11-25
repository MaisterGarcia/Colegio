using Capa_Entidad;
using Capa_Negocio;
using Colegio.Funciones;
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
    public partial class frmDetAlumnos : Form
    {
        private AlumnoCLS oAlumnoCLS = new AlumnoCLS();
        private AlumnoBL _oAlumnoBL = new AlumnoBL();
        private funcionesFormularios _oFunciones = new funcionesFormularios();
        private frmAlumnos _parent;
        public frmDetAlumnos(frmAlumnos parent, AlumnoCLS _oAlumnoCLS = null)
        {
            InitializeComponent();
            oAlumnoCLS = _oAlumnoCLS;
            _oAlumnoBL = new AlumnoBL();
            _oFunciones = new funcionesFormularios();
            _parent = parent;
        }

        private void frmDetAlumnos_Load(object sender, EventArgs e)
        {
            if (oAlumnoCLS != null)
            {
                _oFunciones.cargarFormulario(oAlumnoCLS, this.panel1);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (oAlumnoCLS == null)
            {
                oAlumnoCLS = new AlumnoCLS();
            }
            oAlumnoCLS.nombre = txtnombre.Text;
            oAlumnoCLS.apellidos = txtapellidos.Text;
            var buttons = this.grbgenero.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            oAlumnoCLS.genero = Convert.ToInt32(buttons.Tag);
            oAlumnoCLS.fechanacimiento = dtpfechanacimiento.Value;
            var success = _oFunciones.validarFormulario(oAlumnoCLS);
            if (success == 1)
            {
                var response = oAlumnoCLS.id == 0 ? await _oAlumnoBL.insertarAlumno(oAlumnoCLS) : await _oAlumnoBL.actualizarAlumno(oAlumnoCLS);
                if (response == 1)
                {
                    MessageBox.Show("Se ha guardado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _oFunciones.funcionAlConcluir(panel1, chkContinuar, this);
                }
                _parent.frmAlumnos_Load(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
