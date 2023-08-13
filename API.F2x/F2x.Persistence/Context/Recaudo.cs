using System;
using System.Collections.Generic;

namespace F2x.Persistence.Context;

public partial class Recaudo
{
    public DateTime Fecha { get; set; }

    public string Estacion { get; set; } = null!;

    public string Sentido { get; set; } = null!;

    public int Hora { get; set; }

    public string Categoria { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal ValorTabulado { get; set; }
}
