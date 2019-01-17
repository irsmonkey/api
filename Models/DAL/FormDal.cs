using System;
using System.Collections.Generic;
using System.Linq;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public class FormDal : IFormDal
    {
        private readonly IRSMonkeyContext _context;

        public FormDal(IRSMonkeyContext context)
        {
            _context = context;
        }

        public List<Form> GetAllForms()
        {
            try
            {
                var forms = _context.Form.ToList();
                return forms;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public Form GetAForm()
        {
            throw new NotImplementedException();
        }
    }
}