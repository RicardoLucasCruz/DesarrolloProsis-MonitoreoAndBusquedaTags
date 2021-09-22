using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private void btnList_Click(object sender, EventArgs e)
        {
            this.Hide();
            MexicoIra mexicoAca = new MexicoIra();
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

        private async void btnAceptar2_Click(object sender, EventArgs e)
        {
            Loading loading = new Loading();
            loading.Show();

            Task task = new Task(BotonAceptar);
            task.Start();
            await task;

            loading.Hide();
        }
        public void BotonAceptar()
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

        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
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
    }
}
