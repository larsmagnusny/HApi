using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HApi.DataAccess;
using HApi.Authorization;
using HApi.DataAccess.Entities;

namespace HApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly HContext _db;

        public CommandController(ILogger<LoginController> logger, HContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet]
        [VerifyToken]
        public FolderResult Cd(Guid token, int? currentFolderId, string path){
            Guid userGuid = (Guid)HttpContext.Items["UserId"];
            string[] pathArr = path.Split("/");

            var folders = _db.Folders;

            int curCount = 0;
            var curFolder = folders.FirstOrDefault(o => o.ParentId == currentFolderId && o.UserId == userGuid && o.FolderName.CompareTo(pathArr[curCount]) == 0);
            curCount++;

            while(curCount < pathArr.Length){
                curFolder = folders.FirstOrDefault(o => o.ParentId == curFolder.FolderId && o.UserId == userGuid && o.FolderName.CompareTo(pathArr[curCount]) == 0);
                curCount++;
                if(curFolder == null){
                    return null;
                }
            }

            return new FolderResult { FolderId = curFolder.FolderId, FolderName = curFolder.FolderName };
        }

        [HttpGet]
        [VerifyToken]
        public IEnumerable<FolderResult> Ls(Guid token, int? currentFolderId)
        {
            var folders = _db.Folders;

            return folders.Where(o => o.ParentId == currentFolderId).Select(o => new FolderResult{
                FolderId = o.FolderId,
                FolderName = o.FolderName
            });
        }

        [HttpGet]
        [VerifyToken]
        public IEnumerable<string> Mkdir(Guid token, int? currentFolderId, string FolderName){
            Guid userGuid = (Guid)HttpContext.Items["UserId"];
            var folders = _db.Folders;

            if(currentFolderId.HasValue){
                var parentFolder = folders.FirstOrDefault(o => o.FolderId == currentFolderId.Value);

                if(parentFolder != null){
                    folders.Add(new Folder { ParentId = parentFolder.FolderId, UserId = userGuid, FolderName = FolderName });
                }
                else
                {
                    return new string[]{ "Could not create " + FolderName + " because the parent directory does not exist." };
                }
            }
            else
            {
                folders.Add(new Folder { ParentId = null, UserId = userGuid, FolderName = FolderName });
            }

            return new string[]{ "Folder " + FolderName + " created." };
        }
    }
}
