using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Configuration;

namespace Monitoreo
{
    public partial class MexicoIra : Form
    {
        public MexicoIra()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        private void btnAceptar2_Click(object sender, EventArgs e)
        {
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            string message = "Esto podria demorar uno o mas minutos, por favor espere...";
            string caption = "Cargando...";

            string message2 = "Carga completa, gracias por la espera.";
            string caption2 = "Completado";

            PrincipalIra principal = new PrincipalIra();
            bool Tepozotlan2 = false;
            bool Jorobas2 = false;
            bool Polotitlan2 = false;
            bool Palmillas2 = false;
            bool Chichemequillas2 = false;
            bool Queretaro2 = false;
            bool Libramiento2 = false;
            bool VillaGrande2 = false;
            bool CerroGordo2 = false;
            bool Salamanca2 = false;

            if (TepozotlanCB.Checked == true)
            {
                Tepozotlan2 = true;
            }
            if (JorobasCB.Checked == true)
            {
                Jorobas2 = true;
            }
            if (PotitlanCB.Checked == true)
            {
                Polotitlan2 = true;
            }
            if (PalmillasCB.Checked == true)
            {
                Palmillas2 = true;
            }
            if (ChichemequillasCB.Checked == true)
            {
                Chichemequillas2 = true;
            }
            if (QueretaroCB.Checked == true)
            {
                Queretaro2 = true;
            }
            if (LibramientoCB.Checked == true)
            {
                Libramiento2 = true;
            }
            if (VillaGrandeCB.Checked == true)
            {
                VillaGrande2 = true;
            }
            if (CerroGordoCB.Checked == true)
            {
                CerroGordo2 = true;
            }
            if (SalamancaCB.Checked == true)
            {
                Salamanca2 = true;
            }
            MessageBox.Show(message, caption, buttons, icon);
            principal.PrincipalF(Tepozotlan2, Jorobas2, Polotitlan2, Palmillas2, Chichemequillas2, Queretaro2, Libramiento2, VillaGrande2, CerroGordo2, Salamanca2);

            List<string[]> list = new List<string[]>();

            if (TepozotlanCB.Checked == true)
            {
                list.Add(principal.TepozotlanP);
            }
            if (JorobasCB.Checked == true)
            {
                list.Add(principal.JorobasP);
            }
            if (PotitlanCB.Checked == true)
            {
                list.Add(principal.PolotitlanP);
            }
            if (PalmillasCB.Checked == true)
            {
                list.Add(principal.PalmillasP);
            }
            if (ChichemequillasCB.Checked == true)
            {
                list.Add(principal.ChichemequillasP);
            }
            if (QueretaroCB.Checked == true)
            {
                list.Add(principal.QueretaroP);
            }
            if (LibramientoCB.Checked == true)
            {
                list.Add(principal.LibramientoP);
            }
            if (VillaGrandeCB.Checked == true)
            {
                list.Add(principal.VillaGrandeP);
            }
            if (CerroGordoCB.Checked == true)
            {
                list.Add(principal.CerroGordoP);
            }
            if (SalamancaCB.Checked == true)
            {
                list.Add(principal.SalamancaP);
            }
            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item);
            }

            MessageBox.Show(message2, caption2, buttons, icon);

            btnAceptar2.Enabled = false;
            timer1.Start();
        }
        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            TepozotlanCB.Checked = false;
            JorobasCB.Checked = false;
            PotitlanCB.Checked = false;
            PalmillasCB.Checked = false;
            ChichemequillasCB.Checked = false;
            QueretaroCB.Checked = false;
            LibramientoCB.Checked = false;
            VillaGrandeCB.Checked = false;
            CerroGordoCB.Checked = false;
            SalamancaCB.Checked = false;

            dataGridView1.Rows.Clear();
            timer1.Stop();

            btnAceptar2.Enabled = true;
        }
        private void btnList_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            MexicoAca mexicoAca = new MexicoAca();
            mexicoAca.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string message = "¿Seguro desea cerrar la aplicacion?";
            string caption = "¡Alerta!";

            result = MessageBox.Show(message, caption, buttons, icon);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                timer1.Stop();
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
    
            PrincipalIra principal = new PrincipalIra();
            bool Tepozotlan2 = false;
            bool Jorobas2 = false;
            bool Polotitlan2 = false;
            bool Palmillas2 = false;
            bool Chichemequillas2 = false;
            bool Queretaro2 = false;
            bool Libramiento2 = false;
            bool VillaGrande2 = false;
            bool CerroGordo2 = false;
            bool Salamanca2 = false;

            if (TepozotlanCB.Checked == true)
            {
                Tepozotlan2 = true;
            }
            if (JorobasCB.Checked == true)
            {
                Jorobas2 = true;
            }
            if (PotitlanCB.Checked == true)
            {
                Polotitlan2 = true;
            }
            if (PalmillasCB.Checked == true)
            {
                Palmillas2 = true;
            }
            if (ChichemequillasCB.Checked == true)
            {
                Chichemequillas2 = true;
            }
            if (QueretaroCB.Checked == true)
            {
                Queretaro2 = true;
            }
            if (LibramientoCB.Checked == true)
            {
                Libramiento2 = true;
            }
            if (VillaGrandeCB.Checked == true)
            {
                VillaGrande2 = true;
            }
            if (CerroGordoCB.Checked == true)
            {
                CerroGordo2 = true;
            }
            if (SalamancaCB.Checked == true)
            {
                Salamanca2 = true;
            }
          
            principal.PrincipalF(Tepozotlan2, Jorobas2, Polotitlan2, Palmillas2, Chichemequillas2, Queretaro2, Libramiento2, VillaGrande2, CerroGordo2, Salamanca2);

            List<string[]> list = new List<string[]>();

            if (TepozotlanCB.Checked == true)
            {
                list.Add(principal.TepozotlanP);
            }
            if (JorobasCB.Checked == true)
            {
                list.Add(principal.JorobasP);
            }
            if (PotitlanCB.Checked == true)
            {
                list.Add(principal.PolotitlanP);
            }
            if (PalmillasCB.Checked == true)
            {
                list.Add(principal.PalmillasP);
            }
            if (ChichemequillasCB.Checked == true)
            {
                list.Add(principal.ChichemequillasP);
            }
            if (QueretaroCB.Checked == true)
            {
                list.Add(principal.QueretaroP);
            }
            if (LibramientoCB.Checked == true)
            {
                list.Add(principal.LibramientoP);
            }
            if (VillaGrandeCB.Checked == true)
            {
                list.Add(principal.VillaGrandeP);
            }
            if (CerroGordoCB.Checked == true)
            {
                list.Add(principal.CerroGordoP);
            }
            if (SalamancaCB.Checked == true)
            {
                list.Add(principal.SalamancaP);
            }

            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item);
            }

            btnAceptar2.Enabled = false;
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "lstabintDGV")  //Si es la columna a evaluar
            {
                if (e.Value.ToString().Contains("Desactualizada"))   //Si el valor de la celda contiene la palabra hora
                {
                    e.CellStyle.BackColor = Color.LightYellow;
                }
                else if (e.Value.ToString().Contains("Sin conexion"))
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                }
                else if (e.Value.ToString().Contains("No se encontro la ruta"))
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                }
                else if (e.Value.ToString().Contains("No hay lista"))
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                }
            }
            else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "webServiceDGV")//Si es la columna a evaluar
            {
                if (e.Value.ToString().Contains("Sin conexion"))   //Si el valor de la celda contiene la palabra hora
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                }
                else if (e.Value.ToString().Contains("SQL no visible"))  //Si el valor de la celda contiene la palabra hora");
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                }
            }
        }
    }
}
