using Interview.db.contract;
using System;

namespace Interview.db.inmemory {
  public class CompanyRepo : InMemoryRepository<Company>, ICompanyRepository {
    public CompanyRepo()
    {
      Upsert(new contract.Company() { Name = "Company1", Homepage = "http://www.google.de/", ID = Guid.Parse("b0b30067-0311-48ad-a3c2-8f3b8d3b7bc1") });
      Upsert(new contract.Company() { Name = "Company2", Homepage = "http://www.google.de/", ID = Guid.Parse("2b48ab22-b3c2-42e9-ada5-f786090e463b") });
      Upsert(new contract.Company() { Name = "Company3", Homepage = "http://www.google.de/", ID = Guid.Parse("41b0662c-6156-497c-837e-05e889ee929a") });
      Upsert(new contract.Company() { Name = "Company4", Homepage = "http://www.google.de/", ID = Guid.Parse("25cf9676-7e78-400f-b6e5-d6dff00db891") });
      Upsert(new contract.Company() { Name = "Company5", Homepage = "http://www.google.de/", ID = Guid.Parse("7d0825c7-977b-498f-99a1-ec2fb2aa3f43") });
    }
  }
}
