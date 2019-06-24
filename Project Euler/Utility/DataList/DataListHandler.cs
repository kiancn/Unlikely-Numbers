using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project_Euler
{
    class DataListHandler<T> // will both fetch and write Lists of any object type T
    {
        private DataListObject<T> listObject;

        internal DataListObject<T> ListObject { get => listObject; set => listObject = value; }

        public DataListHandler(DataListObject<T> listObject)
        {
            this.ListObject = listObject;
        }

        public void SaveObject(string location)
        {
            if (ListObject.List == null)
            {
                Console.WriteLine("Aborted saving list object to file, because the list object is null.");
                return;
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(location, FileMode.OpenOrCreate);
            bf.Serialize(file, ListObject);
            Console.WriteLine("\nList has been saved to file in");
            Console.WriteLine("File saved to location: {0}", location);
            file.Close();
            //return list;
        }

        public DataListObject<T> LoadList(string location, bool verbose = false) // opens the file SaveGames.sgl and returns a list of SaveData
        {
            DataListObject<T> list = new DataListObject<T>();
            FileStream file = File.Open(location, FileMode.OpenOrCreate); // create a file(stream)
            BinaryFormatter bf = new BinaryFormatter(); // create binary formatter
            try
            {
                list = (DataListObject<T>)bf.Deserialize(file);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                file.Close(); // close the file-stream
                #region User message on how to fix missing file.
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("|| An error locating file containing a useful list of factorials occured.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("|| You can still use the program, ");
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("but very large calculations will take a very long time. Not kidding. Hours. Days.\n" +
                    "|| Quit program manually if you get bored.\n" +
                    "||\n||| To solve this problem,\n");
                Console.Write("|| \t 1) Find the file");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("  FactorialsList.fl  ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("in the original downloaded zip-file.\n");
                Console.Write("|| \t 2) Copy this file to");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\t C:\\UnlikelyNumbers\\ \t");
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.Write(",` ");
                //Console.ForegroundColor = ConsoleColor.DarkRed;
                //Console.Write(">}");
                //Console.ForegroundColor = ConsoleColor.DarkGreen;
                //Console.Write("-----");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n|| \t 2.1) Create the folder if it doesn't exist.");
                Console.ResetColor();
                #endregion
                return list;
            }
            file.Close(); // close the file-stream          
            if (verbose == true)
            {
                Console.WriteLine("List has been loaded from file and is now in memory.\nPress enter. ");
                Console.ReadLine();
            }


            return list;
        }


        void PrintList(/*List<T> list*/) // why did I write this almost exactly the same twice ? - PrintList is in DataListObject As Well...
        {
            Console.WriteLine("||\n|| {0} ", ListObject.CollectionName);
            Console.WriteLine("||\n|| '{0}'\n|| ", ListObject.CollectionNotes);

            for (int i = 0; i < ListObject.List.Count; i++)
            //for (int i = 0; i < list.Count; i++)
            {
                Console.Write("||\n|| {0} : {1} :\n|| {2}", ListObject.TypeOfThing, i, ListObject.List[i]);
            }
        }
    }
}
