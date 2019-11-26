using System;

namespace Servicios.Colecciones.TADS
{
    public class clsTadVectorial<Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos
        protected Tipo[] atrVectorItems; 
        private int atrCapacidad;
        private bool atrCapacidadFlexible = true;
        private int atrFactorCrecimiento = 10000;
        #endregion
        #region Métodos
        #region Auxiliares
        public bool EstaLlena()
        {
            if (atrLongitud == atrCapacidad)
                return true;
            else
                return false;
        }
        public bool desplazarItems(bool prmHaciaDerecha, int prmIndice)
        {
            if (EstaLlena() && prmHaciaDerecha && atrCapacidadFlexible)
            {
                Tipo[] varVectorAuxiliar = new Tipo[atrCapacidad + atrFactorCrecimiento];
                atrCapacidad += atrFactorCrecimiento;
                int varIndice2 = 0;
                for (int varIndice1 = 0; varIndice1 < prmIndice; varIndice1++)
                {
                    if (varIndice1 != prmIndice)
                    {
                        varVectorAuxiliar[varIndice1] = atrVectorItems[varIndice2];
                        varIndice2++;
                    }
                    else
                        varIndice2--;
                }
                atrVectorItems = varVectorAuxiliar;
            }

            if (!EstaLlena() && prmHaciaDerecha)
                for (int varPosicion = atrLongitud - 1; varPosicion >= prmIndice; varPosicion--)
                    atrVectorItems[varPosicion + 1] = atrVectorItems[varPosicion];
            if (prmHaciaDerecha == false)
                for (int varPosicion = prmIndice; varPosicion < atrLongitud; varPosicion++)
                    atrVectorItems[varPosicion + 1] = atrVectorItems[varPosicion + 1];
            return true;
        }
        #endregion
        #region CRUD´s-Query
        protected override bool InsertarEn(int prmIndice, Tipo prmItem)
        {
            //Verificar Totalidad y capacidad dinamica
            if (EsValido(prmIndice))
                if (desplazarItems(true, prmIndice))
                {
                    atrVectorItems[prmIndice] = prmItem;
                    atrLongitud++;
                    return true;
                }
            return false;
        }
        protected override bool ExtraerEn(int prmIndice, ref Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                prmItem = atrVectorItems[prmIndice];
                desplazarItems(false, prmIndice);
                atrLongitud--;
            }
            return false;
        }
        protected override bool ModificarEn(int prmIndice, Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                atrVectorItems[prmIndice] = prmItem;
                return true;
            }
            return false;
        }
        protected override bool RecuperarEn(int prmIndice, ref Tipo prmItem)
        {
            if (EsValido(prmIndice))
            {
                prmItem = atrVectorItems[prmIndice];
                return true;
            }
            return false;
        }
        #endregion
        #region Ordenamiento
        protected override void MetodoBurbujaSimple(bool prmOrdenarPorDescendente)
        {
            for (uint varIndiceExterior = 1; varIndiceExterior < atrLongitud; varIndiceExterior++)
            {
                for (uint varIndiceInterior = 0; varIndiceInterior < (atrLongitud - (varIndiceExterior)); varIndiceInterior++)
                {
                    atrNumeroComparaciones++;
                    int varComparacionElementos = atrVectorItems[varIndiceInterior].CompareTo(atrVectorItems[varIndiceInterior + 1]);
                    if (varComparacionElementos != 0 && (prmOrdenarPorDescendente ^ varComparacionElementos > 0))
                    {
                        Tipo varElementoTemporal = atrVectorItems[varIndiceInterior];
                        atrVectorItems[varIndiceInterior] = atrVectorItems[varIndiceInterior + 1];
                        atrVectorItems[varIndiceInterior + 1] = varElementoTemporal;
                        atrNumeroIntercambios++;
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}

