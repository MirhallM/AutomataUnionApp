using AutomataUnionApp.Estructuras;

namespace AutomataUnionApp.Simulacion
{
    // Resultado de simular una cadena sobre un autómata:
    // si fue aceptada, la secuencia de estados visitados (traza),
    // y un mensaje de error si la cadena no se pudo procesar
    // (símbolo fuera del alfabeto, autómata sin inicial, etc.)
    public class ResultadoSimulacion
    {
        public bool Aceptada;
        public Lista<string> Traza;
        public string? Error;

        public ResultadoSimulacion()
        {
            Aceptada = false;
            Traza = new Lista<string>();
            Error = null;
        }
    }
}