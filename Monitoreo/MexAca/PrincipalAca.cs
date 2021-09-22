using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Configuration;

namespace Monitoreo
{
    class PrincipalAca
    {
        //Declaracion de variables******************************************************
        public string[] AlpuyecaP { get; set; }
        public string[] PasoMorelosP { get; set; }
        public string[] PoloBlancoP { get; set; }
        public string[] LaVentaP { get; set; }
        public string[] XochitepecP { get; set; }
        public string[] AeropuertoP { get; set; }
        public string[] EmilianoZapataP { get; set; }
        public string[] TlalpanP { get; set; }
        public string[] TresMariasP { get; set; }
        public string[] FranciscoVelazcoP { get; set; }

        //LSBINT
        string AlpuyecaLS;
        string PasoMorelosLS;
        string PoloBlancoLS;
        string LaVentaLS;
        string XochitepecLS;
        string AeropuertoLS;
        string EmilianoZapataLS;
        string TlalpanLS;
        string TresMariasLS;
        string FranciscoVelazcoLS;
        //End LSBINT

        //Tamaño LSTABINT
        string AlpuyecaTamaño;
        string PasoMorelosTamaño;
        string PoloBlancoTamaño;
        string LaVentaTamaño;
        string XochitepecTamaño;
        string AeropuertoTamaño;
        string EmilianoZapataTamaño;
        string TlalpanTamaño;
        string TresMariasTamaño;
        string FranciscoVelazcoTamaño;
        //End Tamaño LSTABINT

        //Ultimas transacciones WS
        string Ult_WS_Al = "";
        string Ult_WS_PsM = "";
        string Ult_WS_PoB = "";
        string Ult_WS_LaV = "";
        string Ult_WS_Xo = "";
        string Ult_WS_Ae = "";
        string Ult_WS_Em = "";
        string Ult_WS_Tl = "";
        string Ult_WS_Tr = "";
        string Ult_WS_FrV = "";
        //End transacciones WS

        //Banderas conexion
        bool B_Al_Serv = false;
        bool B_Al_WS = false;
        bool B_PsM_Serv = false;
        bool B_PsM_WS = false;
        bool B_LaV_Serv = false;
        bool B_LaV_WS = false;
        bool B_Xo_Serv = false;
        bool B_Xo_WS = false;
        bool B_Ae_Serv = false;
        bool B_Ae_WS = false;
        bool B_Em_Serv = false;
        bool B_Em_WS = false;
        bool B_Tl_Serv = false;
        bool B_Tl_WS = false;
        bool B_Tr_Serv = false;
        bool B_Tr_WS = false;
        bool B_FrV_Serv = false;
        bool B_FrV_WS = false;
        bool B_PoB_Serv = false;
        bool B_PoB_WS = false;
        //End Banderas conexion

        //Banderas Transacciones WS Actualizadas
        bool B_WS_Al_Serv = false;
        bool B_WS_Al_WS = false;
        bool B_WS_PsM_Serv = false;
        bool B_WS_PsM_WS = false;
        bool B_WS_PoB_Serv = false;
        bool B_WS_PoB_WS = false;
        bool B_WS_LaV_Serv = false;
        bool B_WS_LaV_WS = false;
        bool B_WS_Xo_Serv = false;
        bool B_WS_Xo_WS = false;
        bool B_WS_Ae_Serv = false;
        bool B_WS_Ae_WS = false;
        bool B_WS_Em_Serv = false;
        bool B_WS_Em_WS = false;
        bool B_WS_Tl_Serv = false;
        bool B_WS_Tl_WS = false;
        bool B_WS_Tr_Serv = false;
        bool B_WS_Tr_WS = false;
        bool B_WS_FrV_Serv = false;
        bool B_WS_FrV_WS = false;
        //End Banderas Transacciones WS Actualizadas 

        //Bandera LSTABINT
        bool B_LSTABINT_Al = false;
        bool B_LSTABINT_PsM = false;
        bool B_LSTABINT_PoB = false;
        bool B_LSTABINT_LaV = false;
        bool B_LSTABINT_Xo = false;
        bool B_LSTABINT_Ae = false;
        bool B_LSTABINT_Em = false;
        bool B_LSTABINT_Tl = false;
        bool B_LSTABINT_Tr = false;
        bool B_LSTABINT_FrV = false;

        bool B_TamañoLSTABINT_Al = true;
        bool B_TamañoLSTABINT_PsM = false;
        bool B_TamañoLSTABINT_PoB = false;
        bool B_TamañoLSTABINT_LaV = false;
        bool B_TamañoLSTABINT_Xo = false;
        bool B_TamañoLSTABINT_Ae = false;
        bool B_TamañoLSTABINT_Em = false;
        bool B_TamañoLSTABINT_Tl = false;
        bool B_TamañoLSTABINT_Tr = false;
        bool B_TamañoLSTABINT_Frv = false;
        //End Bandera LSTABINT

        bool StatusConectionChange = false;
        bool StatusWSChange = false;
        bool StatusLSTABINTChange = false;
        bool StatusSizeChange = false;

        //End Bandera LSTABINT

            /// <summary>
            /// En esta funcion lo que se hace es llamar al la funcion GetFlags, tambien a cada plaza se le da sus datos para asi ser mostradas
            /// </summary>
            /// <param name="Alpuyeca"></param>
            /// <param name="PasoMorelos"></param>
            /// <param name="PaloBlanco"></param>
            /// <param name="LaVenta"></param>
            /// <param name="Xochitepec"></param>
            /// <param name="Aeropuerto"></param>
            /// <param name="EmilianoZapata"></param>
            /// <param name="Tlalpan"></param>
            /// <param name="TresMarias"></param>
            /// <param name="FranciscoVelazco"></param>
        public void PrincipalF(bool Alpuyeca, bool PasoMorelos, bool PaloBlanco, bool LaVenta, bool Xochitepec, bool Aeropuerto, bool EmilianoZapata, bool Tlalpan, bool TresMarias, bool FranciscoVelazco)
        {
            GetFlags(Convert.ToString(ConfigurationManager.ConnectionStrings["Global"]));
             
            //LSTABINT y WS******************************************************
            if (Alpuyeca == true)
            {
                //Alpuyeca
                var APappSettings = ConfigurationManager.AppSettings["AlpuyecaIP"];
                var APappSettingsR = ConfigurationManager.AppSettings["AlpuyecaRuta"];
                AlpuyecaLS = getLSTABINT(APappSettings, APappSettingsR, B_Al_Serv, B_LSTABINT_Al);

                if (StatusConectionChange == true)
                {
                    B_Al_Serv = !B_Al_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_Al = !B_LSTABINT_Al;
                    StatusLSTABINTChange = false;
                }

                if (AlpuyecaLS.Contains("Sin conexion"))
                {
                    AlpuyecaTamaño = "Sin conexion con " + APappSettings;
                }
                else
                {
                    AlpuyecaTamaño = TamañoLSTABINT(APappSettingsR, AlpuyecaLS, B_TamañoLSTABINT_Al);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_Al = !B_TamañoLSTABINT_Al;
                    StatusSizeChange = false;
                }
                //Alpuyeca WS
                var Al79 = ConfigurationManager.AppSettings["Al_IP_79"];
                var conn = ConfigurationManager.AppSettings["AlpulyecaM"];
                Ult_WS_Al = UltimasTransaccionesWS(Al79, Convert.ToString(conn), B_Al_WS, B_WS_Al_WS);

                if (StatusConectionChange == true)
                {
                    B_Al_WS = !B_Al_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_Al_WS = !B_WS_Al_WS;
                    StatusWSChange = false;
                }
            }
            if (PasoMorelos  == true)
            {
                //PasoMorelos
                var PMappSettings = ConfigurationManager.AppSettings["PasoMorelosIP"];
                var PMappSettingsR = ConfigurationManager.AppSettings["PasoMorelosRuta"];
                PasoMorelosLS = getLSTABINT(PMappSettings, PMappSettingsR, B_PsM_Serv, B_LSTABINT_PsM);

                if (StatusConectionChange == true)
                {
                    B_PsM_Serv = !B_PsM_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_PsM = !B_LSTABINT_PsM;
                    StatusLSTABINTChange = false;
                }

                if (PasoMorelosLS.Contains("Sin conexion"))
                {
                    PasoMorelosTamaño = "Sin conexion con " + PMappSettings;
                }
                else
                {
                    PasoMorelosTamaño = TamañoLSTABINT(PMappSettingsR, PasoMorelosLS, B_TamañoLSTABINT_PsM);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_PsM = !B_TamañoLSTABINT_PsM;
                    StatusSizeChange = false;
                }
                //PasoMorelos WS
                var PsM79 = ConfigurationManager.AppSettings["PsM_IP_79"];
                var conn = ConfigurationManager.AppSettings["PasoMorelosM"];
                Ult_WS_PsM = UltimasTransaccionesWS(PsM79, Convert.ToString(conn), B_PsM_WS, B_WS_PsM_WS);

                if (StatusConectionChange == true)
                {
                    B_PsM_WS = !B_PsM_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_PsM_WS = !B_WS_PsM_WS;
                    StatusWSChange = false;
                }
            }
            if (PaloBlanco)
            {
                //Potitlan
                var PoBappSettings = ConfigurationManager.AppSettings["PaloBlancoIP"];
                var PoBappSettingsR = ConfigurationManager.AppSettings["PaloBlancoRuta"];
                PoloBlancoLS = getLSTABINT(PoBappSettings, PoBappSettingsR, B_PoB_Serv, B_LSTABINT_PoB);

                if (StatusConectionChange == true)
                {
                    B_PoB_Serv = !B_PoB_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_PoB = !B_LSTABINT_PoB;
                    StatusLSTABINTChange = false;
                }

                if (PoloBlancoLS.Contains("Sin conexion"))
                {
                    PoloBlancoTamaño = "Sin conexion con " + PoBappSettings;
                }
                else
                {
                    PoloBlancoTamaño = TamañoLSTABINT(PoBappSettingsR, PoloBlancoLS, B_TamañoLSTABINT_PoB);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_PoB = !B_TamañoLSTABINT_PoB;
                    StatusSizeChange = false;
                }
                //Palo Blanco WS
                var PaB79 = ConfigurationManager.AppSettings["PaB_IP_79"];
                var conn = ConfigurationManager.AppSettings["PaloBlancoM"];
                Ult_WS_PoB = UltimasTransaccionesWS(PaB79, Convert.ToString(conn), B_PoB_WS, B_WS_PoB_WS);

                if (StatusConectionChange == true)
                {
                    B_PoB_WS = !B_PoB_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_PoB_WS = !B_WS_PoB_WS;
                    StatusWSChange = false;
                }
            }
            if (LaVenta)
            {
                //La venta
                var LaVappSettings = ConfigurationManager.AppSettings["LaVentaIP"];
                var LaVappSettingsR = ConfigurationManager.AppSettings["LaVentaRuta"];
                LaVentaLS = getLSTABINT(LaVappSettings, LaVappSettingsR, B_LaV_Serv, B_LSTABINT_LaV);

                if (StatusConectionChange == true)
                {
                    B_LaV_Serv = !B_LaV_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_LaV = !B_LSTABINT_LaV;
                    StatusLSTABINTChange = false;
                }

                if (LaVentaLS.Contains("Sin conexion"))
                {
                    LaVentaTamaño = "Sin conexion con " + LaVappSettings;
                }
                else
                {
                    LaVentaTamaño = TamañoLSTABINT(LaVappSettingsR, LaVentaLS, B_TamañoLSTABINT_LaV);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_LaV = !B_TamañoLSTABINT_LaV;
                    StatusSizeChange = false;
                }
                //La venta WS
                var LaV79 = ConfigurationManager.AppSettings["LaV_IP_79"];
                var conn = ConfigurationManager.AppSettings["LaVentaM"];
                Ult_WS_LaV = UltimasTransaccionesWS(LaV79, Convert.ToString(conn), B_LaV_WS, B_WS_LaV_WS);

                if (StatusConectionChange == true)
                {
                    B_LaV_WS = !B_LaV_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_LaV_WS = !B_WS_LaV_WS;
                    StatusWSChange = false;
                }
            }
            if (Xochitepec == true)
            {
                //Xochitepec
                var XoappSettings = ConfigurationManager.AppSettings["XochitepecIP"];
                var XoappSettingsR = ConfigurationManager.AppSettings["XochitepecRuta"];
                XochitepecLS = getLSTABINT(XoappSettings, XoappSettingsR, B_Xo_Serv, B_LSTABINT_Xo);

                if (StatusConectionChange == true)
                {
                    B_Xo_Serv = !B_Xo_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_Xo = !B_LSTABINT_Xo;
                    StatusLSTABINTChange = false;
                }

                if (XochitepecLS.Contains("Sin conexion"))
                {
                    XochitepecTamaño = "Sin conexion con " + XoappSettings;
                }
                else
                {
                    XochitepecTamaño = TamañoLSTABINT(XoappSettingsR, XochitepecTamaño, B_TamañoLSTABINT_Xo);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_Xo = !B_TamañoLSTABINT_Xo;
                    StatusSizeChange = false;
                }
                //Xochitepec WS
                var xo79 = ConfigurationManager.AppSettings["Xo_IP_79"];
                var conn = ConfigurationManager.AppSettings["XochitepecM"];
                Ult_WS_Xo = UltimasTransaccionesWS(xo79, Convert.ToString(conn), B_Xo_WS, B_WS_Xo_WS);

                if (StatusConectionChange == true)
                {
                    B_Xo_WS = !B_Xo_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_Xo_WS = !B_WS_Xo_WS;
                    StatusWSChange = false;
                }
            }
            if (Aeropuerto == true)
            {
                //Aeropuerto
                var AeappSettings = ConfigurationManager.AppSettings["AeropuertoIP"];
                var AeappSettingsR = ConfigurationManager.AppSettings["AeropuertoRuta"];
                AeropuertoLS = getLSTABINT(AeappSettings, AeappSettingsR, B_Ae_Serv, B_LSTABINT_Ae);

                if (StatusConectionChange == true)
                {
                    B_Ae_Serv = !B_Ae_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_Ae = !B_LSTABINT_Ae;
                    StatusLSTABINTChange = false;
                }

                if (AeropuertoLS.Contains("Sin conexion"))
                {
                    AeropuertoTamaño = "Sin conexion con " + AeappSettings;
                }
                else
                {
                    AeropuertoTamaño = TamañoLSTABINT(AeappSettingsR, AeropuertoLS, B_TamañoLSTABINT_Ae);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_Ae = !B_TamañoLSTABINT_Ae;
                    StatusSizeChange = false;
                }
                //Aeropuerto WS
                var Ae79 = ConfigurationManager.AppSettings["Ae_IP_79"];
                var conn = ConfigurationManager.AppSettings["AeropuertoM"];
                Ult_WS_Ae = UltimasTransaccionesWS(Ae79, Convert.ToString(conn), B_Ae_WS, B_WS_Ae_WS);

                if (StatusConectionChange == true)
                {
                    B_Ae_WS = !B_Ae_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_Ae_WS = !B_WS_Ae_WS;
                    StatusWSChange = false;
                }
            }
            if (EmilianoZapata == true)
            {
                //Emiliano Zapata
                var EmZappSettings = ConfigurationManager.AppSettings["EmilianoZapataIP"];
                var EmZappSettingsR = ConfigurationManager.AppSettings["EmilianoZapataRuta"];
                EmilianoZapataLS = getLSTABINT(EmZappSettings, EmZappSettingsR, B_Em_Serv, B_LSTABINT_Em);

                if (StatusConectionChange == true)
                {
                    B_Em_Serv = !B_Em_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_Em = !B_LSTABINT_Em;
                    StatusLSTABINTChange = false;
                }

                if (EmilianoZapataLS.Contains("Sin conexion"))
                {
                    EmilianoZapataTamaño = "Sin conexion con " + EmZappSettings;
                }
                else
                {
                    EmilianoZapataTamaño = TamañoLSTABINT(EmZappSettingsR, EmilianoZapataLS, B_TamañoLSTABINT_Em);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_Em = !B_TamañoLSTABINT_Em;
                    StatusSizeChange = false;
                }
                //Emiliano Zapata WS
                var EZ79 = ConfigurationManager.AppSettings["EmZ_IP_79"];
                var conn = ConfigurationManager.AppSettings["EmilianoZapataM"];
                Ult_WS_Em = UltimasTransaccionesWS(EZ79, conn, B_Em_WS, B_WS_Em_WS);

                if (StatusConectionChange == true)
                {
                    B_Em_WS = !B_Em_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_Em_WS = !B_WS_Em_WS;
                    StatusWSChange = false;
                }
            }
            if (Tlalpan == true)
            {
                //Tlalpan
                var TpappSettings = ConfigurationManager.AppSettings["TlalpanIP"];
                var TpappSettingsR = ConfigurationManager.AppSettings["TlalpanRuta"];
                TlalpanLS = getLSTABINT(TpappSettings, TpappSettingsR, B_Tl_Serv, B_LSTABINT_Tl);

                if (StatusConectionChange == true)
                {
                    B_Tl_Serv = !B_Tl_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_Tl = !B_LSTABINT_Tl;
                    StatusLSTABINTChange = false;
                }

                if (TlalpanLS.Contains("Sin conexion"))
                {
                    TlalpanTamaño = "Sin conexion con " + TpappSettings;
                }
                else
                {
                    TlalpanTamaño = TamañoLSTABINT(TpappSettingsR, TlalpanLS, B_TamañoLSTABINT_Tl);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_Tl = !B_TamañoLSTABINT_Tl;
                    StatusSizeChange = false;
                }
                //Tlalpan WS
                var Tl79 = ConfigurationManager.AppSettings["Tl_IP_79"];
                var conn = ConfigurationManager.AppSettings["TlalpanM"];
                Ult_WS_Tl = UltimasTransaccionesWS(Tl79, conn, B_Tl_WS, B_WS_Tl_WS);

                if (StatusConectionChange == true)
                {
                    B_Tl_WS = !B_Tl_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_Tl_WS = !B_WS_Tl_WS;
                    StatusWSChange = false;
                }
            }
            if (TresMarias == true)
            {
                //TresMarias
                var TMappSettings = ConfigurationManager.AppSettings["TresMariasIP"];
                var TMappSettingsR = ConfigurationManager.AppSettings["TresMariasRuta"];
                TresMariasLS = getLSTABINT(TMappSettings, TMappSettingsR, B_Tr_Serv, B_LSTABINT_Tr);

                if (StatusConectionChange == true)
                {
                    B_Tr_Serv = !B_Tr_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_Tr = !B_LSTABINT_Tr;
                    StatusLSTABINTChange = false;
                }

                if (TresMariasLS.Contains("Sin conexion"))
                {
                    TresMariasTamaño = "Sin conexion con " + TMappSettings;
                }
                else
                {
                    TresMariasTamaño = TamañoLSTABINT(TMappSettingsR, TresMariasLS, B_TamañoLSTABINT_Tr);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_Tr = !B_TamañoLSTABINT_Tr;
                    StatusSizeChange = false;
                }
                //Tres Marias WS
                var CG79 = ConfigurationManager.AppSettings["TrM_IP_79"];
                var conn = ConfigurationManager.AppSettings["TresMariasM"];
                Ult_WS_Tr = UltimasTransaccionesWS(CG79, Convert.ToString(conn), B_Tr_WS, B_WS_Tr_WS);

                if (StatusConectionChange == true)
                {
                    B_Tr_WS = !B_Tr_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_Tr_WS = !B_WS_Tr_WS;
                    StatusWSChange = false;
                }
            }
            if (FranciscoVelazco == true)
            {
                //Francisco
                var FVappSettings = ConfigurationManager.AppSettings["FranciscoVelazcoIP"];
                var FVappSettingsR = ConfigurationManager.AppSettings["FranciscoVelazcoRuta"];
                FranciscoVelazcoLS = getLSTABINT(FVappSettings, FVappSettingsR, B_FrV_Serv, B_LSTABINT_FrV);

                if (StatusConectionChange == true)
                {
                    B_FrV_Serv = !B_FrV_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_FrV = !B_LSTABINT_FrV;
                    StatusLSTABINTChange = false;
                }

                if (FranciscoVelazcoLS.Contains("Sin conexion"))
                {
                    FranciscoVelazcoTamaño = "Sin conexion con " + FVappSettings;
                }
                else
                {
                    FranciscoVelazcoTamaño = TamañoLSTABINT(FVappSettingsR, FranciscoVelazcoLS, B_TamañoLSTABINT_Frv);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_Frv = !B_TamañoLSTABINT_Frv;
                    StatusSizeChange = false;
                }
                //FranciscoVelazco WS
                var SA79 = ConfigurationManager.AppSettings["FrV_IP_79"];
                var conn = ConfigurationManager.AppSettings["FranciscoVelazcoM"];
                Ult_WS_FrV = UltimasTransaccionesWS(SA79, Convert.ToString(conn), B_FrV_WS, B_WS_FrV_WS);

                if (StatusConectionChange == true)
                {
                    B_FrV_WS = !B_FrV_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_FrV_WS = !B_WS_FrV_WS;
                    StatusWSChange = false;
                }
            }

            //Llenar Datos******************************************************

            AlpuyecaP = new string[] { "Alpuyeca", AlpuyecaLS + Environment.NewLine + AlpuyecaTamaño, Ult_WS_Al };
            PasoMorelosP = new string[] { "Paso Morelos", PasoMorelosLS + Environment.NewLine + PasoMorelosTamaño, Ult_WS_PsM };
            PoloBlancoP = new string[] { "Palo Blanco", PoloBlancoLS + Environment.NewLine + PoloBlancoTamaño, Ult_WS_PoB };
            LaVentaP = new string[] { "La venta", LaVentaLS + Environment.NewLine + LaVentaTamaño, Ult_WS_LaV };
            XochitepecP = new string[] { "Xochitepec", XochitepecLS + "\r\n" + XochitepecTamaño, Ult_WS_Xo };
            AeropuertoP = new string[] { "Aeropuerto", AeropuertoLS + Environment.NewLine + AeropuertoTamaño, Ult_WS_Ae };
            EmilianoZapataP = new string[] { "Emiliano Zapata", EmilianoZapataLS + Environment.NewLine + EmilianoZapataTamaño, Ult_WS_Em };
            TlalpanP = new string[] { "Tlalpan", TlalpanLS + Environment.NewLine + TlalpanTamaño, Ult_WS_Tl };
            TresMariasP = new string[] { "Tres Marias", TresMariasLS + Environment.NewLine + TresMariasTamaño, Ult_WS_Tr };
            FranciscoVelazcoP = new string[] { "Francisco Velazco", FranciscoVelazcoLS + Environment.NewLine + FranciscoVelazcoTamaño, Ult_WS_FrV };
        }
        /// <summary>
        /// Obtengo el nombre, extencion, fecha de creacion de la lista lstabint deseada
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="ruta"></param>
        /// <param name="Bandera"></param>
        /// <param name="BanderaLS"></param>
        /// <returns></returns>
        public string getLSTABINT(string IP, string ruta, bool Bandera, bool BanderaLS)
        {
            string Res;
            DateTime FH_Transaccion;
            Ping ping = new Ping();
            PingReply respuestaReply = ping.Send(IP);

            if (respuestaReply.Status == IPStatus.Success)
            {
                if (Bandera == false)
                {
                    Metodos.InsertLog(IP, 101);
                    StatusConectionChange = true;
                }

                try
                {
                    string Nombre = Metodos.NombreLSTABINT(ruta);
                    FileInfo file = new FileInfo($@"{ruta}\\PARAM\\ACTUEL\\{Nombre}");
                    FH_Transaccion = file.CreationTime;
                    string extension = Path.GetExtension($@"{ruta}\\PARAM\\ACTUEL\\{Nombre}");

                    if (Nombre == string.Empty)
                    {
                        Res = "No hay lista";
                    }
                    else
                    {
                        int DiferenciaDias = DateTime.Now.Subtract(FH_Transaccion).Days;

                        if (DiferenciaDias != 0)
                        {
                            Res = Nombre + "\r\n" + extension + "\r\n" + FH_Transaccion + "\r\n" + "Desactualizada";

                            if (BanderaLS == true)
                            {
                                Metodos.InsertLog(IP, 500);
                                StatusLSTABINTChange = true;
                            }
                        }
                        else
                        {
                            int DiferenciasHoras = DateTime.Now.Subtract(FH_Transaccion).Hours;

                            if (DiferenciasHoras != 0)
                            {
                                Res = Nombre + "\r\n" + extension + "\r\n" + FH_Transaccion + "\r\n" + "Desactualizada";

                                if (BanderaLS == true)
                                {
                                    Metodos.InsertLog(IP, 500);
                                    StatusLSTABINTChange = true;
                                }
                            }
                            else
                            {
                                int DiferenciaMinutos = DateTime.Now.Subtract(FH_Transaccion).Minutes;

                                if (DiferenciaMinutos > 30)
                                {
                                    Res = Nombre + "\r\n" + extension + "\r\n" + FH_Transaccion + "\r\n" + "Desactualizada";

                                    if (BanderaLS == true)
                                    {
                                        Metodos.InsertLog(IP, 500);
                                        StatusLSTABINTChange = true;
                                    }
                                }
                                else
                                {
                                    Res = Nombre + "\r\n" + extension + "\r\n" + FH_Transaccion;

                                    if (BanderaLS == false)
                                    {
                                        Metodos.InsertLog(IP, 501);
                                        StatusLSTABINTChange = true;
                                    }
                                }
                            }
                        }
                    }

                    return Res;
                }
                catch (Exception)
                {
                    Res = "No se encontro la ruta";
                    return Res;
                    throw;
                }
            }
            else
            {
                if (Bandera == true)
                {
                    Metodos.InsertLog(IP, 100);
                    StatusConectionChange = true;
                }

                Res = "Sin conexion con " + IP;

                return Res;
            }
        }
        /// <summary>
        /// Obtengo el tamaño de mi lstabint
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Nombre"></param>
        /// <param name="Bandera"></param>
        /// <returns></returns>
        private string TamañoLSTABINT(string IP, string Nombre, bool Bandera)
        {
            string Variable = "";
            int VarNum;
            DirectoryInfo directory = new DirectoryInfo($@"{IP}\\PARAM\\ACTUEL\\");

            if (Bandera == true)
            {
                FileInfo[] fiArr = directory.GetFiles();

                foreach (FileInfo item in fiArr)
                {
                    if (Nombre.Contains(item.Name))
                    {
                        if (item.Length < 1048576)
                        {
                            Variable = (item.Length / 1024).ToString("###0") + "KB";
                        }
                        else
                        {
                            VarNum = Convert.ToInt32((item.Length / 1024) / 1024);

                            if (VarNum < 200)
                            {
                                Variable = ((item.Length / 1024) / 1024).ToString("###0") + "MB" + System.Environment.NewLine + "Lista pequeña";

                                if (Bandera == true)
                                {
                                    Metodos.InsertLog(IP, 600);
                                    StatusSizeChange = true;
                                }
                            }
                            else
                            {
                                Variable = ((item.Length / 1024) / 1024).ToString("###0") + "MB";

                                if (Bandera == false)
                                {
                                    Metodos.InsertLog(IP, 601);
                                    StatusSizeChange = true;
                                }
                            }
                        }
                    }
                }
            }

            return Variable;
        }
        /// <summary>
        /// Obntengo el ultimo cruce
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="conexion"></param>
        /// <param name="Bandera"></param>
        /// <param name="BanderaWS"></param>
        /// <returns></returns>
        private string UltimasTransaccionesWS(string IP, string conexion, bool Bandera, bool BanderaWS)
        {
            string Res = "";
            //Ping ping = new Ping();
            //PingReply respuestaReply = ping.Send(IP);

            //if (respuestaReply.Status == IPStatus.Success)
            //{            
            try
            {
                SqlConnection conn = new SqlConnection(conexion);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT TOP 1 [DATE_TRANSACTION] FROM [ProsisDBv1_1].[dbo].[pn_importacion_wsIndra] ORDER BY DATE_TRANSACTION DESC";
                cmd.Connection = conn;

                if (Bandera == false)
                {
                    Metodos.InsertLog(IP, 101);
                    StatusConectionChange = true;
                }

                DateTime FH_Transaccion;

                FH_Transaccion = Convert.ToDateTime(cmd.ExecuteScalar());

                int DiferenciasDias = DateTime.Now.Subtract(FH_Transaccion).Days;

                if (DiferenciasDias != 0)
                {
                    Res = FH_Transaccion + "\r\n" + "Desactualizada";

                    if (BanderaWS == true)
                    {
                        Metodos.InsertLog(IP, 400);
                        StatusWSChange = true;
                    }
                }
                else
                {
                    int DiferenciaHoras = DateTime.Now.Subtract(FH_Transaccion).Hours;

                    if (DiferenciaHoras != 0)
                    {
                        Res = FH_Transaccion + "\r\n" + "Desactualizada";

                        if (BanderaWS == true)
                        {
                            Metodos.InsertLog(IP, 400);
                            StatusWSChange = true;
                        }
                    }
                    else
                    {
                        int DiferenciaMinutos = DateTime.Now.Subtract(FH_Transaccion).Minutes;

                        if (DiferenciaMinutos > 30)
                        {
                            Res = FH_Transaccion + "\r\n" + "Desactualizada";

                            if (BanderaWS == true)
                            {
                                Metodos.InsertLog(IP, 400);
                                StatusWSChange = true;
                            }
                        }
                        else
                        {
                            Res = Convert.ToString(FH_Transaccion);
                            if (true)
                            {
                                if (BanderaWS == false)
                                {
                                    Metodos.InsertLog(IP, 401);
                                    StatusWSChange = true;
                                }
                            }
                        }
                    }
                }

                conn.Close();

                return Res;
            }
            catch (Exception)
            {
                Res = "SQL no visible";
                return Res;
                throw;
            }
            //}
            //else
            //{
            //    if (Bandera == true)
            //    {
            //        Metodos.InsertLog(IP, 100);
            //        StatusConectionChange = true;
            //    }

            //    Res = "Sin conexion con  " + IP;
            //    return Res;
            //}
        }

        /// <summary>
        /// Metodo para traer datos de la bases de datos e igularlos con las variables locales
        /// </summary>
        public void GetFlags(string conexion)
        {
            List<Flag> flags = getBanderas.GetAll(conexion);

            //Conexion banderas
            foreach (var item in flags)
            {
                switch (item.id_flag)
                {
                    case 31:
                        B_Al_Serv = item.conexion;
                        break;
                    case 33:
                        B_Al_WS = item.conexion;
                        break;
                    case 34:
                        B_PsM_Serv = item.conexion;
                        break;
                    case 36:
                        B_PsM_WS = item.conexion;
                        break;
                    case 37:
                        B_PoB_Serv = item.conexion;
                        break;
                    case 39:
                        B_PoB_WS = item.conexion;
                        break;
                    case 40:
                        B_LaV_Serv = item.conexion;
                        break;
                    case 42:
                        B_LaV_WS = item.conexion;
                        break;
                    case 43:
                        B_Xo_Serv = item.conexion;
                        break;
                    case 45:
                        B_Xo_WS = item.conexion;
                        break;
                    case 46:
                        B_Ae_Serv = item.conexion;
                        break;
                    case 48:
                        B_Ae_WS = item.conexion;
                        break;
                    case 49:
                        B_Em_Serv = item.conexion;
                        break;
                    case 51:
                        B_Em_WS = item.conexion;
                        break;
                    case 52:
                        B_Tl_Serv = item.conexion;
                        break;
                    case 54:
                        B_Tl_WS = item.conexion;
                        break;
                    case 55:
                        B_Tr_Serv = item.conexion;
                        break;
                    case 57:
                        B_Tr_WS = item.conexion;
                        break;
                    case 58:
                        B_FrV_Serv = item.conexion;
                        break;
                    case 60:
                        B_FrV_WS = item.conexion;
                        break;
                    default:
                        break;
                }
            }

            //WS banderas
            foreach (var item in flags)
            {
                switch (item.id_flag)
                {
                    case 31:
                        B_WS_Al_Serv = item.WS;
                        break;
                    case 33:
                        B_WS_Al_WS = item.WS;
                        break;
                    case 34:
                        B_WS_PsM_Serv = item.WS;
                        break;
                    case 36:
                        B_WS_PsM_WS = item.WS;
                        break;
                    case 37:
                        B_WS_PoB_Serv = item.WS;
                        break;
                    case 39:
                        B_WS_PoB_WS = item.WS;
                        break;
                    case 40:
                        B_WS_LaV_Serv = item.WS;
                        break;
                    case 42:
                        B_WS_LaV_WS = item.WS;
                        break;
                    case 43:
                        B_WS_Xo_Serv = item.WS;
                        break;
                    case 45:
                        B_WS_Xo_WS = item.WS;
                        break;
                    case 46:
                        B_WS_Ae_Serv = item.WS;
                        break;
                    case 48:
                        B_WS_Ae_WS = item.WS;
                        break;
                    case 49:
                        B_WS_Em_Serv = item.WS;
                        break;
                    case 51:
                        B_WS_Em_WS = item.WS;
                        break;
                    case 52:
                        B_WS_Tl_Serv = item.WS;
                        break;
                    case 54:
                        B_WS_Tl_WS = item.WS;
                        break;
                    case 55:
                        B_WS_Tr_Serv = item.WS;
                        break;
                    case 57:
                        B_WS_Tr_WS = item.WS;
                        break;
                    case 58:
                        B_WS_FrV_Serv = item.WS;
                        break;
                    case 60:
                        B_WS_FrV_WS = item.WS;
                        break;
                    default:
                        break;
                }
            }

            //LSTABINT banderas
            foreach (var item in flags)
            {
                switch (item.id_flag)
                {
                    case 31:
                        B_LSTABINT_Al = item.LSTABINT;
                        break;
                    case 34:
                        B_LSTABINT_PsM = item.LSTABINT;
                        break;
                    case 37:
                        B_LSTABINT_PoB = item.LSTABINT;
                        break;
                    case 40:
                        B_LSTABINT_LaV = item.LSTABINT;
                        break;
                    case 43:
                        B_LSTABINT_Xo = item.LSTABINT;
                        break;
                    case 46:
                        B_LSTABINT_Ae = item.LSTABINT;
                        break;
                    case 49:
                        B_LSTABINT_Em = item.LSTABINT;
                        break;
                    case 52:
                        B_LSTABINT_Tl = item.LSTABINT;
                        break;
                    case 55:
                        B_LSTABINT_Tr = item.LSTABINT;
                        break;
                    case 58:
                        B_LSTABINT_FrV = item.LSTABINT;
                        break;
                    default:
                        break;
                }
            }

            //Tam LSTABINT banderas
            foreach (var item in flags)
            {
                switch (item.id_flag)
                {
                    case 31:
                        B_TamañoLSTABINT_Al = item.LSTABINT;
                        break;
                    case 34:
                        B_TamañoLSTABINT_PsM = item.LSTABINT;
                        break;
                    case 37:
                        B_TamañoLSTABINT_PoB = item.LSTABINT;
                        break;
                    case 40:
                        B_TamañoLSTABINT_LaV = item.LSTABINT;
                        break;
                    case 43:
                        B_TamañoLSTABINT_Xo = item.LSTABINT;
                        break;
                    case 46:
                        B_TamañoLSTABINT_Ae = item.LSTABINT;
                        break;
                    case 49:
                        B_TamañoLSTABINT_Em = item.LSTABINT;
                        break;
                    case 52:
                        B_TamañoLSTABINT_Tl = item.LSTABINT;
                        break;
                    case 55:
                        B_TamañoLSTABINT_Tr = item.LSTABINT;
                        break;
                    case 58:
                        B_TamañoLSTABINT_Frv = item.LSTABINT;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}