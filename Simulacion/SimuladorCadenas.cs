using AutomataUnionApp.Dominio;

namespace AutomataUnionApp.Simulacion
{
    // Simula el procesamiento de una cadena sobre un Automata.
    // Es genérico a propósito: el mismo método se usa para probar
    // la cadena en el Autómata 1, el Autómata 2 y el Autómata Unión,
    // que es justo lo que pide el "veredicto de aceptación triple".
    public class SimuladorCadenas
    {
        public ResultadoSimulacion Simular(Automata automata, string cadena)
        {
            ResultadoSimulacion resultado = new ResultadoSimulacion();

            if (string.IsNullOrEmpty(automata.EstadoInicial))
            {
                resultado.Error = "El autómata no tiene un estado inicial definido.";
                return resultado;
            }

            string estadoActual = automata.EstadoInicial;
            resultado.Traza.Agregar(estadoActual);

            int i = 0;
            while (i < cadena.Length)
            {
                string simbolo = cadena[i].ToString();

                if (!automata.Alfabeto.Existe(simbolo))
                {
                    resultado.Error = $"El símbolo '{simbolo}' no pertenece al alfabeto del autómata.";
                    return resultado;
                }

                Transicion? transicion = automata.BuscarTransicion(estadoActual, simbolo);
                if (transicion == null)
                {
                    resultado.Error = $"No existe transición desde '{estadoActual}' con el símbolo '{simbolo}'.";
                    return resultado;
                }

                estadoActual = transicion.Destino;
                resultado.Traza.Agregar(estadoActual);

                i++;
            }

            resultado.Aceptada = automata.EstadosFinales.Existe(estadoActual);
            return resultado;
        }
    }
}