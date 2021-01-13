namespace SmartSchool.WebAPI.Helper
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;
        
        public int PageSize { 
            get{return pageSize;} 
            set{pageSize = (value > MaxPageSize) ? MaxPageSize : value;} 
            }

        public int? Matricula { get; set; } = null;

        public string Nome { get; set; } = string.Empty;

        public int? Ativo { get; set; } = null;

        public string Ordenacao { get; set; } = string.Empty;
    }
}