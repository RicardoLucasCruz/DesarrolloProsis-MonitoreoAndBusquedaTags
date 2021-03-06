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
    class PrincipalIra
    {
        //Declaracion de variables******************************************************
        public string[] QueretaroP { get; set; }
        public string[] CerroGordoP { get; set; }
        public string[] LibramientoP { get; set; }
        public string[] VillaGrandeP { get; set; }
        public string[] TepozotlanP { get; set; }
        public string[] JorobasP { get; set; }
        public string[] PolotitlanP { get; set; }
        public string[] PalmillasP { get; set; }
        public string[] ChichemequillasP { get; set; }
        public string[] SalamancaP { get; set; }

        //LSBINT
        string TepozotlanLS;
        string JorobasLS;
        string PolotitlanLS;
        string PalmillasLS;
        string ChichemequillasLS;
        string QueretaroLS;
        string LibramientoLS;
        string VillaGrandLS;
        string CerroGordoLS;
        string SalamancaLS;
        //End LSBINT

        //Tamaño LSTABINT
        string TepozotlanTamaño;
        string JorobasTamaño;
        string PolotitlanTamaño;
        string PalmillasTamaño;
        string ChichemequillasTamaño;
        string SalamancaTamaño;
        string QueretaroTamaño;
        string CerroGordoTamaño;
        string LibramientoTamaño;
        string VillaGrandTamaño;
        //End Tamaño LSTABINT

        //Ultimas transacciones WS
        string Ult_WS_Qro = "";
        string Ult_WS_CG = "";
        string Ult_WS_Lib = "";
        string Ult_WS_VG = "";
        string Ult_WS_TP = "";
        string Ult_WS_JO = "";
        string Ult_WS_PA = "";
        string Ult_WS_PO = "";
        string Ult_WS_CHI = "";
        string Ult_WS_SA = "";
        //End transacciones WS

        //Banderas conexion
        bool B_Qro_Serv = false;
        bool B_Qro_WS = false;
        bool B_CG_Serv = false;
        bool B_CG_WS = false;
        bool B_Lib_Serv = false;
        bool B_Lib_WS = false;
        bool B_VG_Serv = false;
        bool B_VG_WS = false;
        bool B_TP_Serv = false;
        bool B_TP_WS = false;
        bool B_JO_Serv = false;
        bool B_JO_WS = false;
        bool B_PO_Serv = false;
        bool B_PO_WS = false;
        bool B_PA_Serv = false;
        bool B_PA_WS = false;
        bool B_CHI_Serv = false;
        bool B_CHI_WS = false;
        bool B_SA_Serv = false;
        bool B_SA_WS = false;
        //End Banderas conexion

        //Banderas Transacciones WS Actualizadas
        bool B_WS_Qro_Serv = false;
        bool B_WS_Qro_WS = false;
        bool B_WS_CG_Serv = false;
        bool B_WS_CG_WS = false;
        bool B_WS_Lib_Serv = false;
        bool B_WS_Lib_WS = false;
        bool B_WS_VG_Serv = false;
        bool B_WS_VG_WS = false;
        bool B_WS_TP_Serv = false;
        bool B_WS_TP_WS = false;
        bool B_WS_JO_Serv = false;
        bool B_WS_JO_WS = false;
        bool B_WS_PO_Serv = false;
        bool B_WS_PO_WS = false;
        bool B_WS_PA_Serv = false;
        bool B_WS_PA_WS = false;
        bool B_WS_CHI_Serv = false;
        bool B_WS_CHI_WS = false;
        bool B_WS_SA_Serv = false;
        bool B_WS_SA_WS = false;
        //End Banderas Transacciones WS Actualizadas 

        //Bandera LSTABINT
        bool B_LSTABINT_Qro = false;
        bool B_LSTABINT_CG = false;
        bool B_LSTABINT_Lib = false;
        bool B_LSTABINT_VG = false;
        bool B_LSTABINT_TP = false;
        bool B_LSTABINT_JO = false;
        bool B_LSTABINT_PO = false;
        bool B_LSTABINT_PA = false;
        bool B_LSTABINT_CHI = false;
        bool B_LSTABINT_SA = false;

        bool B_TamañoLSTABINT_Qro = true;
        bool B_TamañoLSTABINT_CG = false;
        bool B_TamañoLSTABINT_Lib = false;
        bool B_TamañoLSTABINT_VG = false;
        bool B_TamañoLSTABINT_TP = false;
        bool B_TamañoLSTABINT_JO = false;
        bool B_TamañoLSTABINT_PO = false;
        bool B_TamañoLSTABINT_PA = false;
        bool B_TamañoLSTABINT_CHI = false;
        bool B_TamañoLSTABINT_SA = false;
        //End Bandera LSTABINT

        bool StatusConectionChange = false;
        bool StatusWSChange = false;
        bool StatusLSTABINTChange = false;
        bool StatusSizeChange = false;

        //End Bandera LSTABINT
        /// <summary>
        /// En esta funcion lo que se hace es llamar al la funcion GetFlags, tambien a cada plaza se le da sus datos para asi ser mostradas
        /// </summary>
        /// <param name="Tepozotlan"></param>
        /// <param name="Jorobas"></param>
        /// <param name="Polotitlan"></param>
        /// <param name="Palmillas"></param>
        /// <param name="Chichemequillas"></param>
        /// <param name="Queretaro"></param>
        /// <param name="Libramiento"></param>
        /// <param name="VillaGrande"></param>
        /// <param name="CerroGordo"></param>
        /// <param name="Salamanca"></param>
        public void PrincipalF(bool Tepozotlan, bool Jorobas, bool Polotitlan, bool Palmillas, bool Chichemequillas, bool Queretaro, bool Libramiento, bool VillaGrande, bool CerroGordo, bool Salamanca)
        {
            GetFlags(Convert.ToString(ConfigurationManager.ConnectionStrings["Global"]));

            //LSTABINTyWS******************************************************
            if (Tepozotlan == true)
            {
                //Tepozotlan
                var TPappSettings = ConfigurationManager.AppSettings["TepozotlanIP"];
                var TPappSettingsR = ConfigurationManager.AppSettings["TepozotlanRuta"];
                TepozotlanLS = getLSTABINT(TPappSettings, TPappSettingsR, B_TP_Serv, B_LSTABINT_TP);

                if (StatusConectionChange == true)
                {
                    B_TP_Serv = !B_TP_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_TP = !B_LSTABINT_TP;
                    StatusLSTABINTChange = false;
                }

                if (TepozotlanLS.Contains("Sin conexion") || TepozotlanLS.Contains("No se encontro la ruta"))
                {
                    TepozotlanTamaño = "Sin conexion con " + TPappSettings;
                }
                else
                {
                    TepozotlanTamaño = TamañoLSTABINT(TPappSettingsR, TepozotlanLS, B_TamañoLSTABINT_TP);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_TP = !B_TamañoLSTABINT_TP;
                    StatusSizeChange = false;
                }
                //Tepozotlan WS
                var TP79 = ConfigurationManager.AppSettings["TP_IP_79"];
                var name = ConfigurationManager.AppSettings["TepozotlanNom"];
                var Conn = ConfigurationManager.ConnectionStrings["TepozotlanW"];
                Ult_WS_TP = UltimasTransaccionesWS(TP79, Convert.ToString(Conn), B_TP_WS, B_WS_TP_WS, name);

                if (StatusConectionChange == true)
                {
                    B_TP_WS = !B_TP_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_TP_WS = !B_WS_TP_WS;
                    StatusWSChange = false;
                }
            }
            if (Jorobas == true)
            {
                //Jorobas
                var JOappSettings = ConfigurationManager.AppSettings["JorobasIP"];
                var JOappSettingsRuta = ConfigurationManager.AppSettings["JorobasRuta"];
                JorobasLS = getLSTABINT(JOappSettings, JOappSettingsRuta, B_JO_Serv, B_LSTABINT_JO);

                if (StatusConectionChange == true)
                {
                    B_JO_Serv = !B_JO_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_JO = !B_LSTABINT_JO;
                    StatusLSTABINTChange = false;
                }

                if (JorobasLS.Contains("Sin conexion") || JorobasLS.Contains("No se encontro la ruta"))
                {
                    JorobasTamaño = "Sin conexion con " + JOappSettings;
                }
                else
                {
                    JorobasTamaño = TamañoLSTABINT(JOappSettingsRuta, JorobasLS, B_TamañoLSTABINT_JO);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_JO = !B_TamañoLSTABINT_JO;
                    StatusSizeChange = false;
                }
                //Jorobas WS
                var JO79 = ConfigurationManager.AppSettings["JO_IP_79"];
                var name = ConfigurationManager.AppSettings["JorobasNom"];
                var conn = ConfigurationManager.ConnectionStrings["JorobasW"];
                Ult_WS_JO = UltimasTransaccionesWS(JO79, Convert.ToString(conn), B_JO_WS, B_WS_JO_WS, name);

                if (StatusConectionChange == true)
                {
                    B_JO_WS = !B_JO_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_JO_WS = !B_WS_JO_WS;
                    StatusWSChange = false;
                }
            }
            if (Polotitlan)
            {
                //Potitlan
                var POappSettings = ConfigurationManager.AppSettings["PolotitlanIP"];
                var POappSettingsRuta = ConfigurationManager.AppSettings["PolotitlanRuta"];
                PolotitlanLS = getLSTABINT(POappSettings, POappSettingsRuta, B_PO_Serv, B_LSTABINT_PO);

                if (StatusConectionChange == true)
                {
                    B_PO_Serv = !B_PO_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_PO = !B_LSTABINT_PO;
                    StatusLSTABINTChange = false;
                }

                if (PolotitlanLS.Contains("Sin conexion") || PolotitlanLS.Contains("No se encontro la ruta"))
                {
                    PolotitlanTamaño = "Sin conexion con " + POappSettings;
                }
                else
                {
                    PolotitlanTamaño = TamañoLSTABINT(POappSettingsRuta, PolotitlanLS, B_TamañoLSTABINT_PO);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_PO = !B_TamañoLSTABINT_PO;
                    StatusSizeChange = false;
                }
                //Potitlan WS
                var PO79 = ConfigurationManager.AppSettings["PO_IP_79"];
                var name = ConfigurationManager.AppSettings["PolotitlanNom"];
                var con = ConfigurationManager.ConnectionStrings["PolotitlanW"];
                Ult_WS_PO = UltimasTransaccionesWS(PO79, Convert.ToString(con), B_PO_WS, B_WS_PO_WS, name);

                if (StatusConectionChange == true)
                {
                    B_PO_WS = !B_PO_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_PO_WS = !B_WS_PO_WS;
                    StatusWSChange = false;
                }
            }
            if (Palmillas)
            {
                //Palmillas
                var PAappSettings = ConfigurationManager.AppSettings["PalmillasIP"];
                var PAappSettingsR = ConfigurationManager.AppSettings["PalmillasRuta"];
                PalmillasLS = getLSTABINT(PAappSettings, PAappSettingsR, B_PA_Serv, B_LSTABINT_PA);

                if (StatusConectionChange == true)
                {
                    B_PA_Serv = !B_PA_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_PA = !B_LSTABINT_PA;
                    StatusLSTABINTChange = false;
                }

                if (PalmillasLS.Contains("Sin conexion") || PalmillasLS.Contains("No se encontro la ruta"))
                {
                    PalmillasTamaño = "Sin conexion con " + PAappSettings;
                }
                else
                {
                    PalmillasTamaño = TamañoLSTABINT(PAappSettingsR, PalmillasLS, B_TamañoLSTABINT_PA);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_PA = !B_TamañoLSTABINT_PA;
                    StatusSizeChange = false;
                }
                //Palmillas WS
                var PA79 = ConfigurationManager.AppSettings["PA_IP_79"];
                var name = ConfigurationManager.AppSettings["PalmillasNom"];
                var conn = ConfigurationManager.ConnectionStrings["PalmillasW"];
                Ult_WS_PA = UltimasTransaccionesWS(PA79, Convert.ToString(conn), B_PA_WS, B_WS_PA_WS, name);

                if (StatusConectionChange == true)
                {
                    B_PA_WS = !B_PA_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_PA_WS = !B_WS_PA_WS;
                    StatusWSChange = false;
                }
            }
            if (Chichemequillas == true)
            {
                //Chichemequillas
                var CHIappSettings = ConfigurationManager.AppSettings["ChichemequillasIP"];
                var CHIappSettingsR = ConfigurationManager.AppSettings["ChichemequillasRuta"];
                ChichemequillasLS = getLSTABINT(CHIappSettings, CHIappSettingsR, B_CHI_Serv, B_LSTABINT_CHI);

                if (StatusConectionChange == true)
                {
                    B_CHI_Serv = !B_CHI_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_CHI = !B_LSTABINT_CHI;
                    StatusLSTABINTChange = false;
                }

                if (ChichemequillasLS.Contains("Sin conexion") || ChichemequillasLS.Contains("No se encontro la ruta"))
                {
                    ChichemequillasTamaño = "Sin conexion con " + CHIappSettings;
                }
                else
                {
                    ChichemequillasTamaño = TamañoLSTABINT(CHIappSettingsR, ChichemequillasLS, B_TamañoLSTABINT_CHI);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_CHI = !B_TamañoLSTABINT_CHI;
                    StatusSizeChange = false;
                }
                //Chichemequillas WS
                var CHI79 = ConfigurationManager.AppSettings["CHI_IP_79"];
                var name = ConfigurationManager.AppSettings["ChichimequillasNom"];
                var conn = ConfigurationManager.ConnectionStrings["ChichimequillasW"];
                Ult_WS_CHI = UltimasTransaccionesWS(CHI79, Convert.ToString(conn), B_CHI_WS, B_WS_CHI_WS, name);

                if (StatusConectionChange == true)
                {
                    B_CHI_WS = !B_CHI_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_CHI_WS = !B_WS_CHI_WS;
                    StatusWSChange = false;
                }
            }
            if (Queretaro == true)
            {
                //Queretaro
                var QappSettings = ConfigurationManager.AppSettings["QueretaroIP"];
                var QappSettingsR = ConfigurationManager.AppSettings["QueretaroRuta"];
                QueretaroLS = getLSTABINT(QappSettings, QappSettingsR, B_Qro_Serv, B_LSTABINT_Qro);

                if (StatusConectionChange == true)
                {
                    B_Qro_Serv = !B_Qro_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_Qro = !B_LSTABINT_Qro;
                    StatusLSTABINTChange = false;
                }

                if (QueretaroLS.Contains("Sin conexion") || QueretaroLS.Contains("No se encontro la ruta"))
                {
                    QueretaroTamaño = "Sin conexion con " + QappSettings;
                }
                else
                {
                    QueretaroTamaño = TamañoLSTABINT(QappSettingsR, QueretaroLS, B_TamañoLSTABINT_Qro);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_Qro = !B_TamañoLSTABINT_Qro;
                    StatusSizeChange = false;
                }
                //Queretaro WS
                var QR79 = ConfigurationManager.AppSettings["Qro_IP_79"];
                var name = ConfigurationManager.AppSettings["QueretaroNom"];
                var conn = ConfigurationManager.ConnectionStrings["QueretaroW"];
                Ult_WS_Qro = UltimasTransaccionesWS(QR79, Convert.ToString(conn), B_Qro_WS, B_WS_Qro_WS, name);

                if (StatusConectionChange == true)
                {
                    B_Qro_WS = !B_Qro_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_Qro_WS = !B_WS_Qro_WS;
                    StatusWSChange = false;
                }
            }
            if (Libramiento == true)
            {
                //Libramiento
                var LIBappSettings = ConfigurationManager.AppSettings["LibramientoIP"];
                var LIBappSettingsR = ConfigurationManager.AppSettings["LibramientoRuta"];
                LibramientoLS = getLSTABINT(LIBappSettings, LIBappSettingsR, B_Lib_Serv, B_LSTABINT_Lib);

                if (StatusConectionChange == true)
                {
                    B_Lib_Serv = !B_Lib_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_Lib = !B_LSTABINT_Lib;
                    StatusLSTABINTChange = false;
                }

                if (LibramientoLS.Contains("Sin conexion") || LibramientoLS.Contains("No se encontro la ruta"))
                {
                    LibramientoTamaño = "Sin conexion con " + LIBappSettings;
                }
                else
                {
                    LibramientoTamaño = TamañoLSTABINT(LIBappSettingsR, LibramientoLS, B_TamañoLSTABINT_Lib);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_Lib = !B_TamañoLSTABINT_Lib;
                    StatusSizeChange = false;
                }
                //Libramiento WS
                var LIB79 = ConfigurationManager.AppSettings["Lib_IP_79"];
                var name = ConfigurationManager.AppSettings["LibramientoNom"];
                var conn = Convert.ToString(ConfigurationManager.ConnectionStrings["LibramientoW"]);
                Ult_WS_Lib = UltimasTransaccionesWS(LIB79, Convert.ToString(conn), B_Lib_WS, B_WS_Lib_WS, name);

                if (StatusConectionChange == true)
                {
                    B_Lib_WS = !B_Lib_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_Lib_WS = !B_WS_Lib_WS;
                    StatusWSChange = false;
                }
            }
            if (VillaGrande == true)
            {
                //VillaGrande
                var VGappSettings = ConfigurationManager.AppSettings["VillaGrandIP"];
                var VGappSettingsR = ConfigurationManager.AppSettings["VillaGrandRuta"];
                VillaGrandLS = getLSTABINT(VGappSettings, VGappSettingsR, B_VG_Serv, B_LSTABINT_VG);

                if (StatusConectionChange == true)
                {
                    B_VG_Serv = !B_VG_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_VG = !B_LSTABINT_VG;
                    StatusLSTABINTChange = false;
                }

                if (VillaGrandLS.Contains("Sin conexion") || VillaGrandLS.Contains("No se encontro la ruta"))
                {
                    VillaGrandTamaño = "Sin conexion con " + VGappSettings;
                }
                else
                {
                    VillaGrandTamaño = TamañoLSTABINT(VGappSettingsR, VillaGrandLS, B_TamañoLSTABINT_VG);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_VG = !B_TamañoLSTABINT_VG;
                    StatusSizeChange = false;
                }
                //VillaGrande WS
                var VG79 = ConfigurationManager.AppSettings["VG_IP_79"];
                var name = ConfigurationManager.AppSettings["VillaGrandNom"];
                var conn = ConfigurationManager.ConnectionStrings["VillaGrandeW"];
                Ult_WS_VG = UltimasTransaccionesWS(VG79, Convert.ToString(conn), B_VG_WS, B_WS_VG_WS, name);

                if (StatusConectionChange == true)
                {
                    B_VG_WS = !B_VG_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_VG_WS = !B_WS_VG_WS;
                    StatusWSChange = false;
                }
            }
            if (CerroGordo == true)
            {
                //CerroGordo
                var CGappSettings = ConfigurationManager.AppSettings["CerroGordoIP"];               
                var CGappSettingsR = ConfigurationManager.AppSettings["CerroGordoRuta"];
                CerroGordoLS = getLSTABINT(CGappSettings, CGappSettingsR, B_CG_Serv, B_LSTABINT_CG);

                if (StatusConectionChange == true)
                {
                    B_CG_Serv = !B_CG_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_CG = !B_LSTABINT_CG;
                    StatusLSTABINTChange = false;
                }

                if (CerroGordoLS.Contains("Sin conexion") || CerroGordoLS.Contains("No se encontro la ruta"))
                {
                    CerroGordoTamaño = "Sin conexion con " + CGappSettings;
                }
                else
                {
                    CerroGordoTamaño = TamañoLSTABINT(CGappSettingsR, CerroGordoLS, B_TamañoLSTABINT_CG);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_CG = !B_TamañoLSTABINT_CG;
                    StatusSizeChange = false;
                }
                //CerroGordo WS
                var CG79 = ConfigurationManager.AppSettings["CG_IP_79"];
                var name = ConfigurationManager.AppSettings["CerroGordoNom"];
                var conn = ConfigurationManager.ConnectionStrings["CerroGordoW"];
                Ult_WS_CG = UltimasTransaccionesWS(CG79, Convert.ToString(conn), B_CG_WS, B_WS_CG_WS, name);

                if (StatusConectionChange == true)
                {
                    B_CG_WS = !B_CG_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_CG_WS = !B_WS_CG_WS;
                    StatusWSChange = false;
                }
            }
            if (Salamanca == true)
            {
                //Salamanca
                var SAappSettings = ConfigurationManager.AppSettings["SalamancaIP"];
                var SAappSettingsR = ConfigurationManager.AppSettings["SalamancaRuta"];
                SalamancaLS = getLSTABINT(SAappSettings, SAappSettingsR, B_SA_Serv, B_LSTABINT_SA);

                if (StatusConectionChange == true)
                {
                    B_SA_Serv = !B_SA_Serv;
                    StatusConectionChange = false;
                }

                if (StatusLSTABINTChange == true)
                {
                    B_LSTABINT_SA = !B_LSTABINT_SA;
                    StatusLSTABINTChange = false;
                }

                if (SalamancaLS.Contains("Sin conexion") || SalamancaLS.Contains("No se encontro la ruta"))
                {
                    SalamancaTamaño = "Sin conexion con " + SAappSettings;
                }
                else
                {
                    SalamancaTamaño = TamañoLSTABINT(SAappSettingsR, SalamancaLS, B_TamañoLSTABINT_SA);
                }

                if (StatusSizeChange == true)
                {
                    B_TamañoLSTABINT_SA = !B_TamañoLSTABINT_SA;
                    StatusSizeChange = false;
                }
                //Salamanca WS
                var SA79 = ConfigurationManager.AppSettings["SA_IP_79"];
                var name = ConfigurationManager.AppSettings["SalamancaNom"];
                var conn = ConfigurationManager.ConnectionStrings["SalamancaW"];
                Ult_WS_SA = UltimasTransaccionesWS(SA79, Convert.ToString(conn), B_SA_WS, B_WS_SA_WS, name);

                if (StatusConectionChange == true)
                {
                    B_SA_WS = !B_SA_WS;
                    StatusConectionChange = false;
                }

                if (StatusWSChange == true)
                {
                    B_WS_SA_WS = !B_WS_SA_WS;
                    StatusWSChange = false;
                }
            }

            //Llenar Datos******************************************************

            QueretaroP = new string[] { "Queretaro", QueretaroLS + Environment.NewLine + QueretaroTamaño, Ult_WS_Qro };
            CerroGordoP = new string[] { "Cerro Gordo", CerroGordoLS + Environment.NewLine + CerroGordoTamaño, Ult_WS_CG };
            LibramientoP = new string[] { "Libramiento", LibramientoLS + Environment.NewLine + LibramientoTamaño, Ult_WS_Lib };
            VillaGrandeP = new string[] { "Villa Grand", VillaGrandLS + Environment.NewLine + VillaGrandTamaño, Ult_WS_VG };
            TepozotlanP = new string[] { "Tepozotlan", TepozotlanLS + "\r\n" + TepozotlanTamaño, Ult_WS_TP };
            JorobasP = new string[] { "Jorobas", JorobasLS + Environment.NewLine + JorobasTamaño, Ult_WS_JO };
            PolotitlanP = new string[] { "Polotitla", PolotitlanLS + Environment.NewLine + PolotitlanTamaño, Ult_WS_PO };
            PalmillasP = new string[] { "Palmillas", PalmillasLS + Environment.NewLine + PalmillasTamaño, Ult_WS_PA };
            ChichemequillasP = new string[] { "Chichimequillas", ChichemequillasLS + Environment.NewLine + ChichemequillasTamaño, Ult_WS_CHI };
            SalamancaP = new string[] { "Salamanca", SalamancaLS + Environment.NewLine + SalamancaTamaño, Ult_WS_SA };
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
                    FH_Transaccion = file.LastWriteTime;
                    string extension = Path.GetExtension($@"{ruta}\\PARAM\\ACTUEL\\{Nombre}");

                    if (Nombre == "")
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
                    try
                    {
                        string Nombre = Metodos.NombreLSTABINT(ruta);
                        FileInfo file = new FileInfo($@"{ruta}\PARAM\ACTUEL\{Nombre}");
                        FH_Transaccion = file.LastWriteTime;
                        string extension = Path.GetExtension($@"{ruta}\PARAM\ACTUEL\{Nombre}");

                        if (Nombre == "")
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

            try
            {
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
            }
            catch (Exception)
            {
                try
                {
                    DirectoryInfo directory2 = new DirectoryInfo($@"{IP}\PARAM\ACTUEL\");

                    if (Bandera == true)
                    {
                        FileInfo[] fiArr = directory2.GetFiles();

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
                }
                catch (Exception ex)
                {
                    Logs.CrearArchivo(this, ex);
                    throw;
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
        private string UltimasTransaccionesWS(string IP, string conexion, bool Bandera, bool BanderaWS, string nombre)
        {
            string Res = "";
            Ping ping = new Ping();
            PingReply respuestaReply = ping.Send(IP);

            if (respuestaReply.Status == IPStatus.Success)
            {
                try
                {
                    SqlConnection conn = new SqlConnection($"Data Source={IP},1433;Network Library=DBMSSOCN;Initial Catalog={nombre};User ID=sa;Password=CAPUFE;");
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = $"SELECT TOP 1 [DATE_TRANSACTION] FROM [{nombre}].[dbo].[pn_importacion_wsIndra] ORDER BY DATE_TRANSACTION DESC";
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
                    try
                    {
                        SqlConnection conn = new SqlConnection(conexion);
                        conn.Open();

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = $"SELECT TOP 1 [DATE_TRANSACTION] FROM [{nombre}].[dbo].[pn_importacion_wsIndra] ORDER BY DATE_TRANSACTION DESC";
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
                }
            }
            else
            {
                if (Bandera == true)
                {
                    Metodos.InsertLog(IP, 100);
                    StatusConectionChange = true;
                }

                Res = "Sin conexion con  " + IP;
                return Res;
            }
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
                    case 1:
                        B_Qro_Serv = item.conexion;
                        break;
                    case 3:
                        B_Qro_WS = item.conexion;
                        break;
                    case 4:
                        B_CG_Serv = item.conexion;
                        break;
                    case 6:
                        B_CG_WS = item.conexion;
                        break;
                    case 7:
                        B_Lib_Serv = item.conexion;
                        break;
                    case 9:
                        B_Lib_WS = item.conexion;
                        break;
                    case 10:
                        B_VG_Serv = item.conexion;
                        break;
                    case 12:
                        B_VG_WS = item.conexion;
                        break;
                    case 13:
                        B_TP_Serv = item.conexion;
                        break;
                    case 15:
                        B_TP_WS = item.conexion;
                        break;
                    case 16:
                        B_JO_Serv = item.conexion;
                        break;
                    case 18:
                        B_JO_WS = item.conexion;
                        break;
                    case 19:
                        B_PO_Serv = item.conexion;
                        break;
                    case 21:
                        B_PO_WS = item.conexion;
                        break;
                    case 22:
                        B_PA_Serv = item.conexion;
                        break;
                    case 24:
                        B_PA_WS = item.conexion;
                        break;
                    case 25:
                        B_CHI_Serv = item.conexion;
                        break;
                    case 27:
                        B_CHI_WS = item.conexion;
                        break;
                    case 28:
                        B_SA_Serv = item.conexion;
                        break;
                    case 30:
                        B_SA_WS = item.conexion;
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
                    case 1:
                        B_WS_Qro_Serv = item.WS;
                        break;
                    case 3:
                        B_WS_Qro_WS = item.WS;
                        break;
                    case 4:
                        B_WS_CG_Serv = item.WS;
                        break;
                    case 6:
                        B_WS_CG_WS = item.WS;
                        break;
                    case 7:
                        B_WS_Lib_Serv = item.WS;
                        break;
                    case 9:
                        B_WS_Lib_WS = item.WS;
                        break;
                    case 10:
                        B_WS_VG_Serv = item.WS;
                        break;
                    case 12:
                        B_WS_VG_WS = item.WS;
                        break;
                    case 13:
                        B_WS_TP_Serv = item.WS;
                        break;
                    case 15:
                        B_WS_TP_WS = item.WS;
                        break;
                    case 16:
                        B_WS_JO_Serv = item.WS;
                        break;
                    case 18:
                        B_WS_JO_WS = item.WS;
                        break;
                    case 19:
                        B_WS_PO_Serv = item.WS;
                        break;
                    case 21:
                        B_WS_PO_WS = item.WS;
                        break;
                    case 22:
                        B_WS_PA_Serv = item.WS;
                        break;
                    case 24:
                        B_WS_PA_WS = item.WS;
                        break;
                    case 25:
                        B_WS_CHI_Serv = item.WS;
                        break;
                    case 27:
                        B_WS_CHI_WS = item.WS;
                        break;
                    case 28:
                        B_WS_SA_Serv = item.WS;
                        break;
                    case 30:
                        B_WS_SA_WS = item.WS;
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
                    case 1:
                        B_LSTABINT_Qro = item.LSTABINT;
                        break;
                    case 4:
                        B_LSTABINT_CG = item.LSTABINT;
                        break;
                    case 7:
                        B_LSTABINT_Lib = item.LSTABINT;
                        break;
                    case 10:
                        B_LSTABINT_VG = item.LSTABINT;
                        break;
                    case 13:
                        B_LSTABINT_TP = item.LSTABINT;
                        break;
                    case 16:
                        B_LSTABINT_JO = item.LSTABINT;
                        break;
                    case 19:
                        B_LSTABINT_PO = item.LSTABINT;
                        break;
                    case 22:
                        B_LSTABINT_PA = item.LSTABINT;
                        break;
                    case 25:
                        B_LSTABINT_CHI = item.LSTABINT;
                        break;
                    case 28:
                        B_LSTABINT_SA = item.LSTABINT;
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
                    case 1:
                        B_TamañoLSTABINT_Qro = item.tam;
                        break;
                    case 4:
                        B_TamañoLSTABINT_CG = item.tam;
                        break;
                    case 7:
                        B_TamañoLSTABINT_Lib = item.tam;
                        break;
                    case 10:
                        B_TamañoLSTABINT_VG = item.tam;
                        break;
                    case 13:
                        B_TamañoLSTABINT_CHI = item.tam;
                        break;
                    case 16:
                        B_TamañoLSTABINT_TP = item.tam;
                        break;
                    case 19:
                        B_TamañoLSTABINT_JO = item.tam;
                        break;
                    case 22:
                        B_TamañoLSTABINT_PO = item.tam;
                        break;
                    case 25:
                        B_TamañoLSTABINT_PA = item.tam;
                        break;
                    case 28:
                        B_TamañoLSTABINT_SA = item.tam;
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
