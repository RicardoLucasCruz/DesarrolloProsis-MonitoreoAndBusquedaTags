using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitoreo
{
    public partial class BusquedaTag : Form
    {
        public BusquedaTag()
        {
            InitializeComponent();
            txtTagBuscar.Enabled = false;
            txtTag.Enabled = false;
            txtMoney.Enabled = false;
            txtLista.Enabled = false;
            btnBuscar.Enabled = false;
            btnLimpiar.Enabled = false;
            txtResiden.Enabled = false;
            txtFechaCreacion.Enabled = false;
            txtEstatus.Text = "";
            txtEstatus.Enabled = false;
        }
        private string Ruta;
        private string Nombre;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string message = "¿Seguro desea cerrar la aplicacion?";
            string caption = "Alerta";

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string ruta = txtRuta.Text;

            if (ruta == "z:" || ruta == "Z:")
            {
                Nombre = Metodos.ValidarRuta(ruta);
            }
            else
            {
                Nombre = Metodos.ValidarRutaLarga(ruta);
            }

            if (ruta == "")
            {
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                string message = "Debe ingresar una ruta";
                string caption = "Alerta";
                MessageBox.Show(message, caption, buttons, icon);
                txtRuta.Text = "";
            }
            else if (Nombre == null || Nombre == "" || Nombre == "Sin conexion, o ruta no encontrada")
            {
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                string message = "Lista LSTABINT no encontrada, compruebe si la ruta esta escrita correctamente o de lo contrario verifique su existencia";
                string caption = "Error";
                MessageBox.Show(message, caption, buttons, icon);
                txtRuta.Text = "";
            }
            else
            {
                txtTagBuscar.Enabled = true;
                Ruta = ruta;
                txtRuta.Text = Ruta;
                txtRuta.Enabled = false;
                btnAceptar.Enabled = false;
                btnBuscar.Enabled = true;
            }
        }

        private void btnLimpiarRuta_Click(object sender, EventArgs e)
        {
            txtRuta.Text = "";
            txtRuta.Enabled = true;
            btnAceptar.Enabled = true;
            txtTagBuscar.Enabled = false;
            txtTagBuscar.Text = "";
            txtLista.Text = "";
            txtMoney.Text = "";
            txtTag.Text = "";
            txtTagBuscar.Enabled = false;
            txtTag.Enabled = false;
            txtMoney.Enabled = false;
            txtLista.Enabled = false;
            btnBuscar.Enabled = false;
            btnLimpiar.Enabled = false;
            txtResiden.Text = "";
            txtFechaCreacion.Text = "";
            txtEstatus.Text = "";
            txtEstatus.BackColor = Color.White;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string tag = txtTagBuscar.Text;

            if (tag == "")
            {
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                string message = "Debe ingresar un tag";
                string caption = "Alerta";
                MessageBox.Show(message, caption, buttons, icon);
                txtTagBuscar.Text = "";
            }
            else
            {
                string rutaTag;
                FileInfo file;

                if (Ruta == "z:" || Ruta == "Z:")
                {
                    rutaTag = $@"{Ruta}\\PARAM\\ACTUEL\\{Nombre}";
                    file = new FileInfo($@"{Ruta}\\PARAM\\ACTUEL\\{Nombre}");
                }
                else
                {
                    rutaTag = $@"{Ruta}\\{Nombre}";
                    file = new FileInfo($@"{Ruta}\\{Nombre}");
                }

                string res = Metodos.BuscarTag(rutaTag, tag);

                if (res == "" || res == "No se encontro la ruta")
                {
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    string message = "Tag no encontrado, verifique si esta escrito correctamente o de lo contrario compruebe su existencia";
                    string caption = "Error";
                    MessageBox.Show(message, caption, buttons, icon);
                    txtTagBuscar.Text = "";
                }
                else
                {
                    txtTag.Text = tag;
                    int pesos = Convert.ToInt16(res.Substring(28, 6));
                    int centavos = Convert.ToInt16(res.Substring(34, 2));
                    string money = $"${pesos}.{centavos}";
                    DateTime date = file.LastWriteTime;
                    string validacion = Convert.ToString(res.Substring(26, 2));
                    string residente = Convert.ToString(res.Substring(55, 2));
                    txtFechaCreacion.Text = Convert.ToString(date);
                    if (validacion == "01")
                    {
                        txtEstatus.Text = "Valido";
                        txtEstatus.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        txtEstatus.Text = "Invalido";
                        txtEstatus.BackColor = Color.OrangeRed;
                    }
                    if (residente == "00")
                    {
                        txtResiden.Text = $"No es residente {residente}";
                    }
                    else
                    {
                        txtResiden.Text = $"Si es residente {residente}";
                    }
                    txtMoney.Text = money;
                    txtTagBuscar.Text = tag;
                    txtTagBuscar.Enabled = false;
                    txtLista.Text = Nombre;
                    btnLimpiar.Enabled = true;
                    btnBuscar.Enabled = false;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTagBuscar.Text = "";
            txtLista.Text = "";
            txtMoney.Text = "";
            txtTag.Text = "";
            txtTagBuscar.Enabled = true;
            btnLimpiar.Enabled = false;
            btnBuscar.Enabled = true;
            txtResiden.Text = "";
            txtFechaCreacion.Text = "";
            txtEstatus.Text = "";
            txtEstatus.BackColor = Color.White;
        }

        private void btnMonitoreo_Click(object sender, EventArgs e)
        {
            this.Hide();
            MexicoIra mexicoAca = new MexicoIra();
            mexicoAca.Show();
        }
    }
}
