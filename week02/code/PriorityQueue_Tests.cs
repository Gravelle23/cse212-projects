using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue a single item and then Dequeue it.
    // Expected Result: Return item A. Queue becomes empty.
    // Defect(s) Found: 
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities.
    // Expected Result: Dequeue should return B first because it has the highest priority.
    // Defect(s) Found: 
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Enqueue multiple items with same priorities.   
    // Expected Result: Dequeue should return items in the order they were added for same priority.(FIFO)
    // Defect(s) Found: 
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);

        var result1 = priorityQueue.Dequeue();
        var result2 = priorityQueue.Dequeue();
        var result3 = priorityQueue.Dequeue();

        Assert.AreEqual("A", result1);
        Assert.AreEqual("B", result2);
        Assert.AreEqual("C", result3);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found:
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException)
        {
            Assert.AreEqual("the queue is empty", "the queue is empty");
        }
    }

    [TestMethod]
    // Scenario: Enqueue A (1), B (5), Dequeue, B (5), then enqueue C (10), Dequeue C (10), Dequeue A (1)
    // Expected Result: Dequeue should return items based on priority and order of addition.
    // Defect(s) Found:
    public void TestPriorityQueue_EnqueueAfterDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);

        Assert.AreEqual("B", priorityQueue.Dequeue());

        priorityQueue.Enqueue("C", 10);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

}