using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> : clsNodo<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private clsNodoDobleEnlazado<Tipo> atrSiguiente;
        private clsNodoDobleEnlazado<Tipo> atrAnterior;
        #endregion
        #region Métodos Constructores
        public clsNodoDobleEnlazado(Tipo prmItem): base(prmItem){ }
        #endregion
        #region Métodos Accesores - Mutadores
        public clsNodoDobleEnlazado<Tipo> darSiguiente() { return atrSiguiente; }
        public clsNodoDobleEnlazado<Tipo> darAnterior() { return atrAnterior; }
        public void ponerSiguiente(clsNodoDobleEnlazado<Tipo> prmNodo) { atrSiguiente = prmNodo; }
        public void ponerAnterior(clsNodoDobleEnlazado<Tipo> prmNodo) { atrAnterior = prmNodo; }
        #endregion
    }
}
