using Tranzact.Premium.Domain.Common;

namespace Tranzact.Premium.Domain
{
    public class State : BaseAuditableEntity
    {
        //public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
