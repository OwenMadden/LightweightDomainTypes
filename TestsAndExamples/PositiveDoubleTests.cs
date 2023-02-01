using System;
using Examples;
using Microsoft.FSharp.Core;
using NUnit.Framework;

namespace TestsAndExamples;

public class PositiveDoubleTests
{
    [Test]
    public void Create_GivenPositiveDouble_Succeeds()
    {
        var smallPositive = Double.Epsilon;
        Assert.That(PositiveDoubleModule.Unwrap(PositiveDoubleModule.Create(smallPositive)), Is.EqualTo(smallPositive));
    }

    [Test]
    public void Create_GivenNonPositiveDouble_ThrowsException()
    {   
        //Neither of these compile 
        //new PositiveDouble(0);
        //PositiveDouble.NewPositiveDouble(0);
        
        //Forced to call create.
        Assert.Throws<Exception>(() => PositiveDoubleModule.Create(0));
    }

    [Test]
    public void Comparison_Examples()
    {
        var one = PositiveDoubleModule.Create(1.0);
        var anotherOne = PositiveDoubleModule.Create(1.0);
        var two = PositiveDoubleModule.Create(2.0);
        //Assert.That(one == anotherOne);
        Assert.That(one.Equals(anotherOne));
        //Assert.That(one < two);
    }

    private double DivisionExample(double dividend, PositiveDouble divisor)
        => dividend / PositiveDoubleModule.Unwrap(divisor);
}