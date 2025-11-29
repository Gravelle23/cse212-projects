using System.Collections;
using System.Collections.Generic;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Make a new node that holds the value.
        Node newNode = new Node(value);

        // If the list is empty, head and tail both become this node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // Otherwise, plug it in before the current head.
        else
        {
            // new node points forward to old head
            newNode.Next = _head;   
            // old head points back to new node
            _head.Prev = newNode;   
            // update head
            _head = newNode;        
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new Node(value);

        // If the list is empty, this node is both head and tail.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // Otherwise, attach it after the current tail.
        else
        {
            // old tail points forward to new node
            _tail.Next = newNode;   
            // new node points back to old tail
            newNode.Prev = _tail;   
            // update tail
            _tail = newNode;        
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item (or is empty),
        // set head and tail to null.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item,
        // move head forward one step.
        else if (_head is not null)
        {
            // new head no longer has a previous
            _head.Next!.Prev = null; 
            // advance head
            _head = _head.Next;      
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // If the list has zero or one item, same logic as RemoveHead.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // More than one item: move tail backward one step.
        else if (_tail is not null)
        {
            // new tail no longer has a next node
            _tail.Prev!.Next = null; 
            // move tail back
            _tail = _tail.Prev;   
            // move tail back
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call InsertTail to add 'newValue'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    // Connect new node to the node containing 'value'
                    newNode.Prev = curr;        
                    // Connect new node to the node after 'value'
                    newNode.Next = curr.Next;  
                    // Connect node after 'value' to the new node
                    curr.Next!.Prev = newNode;  
                    // Connect the node containing 'value' to the new node
                    curr.Next = newNode;        
                    
                }
                // We can exit the function after we insert
                return; 
            }
            // Go to the next node to search for 'value'
            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If it's the head, reuse RemoveHead.
                if (curr == _head)
                {
                    RemoveHead();
                }
                // If it's the tail, reuse RemoveTail.
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // Otherwise, it's in the middle: bypass it.
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }

                // Only remove the FIRST match, then stop.
                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }

            // Keep going – must replace *all* matches.
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        // Start at the beginning since this is a forward iteration.
        var curr = _head; 
        while (curr is not null)
        {
            // Provide (yield) each item to the user
            yield return curr.Data; 
            // Go forward in the linked list
            curr = curr.Next;       
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // Start from the tail and walk backwards.
        var curr = _tail;

        while (curr is not null)
        {
            // Give back each value
            yield return curr.Data; 
            // Move backward
            curr = curr.Prev;       
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
