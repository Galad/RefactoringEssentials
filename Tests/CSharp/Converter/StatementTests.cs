﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RefactoringEssentials.Tests.CSharp.Converter
{
    [TestFixture]
    public class StatementTests : ConverterTestBase
    {
        [Test]
        public void EmptyStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        If True Then
        End If

        While True
        End While

        While True
        End While

        Do
        Loop While True
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        if (true) ;
        while (true) ;
        for (;;) ;
        do ; while (true);
    }
}");
        }

        [Test]
        public void AssignmentStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer
        b = 0
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int b;
        b = 0;
    }
}");
        }

        [Test]
        public void AssignmentStatementInDeclaration()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer = 0
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int b = 0;
    }
}");
        }

        [Test]
        public void AssignmentStatementInVarDeclaration()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b = 0
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        var b = 0;
    }
}");
        }

        [Test]
        public void ObjectInitializationStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As String
        b = New String(""test"")
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        string b;
        b = new string(""test"");
    }
}");
        }

        [Test]
        public void ObjectInitializationStatementInDeclaration()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As String = New String(""test"")
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        string b = new string(""test"");
    }
}");
        }

        [Test]
        public void ObjectInitializationStatementInVarDeclaration()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b = New String(""test"")
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        var b = new string(""test"");
    }
}");
        }

        [Test]
        public void ArrayDeclarationStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer()
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[] b;
    }
}");
        }

        [Test]
        public void ArrayInitializationStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer() = {1, 2, 3}
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[] b = { 1, 2, 3 };
    }
}");
        }

        [Test]
        public void ArrayInitializationStatementInVarDeclaration()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b = {1, 2, 3}
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        var b = { 1, 2, 3 };
    }
}");
        }

        [Test]
        public void ArrayInitializationStatementWithType()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer() = New Integer() {1, 2, 3}
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[] b = new int[] { 1, 2, 3 };
    }
}");
        }

        [Test]
        public void ArrayInitializationStatementWithLength()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer() = New Integer(2) {1, 2, 3}
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[] b = new int[3] { 1, 2, 3 };
    }
}");
        }

        [Test]
        public void MultidimensionalArrayDeclarationStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer(,)
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[,] b;
    }
}");
        }

        [Test]
        public void MultidimensionalArrayInitializationStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer(,) = {{1, 2}, {3, 4}}
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[,] b = { { 1, 2 }, { 3, 4 } };
    }
}");
        }

        [Test]
        public void MultidimensionalArrayInitializationStatementWithType()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer(,) = New Integer(,) {{1, 2}, {3, 4}}
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[,] b = new int[,] { { 1, 2 }, { 3, 4 } };
    }
}");
        }

        [Test]
        public void MultidimensionalArrayInitializationStatementWithLengths()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer(,) = New Integer(1, 1) {{1, 2}, {3, 4}}
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[,] b = new int[2, 2] { { 1, 2 }, { 3, 4 } };
    }
}");
        }

        [Test]
        public void JaggedArrayDeclarationStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer()()
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[][] b;
    }
}");
        }

        [Test]
        public void JaggedArrayInitializationStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer()() = {New Integer() {1, 2}, New Integer() {3, 4}}
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[][] b = { new int[] { 1, 2 }, new int[] { 3, 4 } };
    }
}");
        }

        [Test]
        public void JaggedArrayInitializationStatementWithType()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer()() = New Integer()() {New Integer() {1, 2}, New Integer() {3, 4}}
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[][] b = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
    }
}");
        }

        [Test]
        public void JaggedArrayInitializationStatementWithLength()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer()() = New Integer(1)() {New Integer() {1, 2}, New Integer() {3, 4}}
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int[][] b = new int[2][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
    }
}");
        }

        [Test]
        public void DeclarationStatements()
        {
            TestConversionVisualBasicToCSharp(
@"Class Test
    Private Sub TestMethod()
the_beginning:
        Dim value As Integer = 1
        Const myPIe As Double = System.Math.PI
        Dim text = ""This is my text!""
        GoTo the_beginning
    End Sub
End Class", @"class Test {
    void TestMethod()
    {
the_beginning:
        int value = 1;
        const double myPIe = System.Math.PI;
        var text = ""This is my text!"";
        goto the_beginning;
    }
}");
        }

        [Test]
        public void IfStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod(ByVal a As Integer)
        Dim b As Integer

        If a = 0 Then
            b = 0
        ElseIf a = 1 Then
            b = 1
        ElseIf a = 2 OrElse a = 3 Then
            b = 2
        Else
            b = 3
        End If
    End Sub
End Class", @"
class TestClass
{
    void TestMethod (int a)
    {
        int b;
        if (a == 0) {
            b = 0;
        } else if (a == 1) {
            b = 1;
        } else if (a == 2 || a == 3) {
            b = 2;
        } else {
            b = 3;
        }
    }
}");
        }

        [Test]
        public void WhileStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer
        b = 0

        While b = 0
            If b = 2 Then Continue While
            If b = 3 Then Exit While
            b = 1
        End While
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int b;
        b = 0;
        while (b == 0)
        {
            if (b == 2)
                continue;
            if (b == 3)
                break;
            b = 1;
        }
    }
}");
        }

        [Test]
        public void DoWhileStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        Dim b As Integer
        b = 0

        Do
            If b = 2 Then Continue Do
            If b = 3 Then Exit Do
            b = 1
        Loop While b = 0
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        int b;
        b = 0;
        do
        {
            if (b == 2)
                continue;
            if (b == 3)
                break;
            b = 1;
        }
        while (b == 0);
    }
}");
        }

        [Test]
        public void ForEachStatementWithExplicitType()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod(ByVal values As Integer())
        For Each val As Integer In values
            If val = 2 Then Continue For
            If val = 3 Then Exit For
        Next
    End Sub
End Class", @"
class TestClass
{
    void TestMethod(int[] values)
    {
        foreach (int val in values)
        {
            if (val == 2)
                continue;
            if (val == 3)
                break;
        }
    }
}");
        }

        [Test]
        public void ForEachStatementWithVar()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod(ByVal values As Integer())
        For Each val In values
            If val = 2 Then Continue For
            If val = 3 Then Exit For
        Next
    End Sub
End Class", @"
class TestClass
{
    void TestMethod(int[] values)
    {
        foreach (var val in values)
        {
            if (val == 2)
                continue;
            if (val == 3)
                break;
        }
    }
}");
        }

        [Test]
        public void SyncLockStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod(ByVal nullObject As Object)
        If nullObject Is Nothing Then Throw New ArgumentNullException(NameOf(nullObject))

        SyncLock nullObject
            Console.WriteLine(nullObject)
        End SyncLock
    End Sub
End Class", @"
class TestClass
{
    void TestMethod(object nullObject)
    {
        if (nullObject == null)
            throw new ArgumentNullException(nameof(nullObject));
        lock (nullObject) {
            Console.WriteLine(nullObject);
        }
    }
}");
        }

        [Test]
        public void ForWithUnknownConditionAndSingleStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        i = 0

        While unknownCondition
            b(i) = s(i)
            i += 1
        End While
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        for (i = 0; unknownCondition; i++)
            b[i] = s[i];
    }
}");
        }

        [Test]
        public void ForWithUnknownConditionAndBlock()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        i = 0

        While unknownCondition
            b(i) = s(i)
            i += 1
        End While
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        for (i = 0; unknownCondition; i++) {
            b[i] = s[i];
        }
    }
}");
        }

        [Test]
        public void ForWithSingleStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        For i = 0 To [end] - 1
            b(i) = s(i)
        Next
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        for (i = 0; i < end; i++) b[i] = s[i];
    }
}");
        }

        [Test]
        public void ForWithBlock()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod()
        For i = 0 To [end] - 1
            b(i) = s(i)
        Next
    End Sub
End Class", @"
class TestClass
{
    void TestMethod()
    {
        for (i = 0; i < end; i++) {
            b[i] = s[i];
        }
    }
}");
        }

        [Test]
        public void LabeledAndForStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class GotoTest1
    Private Shared Sub Main()
        Dim x As Integer = 200, y As Integer = 4
        Dim count As Integer = 0
        Dim array As String(,) = New String(x - 1, y - 1) {}

        For i As Integer = 0 To x - 1

            For j As Integer = 0 To y - 1
                array(i, j) = (System.Threading.Interlocked.Increment(count)).ToString()
            Next
        Next

        Console.Write(""Enter the number to search for: "")
        Dim myNumber As String = Console.ReadLine()

        For i As Integer = 0 To x - 1

            For j As Integer = 0 To y - 1

                If array(i, j).Equals(myNumber) Then
                    GoTo Found
                End If
            Next
        Next

        Console.WriteLine(""The number {0} was not found."", myNumber)
        GoTo Finish
Found:
        Console.WriteLine(""The number {0} is found."", myNumber)
Finish:
        Console.WriteLine(""End of search."")
        Console.WriteLine(""Press any key to exit."")
        Console.ReadKey()
    End Sub
End Class", @"
class GotoTest1
{
    static void Main()
    {
        int x = 200, y = 4;
        int count = 0;
        string[,] array = new string[x, y];

        for (int i = 0; i < x; i++)

            for (int j = 0; j < y; j++)
                array[i, j] = (++count).ToString();

        Console.Write(""Enter the number to search for: "");

        string myNumber = Console.ReadLine();

                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (array[i, j].Equals(myNumber))
                        {
                            goto Found;
                        }
                    }
                }

            Console.WriteLine(""The number {0} was not found."", myNumber);
            goto Finish;

        Found:
            Console.WriteLine(""The number {0} is found."", myNumber);

        Finish:
            Console.WriteLine(""End of search."");


            Console.WriteLine(""Press any key to exit."");
            Console.ReadKey();
        }
    }");
        }

        [Test]
        public void ThrowStatement()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod(ByVal nullObject As Object)
        If nullObject Is Nothing Then Throw New ArgumentNullException(NameOf(nullObject))
    End Sub
End Class", @"
class TestClass
{
    void TestMethod(object nullObject)
    {
        if (nullObject == null)
            throw new ArgumentNullException(nameof(nullObject));
    }
}");
        }

        [Test]
        public void AddRemoveHandler()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Public Event MyEvent As EventHandler

    Private Sub TestMethod(ByVal e As EventHandler)
        AddHandler Me.MyEvent, e
        AddHandler Me.MyEvent, AddressOf MyHandler
    End Sub

    Private Sub TestMethod2(ByVal e As EventHandler)
        RemoveHandler Me.MyEvent, e
        RemoveHandler Me.MyEvent, AddressOf MyHandler
    End Sub

    Private Sub MyHandler(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
End Class", @"using System;

class TestClass
{
    public event EventHandler MyEvent;

    void TestMethod(EventHandler e)
    {
        this.MyEvent += e;
        this.MyEvent += MyHandler;
    }

    void TestMethod2(EventHandler e)
    {
        this.MyEvent -= e;
        this.MyEvent -= MyHandler;
    }

    void MyHandler(object sender, EventArgs e)
    {

    }
}");
        }

        [Test]
        public void SelectCase1()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Sub TestMethod(ByVal number As Integer)
        Select Case number
            Case 0, 1, 2
                Console.Write(""number is 0, 1, 2"")
            Case 3
                Console.Write(""section 3"")
                GoTo _Select0_Case5
            Case 4
                Console.Write(""section 4"")
                GoTo _Select0_CaseDefault
            Case 5
_Select0_Case5:
                Console.Write(""section 5"")
            Case Else
_Select0_CaseDefault:
                Console.Write(""default section"")
        End Select
    End Sub
End Class", @"
class TestClass
{
    void TestMethod(int number)
    {
        switch (number) {
            case 0:
            case 1:
            case 2:
                Console.Write(""number is 0, 1, 2"");
                break;
            case 3:
                Console.Write(""section 3"");
                goto case 5;
            case 4:
                Console.Write(""section 4"");
                goto default;
            case 5:
                Console.Write(""section 5"");
                break;
            default:
                Console.Write(""default section"");
                break;
        }
    }
}");
        }

        [Test]
        public void TryCatch()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Shared Function Log(ByVal message As String) As Boolean
        Console.WriteLine(message)
        Return False
    End Function

    Private Sub TestMethod(ByVal number As Integer)
        Try
            Console.WriteLine(""try"")
        Catch e As Exception
            Console.WriteLine(""catch1"")
        Catch
            Console.WriteLine(""catch all"")
        Finally
            Console.WriteLine(""finally"")
        End Try

        Try
            Console.WriteLine(""try"")
        Catch __unusedIOException1__ As System.IO.IOException
            Console.WriteLine(""catch1"")
        Catch e As Exception When Log(e.Message)
            Console.WriteLine(""catch2"")
        End Try

        Try
            Console.WriteLine(""try"")
        Finally
            Console.WriteLine(""finally"")
        End Try
    End Sub
End Class", @"
class TestClass
{
    static bool Log(string message)
    {
        Console.WriteLine(message);
        return false;
    }

    void TestMethod(int number)
    {
        try {
            Console.WriteLine(""try"");
        } catch (Exception e) {
            Console.WriteLine(""catch1"");
        } catch {
            Console.WriteLine(""catch all"");
        } finally {
            Console.WriteLine(""finally"");
        }
        try {
            Console.WriteLine(""try"");
        } catch (System.IO.IOException) {
            Console.WriteLine(""catch1"");
        } catch (Exception e) when (Log(e.Message)) {
            Console.WriteLine(""catch2"");
        }
        try {
            Console.WriteLine(""try"");
        } finally {
            Console.WriteLine(""finally"");
        }
    }
}");
        }

        [Test]
        public void Yield()
        {
            TestConversionVisualBasicToCSharp(@"Class TestClass
    Private Iterator Function TestMethod(ByVal number As Integer) As IEnumerable(Of Integer)
        If number < 0 Then Return

        For i As Integer = 0 To number - 1
            Yield i
        Next
    End Function
End Class", @"
class TestClass
{
    IEnumerable<int> TestMethod(int number)
    {
        if (number < 0)
            yield break;
        for (int i = 0; i < number; i++)
            yield return i;
    }
}");
        }
    }
}