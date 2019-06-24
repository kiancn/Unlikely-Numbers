using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    [Serializable]
    class DataListObject<T> // form for an a list of objects of any type, <T>
    {
        private string collectionName = "Saved List of Type T";
        private string collectionNotes = "Saved List Has No Notes.";
        private string typeOfThing = "type"; // insert single word useful to pull for string descriptions

        public DataListObject(string collectionName = "Saved List of Type T", string collectionNotes = "Saved List Has No Notes.", List<T> list = null, string typeOfThing = "type")
        {
            this.collectionName = collectionName;
            this.collectionNotes = collectionNotes;
            if (list != null)
            {
                this.List = list;
            }
            
            this.typeOfThing = typeOfThing;
        }

        public string CollectionName { get => collectionName; /*set => collectionName = value;*/ }
        public string CollectionNotes { get => collectionNotes;/* set => collectionNotes = value;*/ }
        public List<T> List { get; }
        public string TypeOfThing { get => typeOfThing; /*set => typeOfThing = value;*/ }

        internal void PrintList(/*List<T> list*/)
        {
            Console.WriteLine("|| {0} ", CollectionName);
            Console.WriteLine("||\n|| '{0}'\n|| ", CollectionNotes);

            if (List != null)
            {
                for (int i = 0; i < List.Count; i++)
                //for (int i = 0; i < list.Count; i++)
                {
                    Console.Write("||\n|| {0} : {1} :\n|| {2}", TypeOfThing, i, List[i]);
                }
            }
            else
            {
                Console.WriteLine("|| There is no list to print in the '{0}'\n|| Get a better list and try again.");
            }            
        }
    }
}
