using System;
using System.Collections.Generic;
using System.Linq;
using IrsMonkeyApi.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace IrsMonkeyApi.Models.DAL
{

    public class ResolutionDal : IResolutionDal
    {
        private readonly IRSMonkeyContext _context;

        public ResolutionDal(IRSMonkeyContext context)
        {
            _context = context;
        }

        public List<Resolution> GetAllResolutions()
        {
            try
            {
                using (_context)
                {

                    var resolutions = _context.Resolution
                        .Join(_context.FormResolution
                            , resolution => resolution.ResolutionId
                            , formResolution => formResolution.ResolutionId
                            , (resolution, formResolution) => new {resolution, formResolution})
                        .Join(_context.Form, 

                    /*var resolutions = _context.Resolution
                        .Include(fr => fr.FormResolution)
                        .ThenInclude(f => f.Form)
                        .ThenInclude(q => q.FormQuestion)
                        .ThenInclude(ws => ws.WizardStepId)
                        .ThenInclude(qa => qa.FormQuestionAnswer)
                        .Where(r => r.IsDeleted == false)
                        .ToList();*/
                    
                    return resolutions;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Resolution GetAResolution()
        {
            throw new NotImplementedException();
        }
    }
}