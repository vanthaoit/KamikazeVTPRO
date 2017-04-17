using System;
using KamikazeVTPRO.Data.Infrastructure;
using KamikazeVTPRO.Data.Repositories;
using KamikazeVTPRO.Model.Models;
using KamikazeVTPRO.Service.Infrastructure;

namespace KamikazeVTPRO.Service
{
    public interface IErrorService : IValidationService
    {
        void Create(Error error);
    }

    public class ErrorService : ValidationService, IErrorService
    {
        private IErrorRepository _errorRepository;
        public ErrorService(IUnitOfWork unitOfWork,IErrorRepository errorRepository) : base(unitOfWork)
        {
            this._errorRepository = errorRepository;
        }

        public void Create(Error error)
        {
            _errorRepository.Add(error);
        }
    }
}