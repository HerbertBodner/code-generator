using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core.Models
{
    public class EntityProperty
    {
        public EntityProperty(PropertyInfo propInfo)
        {
            PropInfo = propInfo;
        }

        public PropertyInfo PropInfo { get; private set; }

        public string Name
        {
            get { return PropInfo.Name; }
        }

        public string TypeName
        {
            get {
                return GetTypeName(PropInfo.PropertyType);
            }
        }

        public string GetTypeNameWithPostfix(string namespacePrefix, string postFix)
        {
            return GetTypeName(PropInfo.PropertyType, namespacePrefix, postFix);
        }

        private string GetTypeName(Type t, string namespacePrefix = null, string postFix = null)
        {
            if (!t.IsGenericType)
            {
                if (!string.IsNullOrEmpty(namespacePrefix) && t.Namespace.StartsWith(namespacePrefix))
                {
                    return t.Name + postFix;
                }
                else
                {
                    return t.Name;
                }
                
            }

            if (t.IsNested && t.DeclaringType.IsGenericType)
            {
                throw new NotImplementedException();
            }

            
            var strb = new StringBuilder();
            var genericType = t.GetGenericTypeDefinition();
            var genericTypeName = genericType.Name.Substring(0, t.Name.IndexOf('`'));
            if (!string.IsNullOrEmpty(namespacePrefix) && genericType.Namespace.StartsWith(namespacePrefix))
            {
                strb.Append(genericTypeName + postFix);
            }
            else
            {
                strb.Append(genericTypeName);
            }
            strb.Append("<");

            strb.Append(string.Join(", ", t.GenericTypeArguments.ToList().Select(x => GetTypeName(x, namespacePrefix, postFix))));

            strb.Append(">");

            return strb.ToString();
        }
    }
}
