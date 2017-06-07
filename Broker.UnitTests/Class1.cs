using Microsoft.Practices.Unity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.UnitTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Container_ResolveAll_Handles_Type_Never_Registered()
        {
            var container = new UnityContainer();
            var registrations = container.ResolveAll(typeof(IDisposable));
            CollectionAssert.IsEmpty(registrations);
        }
        [Test]
        public void Container_Resolve_Throws_With_Type_Never_Registered()
        {
            var container = new UnityContainer();
            Assert.Throws<ResolutionFailedException>(() => container.Resolve(typeof(IDisposable)));
        }
    }
}
