using System;


namespace Servicios.Colecciones.Interfaces
{
    interface iTadCuerpo<Tipo> where Tipo : IComparable
    {
        bool Encontrar(Tipo prmItem, ref int prmIndice);
        bool Existe(Tipo prmItem);
    }
}
