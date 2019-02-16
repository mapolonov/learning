using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumerableUsage
{
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

  public class PeopleCollection : IEnumerable
  {
    private List<Person> persons;

    public PeopleCollection(List<Person> pArray)
    {
        persons = pArray;

       /* for (int i = 0; i < pArray.Count; i++)
        {
          persons[i] = pArray[i+1];
        }*/
    }

    #region IEnumerable Members

    public IEnumerator GetEnumerator()
    {
      //return persons.GetEnumerator();
      return new PeopleEnum(persons);
    }

    #endregion
  }

  public class PeopleEnum : IEnumerator
  {
    public List<Person> _people;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public PeopleEnum(List<Person> list)
    {
      _people = list;
    }

    public bool MoveNext()
    {
      position++;
      return (position < _people.Count);
    }

    public void Reset()
    {
      position = -1;
    }

    public object Current
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





  class Program
  {
    static void Main(string[] args)
    {

      List<Person> peopleArray = new List<Person>
        {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
        };

      PeopleCollection peopleList = new PeopleCollection(peopleArray);

      IEnumerator en = peopleList.GetEnumerator();

      while(en.MoveNext())
      Console.WriteLine((en.Current as Person).lastName);

      foreach (Person p in peopleList)
        Console.WriteLine(p.firstName + " " + p.lastName);

      Console.WriteLine(peopleArray[0]);


    }
  }
}
