using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoreo
{
    static class PaletaColores
    {
        public static Color tituloGrilla;
        public static Color panelBotones;
        public static Color backGrilla;
        public static Color panelFondos;
        public static Color panelTitulos;
        public static Color titulos;

        //Por defecto 
        private static readonly Color tituloGrillaD = Color.FromArgb(111, 178, 214); //E
        private static readonly Color panelBotonesD = Color.FromArgb(131, 210, 252); //D
        private static readonly Color backGrillaD = Color.FromArgb(124, 199, 240);   //C
        private static readonly Color panelFondosD = Color.FromArgb(91, 146, 176);   //A
        private static readonly Color panelTitulosD = Color.FromArgb(111, 178, 214); //E
        private static readonly Color titulosD = Color.FromArgb(115, 180, 210); //E

        public static void ElegirTema(string tema)
        {
            if (tema == "Defecto")
            {
                tituloGrilla = tituloGrillaD;
                panelBotones = panelBotonesD;
                backGrilla = backGrillaD;
                panelFondos = panelFondosD;
                panelTitulos = panelTitulosD;
                titulos = titulosD;
            }
        }
    }
}
