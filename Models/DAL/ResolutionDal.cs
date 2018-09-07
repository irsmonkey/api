using System;
using System.Collections.Generic;
using System.Linq;
using IrsMonkeyApi.Models.DB;
using Microsoft.EntityFrameworkCore;

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
                        .Include(w => w.Wizard)
                        .ThenInclude(f=> f.Form)
                        .ThenInclude(q => q.FormQuestion)
                        .ThenInclude(qa => qa.FormQuestionAnswer)
                        .Where(r => r.IsDeleted == false && r.FormResolution.Count == 0)
                        .ToList();
                    
                    var resolutionsWithOutWizard = _context.Resolution.Where(r => r.IsDeleted == false && r.Wizard.Count == 0)
                        .Include(fr => fr.FormResolution)
                        .ThenInclude(f=> f.Form)
                        .ThenInclude(q => q.FormQuestion)
                        .ThenInclude(qa => qa.FormQuestionAnswer)
                        .ToList();
                    
                    resolutions.AddRange(resolutionsWithOutWizard);
                    
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