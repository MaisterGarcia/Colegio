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
    public partial class frmDetGrados : Form
    {
        private GradosCLS oGradosCLS = new GradosCLS();
        private GradosBL _oGradosBL = new GradosBL();
        private ProfesoresBL _oProfesoresBL = new ProfesoresBL();
        private funcionesFormularios _oFunciones = new funcionesFormularios();
        private frmGrados _parent;
        public frmDetGrados(frmGrados parent, GradosCLS _oGradosCLS = null)
        {
            InitializeComponent();
            oGradosCLS = _oGradosCLS;
            _oGradosBL = new GradosBL();
            _oFunciones = new funcionesFormularios();
            _oProfesoresBL = new ProfesoresBL();
            _parent = parent;
        }

        private async void frmDetGrados_Load(object sender, EventArgs e)
        {
            await _oFunciones.llenarCombo(cmbprofesorid, await _oProfesoresBL.listarProfesores(), "Nombre", "id");
            if (oGradosCLS != null)
            {
                _oFunciones.cargarFormulario(oGradosCLS, this.panel1);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (oGradosCLS == null)
            {
                oGradosCLS = new GradosCLS();
            }
            oGradosCLS.nombre = txtnombre.Text;
            oGradosCLS.profesorid = (int)cmbprofesorid.SelectedValue;
            var success = _oFunciones.validarFormulario(oGradosCLS);
            if (success == 1)
            {
                var response = oGradosCLS.id == 0 ? await _oGradosBL.insertarGrados(oGradosCLS) : await _oGradosBL.actualizarGrados(oGradosCLS);
                if (response == 1)
                {
                    MessageBox.Show("Se ha guardado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _oFunciones.funcionAlConcluir(panel1, chkContinuar, this);
                }
                _parent.frmGrados_Load(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
