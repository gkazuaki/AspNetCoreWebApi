using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SmartSchool.WebAPI.Helper
{
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, int currentPage, int itensPerPage, int totalItens, int totalPages) 
        {
            var paginationHeader = new PaginationHeader(currentPage, itensPerPage, totalItens, totalPages);

            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Header","Pagination");
        }
    }
}