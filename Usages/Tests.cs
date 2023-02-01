using System;
using NUnit.Framework;

namespace Usages
{
    [TestFixture]
    public class Tests
    {
        [TestFixture]
        public class UtcTimeTests
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
}