using Nuke.Common;
using Nuke.Common.Tools.DotNet;

partial class TrafficBuild : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<TrafficBuild>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    Target Clean => definition => definition
       .Before(Restore)
       .OnlyWhenStatic(() => IsLocalBuild)
       .Executes(() => { });

    Target Restore => definition => definition
       .Executes(() => DotNetTasks.DotNetRestore());

    Target Compile => definition => definition
       .DependsOn(Restore)
       .Executes(() => DotNetTasks.DotNetBuild(configuration => configuration.SetConfiguration(Configuration)));

    Target Test => definition => definition
       .DependsOn(Compile)
       .Executes(() => DotNetTasks.DotNetTest());

    Target Build => definition => definition
       .DependsOn(Test)
       .Executes();
}