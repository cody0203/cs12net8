using Packt.Shared;

public class StoringDataInMemory {
    // Heap and Stack in brief:
    // Stack is faster to work with but limited in size. Stack uses a LI, FO mechanism.
    // Heap memory is slower but much more plentiful.

    // Reference type and value type in brief:
    // Reference type is stored on the heap except for its memory address on the stack. 
    // Value type is stored on the stack.
    // If a value type is used for a field of a reference type, then that part is stored on the heap.
    // If a value type has a field that is a reference type, then that part of the value type is stored on the heap.

    void SomeMethod()
    // When the method completes, all the stack memory is automatically released form the top of the stack.
    // Howevery, heap memory could still be allocated after a methid returns.
    // The garbage collector will do it at a future date. Heap memory is not immediately released to improve performance.
    {

        int number1 = 49; // a value type (aka struct) -> is allocated on the stack, uses 4 bytes of memory (32-bit integer). Its value, 49, is stored directly in the variable.
        long number2 = 12; // also a value type -> is also allocated on the stack, uses 8 bytes of memory (64-bit integer).
        System.Drawing.Point location = new(x: 4, y: 7); // also a value type, is allocated on the stack, uses 8 bytes of memory (made up from two 32-bit integer).

        Person kevin = new() { Name = "Kevin", Born = new(year: 1998, month: 1, day: 1, hour: 0, minute: 0, second: 0, offset: TimeSpan.Zero) }; // a reference type (aka class)
        // 8 bytes for a 64-bit memory address (assuming a 64-bit os) are allocated on the stack, and enough bytes are allocated on the heap to store an instance of a Person.

        Person kelly; // also a reference type, 8 bytes of 64-bit memory addresses are allocated on the stack.
        // is currently unassigned (null), meaning no memory has yet been allocated for it on heap.
        // If we assign keven to kelly, then the memory address of the Person on the heap would be copied into kelly.
        kelly = kevin; // Both variables point at the same Person on heap.
    }
}