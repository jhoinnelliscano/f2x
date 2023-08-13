using F2x.Persistence.Context;
using System.Linq;
using System.Linq.Expressions;

namespace F2x.Persistence.Helpers
{
    public static class RecaudoEntityHelper
    {
        public static Expression<Func<Recaudo, bool>> FiltersExpression(string? category, string? station, string? direction, DateTime? startDate, DateTime? endDate, int hour)
        {
            Expression<Func<Recaudo, bool>> filters =
                x => !x.Categoria.Equals("");

            if (!string.IsNullOrEmpty(category))
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Categoria.Equals(category);
                filters = CombineWithAnd(filters, filterValues);
            }

            if (!string.IsNullOrEmpty(station))
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Estacion.Equals(station);
                filters = CombineWithAnd(filters, filterValues);
            }

            if (!string.IsNullOrEmpty(direction))
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Sentido.Equals(direction);
                filters = CombineWithAnd(filters, filterValues);
            }

            if (hour > 0)
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Hora == hour;
                filters = CombineWithAnd(filters, filterValues);
            }

            if (startDate != null)
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Fecha >= startDate;
                filters = CombineWithAnd(filters, filterValues);
            }

            if (endDate != null)
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Fecha <= endDate;
                filters = CombineWithAnd(filters, filterValues);
            }


            return filters;
        }

        public static Expression<Func<Recaudo, bool>> FiltersExpression(string? category, string? station, string? direction, int month, int year)
        {
            Expression<Func<Recaudo, bool>> filters =
                x => !x.Categoria.Equals("");

            if (!string.IsNullOrEmpty(category))
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Categoria.Equals(category);
                filters = CombineWithAnd(filters, filterValues);
            }

            if (!string.IsNullOrEmpty(station))
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Estacion.Equals(station);
                filters = CombineWithAnd(filters, filterValues);
            }

            if (!string.IsNullOrEmpty(direction))
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Sentido.Equals(direction);
                filters = CombineWithAnd(filters, filterValues);
            }

            if (month > 0)
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Fecha.Month == month;
                filters = CombineWithAnd(filters, filterValues);
            }

            if (year > 0)
            {
                Expression<Func<Recaudo, bool>> filterValues = x => x.Fecha.Year == year;
                filters = CombineWithAnd(filters, filterValues);
            }


            return filters;
        }

        private static Expression<Func<Recaudo, bool>> CombineWithAnd(Expression<Func<Recaudo, bool>> first, Expression<Func<Recaudo, bool>> second)
        {
            var paramExpr = Expression.Parameter(typeof(Recaudo));
            var exprBody = Expression.And(first.Body, second.Body);
            exprBody = (BinaryExpression)new ReplaceParameterHelper(paramExpr).Visit(exprBody);
            return Expression.Lambda<Func<Recaudo, bool>>(exprBody, paramExpr);
        }
    }
}
