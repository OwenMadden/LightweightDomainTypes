using System;
using Examples;
using Microsoft.FSharp.Core;
using NUnit.Framework;

namespace TestsAndExamples;

public class Tests
{
    [Test]
    public void Create_GivenUtcTime_Succeeds()
    {
        var now = DateTime.UtcNow;
        Assert.That(UtcTimeModule.DateTime(UtcTimeModule.Create(now)), Is.EqualTo(now));
    }
        
    [Test]
    public void Create_GivenNonUtcTime_ThrowsException()
        => Assert.Throws<Exception>(() => UtcTimeModule.Create(DateTime.Now));
        
    [Test]
    public void TryCreate_GivenUtcTime_Succeeds()
    {
        var now = DateTime.UtcNow;
        Assert.That(UtcTimeModule.DateTime(UtcTimeModule.TryCreate(now).Value), Is.EqualTo(now));
    }
        
    [Test]
    public void TryCreate_GivenNonUtcTime_ReturnsNone()
        => Assert.That(() => UtcTimeModule.TryCreate(DateTime.Now), Is.EqualTo(FSharpOption<UtcTime>.None));

}