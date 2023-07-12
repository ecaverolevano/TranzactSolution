using System.ComponentModel.DataAnnotations;
using Tranzact.Premium.Domain.Common;

namespace Tranzact.Premium.Domain
{
    public class Plan: BaseAuditableEntity
    {
        //[Key]
        //public int Id { get; set; }
        public string Code { get; set; }
    }
}
