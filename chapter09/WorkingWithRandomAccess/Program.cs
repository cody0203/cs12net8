﻿using Microsoft.Win32.SafeHandles;
using System.Text;

using SafeFileHandle handle = File.OpenHandle(path: "coffee.txt", mode: FileMode.OpenOrCreate, access: FileAccess.ReadWrite);

// Write some code encoded as byte array, and then store it in a read-only memory buffer to the file.
string message = "Café £4.39";
ReadOnlyMemory<byte> buffer = new(Encoding.UTF8.GetBytes(message));
await RandomAccess.WriteAsync(handle, buffer, fileOffset: 0);

// To read from the file, get the length of the file, allocate a memory buffer for the contents using that length, and then read the file.
long length = RandomAccess.GetLength(handle);
Memory<byte> contentBytes = new(new byte[length]);
await RandomAccess.ReadAsync(handle, contentBytes, fileOffset: 0);
string content = Encoding.UTF8.GetString(contentBytes.ToArray());
WriteLine($"Content of file: {content}");