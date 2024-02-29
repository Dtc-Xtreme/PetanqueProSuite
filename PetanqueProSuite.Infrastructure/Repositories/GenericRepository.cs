namespace PetanqueProSuite.Infrastructure.Repositories
{
    public abstract class GenericRepository
    {
        protected readonly PetanqueProSuiteDbContext context;

        public GenericRepository(PetanqueProSuiteDbContext ctx)
        {
            this.context = ctx;
        }

        public async Task<bool> CreateAsync<T>(T item) where T : class
        {
            try
            {
                await context.Set<T>().AddAsync(item);
                return await context.SaveChangesAsync() != 0 ? true : false;
            }
            catch (Exception ex)
            {

            }
            return false;

        }

        public async Task<bool> SaveAsync<T>(T item)
        {

            try
            {
                return await context.SaveChangesAsync() != 0 ? true : false;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public async Task<bool> DeleteAsync<T>(T item)
        {
            try
            {
                context.Remove(item);
                return await context.SaveChangesAsync() != 0 ? true : false;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}
