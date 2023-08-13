using Policy.PersonalSoft.EntityDomain.Commands;
using Policy.PersonalSoft.EntityDomain.Domain;
using Policy.PersonalSoft.Persistence;
using Policy.PersonalSoft.UseCases.Interfaces;

namespace Policy.PersonalSoft.UseCases.Services
{
    public class InsurancePolicyPlanService : IInsurancePolicyPlanService
    {
        private readonly IUnitOfWork unitOfWork;

        public InsurancePolicyPlanService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsyn(CreateInsurancePolicyPlanCommand createInsurancePolicyPlanCommand)
        {
            var insurancePolicyPlan = createInsurancePolicyPlanCommand.GetDomain();
            await unitOfWork.InsurancePolicyPlanCommandsRepository.CreateAsync(insurancePolicyPlan);
        }

        public async Task<IEnumerable<InsurancePolicyPlan>> GetAllAsyn() => await unitOfWork.InsurancePolicyPlanQueriesRepository.GetAllAsync();
    }
}
