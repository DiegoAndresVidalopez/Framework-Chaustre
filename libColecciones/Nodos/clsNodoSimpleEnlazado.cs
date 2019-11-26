using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoSimpleEnlazado<Tipo> : clsNodo<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private clsNodoSimpleEnlazado<Tipo> atrSiguiente;
        #endregion
        #region Metodos Constructores
        public clsNodoSimpleEnlazado(Tipo prmItem): base(prmItem){ }
        #endregion
        #region Métodos Accesores - Mutadores
        public clsNodoSimpleEnlazado<Tipo> darSiguiente() { return atrSiguiente; }
        public void ponerSiguiente(clsNodoSimpleEnlazado<Tipo> prmNodo) { atrSiguiente = prmNodo; }
        #endregion
    }
}
