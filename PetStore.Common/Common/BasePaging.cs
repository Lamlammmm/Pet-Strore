namespace PetStore.Common.Common
{
    public class BasePaging
    {
        public string? Keyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}