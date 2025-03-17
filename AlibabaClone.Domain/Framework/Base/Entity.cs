using AlibabaClone.Domain.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlibabaClone.Domain.Framework.Base
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id{ get; set; }
    }
}
