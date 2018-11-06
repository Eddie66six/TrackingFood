using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Applications;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Application
{
    public class CompanyBranchApplication: BaseApplication, ICompanyBranchApplication
    {
        private readonly ICompanyBranchRepository _companyBranchRepository;
        public CompanyBranchApplication(IUnitOfWork unitOfWork, ICompanyBranchRepository companyBranchRepository) : base(unitOfWork)
        {
            _companyBranchRepository = companyBranchRepository;
        }

        public int? Create(CreateCompanyBranchViewModel companyBranch)
        {
            var objCompanyBranch = new CompanyBranch(companyBranch.Name, companyBranch.IdCompany, companyBranch.Latitude, companyBranch.Longitude);
            _companyBranchRepository.Create(objCompanyBranch);
            if (!IsError() && _companyBranchRepository.ExistCompanyNameDapper(objCompanyBranch.Name))
                AddError("Company branch already exists");

            if (Commit())
                return objCompanyBranch.IdCompany;
            return null;
        }
    }
}