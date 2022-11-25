using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colegio.Funciones
{
    public class funcionesFormularios
    {
        public void cargarFormulario(dynamic entidad, Panel panel)
        {
            if (entidad != null)
            {
                foreach (var propertyInfo in entidad.GetType()
                                  .GetProperties(
                                          BindingFlags.Public
                                          | BindingFlags.Instance))
                {
                    foreach (Control c in panel.Controls)
                    {
                        //Console.WriteLine(propertyInfo.GetValue(entidad).ToString());
                        //Console.WriteLine(c.Name);
                        //Console.WriteLine("Propiedad " + propertyInfo.Name.ToString());

                        if (c.Name.Contains(propertyInfo.Name.ToString()))
                        {
                            if (c.GetType().Name == "TextBox")
                            {
                                c.Text = propertyInfo.GetValue(entidad).ToString().Trim();
                            }
                            else if (c is ComboBox)
                            {
                                if (propertyInfo.PropertyType == typeof(string))
                                    ((ComboBox)c).SelectedValue = propertyInfo.GetValue(entidad).ToString();
                                if (propertyInfo.PropertyType == typeof(Int32))
                                    ((ComboBox)c).SelectedValue = propertyInfo.GetValue(entidad);
                            }
                            else if (c is GroupBox)
                            {
                                foreach (Control g in c.Controls)
                                {
                                    if (g is RadioButton)
                                    {
                                        var nombreRadio = entidad.radios[(int)propertyInfo.GetValue(entidad)];
                                        if (g.Name.Contains(nombreRadio))
                                        {
                                            ((RadioButton)g).Checked = true;
                                        }
                                    }
                                }
                            }
                            else if (c is CheckBox)
                            {
                                if ((int)propertyInfo.GetValue(entidad) == 1)
                                {
                                    ((CheckBox)c).Checked = true;
                                }
                            }
                            else if (c is DateTimePicker)
                            {
                                ((DateTimePicker)c).Value = propertyInfo.GetValue(entidad);
                            }

                        }
                    }
                }
            }
        }
        public int validarFormulario(object instance)
        {
            ValidationContext context = new ValidationContext(instance, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(instance, context, errors, true))
            {
                var mensaje = "";
                foreach (ValidationResult result in errors)
                    mensaje += result + "\n";
                MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            else
            {
                return 1;
            }

        }
        public void funcionAlConcluir(Panel panel, CheckBox chk, Form form)
        {
            if (chk.Checked == true)
            {
                limpiarControles(panel, form);
            }
            else
            {
                form.Close();
            }
        }
        public void limpiarControles(Panel panel, Form frm)
        {
            foreach (var ctrl in panel.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
                else if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = false;
                }
                else if (ctrl is GroupBox)
                {
                    foreach (Control g in ((GroupBox)ctrl).Controls)
                    {
                        if (g is RadioButton)
                        {
                            ((RadioButton)g).Checked = false;
                            if (Convert.ToInt32(((RadioButton)g).Tag) == 0)
                            {
                                ((RadioButton)g).Checked = true;
                            }
                        }
                    }
                }
            }
        }
        public async Task llenarCombo(ComboBox combo, object instance, string display, string valuemember)
        {
            try
            {
                combo.DataSource = instance;
                combo.DisplayMember = display;
                combo.ValueMember = valuemember;
                combo.SelectedItem = null;
                combo.SelectedText = "--Seleccione--";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el ComboBox: " + ex.ToString());
            }

        }
    }
}
