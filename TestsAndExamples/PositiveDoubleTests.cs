using System;
using System.Collections.Generic;
using System.Linq;
using Examples;
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
        //Assert.That(one == anotherOne); //Raises warning or error when [Struct]
        Assert.That(one.Equals(anotherOne));
        var sorted = (new[] {two, one, anotherOne}).OrderBy(i => i);
        
        CollectionAssert.AreEqual(new []{one, anotherOne, two }, sorted);
        Assert.That(Comparer<PositiveDouble>.Default.Compare(one, two), Is.EqualTo(-1));
        Assert.That(Comparer<PositiveDouble>.Default.Compare(two, one), Is.EqualTo(+1));
        Assert.That(Comparer<PositiveDouble>.Default.Compare(one, one), Is.Zero);
    }

    private double DivisionExample(double dividend, PositiveDouble divisor)
        => dividend / PositiveDoubleModule.Unwrap(divisor);

    [Test]
    public void CSharpRecordComparison_Examples()
    {
        var one = new PositiveDoubleAsRecord(1.0);
        var anotherOne = new PositiveDoubleAsRecord(1.0);
        var two = new PositiveDoubleAsRecord(2.0);
        Assert.That(one == anotherOne); //Both equalities pass
        Assert.That(one.Equals(anotherOne));
        
        var sorted = (new[] {two, one, anotherOne}).OrderBy(i => i);
        
        //CollectionAssert.AreEqual(new []{one, anotherOne, two }, sorted); //Does not sort so this will fail.
        //Assert.That(Comparer<PositiveDoubleAsRecord>.Default.Compare(one, two), Is.EqualTo(-1));
        //Assert.That(Comparer<PositiveDoubleAsRecord>.Default.Compare(two, one), Is.EqualTo(+1));
        //Assert.That(Comparer<PositiveDoubleAsRecord>.Default.Compare(one, one), Is.Zero);
    }
    
    [Test]
    public void CSharpClassComparison_Examples()
    {
        var one = new PositiveDoubleAsClass(1.0);
        var anotherOne = new PositiveDoubleAsClass(1.0);
        var two = new PositiveDoubleAsClass(2.0);
        //Assert.That(one == anotherOne); //Both equalities fail with no warning
        //Assert.That(one.Equals(anotherOne));
        
        var sorted = (new[] {two, one, anotherOne}).OrderBy(i => i);
        
        //CollectionAssert.AreEqual(new []{one, anotherOne, two }, sorted); //Does not sort so this will fail.
        //Assert.That(Comparer<PositiveDoubleAsClass>.Default.Compare(one, two), Is.EqualTo(-1));
        //Assert.That(Comparer<PositiveDoubleAsClass>.Default.Compare(two, one), Is.EqualTo(+1));
        //Assert.That(Comparer<PositiveDoubleAsClass>.Default.Compare(one, one), Is.Zero);
    }
}