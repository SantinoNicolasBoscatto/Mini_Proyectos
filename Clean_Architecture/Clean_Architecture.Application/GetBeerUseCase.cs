using Clean_Architecture.Domain;

namespace Clean_Architecture.Application
{
    // USE-CASE, Si utilizamos CQRS ese vendria a ser los Use-Case
    public class GetBeerUseCase<TEntity, TOut> where TEntity : class
    {
        private readonly IRepository<TEntity> repository;
        private readonly IPresenter<TEntity, TOut> presenter;

        public GetBeerUseCase(IRepository<TEntity> repository, IPresenter<TEntity, TOut> presenter)
        {
            this.repository = repository;
            this.presenter = presenter;
        }

        public async Task<IEnumerable<TOut>> ExecuteAsync()
        {
            var entities = await repository.GeAllAsync();
            return presenter.Present(entities);
        }
    }
}
