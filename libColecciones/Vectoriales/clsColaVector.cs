using System;
using Servicios.Colecciones.TADS;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsColaVector<Tipo> : clsTadVectorial<Tipo>, iCola<Tipo> where Tipo : IComparable
    {
        #region Metodos
        public bool Encolar(Tipo prmItem) { return InsertarEn(0, prmItem); }
        public bool Desencolar(ref Tipo prmItem) { return ExtraerEn(0, ref prmItem); }
        public bool Revisar(ref Tipo prmItem) { return Existe(prmItem); }
        #endregion
    }
}
