using AlibabaClone.Domain.Framework.Interfaces;

namespace AlibabaClone.Domain.Framework.Base
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id{ get; set; }
    }
}
