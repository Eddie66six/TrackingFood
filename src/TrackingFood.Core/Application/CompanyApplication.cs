using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Application
{
    public class CompanyApplication: BaseApplication, ICompanyApplication
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyApplication(IUnitOfWork unitOfWork, ICompanyRepository companyRepository) : base(unitOfWork)
        {
            _companyRepository = companyRepository;
        }

        public int? Create(CreateCompanyViewModel company)
        {
            var objCompany = new Company(company.Name);
            _companyRepository.Create(objCompany);
            if (!IsError() && _companyRepository.ExistCompanyNameDapper(objCompany.Name))
                AddError("Company already exists");

            if (Commit())
                return objCompany.IdCompany;
            return null;
        }
    }
}