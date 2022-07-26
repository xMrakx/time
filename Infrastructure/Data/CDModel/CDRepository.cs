using CDShopApp.Domain;

namespace CDShopApp.Infrastructure.Data.CDModel;

public class CDRepository : ICDRepository
{
    private readonly CDContext _dbContext;

    public CDRepository(CDContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<CD> GetCDs()
    {
        return _dbContext.CD.ToList();
    }

    public int Add(CD cD)
    {
        return _dbContext.CD.Add(cD).Entity.Id;
    }

    public void Update(CD cD)
    {
        _dbContext.CD.Update(cD);
    }

    public void Delete(CD cD)
    {
        _dbContext.CD.Remove(cD);
    }

    public CD GetCD(int id)
    {
        return _dbContext.CD.SingleOrDefault(cD => cD.Id == id);
    }
}
