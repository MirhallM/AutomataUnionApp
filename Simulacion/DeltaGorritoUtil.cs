namespace AutomataUnionApp.Simulacion
{
    // Genera el texto de la derivación formal de la función de transición
    // extendida (δ̂, "delta gorrito") a partir del resultado de una
    // simulación, con el mismo formato usado en clase:
    //   δ̂(q,ε) = q1
    //   δ̂(q1,1) = δ(δ̂(q,ε),1)
    //   = δ(q1,1)
    //   = q2
    //   ...
    public static class DeltaGorritoUtil
    {
        private const string Delta = "δ";
        private const string DeltaGorrito = "δ̂";
        private const string EstadoGenerico = "q";

        public static string Generar(string cadena, ResultadoSimulacion resultado)
        {
            if (resultado.Error != null)
            {
                return "No se puede construir la derivación: " + resultado.Error;
            }

            if (resultado.Traza.Cantidad == 0)
            {
                return "";
            }

            string estadoInicial = resultado.Traza.ObtenerEn(0);
            string texto = DeltaGorrito + "(" + EstadoGenerico + ",ε) = " + estadoInicial + "\n";

            for (int i = 1; i <= cadena.Length; i++)
            {
                string prefijoActual = cadena.Substring(0, i);
                string prefijoAnterior = cadena.Substring(0, i - 1);
                string etiquetaAnterior = prefijoAnterior.Length > 0 ? prefijoAnterior : "ε";

                // La primera vez, la llamada interna hace referencia al caso
                // base (con el estado genérico "q"); de ahí en adelante, se
                // refiere a la línea anterior ya con el estado inicial real.
                string primerArgumentoInterno = (i == 1) ? EstadoGenerico : estadoInicial;

                char simbolo = cadena[i - 1];
                string estadoAntes = resultado.Traza.ObtenerEn(i - 1);
                string estadoDespues = resultado.Traza.ObtenerEn(i);

                texto += DeltaGorrito + "(" + estadoInicial + "," + prefijoActual + ") = "
                       + Delta + "(" + DeltaGorrito + "(" + primerArgumentoInterno + "," + etiquetaAnterior + ")," + simbolo + ")\n";
                texto += "= " + Delta + "(" + estadoAntes + "," + simbolo + ")\n";
                texto += "= " + estadoDespues + "\n";
            }

            texto += "\n";
            if (resultado.Aceptada)
            {
                texto += "La cadena SÍ fue aceptada.";
            }
            else
            {
                texto += "La cadena NO fue aceptada, porque el estado alcanzado no es de aceptación.";
            }

            return texto;
        }
    }
}