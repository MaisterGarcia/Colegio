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
    public partial class frmDetAlumnosGrados : Form
    {
        private AlumnoGradoCLS oAlumnoGradoCLS = new AlumnoGradoCLS();
        private GradosBL _oGradosBL = new GradosBL();
        private AlumnoGradoBL _oAlumnoGradoBL = new AlumnoGradoBL();
        private AlumnoBL _oAlumnoBL = new AlumnoBL();
        private funcionesFormularios _oFunciones = new funcionesFormularios();
        private frmAlumnosGrados _parent;
        public frmDetAlumnosGrados(frmAlumnosGrados parent, AlumnoGradoCLS _oAlumnoGradoCLS = null)
        {
            InitializeComponent();
            oAlumnoGradoCLS = _oAlumnoGradoCLS;
            _oAlumnoGradoBL = new AlumnoGradoBL();
            _oGradosBL = new GradosBL();
            _oFunciones = new funcionesFormularios();
            _oAlumnoBL = new AlumnoBL();
            _parent = parent;
        }

        private async void frmDetAlumnosGrados_Load(object sender, EventArgs e)
        {
            await _oFunciones.llenarCombo(cmbalumnoid, await _oAlumnoBL.listarAlumnos(), "FullName", "id");
            await _oFunciones.llenarCombo(cmbgradoid, await _oGradosBL.listarGrados(), "nombre", "id");
            if (oAlumnoGradoCLS != null)
            {
                _oFunciones.cargarFormulario(oAlumnoGradoCLS, this.panel1);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (oAlumnoGradoCLS == null)
            {
                oAlumnoGradoCLS = new AlumnoGradoCLS();

            }
            oAlumnoGradoCLS.seccion = txtseccion.Text;
            oAlumnoGradoCLS.alumnoid = (int)cmbalumnoid.SelectedValue;
            oAlumnoGradoCLS.gradoid = (int)cmbgradoid.SelectedValue;
            var success = _oFunciones.validarFormulario(oAlumnoGradoCLS);
            if (success == 1)
            {
                var response = oAlumnoGradoCLS.id == 0 ? await _oAlumnoGradoBL.insertarAlumnoGrado(oAlumnoGradoCLS) : await _oAlumnoGradoBL.actualizarAlumnoGrado(oAlumnoGradoCLS);
                if (response == 1)
                {
                    MessageBox.Show("Se ha guardado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _oFunciones.funcionAlConcluir(panel1, chkContinuar, this);
                }
                _parent.frmAlumnosGrados_Load(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
