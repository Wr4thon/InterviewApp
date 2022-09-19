using System;

namespace Interview.db.inmemory {
  public class InterviewRepo : InMemoryRepository<contract.Interview>, contract.IInterviewRepository {
    private readonly contract.ICompanyRepository _companyRepo;

    public InterviewRepo(contract.ICompanyRepository companyRepo)
    {
      this._companyRepo = companyRepo;
      Upsert(new contract.Interview() { ID = Guid.Parse("cd38630b-e46f-436a-b023-e42b4a4c1c26"), CompanyID = Guid.Parse("b0b30067-0311-48ad-a3c2-8f3b8d3b7bc1"), Name = "Interview 1 at Company 1" });
      Upsert(new contract.Interview() { ID = Guid.Parse("a86663a6-292c-4488-9421-ec387e542fba"), CompanyID = Guid.Parse("b0b30067-0311-48ad-a3c2-8f3b8d3b7bc1"), Name = "Interview 2 at Company 1" });
      Upsert(new contract.Interview() { ID = Guid.Parse("f2e1ea29-def7-4afa-b028-9a997d0704ac"), CompanyID = Guid.Parse("b0b30067-0311-48ad-a3c2-8f3b8d3b7bc1"), Name = "Interview 3 at Company 1" });
      Upsert(new contract.Interview() { ID = Guid.Parse("c3434827-2b98-4437-b180-db8cdf483b69"), CompanyID = Guid.Parse("41b0662c-6156-497c-837e-05e889ee929a"), Name = "Interview at Company 3" });
    }
  }
}
