using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VerifyNUnit;

namespace GildedRoseTests;

[TestFixture]
public class ApprovalTest
{
    [Test]
    public Task ThirtyDays()
    {
        var fakeOutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeOutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        TextTestFixture.Main(["30"]);
        var output = fakeOutput.ToString();

        return Verifier.Verify(output);
    }
}