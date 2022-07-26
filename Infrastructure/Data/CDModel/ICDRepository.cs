using System.Collections.Generic;
using CDShopApp.Domain;

namespace CDShopApp.Infrastructure.Data.CDModel;

public interface ICDRepository
{
    List<CD> GetCDs();
    CD GetCD(int id);
    int Add(CD cD);
    void Update(CD cD);
    void Delete(CD cD);
}