using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acidic.DomainDrivenDesign.UnitTests.Performance
{
    [TestClass]
    public class ValuePerformanceTests
    {
        [TestMethod]
        public void GetHashCode_Performance_PropertyArrayBasedValue()
        {
            var value = new PropertyArrayBasedValue();

            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            var hashcode1 = value.GetHashCode();
            stopwatch.Stop();
            Trace.WriteLine($"Property array based value ticks 1: {stopwatch.ElapsedTicks}");
            stopwatch.Restart();
            var hashcode2 = value.GetHashCode();
            stopwatch.Stop();
            Trace.WriteLine($"Property array based value ticks 2: {stopwatch.ElapsedTicks}");
            stopwatch.Restart();
            var hashcode3 = value.GetHashCode();
            stopwatch.Stop();
            Trace.WriteLine($"Property array based value ticks 3: {stopwatch.ElapsedTicks}");
        }
        
        [TestMethod]
        public void GetHashCode_Performance_LazyPropertyArrayBasedValue()
        {
            var value = new LazyPropertyArrayBasedValue();

            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            var hashcode1 = value.GetHashCode();
            stopwatch.Stop();
            Trace.WriteLine($"Lazy property array based value ticks 1: {stopwatch.ElapsedTicks}");
            stopwatch.Restart();
            var hashcode2 = value.GetHashCode();
            stopwatch.Stop();
            Trace.WriteLine($"Lazy property array based value ticks 2: {stopwatch.ElapsedTicks}");
            stopwatch.Restart();
            var hashcode3 = value.GetHashCode();
            stopwatch.Stop();
            Trace.WriteLine($"Lazy property array based value ticks 3: {stopwatch.ElapsedTicks}");
        }

        [TestMethod]
        public void GetHashCode_Performance_ReflectionBasedValue()
        {
            var value = new ReflectionBasedValue();

            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            var hashcode1 = value.GetHashCode();
            stopwatch.Stop();
            Trace.WriteLine($"Reflection based value ticks 1: {stopwatch.ElapsedTicks}");
            stopwatch.Restart();
            var hashcode2 = value.GetHashCode();
            stopwatch.Stop();
            Trace.WriteLine($"Reflection based value ticks 2: {stopwatch.ElapsedTicks}");
            stopwatch.Restart();
            var hashcode3 = value.GetHashCode();
            stopwatch.Stop();
            Trace.WriteLine($"Reflection based value ticks 3: {stopwatch.ElapsedTicks}");
        }
    }
}