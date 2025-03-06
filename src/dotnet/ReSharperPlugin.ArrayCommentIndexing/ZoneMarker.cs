using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Psi.CSharp;

namespace ReSharperPlugin.ArrayCommentIndexing;

[ZoneMarker]
public class ZoneMarker : IRequire<ILanguageCSharpZone>
{
}