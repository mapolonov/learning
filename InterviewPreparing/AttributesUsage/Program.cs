﻿using System;
using System.IO;

namespace AttributesUsage
{

    [System.AttributeUsage(AttributeTargets.Class |AttributeTargets.Struct)]
    public class AuthorAttribute : Attribute
    {
        private string name;
        public double version;

        public AuthorAttribute(string name)
        {
            this.name = name;
            version = 1.0;
        }
    }


    [Author("Michail Apolonov", version = 2.0 )]
    class MyClass
    {
        public MyClass()
        {
        }

        public MyClass(int x)
        {

        }

        //[method: SomeAttr]
        public void MyMethod()
        {
            string s = "my method string";
            int innerY = 22;
        }
    }

    class Program
    {

      private static void GetHeaders()
      {
        uint peHeader;
        uint peHeaderSignature;
        ushort machine;
        ushort sections;
        uint timestamp;
        uint pSymbolTable;
        uint noOfSymbol;
        ushort optionalHeaderSize;
        ushort characteristics;
        ushort dataDictionaryStart;
        uint[] dataDictionaryRVA = new uint[16];
        uint[] dataDictionarySize = new uint[16];


        Stream fs = new FileStream(@"AttributesUsage.exe", FileMode.Open,
    FileAccess.Read);
        BinaryReader reader = new BinaryReader(fs);

        //PE Header starts @ 0x3C (60). Its a 4 byte header.
        fs.Position = 0x3C;

        peHeader = reader.ReadUInt32();

        //Moving to PE Header start location...
        fs.Position = peHeader;
        peHeaderSignature = reader.ReadUInt32();
        
        //We can also show all these value, but we will be       
        //limiting to the CLI header test.

        machine = reader.ReadUInt16();
        
        sections = reader.ReadUInt16();
        timestamp = reader.ReadUInt32();
        pSymbolTable = reader.ReadUInt32();
        noOfSymbol = reader.ReadUInt32();
        optionalHeaderSize = reader.ReadUInt16();
        characteristics = reader.ReadUInt16();

        /*
Now we are at the end of the PE Header and from here, the
          PE Optional Headers starts...
    To go directly to the datadictionary, we'll increase the      
    stream’s current position to with 96 (0x60). 96 because,
          28 for Standard fields
          68 for NT-specific fields
From here DataDictionary starts...and its of total 128 bytes. DataDictionay has 16 directories in total,
doing simple maths 128/16 = 8.
So each directory is of 8 bytes.
          In this 8 bytes, 4 bytes is of RVA and 4 bytes of Size.
           
btw, the 15th directory consist of CLR header! if its 0, its not a CLR file :)
          */
        dataDictionaryStart = Convert.ToUInt16(Convert.ToUInt16
        (fs.Position) + 0x60);
        fs.Position = dataDictionaryStart;
        for (int i = 0; i < 15; i++)
        {
          dataDictionaryRVA[i] = reader.ReadUInt32();
          dataDictionarySize[i] = reader.ReadUInt32();
        }
        if (dataDictionaryRVA[14] == 0)
        {
          Console.WriteLine("This is NOT a valid CLR File!!");
        }
        else
        {
          Console.WriteLine("This is a valid CLR File..");
        }
        fs.Close();
      }


        //attribute usage example
        /*
          public static String Format(Type enumType, Object value, String format) {
            // Does the enumerated type have an instance of
            // the FlagsAttribute type applied to it?
  
  !!!!!!!!  if (enumType.IsDefined(typeof(FlagsAttribute), false)) {
            // Yes; execute code treating value as a bit flag enumerated type.
            ...
            } else {
            // No; execute code treating value as a normal enumerated type.
            ...
            }
            ...
            }
         */


        static void Main(string[] args)
        {
            MyClass mc = new MyClass();

            bool def = typeof(MyClass).IsDefined(typeof(AuthorAttribute), false);
            Console.WriteLine(def);

          GetHeaders();

        }
    }
}
