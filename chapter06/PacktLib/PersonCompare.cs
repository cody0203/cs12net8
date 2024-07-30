namespace Packt.Shared;

public class PersonCompare : IComparer<Person?>
{
    public int Compare(Person? x, Person? y)
    {
        int position;

        if ((x is not null) && (y is not null))
        {
            if ((x.Name is not null) && (y.Name is not null))
            {
                int result = x.Name.Length.CompareTo(y.Name.Length);
                if (result == 0)
                {
                    return x.Name.CompareTo(y.Name);
                }
                else
                {
                    position = result;
                }
            }
            else if ((x.Name is not null) && (y.Name is null))
            {
                position = -1;
            }
            else if ((x.Name is null) && (y.Name is not null))
            {
                position = 1;
            }
            else
            {
                position = 0;
            }
        }
        else if ((x is not null) && (y is null))
        {
            position = -1;
        }
        else if ((x is null) && (y is not null))
        {
            position = 1;
        }
        else
        {
            position = 0;
        }

        return position;
    }
}