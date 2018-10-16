using System;
using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IUploadFileDb
    {
        File UploadFile(string memberId, string resolution, string filename, string documentName);
        List<File> ListFileByUser(Guid memberId);
    }
}