using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IFormDal
    {
        List<Form> GetAllForms();
        Form GetAForm();
    }
}