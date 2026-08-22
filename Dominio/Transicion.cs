namespace AutomataUnionApp.Dominio
{
    // Representa una transición individual de la función delta:
    // desde qué estado, con qué símbolo, hacia qué estado destino.
    public class Transicion
    {
        public string Origen;
        public string Simbolo;
        public string Destino;

        public Transicion(string origen, string simbolo, string destino)
        {
            Origen = origen;
            Simbolo = simbolo;
            Destino = destino;
        }
    }
}