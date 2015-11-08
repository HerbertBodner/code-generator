using CodeGenerator.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodeGenerator.Core.Services
{
    public class EntityReaderService
    {
        public IEnumerable<Entity> GetAllClasses(string assemblyPath, string[] namespaceLst = null)
        {
            if (!File.Exists(assemblyPath))
            {
                throw new FileNotFoundException("File not found", assemblyPath);
            }

            var assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);

            var types = assembly.GetTypes().Where(x => x.IsClass);

            var entities = types
                .Select(x => new Entity
                    {
                        ClassName = x.Name,
                        ClrType = x
                    }
                );

            if (namespaceLst != null && namespaceLst.Any())
            {
                return
                    entities.Where(
                        x => namespaceLst.Any(y => string.Equals(x.ClrType.Namespace, y, StringComparison.Ordinal)));
            }

            return entities;
        }
    }
}
