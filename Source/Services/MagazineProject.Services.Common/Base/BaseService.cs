namespace MagazineProject.Services.Common.Base
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
