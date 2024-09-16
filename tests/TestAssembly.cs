namespace Microsoft.AspNetCore.Builder;

public class TestAssembly
{
    var assembly = Assembly.GetExecutingAssembly();
    var resourceNames = assembly.GetManifestResourceNames();
        foreach (var resourceName in resourceNames)
    {
        Console.WriteLine(resourceName);
    }

}