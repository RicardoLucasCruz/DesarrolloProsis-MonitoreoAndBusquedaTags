﻿using System;
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
            btnUpdate.Enabled = false;
        }
        private async void btnAceptar2_Click(object sender, EventArgs e)
        {
            Loading loading = new Loading();
            loading.Show();

            Task task = new Task(BotonAceptar);
            task.Start();
            await task;

            loading.Hide ();
        }
        public void BotonAceptar()
        {
            CheckForIllegalCrossThreadCalls = false;

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            lbFecha.Text = $"Ultima actualizacion: {dateTime}";

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

            TepozotlanCB.Enabled = false;
            JorobasCB.Enabled = false;
            PotitlanCB.Enabled = false;
            PalmillasCB.Enabled = false;
            ChichemequillasCB.Enabled = false;
            QueretaroCB.Enabled = false;
            LibramientoCB.Enabled = false;
            VillaGrandeCB.Enabled = false;
            CerroGordoCB.Enabled = false;
            SalamancaCB.Enabled = false;

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

            btnUpdate.Enabled = true;
            btnAceptar2.Enabled = false;
        }
        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            lbFecha.Text = "Ultima actualizacion:";
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

            TepozotlanCB.Enabled = true;
            JorobasCB.Enabled = true;
            PotitlanCB.Enabled = true;
            PalmillasCB.Enabled = true;
            ChichemequillasCB.Enabled = true;
            QueretaroCB.Enabled = true;
            LibramientoCB.Enabled = true;
            VillaGrandeCB.Enabled = true;
            CerroGordoCB.Enabled = true;
            SalamancaCB.Enabled = true;

            dataGridView1.Rows.Clear();
            btnUpdate.Enabled = false;
            btnAceptar2.Enabled = true;
        }
        private void btnList_Click_1(object sender, EventArgs e)
        {
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
            }            
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

        private void btnMonitoreo_Click(object sender, EventArgs e)
        {
            this.Hide();
            BusquedaTag busqueda = new BusquedaTag();
            busqueda.Show();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            Loading loading = new Loading();
            loading.Show();

            Task task = new Task(BotonActualizar);
            task.Start();
            await task;

            loading.Hide();
        }       
        public void BotonActualizar()
        {
            CheckForIllegalCrossThreadCalls = false;

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            lbFecha.Text = $"Ultima actualizacion: {dateTime}";
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
    }
}
