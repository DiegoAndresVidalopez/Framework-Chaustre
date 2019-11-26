using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodo<Tipo> where Tipo : IComparable
    {
        #region Métodos Constructores
        public clsNodo(Tipo prmItem)
        {
            atrItem = prmItem;
        }
        #endregion
        #region Métodos Accesores-Mutadores
        private Tipo atrItem;
        public Tipo darItem() { return atrItem; }
        public void ponerItem(Tipo prmItem) { atrItem = prmItem; }
        #endregion
    }
}

