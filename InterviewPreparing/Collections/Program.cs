using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections2
{
  internal class MyCollection : ICollection
  {

    #region ICollection Members

    public void CopyTo(Array array, int index)
    {
      throw new NotImplementedException();
    }

    public int Count
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public bool IsSynchronized
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public object SyncRoot
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    #endregion

    #region IEnumerable Members

    public IEnumerator GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion
  }

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

  internal class People : IEnumerable
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

    public IEnumerator GetEnumerator()
    {
        return new PeopleEnum(_people);
    }
  }

  public class PeopleEnum : IEnumerator
  {
    public Person[] _people;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
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
      //Person[] peopleArray = new Person[3]
      //  {
      //      new Person("John", "Smith"),
      //      new Person("Jim", "Johnson"),
      //      new Person("Sue", "Rabon"),
      //  };

      //People peopleList = new People(peopleArray);
      //foreach (Person p in peopleList)
      //  Console.WriteLine(p.firstName + " " + p.lastName);
        var list = new LinkedList<int>();
        var n1 = list.AddFirst(10);
        list.AddFirst(4);
        var n2 = list.AddLast(15);
        list.AddAfter(n1, 12);
        list.AddBefore(n2, 14);
        

        var list2 = new List<int>();
        var i = list2[1];

    }
  }
}
