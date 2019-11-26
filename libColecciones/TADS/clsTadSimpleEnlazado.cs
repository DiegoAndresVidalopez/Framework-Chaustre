using System;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.TADS
{
    public class clsTadSimpleEnlazado<Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private clsNodoSimpleEnlazado<Tipo> atrNodoPrimero;
        private clsNodoSimpleEnlazado<Tipo> atrNodoUltimo;
        #endregion
        #region Métodos
        #region CRUDs
        protected override bool InsertarEn(int prmIndice, Tipo prmItem)
        {
            clsNodoSimpleEnlazado<Tipo> varNodoNuevo = new clsNodoSimpleEnlazado<Tipo>(prmItem);
            if (EstaVacia())
            {
                atrNodoPrimero = varNodoNuevo;
                atrNodoUltimo = varNodoNuevo;
                atrNodoPrimero.ponerSiguiente(atrNodoUltimo);
                atrLongitud++;
                return true;
            }
            if(prmIndice == 0)
            {
                varNodoNuevo.ponerSiguiente(atrNodoPrimero);
                atrNodoPrimero = varNodoNuevo;
                atrLongitud++;
                return true;
            }
            if(prmIndice == atrLongitud)
            {
                atrNodoUltimo.ponerSiguiente(varNodoNuevo);
                atrNodoUltimo = varNodoNuevo;
                atrLongitud++;
                return true;
            }
            if (EsValido(prmIndice))
            {
                clsNodoSimpleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                for (int varIndice = 1; varIndice < prmIndice - 1; varIndice++)
                    varNodoActual = varNodoActual.darSiguiente();
                varNodoNuevo.ponerSiguiente(varNodoActual.darSiguiente());
                varNodoActual.ponerSiguiente(varNodoNuevo);
                atrLongitud++;
                return true;
            }
            return false;
        }
        protected override bool ExtraerEn(int prmIndice, ref Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                clsNodoSimpleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                clsNodoSimpleEnlazado<Tipo> varNodoExtraido;
                for (int varIndice = 1; varIndice < prmIndice - 1; varIndice++)
                    varNodoActual = varNodoActual.darSiguiente();
                varNodoExtraido = varNodoActual.darSiguiente();
                prmItem = varNodoExtraido.darItem();
                varNodoActual.ponerSiguiente(varNodoExtraido.darSiguiente());
                varNodoExtraido.ponerSiguiente(null);
                varNodoExtraido = null;
                atrLongitud--;
                return true;
            }
            return false;
        }
        protected override bool ModificarEn(int prmIndice, Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                clsNodoSimpleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                for (int varIndice = 1; varIndice < prmIndice; varIndice++)
                    varNodoActual = varNodoActual.darSiguiente();
                varNodoActual.ponerItem(prmItem);
                return true;
            }
            return false;
        }
        protected override bool RecuperarEn(int prmIndice, ref Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                clsNodoSimpleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                for (int varIndice = 1; varIndice < prmIndice; varIndice++)
                    varNodoActual = varNodoActual.darSiguiente();
                prmItem = varNodoActual.darItem();
                return true;
            }
            return false;
        }
        #endregion
        #endregion
    }
}
