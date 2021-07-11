using System;
using System.ComponentModel.DataAnnotations;

namespace HApi.DataAccess.Entities {
    public class Folder {
        [Key]
        public int FolderId { get;set; }
        public int? ParentId { get;set; }
        public Guid UserId { get; set; }
        public string FolderName { get; set; }
    }
}