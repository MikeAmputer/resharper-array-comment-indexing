using System;
using System.Linq;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.ContextActions;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.TextControl;
using JetBrains.Util;
using JetBrains.ReSharper.Resources.Shell;

namespace ReSharperPlugin.ArrayCommentIndexing;

[ContextAction(
    Name = "ArrayIndexingAction",
    Description = "Adds /*index*/ comments before each element in a C# array initializer",
    GroupType = typeof(CSharpContextActions))]
public class ArrayIndexingAction : ContextActionBase
{
    private readonly ICSharpContextActionDataProvider _dataProvider;

    public ArrayIndexingAction(ICSharpContextActionDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public override string Text => "Add Index Comments to Array Elements";

    public override bool IsAvailable(IUserDataHolder cache)
    {
        var element = _dataProvider.GetSelectedElement<IExpression>();

        return element?.GetContainingNode<IArrayInitializer>() != null;
    }

    protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator _)
    {
        var selectedElement = _dataProvider.GetSelectedElement<IExpression>();
        var arrayInitializer = selectedElement?.GetContainingNode<IArrayInitializer>();

        if (arrayInitializer == null)
            return null;

        var factory = _dataProvider.ElementFactory;
        var elements = arrayInitializer.ElementInitializersEnumerable.ToList();

        using var wlc = WriteLockCookie.Create();

        for (var i = 0; i < elements.Count; i++)
        {
            var comment = factory.CreateComment($"/*{i}*/");

            var element = elements[i];
            var prev = element.GetPreviousNonWhitespaceSibling();

            if (prev is ICSharpCommentNode existingComment)
            {
                ModificationUtil.ReplaceChild(existingComment, comment);
            }
            else
            {
                ModificationUtil.AddChildBefore(element, comment);

                var space = factory.CreateWhitespaces(" ").FirstOrDefault();
                if (space != null)
                {
                    ModificationUtil.AddChildBefore(element, space);
                }
            }
        }

        return null;
    }
}