namespace PetStore.Common.Common
{
    public class Pagingnation<T> : PagingnationBase where T : class
    {
        public List<T> Items { get; set; }
    }
}