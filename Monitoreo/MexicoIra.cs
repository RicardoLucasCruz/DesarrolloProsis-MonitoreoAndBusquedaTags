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
    public partial class formMexicoIra : Form
    {
        public formMexicoIra()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            btnUpdate.Enabled = false;
        }
<<<<<<< HEAD

        public int contador = 0;

        private async void btnAceptar2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
=======
        private async void btnAceptar2_Click(object sender, EventArgs e)
        {
>>>>>>> origin
            Loading loading = new Loading();
            loading.Show();

            Task task = new Task(BotonAceptar);
            task.Start();
            await task;
<<<<<<< HEAD
=======

            loading.Hide ();
        }
        public void BotonAceptar()
        {
            CheckForIllegalCrossThreadCalls = false;

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            lbFecha.Text = $"Ultima actualizacion: {dateTime}";
>>>>>>> origin

            loading.Hide ();
        }
        public void BotonAceptar()
        {
            List<Flag> flags = getBanderas.GetAll(Convert.ToString(ConfigurationManager.ConnectionStrings["Global"]));

            if (flags.Count != 0)
            {
<<<<<<< HEAD
                CheckForIllegalCrossThreadCalls = false;
=======
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
>>>>>>> origin

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
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBoxButtons buttons = MessageBoxButtons.OK; ;
                string message = "No hay conexion con la base de datos";
                string caption = "¡Alerta!";
                MessageBox.Show(message, caption, buttons, icon);
            }
<<<<<<< HEAD
=======

            btnUpdate.Enabled = true;
            btnAceptar2.Enabled = false;
>>>>>>> origin
        }
        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            contador = 0;
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
            timer1.Stop();
            this.Hide();
            MexicoAca mexicoAca = new MexicoAca();
            mexicoAca.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            timer1.Stop();
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
        private void btnMonitoreo_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            BusquedaTag busqueda = new BusquedaTag();
            busqueda.Show();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
<<<<<<< HEAD
        {
            timer1.Start();
            contador = 0;
            Loading loading = new Loading();
            loading.Show();

            Task task = new Task(BotonActualizar);
            task.Start();
            await task;

            loading.Hide();
        }       
        public void BotonActualizar()
        {
=======
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
>>>>>>> origin
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

        private void formMexicoIra_Load(object sender, EventArgs e)
        {
            panel2.Location = new Point(10, 140);
            panel1.Location = new Point(986, 140);

            PaletaColores.ElegirTema("Defecto");
            tableLayoutPanel3.BackColor = PaletaColores.titulos;
            tableLayoutPanel5.BackColor = PaletaColores.titulos;

            panel1.BackColor = PaletaColores.panelFondos;
            panel2.BackColor = PaletaColores.panelFondos;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = PaletaColores.panelTitulos;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = PaletaColores.panelTitulos;
            dataGridView1.RowsDefaultCellStyle.BackColor = PaletaColores.backGrilla;
            dataGridView1.BackgroundColor = PaletaColores.backGrilla;
            dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = PaletaColores.panelTitulos;
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = PaletaColores.panelTitulos;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = PaletaColores.panelTitulos;
            dataGridView1.GridColor = Color.White;

            btnMonitoreo.BackColor = PaletaColores.panelBotones;
            btnSalir.BackColor = PaletaColores.panelBotones;
            btnList.BackColor = PaletaColores.panelBotones;
            btnUpdate.BackColor = PaletaColores.panelBotones;
            btnAceptar2.BackColor = PaletaColores.panelBotones;
            btnLimpiar2.BackColor = PaletaColores.panelBotones;
            btnMonitoreo.FlatStyle = FlatStyle.Flat;
            btnMonitoreo.FlatAppearance.BorderColor = Color.White;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderColor = Color.White;
            btnList.FlatStyle = FlatStyle.Flat;
            btnList.FlatAppearance.BorderColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderColor = Color.White;
            btnAceptar2.FlatStyle = FlatStyle.Flat;
            btnAceptar2.FlatAppearance.BorderColor = Color.White;
            btnLimpiar2.FlatStyle = FlatStyle.Flat;
            btnLimpiar2.FlatAppearance.BorderColor = Color.White;

            label4.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            lbFecha.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            tableLayoutPanel2.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.White;
            btnMonitoreo.ForeColor = Color.White;
            btnSalir.ForeColor = Color.White;
            btnList.ForeColor = Color.White;
            btnUpdate.ForeColor = Color.White;
            btnAceptar2.ForeColor = Color.White;
            btnLimpiar2.ForeColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;
            if (contador == 1)
            {
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBoxButtons buttons = MessageBoxButtons.OK; ;
                string message = "Favor de checar las LSTABINT, han pasado 30 minutos desde la ultima actualizacion";
                string caption = "¡Alerta!";
                MessageBox.Show(message, caption, buttons, icon);
            }
        }
    }
}
