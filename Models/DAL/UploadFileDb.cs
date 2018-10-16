using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public class UploadFileDb : IUploadFileDb
    {
        private readonly IRSMonkeyContext _context;

        public UploadFileDb(IRSMonkeyContext context)
        {
            _context = context;
        }

        public File UploadFile(string memberId, string resolution, string filename, string documentName)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var upLoadFolder = new Folder()
                        {
                            MemberId = new Guid(memberId),
                            Name = resolution,
                            DateStamp = DateTime.Now
                        };
                        _context.Folder.Add(upLoadFolder);
                        _context.SaveChanges();
                        var fileUploaded = new File()
                        {
                            FileName = filename,
                            Alias = documentName,
                            FolderId = upLoadFolder.FolderId,
                            DateStamp = DateTime.Now
                        };
                        _context.File.Add(fileUploaded);
                        _context.SaveChanges();
                        transaction.Commit();
                        return fileUploaded;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<File> ListFileByUser(Guid memberId)
        {
            try
            {
                var listOfFiles = (from folder in _context.Folder
                        join file in _context.File
                            on folder.FolderId equals file.FolderId
                        where folder.MemberId == memberId
                        select new File()
                        {
                            FileId = file.FileId,
                            FileName = file.FileName,
                            Alias = file.Alias,
                            DateStamp = file.DateStamp
                        }
                    ).ToList();

                return listOfFiles;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}