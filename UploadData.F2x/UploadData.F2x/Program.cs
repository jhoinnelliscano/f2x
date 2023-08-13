// See https://aka.ms/new-console-template for more information
using System.Net;
using System;
using UploadData.F2x.Model;
using Newtonsoft.Json;
using UploadData.F2x;
using UploadData.F2x.Context;
using System.Collections.Generic;

Console.WriteLine("Inicia servicio!");

var minDate = "2021-10-07";
var maxDate =  DateTime.Today;

Console.WriteLine("Registar data desde " + minDate + " hasta " + maxDate.ToString());

var parsedminDate = DateTime.Parse(minDate);
DateTime i = parsedminDate.Date;

while (i <= DateTime.Today)
{
    var strDate = i.ToString("yyyy-MM-dd");

    try
    {
        Console.WriteLine("Consultar data de " + strDate);

        var conteoList = CallServiceHelper.GetConteoVehiculos(strDate);
        var recaudoList = CallServiceHelper.GetRecaudoVehiculos(strDate);

        if (conteoList!= null && recaudoList != null)
        {
            var conteoListGrouped =
                 from c in conteoList
                 group c by new
                 {
                     c.Categoria,
                     c.Estacion,
                     c.Sentido,
                     c.Hora,
                 } into gv
                 select new VehicleResponse()
                 {
                     Categoria = gv.Key.Categoria,
                     Estacion = gv.Key.Estacion,
                     Sentido = gv.Key.Sentido,
                     Hora = gv.Key.Hora,
                     Cantidad = gv.Sum(x => x.Cantidad),
                 };

            var recaudoListGrouped =
                 from c in recaudoList
                 group c by new
                 {
                     c.Categoria,
                     c.Estacion,
                     c.Sentido,
                     c.Hora,
                 } into gv
                 select new VehicleResponse()
                 {
                     Categoria = gv.Key.Categoria,
                     Estacion = gv.Key.Estacion,
                     Sentido = gv.Key.Sentido,
                     Hora = gv.Key.Hora,
                     ValorTabulado = gv.Sum(x => x.ValorTabulado),
                 };



            var vehicles = from c in conteoListGrouped
                           join r in recaudoListGrouped on new
                           {
                               c.Categoria,
                               c.Estacion,
                               c.Sentido,
                               c.Hora,
                           } equals new
                           {
                               r.Categoria,
                               r.Estacion,
                               r.Sentido,
                               r.Hora,
                           }
                           select new Recaudo()
                           {
                               Fecha = i.Date,
                               Categoria = c.Categoria,
                               Estacion = c.Estacion,
                               Hora = c.Hora,
                               Sentido = c.Sentido,
                               Cantidad = c.Cantidad,
                               ValorTabulado = r.ValorTabulado
                           };

            if (vehicles.Any())
            {
                Console.WriteLine("Registrar data de " + strDate);

                using var context = new DbRecaudoContext();
                context.Recaudos.AddRange(vehicles.ToList());
                context.SaveChanges();
            }
        }
        i = i.AddDays(1);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al registrar data de " + strDate + " | " + ex.Message);
        i = i.AddDays(1);
    }
}








