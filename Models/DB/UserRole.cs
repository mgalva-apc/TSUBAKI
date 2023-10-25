using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class UserRole
    {
        [Key]
        public int RoleID { get; set; }
        public int AccountID { get; set; }
        public int LookUpRoleID { get; set; } 
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}

