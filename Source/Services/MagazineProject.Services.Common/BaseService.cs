namespace MagazineProject.Services.Common
{
    using MagazineProject.Data.UnitOfWork;

    public class BaseService
    {
        protected IUnitOfWorkData Data { get; private set; }

        public BaseService(IUnitOfWorkData data)
        {
            this.Data = data;
        }
    }
}
