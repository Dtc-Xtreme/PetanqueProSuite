namespace WMS.Infrastructure
{
    public interface IGenericRepository
    {
        public Task<bool> CreateAsync<T>(T item) where T : class;
        public Task<bool> SaveAsync<T>(T item);
        public Task<bool> DeleteAsync<T>(T item);
    }
}
