using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoletaAnalise.maui.Models;

internal class Numero
{
    public Guid Id { get; set; }
    public int Valor { get; set; }
    public DateTime DataDoInput { get; set; }

    public Numero()
    {
        DataDoInput = DateTime.Now;
    }

    public override string ToString()
    {
        return Valor.ToString();
    }
}
