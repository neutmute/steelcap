
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SteelCap.Test")]


#if DEBUG
    [assembly: AssemblyProduct("Steelcap (Debug)")]
    [assembly: AssemblyConfiguration("Debug")]
#else
    [assembly: AssemblyProduct("Steelcap (Release)")]
    [assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyVersion("1.0.0.*")]
[assembly: AssemblyFileVersion("1.0.0.1")]
[assembly: AssemblyInformationalVersion("Developer Build")]