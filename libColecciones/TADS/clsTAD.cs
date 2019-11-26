using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.TADS
{
    public class clsTAD<Tipo> : iTadCuerpo<Tipo> where Tipo : IComparable
    {
        #region Atributos
        protected int atrLongitud;
        protected long atrNumeroComparaciones;
        protected long atrNumeroIntercambios;
        #endregion
        #region Métodos
        //#region Auxiliar
        //protected bool EsValido(int prmIndice)
        //{
        //    return prmIndice >= 0 && prmIndice < atrLongitud;
        //}
        //#endregion
        #region CRUD´s
        protected virtual bool InsertarEn(int prmIndice, Tipo prmItem) { return false; }
        protected virtual bool ExtraerEn(int prmIndice, ref Tipo prmItem) { return false; }
        protected virtual bool ModificarEn(int prmIndice, Tipo prmItem) { return false; }
        protected virtual bool RecuperarEn(int prmIndice, ref Tipo prmItem) { return false; }
        public bool Encontrar(Tipo prmItem, ref int prmIndice) { return false; }
        public bool Existe(Tipo prmItem) { return false; }
        protected bool EsValido(int prmIndice ) { return prmIndice >= 0 && prmIndice < atrLongitud; }
        public bool EstaVacia() { return atrLongitud == 0; }
        #endregion
        #region Ordenamiento
        protected virtual void MetodoBurbujaSimple(bool prmOrdenarPorDescendente) {}
        protected virtual void MetodoBurbujaMejorado(bool prmOrdenarPorDescendente) {}
        protected virtual void MetodoBurbujaBiDireccional(bool prmOrdenarPorDescendente) {}
        protected virtual void MetodoInsercion(bool parOrdenarPorDescendente) {}
        protected virtual void MetodoSeleccion(bool parOrdenarPorDescendente) {}
        protected virtual void MetodoQuickSort(bool parOrdenarPorDescendente, int parIndiceDelPrimero, int parIndiceDelUltimo) {}
        protected virtual void MetodoX(bool prmOrdenarPorDescendente) {}

        public bool OrdenarBurbujaSimple(bool prmOrdenarPorDescendente) { return false; }
        public bool OrdenarBurbujaMejorado(bool prmOrdenarPorDescendente) { return false; }
        public bool OrdenarBurbujaBiDireccional(bool prmOrdenarPorDescendente) { return false; }
        public bool OrdenarInsercion(bool prmOrdenarPorDescendente) { return false; }
        public bool OrdenarSeleccion(bool prmOrdenarPorDescendente) { return false; }
        public bool OrdenarQuickSort(bool prmOrdenarPorDescendente) { return false; }
        public bool OrdenarMetodoX(bool prmOrdenarPorDescendente) { return false; }
        #endregion
        #endregion
    }
}