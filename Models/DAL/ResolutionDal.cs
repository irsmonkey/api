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
                    var resolutions = _context.Resolution.Where(r => r.IsDeleted == false && r.FormResolution.Count == 0)
                        .Include(w => w.Wizard)
                        .ThenInclude(f=> f.Form)
                        .ThenInclude(q => q.FormQuestion)
                        .ToList();
                    
                    var resolutionsWithOutWizard = _context.Resolution.Where(r => r.IsDeleted == false && r.Wizard.Count == 0)
                        .Include(fr => fr.FormResolution)
                        .ThenInclude(f=> f.Form)
                        .ThenInclude(q => q.FormQuestion)
                        .ToList();
                    
                    resolutions.AddRange(resolutionsWithOutWizard);
                    
                    return resolutions;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public Resolution GetAResolution()
        {
            throw new NotImplementedException();
        }
    }
}