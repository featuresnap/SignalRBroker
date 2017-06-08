using Broker.App_Start;
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
    public class UnityDependencyResolverTests
    {
        [Test]
        public void GetService_Returns_Default_Instance_Registered_With_Container()
        {
            var container = new UnityContainer();
            var a = new object();
            var b = new object();
            container.RegisterInstance(a);
            container.RegisterInstance("named", b);
            var resolver = new UnityDependencyResolver(container);
            var result = resolver.GetService(typeof(object));
            Assert.AreSame(a, result);
        }

        [Test]
        public void GetServices_Returns_All_Instances_Registered_With_Container()
        {
            var container = new UnityContainer();
            var a = new object();
            var b = new object();
            container.RegisterInstance(a);
            container.RegisterInstance("named", b);
            var resolver = new UnityDependencyResolver(container);
            var result = resolver.GetServices(typeof(object));
            CollectionAssert.Contains(result, a);
            CollectionAssert.Contains(result, b);

        }
    }
}
