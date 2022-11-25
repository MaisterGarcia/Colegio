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
    public partial class frmDetProfesores : Form
    {
        private ProfesoresCLS oProfesoresCLS = new ProfesoresCLS();
        private ProfesoresBL _oProfesoresBL = new ProfesoresBL();
        private funcionesFormularios _oFunciones = new funcionesFormularios();
        private frmProfesores _parent;
        public frmDetProfesores(frmProfesores parent, ProfesoresCLS _oProfesoresCLS = null)
        {
            InitializeComponent();
            oProfesoresCLS = _oProfesoresCLS;
            _oProfesoresBL = new ProfesoresBL();
            _oFunciones = new funcionesFormularios();
            _parent = parent;
        }

        private void frmDetProfesores_Load(object sender, EventArgs e)
        {
            if (oProfesoresCLS != null)
            {
                _oFunciones.cargarFormulario(oProfesoresCLS, this.panel1);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (oProfesoresCLS == null)
            {
                oProfesoresCLS = new ProfesoresCLS();
            }
            oProfesoresCLS.nombre = txtnombre.Text;
            oProfesoresCLS.apellidos = txtapellidos.Text;
            var buttons = this.grbgenero.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            oProfesoresCLS.genero = Convert.ToInt32(buttons.Tag);
            var success = _oFunciones.validarFormulario(oProfesoresCLS);
            if (success == 1)
            {
                var response = oProfesoresCLS.id == 0 ? await _oProfesoresBL.insertarProfesores(oProfesoresCLS) : await _oProfesoresBL.actualizarProfesores(oProfesoresCLS);
                if (response == 1)
                {
                    MessageBox.Show("Se ha guardado correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _oFunciones.funcionAlConcluir(panel1, chkContinuar, this);
                }
                _parent.frmProfesores_Load(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
