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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void AbrirPrincipalPanel2(Form frmPrincipal, object formHijo)
        {
            //if (frmPrincipal.Controls.Count > 0)
            //    frmPrincipal.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            frmPrincipal.IsMdiContainer = true;
            fh.MdiParent = frmPrincipal;
            fh.WindowState = FormWindowState.Maximized;
            frmPrincipal.Tag = fh;
            //frmPrincipal.mnu.Enabled = true;
            //frmPrincipal.mnu.Visible = true;
            fh.Show();

        }

        private void catálogoAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlumnos frm = new frmAlumnos();
            //frm.Show();
            AbrirPrincipalPanel2(this, frm);
        }

        private void catálogoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfesores frm = new frmProfesores();
            //frm.Show();
            AbrirPrincipalPanel2(this, frm);

        }

        private void catálogoDeGradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrados frm = new frmGrados();
            //frm.Show();
            AbrirPrincipalPanel2(this, frm);
        }

        private void asignaciónDeGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlumnosGrados frm = new frmAlumnosGrados();
            //frm.Show();
            AbrirPrincipalPanel2(this, frm);
        }
    }
}
