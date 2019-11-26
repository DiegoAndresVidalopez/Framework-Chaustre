﻿using System;
using Servicios.Colecciones.TADS;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsPilaVector<Tipo> : clsTadVectorial<Tipo>, iPila<Tipo> where Tipo : IComparable
    {
        #region Metodos CRUD-Query
        public bool Apilar(Tipo prmItem) { return InsertarEn(0, prmItem); }
        public bool Desapilar(ref Tipo prmItem) { return ExtraerEn(0, ref prmItem); }
        public bool Revisar(ref Tipo prmItem) { return RecuperarEn(0, ref prmItem); }
        #endregion
    }
}
