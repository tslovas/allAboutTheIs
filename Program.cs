using System;
using System.Collections;
class App
{
    // This is where it all begins. We read the peopleArray
    // then call public class Person (line 22) to fill the
    // people array.
    static void Main()
    {
        Person[] peopleArray = new Person[3]
        {
            new Person("The", "Dude"),
            new Person("Walter", "Sobchak"),
            new Person("Donny", "Kerabatsos"),
        };

        People peopleList = new People(peopleArray);
        foreach (Person p in peopleList)
            Console.WriteLine(p.firstName + " " + p.lastName);

    }
}
// This class defines the person, and gives them their attributes
public class Person
{
    public Person(string fName, string lName)
    {
        this.firstName = fName;
        this.lastName = lName;
    }

    public string firstName;
    public string lastName;
}
// This sub is a collection of all the person objects.
// We place each Person into _people
public class People : IEnumerable
{
    private Person[] _people;
    public People(Person[] pArray)
    {
        _people = new Person[pArray.Length];

        for (int i = 0; i < pArray.Length; i++)
        {
            _people[i] = pArray[i];
        }
    }
    // Implement the GetEnumerator method
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
    // Return a person with PeopleEnum
    public PeopleEnum GetEnumerator()
    {
        return new PeopleEnum(_people);
    }
}
// When you implement IEnumerable, you must also implement IEnumerator.
// Remember that enumerators are placed before the first element
public class PeopleEnum : IEnumerator
{
    public Person[] _people;

    int position = -1;

    public PeopleEnum(Person[] list)
    {
        _people = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _people.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Person Current
    {
        get
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}