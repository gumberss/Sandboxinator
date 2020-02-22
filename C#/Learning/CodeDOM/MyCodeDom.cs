using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;

namespace Learning.CodeDOM
{
    public class MyCodeDom
    {
        public void Process()
        {
            CodeCompileUnit unit = new CodeCompileUnit();

            CodeNamespace codeNamespace = new CodeNamespace("MyTest");

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            CodeNamespaceImport import = new CodeNamespaceImport("System");
            codeNamespace.Imports.Add(import);
            unit.Namespaces.Add(codeNamespace);

            CodeTypeDeclaration myObject = new CodeTypeDeclaration("Headset");
            codeNamespace.Types.Add(myObject);

            CodeMemberField name = new CodeMemberField(typeof(String), "Name");
            name.Attributes = MemberAttributes.Public;
            myObject.Members.Add(name);

            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public;
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(String), "name"));
            myObject.Members.Add(constructor);

            var codeExpression = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("System.Console"),
                "WriteLine",
                new CodePrimitiveExpression("Let's get started")
                );

            var codeExpression2 = new CodeAssignStatement(
                new CodeTypeReferenceExpression("Name"),
                new CodeTypeReferenceExpression("name")
                );

            constructor.Statements.Add(codeExpression);
            constructor.Statements.Add(codeExpression2);

            using (var streamWriter = new StreamWriter("MyCode.cs"))
            {
                provider.GenerateCodeFromCompileUnit(unit, streamWriter, new CodeGeneratorOptions());
            }
        }
    }
}
