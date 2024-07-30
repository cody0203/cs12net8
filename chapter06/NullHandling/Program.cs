int thisCannotBeNull = 4;
// thisCannotBeNull = null; // Compiler error

int? thisCouldBeNull = null;

WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault()); // 0

thisCouldBeNull = 7;

WriteLine(thisCouldBeNull); // 7
WriteLine(thisCouldBeNull.GetValueOrDefault()); // 7


// The actual type of int? is Nullable<int>.
Nullable<int> thisCouldAlsoBeNull = null;
thisCouldAlsoBeNull = 9;
WriteLine(thisCouldAlsoBeNull);