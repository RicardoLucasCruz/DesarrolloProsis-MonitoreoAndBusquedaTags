using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitoreo
{
    public partial class MexicoAca : Form
    {
        public MexicoAca()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            btnUpdate.Enabled = false;
        }

        public int contador = 0;

        private void btnList_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            formMexicoIra mexicoAca = new formMexicoIra();
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

        private async void btnAceptar2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Loading loading = new Loading();
            loading.Show();

            Task task = new Task(BotonAceptar);
            task.Start();
            await task;

            loading.Hide();
        }
        public void BotonAceptar()
        {
            List<Flag> flags = getBanderas.GetAll(Convert.ToString(ConfigurationManager.ConnectionStrings["Global"]));

            if (flags.Count != 0)
            {
                CheckForIllegalCrossThreadCalls = false;

                PrincipalAca principal = new PrincipalAca();

                bool Alpuyeca = false;
                bool PasoMorelos = false;
                bool PaloBlanco = false;
                bool LaVenta = false;
                bool Xochitepec = false;
                bool Aeropuerto = false;
                bool EmilianoZapata = false;
                bool Tlalpan = false;
                bool TresMarias = false;
                bool FrancisciVelazco = false;

                if (AlpuyecaCB.Checked == true)
                {
                    Alpuyeca = true;
                }
                if (PasoMorelosCB.Checked == true)
                {
                    PasoMorelos = true;
                }
                if (PaloBlancoCB.Checked == true)
                {
                    PaloBlanco = true;
                }
                if (LaVentaCB.Checked == true)
                {
                    LaVenta = true;
                }
                if (XochitepecCB.Checked == true)
                {
                    Xochitepec = true;
                }
                if (AeropuertoCB.Checked == true)
                {
                    Aeropuerto = true;
                }
                if (EmilianoZapataCB.Checked == true)
                {
                    EmilianoZapata = true;
                }
                if (TlalpanCB.Checked == true)
                {
                    Tlalpan = true;
                }
                if (TresMariasCB.Checked == true)
                {
                    TresMarias = true;
                }
                if (FranciscoVelazcoCB.Checked == true)
                {
                    FrancisciVelazco = true;
                }

                EmilianoZapataCB.Enabled = false;
                AeropuertoCB.Enabled = false;
                XochitepecCB.Enabled = false;
                PaloBlancoCB.Enabled = false;
                PasoMorelosCB.Enabled = false;
                AlpuyecaCB.Enabled = false;
                TlalpanCB.Enabled = false;
                TresMariasCB.Enabled = false;
                LaVentaCB.Enabled = false;
                FranciscoVelazcoCB.Enabled = false;

                DateTime dateTime = new DateTime();
                dateTime = DateTime.Now;
                lbFecha.Text = $"Ultima actualizacion: {dateTime}";

                principal.PrincipalF(Alpuyeca, PasoMorelos, PaloBlanco, LaVenta, Xochitepec, Aeropuerto, EmilianoZapata, Tlalpan, TresMarias, FrancisciVelazco);

                List<string[]> list = new List<string[]>();

                if (AlpuyecaCB.Checked == true)
                {
                    list.Add(principal.AlpuyecaP);
                }
                if (PasoMorelosCB.Checked == true)
                {
                    list.Add(principal.PasoMorelosP);
                }
                if (PaloBlancoCB.Checked == true)
                {
                    list.Add(principal.PoloBlancoP);
                }
                if (LaVentaCB.Checked == true)
                {
                    list.Add(principal.LaVentaP);
                }
                if (XochitepecCB.Checked == true)
                {
                    list.Add(principal.XochitepecP);
                }
                if (AeropuertoCB.Checked == true)
                {
                    list.Add(principal.AeropuertoP);
                }
                if (EmilianoZapataCB.Checked == true)
                {
                    list.Add(principal.EmilianoZapataP);
                }
                if (TlalpanCB.Checked == true)
                {
                    list.Add(principal.TlalpanP);
                }
                if (TresMariasCB.Checked == true)
                {
                    list.Add(principal.TresMariasP);
                }
                if (FranciscoVelazcoCB.Checked == true)
                {
                    list.Add(principal.FranciscoVelazcoP);
                }

                foreach (var item in list)
                {
                    dataGridView1.Rows.Add(item);
                }

                btnAceptar2.Enabled = false;
                btnUpdate.Enabled = true;
            }
            else
            {
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBoxButtons buttons = MessageBoxButtons.OK; ;
                string message = "No hay conexion con la base de datos";
                string caption = "¡Alerta!";
                MessageBox.Show(message, caption, buttons, icon);
            }
        }

        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            contador = 0;
            timer1.Stop();
            lbFecha.Text = "Ultima actualizacion:";
            AlpuyecaCB.Checked = false;
            PasoMorelosCB.Checked = false;
            PaloBlancoCB.Checked = false;
            LaVentaCB.Checked = false;
            XochitepecCB.Checked = false;
            AeropuertoCB.Checked = false;
            EmilianoZapataCB.Checked = false;
            TlalpanCB.Checked = false;
            TresMariasCB.Checked = false;
            FranciscoVelazcoCB.Checked = false;

            AlpuyecaCB.Enabled = true;
            PasoMorelosCB.Enabled = true;
            PaloBlancoCB.Enabled = true;
            LaVentaCB.Enabled = true;
            XochitepecCB.Enabled = true;
            AeropuertoCB.Enabled = true;
            EmilianoZapataCB.Enabled = true;
            TlalpanCB.Enabled = true;
            TresMariasCB.Enabled = true;
            FranciscoVelazcoCB.Enabled = true;

            dataGridView1.Rows.Clear();
            btnUpdate.Enabled = false;
            btnAceptar2.Enabled = true;
        }
        private void btnMonitoreo_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            BusquedaTag busqueda = new BusquedaTag();
            busqueda.Show();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            contador = 0;
            timer1.Start();
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

            PrincipalAca principal = new PrincipalAca();
            bool Alpuyeca = false;
            bool PasoMorelos = false;
            bool PaloBlanco = false;
            bool LaVenta = false;
            bool Xochitepec = false;
            bool Aeropuerto = false;
            bool EmilianoZapata = false;
            bool Tlalpan = false;
            bool TresMarias = false;
            bool FrancisciVelazco = false;

            if (AlpuyecaCB.Checked == true)
            {
                Alpuyeca = true;
            }
            if (PasoMorelosCB.Checked == true)
            {
                PasoMorelos = true;
            }
            if (PaloBlancoCB.Checked == true)
            {
                PaloBlanco = true;
            }
            if (LaVentaCB.Checked == true)
            {
                LaVenta = true;
            }
            if (XochitepecCB.Checked == true)
            {
                Xochitepec = true;
            }
            if (AeropuertoCB.Checked == true)
            {
                Aeropuerto = true;
            }
            if (EmilianoZapataCB.Checked == true)
            {
                EmilianoZapata = true;
            }
            if (TlalpanCB.Checked == true)
            {
                Tlalpan = true;
            }
            if (TresMariasCB.Checked == true)
            {
                TresMarias = true;
            }
            if (FranciscoVelazcoCB.Checked == true)
            {
                FrancisciVelazco = true;
            }

            principal.PrincipalF(Alpuyeca, PasoMorelos, PaloBlanco, LaVenta, Xochitepec, Aeropuerto, EmilianoZapata, Tlalpan, TresMarias, FrancisciVelazco);

            List<string[]> list = new List<string[]>();

            if (AlpuyecaCB.Checked == true)
            {
                list.Add(principal.AlpuyecaP);
            }
            if (PasoMorelosCB.Checked == true)
            {
                list.Add(principal.PasoMorelosP);
            }
            if (PaloBlancoCB.Checked == true)
            {
                list.Add(principal.PoloBlancoP);
            }
            if (LaVentaCB.Checked == true)
            {
                list.Add(principal.LaVentaP);
            }
            if (XochitepecCB.Checked == true)
            {
                list.Add(principal.XochitepecP);
            }
            if (AeropuertoCB.Checked == true)
            {
                list.Add(principal.AeropuertoP);
            }
            if (EmilianoZapataCB.Checked == true)
            {
                list.Add(principal.EmilianoZapataP);
            }
            if (TlalpanCB.Checked == true)
            {
                list.Add(principal.TlalpanP);
            }
            if (TresMariasCB.Checked == true)
            {
                list.Add(principal.TresMariasP);
            }
            if (FranciscoVelazcoCB.Checked == true)
            {
                list.Add(principal.FranciscoVelazcoP);
            }

            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item);
            }

            btnAceptar2.Enabled = false;
        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "lstabintDGV")  //Si es la columna a evaluar
            {
                if (e.Value.ToString().Contains("Desactualizada"))   //Si el valor de la celda contiene la palabra hora
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (e.Value.ToString().Contains("Sin conexion"))
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (e.Value.ToString().Contains("No se encontro la ruta"))
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (e.Value.ToString().Contains("No hay lista"))
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
            else if (this.dataGridView1.Columns[e.ColumnIndex].Name == "webServiceDGV")//Si es la columna a evaluar
            {
                if (e.Value.ToString().Contains("Sin conexion"))   //Si el valor de la celda contiene la palabra hora
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (e.Value.ToString().Contains("SQL no visible"))  //Si el valor de la celda contiene la palabra hora");
                {
                    e.CellStyle.BackColor = Color.OrangeRed;
                    e.CellStyle.ForeColor = Color.Black;
                }
                if (e.Value.ToString().Contains("Desactualizada"))   //Si el valor de la celda contiene la palabra hora
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void MexicoAca_Load(object sender, EventArgs e)
        {
            panel2.Location = new Point(10, 140);
            panel1.Location = new Point(983, 144);

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
        private void timer1_Tick_1(object sender, EventArgs e)
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
