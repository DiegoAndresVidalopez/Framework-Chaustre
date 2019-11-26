using System;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.TADS
{
    class clsTadDobleEnlazado<Tipo> : clsTAD<Tipo> where Tipo: IComparable
    {
        #region Atributos
        private clsNodoDobleEnlazado<Tipo> atrNodoPrimero;
        private clsNodoDobleEnlazado<Tipo> atrNodoUltimo;
        #endregion
        #region Metodos
        #region CRUDs
        protected override bool InsertarEn(int prmIndice, Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> varNodoNuevo = new clsNodoDobleEnlazado<Tipo>(prmItem);
            if (EstaVacia())
            {
                atrNodoPrimero = varNodoNuevo;
                atrNodoUltimo = varNodoNuevo;
                atrNodoPrimero.ponerSiguiente(atrNodoUltimo);
                atrNodoUltimo.ponerAnterior(atrNodoPrimero);
                atrLongitud++;
                return true;
            }
            if(prmIndice == 0)
            {
                varNodoNuevo.ponerSiguiente(atrNodoPrimero);
                atrNodoPrimero.ponerAnterior(varNodoNuevo);
                atrNodoPrimero = varNodoNuevo;
                atrLongitud++;
                return true;
            }
            if (EsValido(prmIndice))
            {
                clsNodoDobleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                for (int varIndice = 1; varIndice < prmIndice; varIndice++)
                    varNodoActual = varNodoActual.darSiguiente();
                varNodoNuevo.ponerSiguiente(varNodoActual);
                varNodoNuevo.ponerAnterior(varNodoActual.darSiguiente());
                varNodoActual.darAnterior().ponerSiguiente(varNodoNuevo);
                varNodoActual.ponerAnterior(varNodoNuevo);
                atrLongitud++;
                return true;
            }
            return false;
        }
        protected override bool ExtraerEn(int prmIndice, ref Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                clsNodoDobleEnlazado<Tipo> varNodoExtraido = atrNodoPrimero;
                for (int varIndice = 1; varIndice <= prmIndice; varIndice++)
                    varNodoExtraido = varNodoExtraido.darSiguiente();
                prmItem = varNodoExtraido.darItem();
                varNodoExtraido.darAnterior().ponerSiguiente(varNodoExtraido.darSiguiente());
                varNodoExtraido.darSiguiente().ponerAnterior(varNodoExtraido.darAnterior());
                varNodoExtraido.ponerAnterior(null);
                varNodoExtraido.ponerSiguiente(null);
                varNodoExtraido = null;
                atrLongitud--;
                return true;
            }
            return false;
        }
        protected override bool ModificarEn(int prmIndice, Tipo prmItem)
        {
            if (EstaVacia())
            {
                if (prmIndice == 0)
                {
                    atrNodoPrimero.ponerItem(prmItem);
                    return true;
                }
                if (prmIndice == atrLongitud - 1)
                {
                    atrNodoUltimo.ponerItem(prmItem);
                    return true;
                }
                if (EsValido(prmIndice))
                {
                    clsNodoDobleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                    for (int VarIndice = 1; VarIndice <= prmIndice; VarIndice++)
                        varNodoActual = varNodoActual.darSiguiente();
                    varNodoActual.ponerItem(prmItem);
                    return true;
                }
            }
            return false;
        }
        protected override bool RecuperarEn(int prmIndice, ref Tipo prmItem)
        {
            if (EstaVacia())
            {
                if (prmIndice == 0)
                {
                    prmItem = atrNodoPrimero.darItem();
                    return true;
                }
                if (prmIndice == atrLongitud - 1)
                {
                    prmItem = atrNodoUltimo.darItem();
                    return true;
                }
                if (EsValido(prmIndice))
                {
                    clsNodoDobleEnlazado<Tipo> varNodoActual = atrNodoPrimero;
                    for (int VarIndice = 1; VarIndice <= prmIndice; VarIndice++)
                        varNodoActual = varNodoActual.darSiguiente();
                    prmItem = varNodoActual.darItem();
                    return true;
                }
            }
            return false;
        }
        #endregion
        #endregion
    }
}
