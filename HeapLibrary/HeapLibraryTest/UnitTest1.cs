using NUnit.Framework;
using HeapLibrary;

namespace HeapLibraryTest {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void TestConstructor() {
            Heap<int> heap = new Heap<int>();

            Assert.IsNotNull(heap);
        }

        [Test]
        public void TestAdd1() {
            Heap<int> heap = new Heap<int>();

            heap.Add(10, 1);

            Assert.AreEqual(true, heap.Contains(1));
        }

        [Test]
        public void TestAdd2() {
            Heap<int> heap = new Heap<int>();

            heap.Add(10, 1);
            heap.Add(12, 1);

            Assert.AreEqual(true, heap.Contains(1));
        }

        [Test]
        public void TestAdd3() {
            Heap<int> heap = new Heap<int>();

            heap.Add(3, 3);
            heap.Add(2, 2);
            heap.Add(1, 1);

            Assert.AreEqual(true, heap.Contains(1));
            Assert.AreEqual(true, heap.Contains(2));
            Assert.AreEqual(true, heap.Contains(3));
        }

        [Test]
        public void TestTop1() {
            Heap<int> heap = new Heap<int>();

            heap.Add(3, 3);
            heap.Add(2, 2);
            heap.Add(1, 1);

            Assert.AreEqual(1, heap.Top());
        }

        [Test]
        public void TestTop2() {
            Heap<int> heap = new Heap<int>();

            heap.Add(1, 1);
            heap.Add(2, 2);
            heap.Add(3, 3);
            
            Assert.AreEqual(1, heap.Top());
        }

        [Test]
        public void TestTop3() {
            Heap<int> heap = new Heap<int>();

            Assert.AreEqual(0, heap.Top());
        }

        [Test]
        public void TestPop1() {
            Heap<int> heap = new Heap<int>();

            heap.Add(1, 1);
            heap.Add(2, 2);
            heap.Add(3, 3);
            heap.Add(4, 4);
            heap.Add(5, 5);
            heap.Add(6, 6);
            heap.Add(7, 7);

            Assert.AreEqual(1, heap.Pop());
        }

        [Test]
        public void TestPop2() {
            Heap<int> heap = new Heap<int>();

            heap.Add(1, 1);
            heap.Add(2, 2);
            heap.Add(3, 3);
            heap.Add(4, 4);
            heap.Add(5, 5);
            heap.Add(6, 6);
            heap.Add(7, 7);
            heap.Pop();
            heap.Pop();

            Assert.AreEqual(3, heap.Pop());
        }

        [Test]
        public void TestPop3() {
            Heap<int> heap = new Heap<int>();

            heap.Add(1, 1);
            heap.Add(2, 2);
            heap.Add(3, 3);
            heap.Add(4, 4);
            heap.Add(5, 5);
            heap.Add(6, 6);
            heap.Add(7, 7);
            Assert.AreEqual(1, heap.Pop());
            Assert.AreEqual(2, heap.Pop());
            Assert.AreEqual(3, heap.Pop());
            Assert.AreEqual(4, heap.Pop());
            Assert.AreEqual(5, heap.Pop());
            Assert.AreEqual(6, heap.Pop());
            Assert.AreEqual(7, heap.Pop());
        }

        [Test]
        public void TestPop4() {
            Heap<int> heap = new Heap<int>();

            Assert.AreEqual(0, heap.Pop());
        }

        [Test]
        public void TestPop5() {
            Heap<int> heap = new Heap<int>();

            heap.Add(1, 1);
            heap.Add(2, 2);
            heap.Add(2, 3);
            heap.Add(2, 4);
            heap.Add(2, 5);
            Assert.AreEqual(1, heap.Pop());
        }

        [Test]
        public void TestPop6() {
            Heap<int> heap = new Heap<int>();

            heap.Add(5, 5);
            heap.Add(2, 2);
            heap.Add(7, 7);
            heap.Add(15, 15);
            heap.Add(25, 25);
            heap.Add(10, 10);
            heap.Add(3, 3);
            heap.Add(9, 9);
            heap.Add(11, 11);
            Assert.AreEqual(2, heap.Pop());
            Assert.AreEqual(3, heap.Pop());
            Assert.AreEqual(5, heap.Pop());
            Assert.AreEqual(7, heap.Pop());
            Assert.AreEqual(9, heap.Pop());
            Assert.AreEqual(10, heap.Pop());
            Assert.AreEqual(11, heap.Pop());
            Assert.AreEqual(15, heap.Pop());
            Assert.AreEqual(25, heap.Pop());
        }

        [Test]
        public void TestChangeCost1() {
            Heap<int[]> heap = new Heap<int[]>();
            int[] array1 = new int[2];
            int[] array2 = new int[2];

            heap.Add(5, array1);
            heap.Add(10, array2);

            heap.ChangeCost(5, array1);

            Assert.AreEqual(array1, heap.Top());
        }

        [Test]
        public void TestChangeCost2() {
            Heap<int[]> heap = new Heap<int[]>();
            int[] array1 = new int[2];
            int[] array2 = new int[2];

            heap.Add(5, array1);
            heap.Add(10, array2);

            heap.ChangeCost(3, array1);

            Assert.AreEqual(array1, heap.Top());
        }

        [Test]
        public void TestChangeCost3() {
            Heap<int[]> heap = new Heap<int[]>();
            int[] array1 = new int[2];
            int[] array2 = new int[2];

            heap.Add(5, array1);
            heap.Add(10, array2);

            heap.ChangeCost(15, array1);

            Assert.AreEqual(array2, heap.Top());
        }
    }
}