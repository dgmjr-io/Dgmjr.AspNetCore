/*
 * SourceGenerator.cs
 *
 *   Created: 2022-12-14-07:23:00
 *   Modified: 2022-12-14-07:23:00
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Controllers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CSharp;

[Generator]
public class SourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var partialControllerDeclarations = context.SyntaxProvider
            .CreateSyntaxProvider(
                (node, ct) =>
                    node is ClassDeclarationSyntax cds
                    && cds.AttributeLists.Any(
                        al => al.Attributes.Any(a => a.Name.ToString() == "CrudController")
                    ),
                (context, _) => (context.Node as ClassDeclarationSyntax, context.SemanticModel)
            )
            .Collect();
        context.RegisterSourceOutput(
            partialControllerDeclarations,
            (spc, ct) =>
            {
                foreach (var delcaration in ct)
                {
                    var (classDeclaration, semanticModel) = delcaration;
                    var classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
                    var classType = classSymbol.ToDisplayString();
                    var classTypeParts = classType.Split('.');
                    var className = classTypeParts[^1];
                    var namespaceName = string.Join('.', classTypeParts[..^1]);
                    var source = $@"";
                }
            }
        );
    }
}
