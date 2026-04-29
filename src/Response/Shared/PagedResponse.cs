using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apiExemplo.src.Response.Shared
{
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(
            TData? data,
            long totalCount,
            int currentPage = 1,
            int pageSize = Configuration.DefaultPageSize)
            : base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public PagedResponse(
            TData? data,
            int code = Configuration.DefaultStatusCode,
            string? message = null)
            : base(data, code, message)
        {
        }

        public int PageSize { get; set; } = Configuration.DefaultPageSize;
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int CurrentPage { get; set; }
        public long TotalCount { get; set; }

        [JsonIgnore]
        public override dynamic Result => new
        {
            TotalCount,
            CurrentPage,
            PageSize,
            TotalPages,
            Data
        };
    }
}