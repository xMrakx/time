using CDShopApp.Domain;
using CDShopApp.Dto;
using CDShopApp.Infrastructure.Data.CDModel;
using CDShopApp.Infrastructure.UoW;

namespace CDShopApp.Services;

public class CDService : ICDService
{
    private readonly ICDRepository _cdRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CDService(ICDRepository cdRepository, IUnitOfWork unitOfWork)
    {
        _cdRepository = cdRepository;
        _unitOfWork = unitOfWork;
    }

    public List<CD> GetAll()
    {
        return _cdRepository.GetCDs();  
    }

    
    public CD GetByID(int id)
    {
        CD cD = _cdRepository.GetCD(id);
        if (cD == null)
        {
            throw new Exception($"{nameof(CD)} not found, #Id - {id}");
        }
        return cD;
    }

    /*
    public CD GetByName(string name)
    {
        CD cD = _cdRepository.GetByName(name);
        if (cD == null)
        {
            throw new Exception($"{nameof(CD)} not found, #Name - {name}");
        }
        return cD;
    }

    public List<CDPurchaseCount> GetPurchaseCount()
    {
        List<CDPurchaseCount> count = _cdRepository.GetPurchaseCount();
        if (count.Count == 0)
        {
            throw new Exception($"{nameof(CDPurchaseCount)} not found");
        }
        return count;
    }
    */

    public int Add(CDDto cd)
    {
        if (cd == null)
        {
            throw new Exception($"{nameof(CD)} not found");
        }

        CD cDEntity = cd.ConvertToCD();

        return _cdRepository.Add(cDEntity);
    }
        
    public void Update(CDDto cd)
    {

        if (cd == null)
        {
            throw new Exception($"{nameof(CD)} not found, #Id - {cd.Id}");
        }
        CD cDEntity = cd.ConvertToCD();
        _cdRepository.Update(cDEntity);

    }

    public void Delete(int id)
    {
        CD cD = _cdRepository.GetCD(id);
        if (cD == null)
        {
            throw new Exception($"{nameof(CD)} not found, #Id - {id}");
        }
        _cdRepository.Delete(cD);
    }

    public CD GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public List<CDPurchaseCount> GetPurchaseCount()
    {
        throw new NotImplementedException();
    }
}