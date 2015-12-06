using EA.Infrastructure.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.Infrastructure.Entities
{
    public class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
        public virtual StatusType Status { get; protected set; }
        public virtual DateTime InsertDate { get; protected set; }
        public virtual long InsertedBy { get; protected set; }

        public Entity()
        {
            this.InsertDate = DateTime.Now;
            this.Status = StatusType.Available;
            this.InsertedBy = 1;

        }

        public virtual void Passivate()
        {
            this.Status = StatusType.NotAvailable;
        }

        public virtual void Delete()
        {
            this.Status = StatusType.Deleted;
        }

        public virtual void UpdateStatu(
            StatusType statusType)
        {
            this.Status = statusType;
        }
    }
}
