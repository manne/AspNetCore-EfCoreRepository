using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Manne.EfCore.AwesomeModule.Contracts
{
    public class GetAllQuery : IRequest<GetAllResult>, ISieveModel<FilterTerm, SortTerm>
    {
        private const string EscapedCommaPattern = @"(?<!($|[^\\])(\\\\)*?\\),";

        public List<FilterTerm> GetFiltersParsed()
        {
            if (Filters != null)
            {
                var value = new List<FilterTerm>();
                foreach (var filter in Regex.Split(Filters, EscapedCommaPattern))
                {
                    if (string.IsNullOrWhiteSpace(filter)) continue;

                    if (filter.StartsWith("("))
                    {
                        var filterOpAndVal = filter.Substring(filter.LastIndexOf(')') + 1);
                        var subFilters = filter.Replace(filterOpAndVal, "").Replace("(", "", StringComparison.Ordinal).Replace(")", "", StringComparison.Ordinal);
                        var filterTerm = new FilterTerm
                        {
                            Filter = subFilters + filterOpAndVal
                        };
                        if (!value.Any(f => f.Names.Any(n => filterTerm.Names.Any(n2 => n2 == n))))
                        {
                            value.Add(filterTerm);
                        }
                    }
                    else
                    {
                        var filterTerm = new FilterTerm
                        {
                            Filter = filter
                        };
                        value.Add(filterTerm);
                    }
                }
                return value;
            }

            return null;
        }

        public List<SortTerm> GetSortsParsed()
        {
            if (Sorts != null)
            {
                var value = new List<SortTerm>();
                foreach (var sort in Regex.Split(Sorts, EscapedCommaPattern))
                {
                    if (string.IsNullOrWhiteSpace(sort)) continue;

                    var sortTerm = new SortTerm()
                    {
                        Sort = sort
                    };
                    if (value.All(s => s.Name != sortTerm.Name))
                    {
                        value.Add(sortTerm);
                    }
                }
                return value;
            }

            return null;
        }

        [FromQuery]
        public string Filters { get; set; }

        [FromQuery]
        public string Sorts { get; set; }

        [FromQuery]
        public int? Page { get; set; }

        [FromQuery]
        public int? PageSize { get; set; }
    }
}
