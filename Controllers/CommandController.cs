using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HApi.Models;
using HApi.Storage;
using HApi.Storage.Entities;
using HApi.Crypto;
using HApi.DataAccess;

namespace HApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IHDbContext _db;

        public ComputerController(ILogger<LoginController> logger, IHDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        public FolderResult Cd(Guid token, int? currentFolderId, string path){
            if (!TokenStorage.CheckToken(token))
                return null;

            var userGuid = TokenStorage.FindUser(token);

            if(userGuid.HasValue){

                string[] pathArr = path.Split("/");

                var folders = _db.Database.GetCollection<Folder>();

                int curCount = 0;
                var curFolder = folders.FirstOrDefault(o => o.ParentId == currentFolderId && o.UserId == userGuid && o.FolderName.CompareTo(pathArr[curCount++]));

                while(curCount < pathArr.Length){
                    curFolder = folders.FirstOrDefault(o => o.ParentId == curFolder.FolderId && o.UserId == userGuid && o.FolderName.CompareTo(pathArr[curCount++]));

                    if(curFolder == null){
                        return null;
                    }
                }

                return new FolderResult { FolderId = curFolder.FolderId, FolderName = curFolder.FolderName };
            }

            return null;
        }

        [HttpGet]
        public IEnumerable<FolderResult> Ls(Guid token, int? currentFolderId)
        {
            if (!TokenStorage.CheckToken(token))
                return new List<FolderResult>();

            var userGuid = TokenStorage.FindUser(token);

            if(userGuid.HasValue){
                var folders = _db.Database.GetCollection<Folder>();

                return folders.Where(o => o.ParentId == currentFolderId).Select(o => new FolderResult{
                    FolderId = o.FolderId,
                    FolderName = o.FolderName
                });
            }

            return new List<FolderResult>();
        }

        [HttpGet]
        public IEnumerable<string> Mkdir(Guid token, int? currentFolderId, string FolderName){
            if (!TokenStorage.CheckToken(token))
                return new List<string>();

            var userGuid = TokenStorage.FindUser(token);

            if(userGuid.HasValue){
                var folders = _db.Database.GetCollection<Folder>();

                if(currentFolderId.HasValue){
                    var parentFolder = folders.FirstOrDefault(o => o.FolderId = currentFolderId);

                    if(parentFolder != null){
                        folders.Add(new Folder { ParentId = parentFolder.FolderId, UserId = userGuid, FolderName = FolderName });
                        folders.EnsureIndex(o => o.FolderId);
                    }
                    else
                    {
                        return new string[]{ "Could not create " + FolderName + " because the parent directory does not exist." };
                    }
                }
                else
                {
                    folders.Add(new Folder { ParentId = null, UserId = userGuid, FolderName = FolderName });
                    folders.EnsureIndex(o => o.FolderId);
                }

                return new string[]{ "Folder " + FolderName + " created." };
            }

            return new List<string>();
        }
    }
}
