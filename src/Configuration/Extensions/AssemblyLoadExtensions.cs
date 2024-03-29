namespace Microsoft.Extensions.DependencyInjection;

internal static class AssemblyLoadExtensions
{
    public static Assembly? TryLoadAssemblyFromFile(string filename)
    {
        try
        {
            using var asmStream = File.OpenRead(filename);
            return Assembly.Load(asmStream.ReadAllBytes());
        }
        catch
        {
            return null;
        }
    }

    public static Assembly? TryLoadAssembly(AssemblyName name)
    {
        try
        {
            return Assembly.Load(name);
        }
        catch
        {
            return null;
        }
    }

    public static IEnumerable<Assembly> GetAssemblies() =>
        Directory
            .EnumerateFiles(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "*.dll")
            .Select(TryLoadAssemblyFromFile)
            .WhereNotNull()
            .SelectMany(assembly => assembly.GetReferencedAssemblies().Select(TryLoadAssembly))
            // .Distinct()
            .WhereNotNull()
            .ToList();

    public static IEnumerable<type> TryGetTypes(this Assembly asm)
    {
        try
        {
            return asm.GetTypes();
        }
        catch
        {
            return Enumerable.Empty<type>();
        }
    }

    public static IEnumerable<type> GetTypesAssignableTo<T>() =>
        GetAssemblies()
            .SelectMany(TryGetTypes)
            .Where(IsClassAndNotAbstractAndAssignableTo<T>)
            .ToList();

    public static bool IsClassAndNotAbstractAndAssignableTo<T>(this type type) =>
        type.IsClass
        && !type.IsAbstract
        && type.IsAssignableTo<T>();

    public static bool IsAssignableFrom<T>(this Type type) =>
        type.IsAssignableFrom(typeof(T));
    public static bool IsAssignableTo<T>(this Type type) =>
        type.IsAssignableTo(typeof(T));
}
