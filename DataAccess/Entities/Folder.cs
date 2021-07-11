using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HApi.DataAccess.Entities {
    public class Folder {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FolderId { get;set; }
        public int? ParentId { get;set; }
        public Guid UserId { get; set; }
        public string FolderName { get; set; }
    }
}