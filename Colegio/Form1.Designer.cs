
namespace Colegio
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.categoríasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catálogoAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catálogoDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catálogoDeGradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaciónDeGruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoríasToolStripMenuItem,
            this.accionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // categoríasToolStripMenuItem
            // 
            this.categoríasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catálogoAlumnosToolStripMenuItem,
            this.catálogoDeToolStripMenuItem,
            this.catálogoDeGradosToolStripMenuItem});
            this.categoríasToolStripMenuItem.Name = "categoríasToolStripMenuItem";
            this.categoríasToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.categoríasToolStripMenuItem.Text = "Catálogos";
            // 
            // catálogoAlumnosToolStripMenuItem
            // 
            this.catálogoAlumnosToolStripMenuItem.Name = "catálogoAlumnosToolStripMenuItem";
            this.catálogoAlumnosToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.catálogoAlumnosToolStripMenuItem.Text = "Catálogo Alumnos";
            this.catálogoAlumnosToolStripMenuItem.Click += new System.EventHandler(this.catálogoAlumnosToolStripMenuItem_Click);
            // 
            // catálogoDeToolStripMenuItem
            // 
            this.catálogoDeToolStripMenuItem.Name = "catálogoDeToolStripMenuItem";
            this.catálogoDeToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.catálogoDeToolStripMenuItem.Text = "Catálogo de Profesores";
            this.catálogoDeToolStripMenuItem.Click += new System.EventHandler(this.catálogoDeToolStripMenuItem_Click);
            // 
            // catálogoDeGradosToolStripMenuItem
            // 
            this.catálogoDeGradosToolStripMenuItem.Name = "catálogoDeGradosToolStripMenuItem";
            this.catálogoDeGradosToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.catálogoDeGradosToolStripMenuItem.Text = "Catálogo de Grados";
            this.catálogoDeGradosToolStripMenuItem.Click += new System.EventHandler(this.catálogoDeGradosToolStripMenuItem_Click);
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asignaciónDeGruposToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.accionesToolStripMenuItem.Text = "Acciones";
            // 
            // asignaciónDeGruposToolStripMenuItem
            // 
            this.asignaciónDeGruposToolStripMenuItem.Name = "asignaciónDeGruposToolStripMenuItem";
            this.asignaciónDeGruposToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.asignaciónDeGruposToolStripMenuItem.Text = "Asignación de Grupos";
            this.asignaciónDeGruposToolStripMenuItem.Click += new System.EventHandler(this.asignaciónDeGruposToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Colegio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem categoríasToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem catálogoAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catálogoDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catálogoDeGradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignaciónDeGruposToolStripMenuItem;
    }
}

