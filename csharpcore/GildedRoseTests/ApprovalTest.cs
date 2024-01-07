using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace GildedRoseTests;

[UseReporter(typeof(DiffReporter))]
public class ApprovalTest
{
    [Test]
    public void ThirtyDays()
    {
        var fakeOutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeOutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        TextTestFixture.Main(["30"]);
        var output = fakeOutput.ToString();

        Approvals.Verify(output);
    }
}