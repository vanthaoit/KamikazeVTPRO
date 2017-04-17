using KamikazeVTPRO.Data.Infrastructure;

namespace KamikazeVTPRO.Service.Infrastructure
{
    public abstract class ValidationService : IValidationService
    {
        #region Properties

        protected IUnitOfWork _unitOfWork
        {
            get; set;
        }

        #endregion Properties

        public ValidationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #region Implementation

        public void Save()
        {
            _unitOfWork.Commit();
        }

        #endregion Implementation
    }
}