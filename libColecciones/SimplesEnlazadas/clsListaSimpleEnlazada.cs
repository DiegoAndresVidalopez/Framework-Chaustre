using System;
using Servicios.Colecciones.TADS;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.SimpleEnlazadas
{
    class clsListaSimpleEnlazado<Tipo> : clsTadSimpleEnlazado<Tipo>, iLista<Tipo> where Tipo : IComparable
    {
        #region Métodos CRUD-Query
        public bool Agregar(Tipo prmItem) { return false; }
        public bool Insertar(int prmIndice, Tipo prmItem) { return InsertarEn(0, prmItem); }
        public bool Modificar(int prmIndice, Tipo prmItem) { return ModificarEn(prmIndice, prmItem); }
        public bool Remover(int prmIndice, ref Tipo prmItem) { return ExtraerEn(0, ref prmItem); }
       // public bool Extraer(ref Tipo prmItem, int prmIndice) { return false; }
        public bool Recuperar(int prmIndice, ref Tipo prmItem) { return RecuperarEn(prmIndice, ref prmItem);}
        #endregion
    }
}
