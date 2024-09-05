namespace ProgramTest;
using miLibreriaDeClases;

[TestClass]
public class UnitTest1
{
    [TestClass]
    public class ListaDobleEnlazadaTests
    {
        [TestMethod]
        public void TestInsertInOrder()
        {
            var lista = new ListaDobleEnlazada();
            lista.InsertInOrder(3);
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);

            Assert.AreEqual(1, lista.DeleteFirst());
            Assert.AreEqual(2, lista.DeleteFirst());
            Assert.AreEqual(3, lista.DeleteFirst());
        }

        [TestMethod]
        public void TestDeleteFirst()
        {
            var lista = new ListaDobleEnlazada();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);

            Assert.AreEqual(1, lista.DeleteFirst());
            Assert.AreEqual(2, lista.DeleteFirst());

            Assert.ThrowsException<InvalidOperationException>(() => lista.DeleteFirst());
        }

        [TestMethod]
        public void TestDeleteLast()
        {
            var lista = new ListaDobleEnlazada();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);

            Assert.AreEqual(2, lista.DeleteLast());
            Assert.AreEqual(1, lista.DeleteLast());

            Assert.ThrowsException<InvalidOperationException>(() => lista.DeleteLast());
        }

        [TestMethod]
        public void TestDeleteValue()
        {
            var lista = new ListaDobleEnlazada();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            Assert.IsTrue(lista.DeleteValue(2));
            Assert.IsFalse(lista.DeleteValue(4));

            Assert.AreEqual(1, lista.DeleteFirst());
            Assert.AreEqual(3, lista.DeleteFirst());
        }

        [TestMethod]
        public void TestGetMiddle()
        {
            var lista = new ListaDobleEnlazada();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            Assert.AreEqual(2, lista.GetMiddle());

            lista.InsertInOrder(4);
            Assert.AreEqual(2, lista.GetMiddle());
        }

        [TestMethod]
        public void TestMergeSorted()
        {
            var listA = new ListaDobleEnlazada();
            listA.InsertInOrder(1);
            listA.InsertInOrder(3);
            listA.InsertInOrder(5);

            var listB = new ListaDobleEnlazada();
            listB.InsertInOrder(2);
            listB.InsertInOrder(4);
            listB.InsertInOrder(6);

            listA.MergeSorted(listA, listB, SortDirection.Ascendente);

            Assert.AreEqual(1, listA.DeleteFirst());
            Assert.AreEqual(2, listA.DeleteFirst());
            Assert.AreEqual(3, listA.DeleteFirst());
            Assert.AreEqual(4, listA.DeleteFirst());
            Assert.AreEqual(5, listA.DeleteFirst());
            Assert.AreEqual(6, listA.DeleteFirst());
        }

        [TestMethod]
        public void TestInvertirLista()
        {
            var lista = new ListaDobleEnlazada();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            lista.InvertirLista();

            Assert.AreEqual(3, lista.DeleteFirst());
            Assert.AreEqual(2, lista.DeleteFirst());
            Assert.AreEqual(1, lista.DeleteFirst());
        }
    }
}