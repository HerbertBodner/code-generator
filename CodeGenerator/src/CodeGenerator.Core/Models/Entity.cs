using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Core.Models
{
    public class Entity
    {
        public Entity(Type clrType)
        {
            ClrType = clrType;

            var classProps = clrType.GetProperties().ToList();

            Properties = classProps
                .Where(x => x.DeclaringType == clrType)
                .Select(x => new EntityProperty(x)).ToList();
        }

        public Type ClrType { get; set; }

        public string ClassName {
            get { return ClrType.Name; }
        }

        public string Namespace {
            get { return ClrType.Namespace; }
        }

        public List<EntityProperty> Properties { get; set; }
    }
}
