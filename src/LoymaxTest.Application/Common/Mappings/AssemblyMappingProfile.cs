using System.Reflection;
using AutoMapper;

namespace LoymaxTest.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            AppleMappingsFromAssembly(assembly);
        }

        private void AppleMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(k => k.GetInterfaces()
                    .Any(l => l.IsGenericType && l.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
