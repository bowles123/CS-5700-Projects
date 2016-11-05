using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.CommandPattern;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class InvokerTests
    {
        private CommandFactory factory = new CommandFactory();

        [TestMethod]
        public void NotNullCommandInvokingTest()
        {
            Invoker.getUniqueInstance().Start();
            Invoker.getUniqueInstance().Enqueue(factory.Create("new"));
            Invoker.getUniqueInstance().Enqueue(factory.Create("add", "Shark"));
            Invoker.getUniqueInstance().Enqueue(factory.Create("add", "Dolphin"));
            Thread.Sleep(100);

            Assert.AreEqual(3, Invoker.getUniqueInstance().History.Count);
            Assert.AreEqual("ADD", Invoker.getUniqueInstance().History.Peek().ActualCommand);
            Invoker.getUniqueInstance().Undo();
            Assert.AreEqual(2, Invoker.getUniqueInstance().History.Count);
            Assert.AreEqual("ADD", Invoker.getUniqueInstance().History.Peek().ActualCommand);
            Invoker.getUniqueInstance().Undo();
            Assert.AreEqual(1, Invoker.getUniqueInstance().History.Count);
            Assert.AreEqual("NEW", Invoker.getUniqueInstance().History.Peek().ActualCommand);
            Invoker.getUniqueInstance().Undo();
            Assert.AreEqual(0, Invoker.getUniqueInstance().History.Count);
            Invoker.getUniqueInstance().Stop();
        }

        [TestMethod]
        public void NullCommandInvokingTest()
        {
            Invoker.getUniqueInstance().Start();
            Invoker.getUniqueInstance().Enqueue(null);
            Invoker.getUniqueInstance().Enqueue(null);
            Assert.AreEqual(0, Invoker.getUniqueInstance().History.Count);
            Invoker.getUniqueInstance().Stop();
        }
    }
}
