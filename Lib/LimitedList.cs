using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class LimitedList<T> : IEnumerable<T>  where T:class   //- om man tager bort IEnumerable<T> kan man inte använda Link
                                                                  //- where T:class ger att T kan ej vara en värdetyp
                                                                  //- samt array:er.
                                                                  //- T är en typ så T:class anger typen 

    {               
        private T[] list;     //- En array deklareras.
        public int Capacity { get; }



        public LimitedList(int capacity)    //- konstruktor
        {
            Capacity = capacity;
            list = new T[capacity];  //- en lista med längden capacity
                                     //- jfr. public int[] apa =  {1,2,3,4,5};
        }



        public bool Add(T element)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == null) { list[i] = element; return true; }
            }
            return false;
        }



        public bool Remove(T element)
        {
            for(int i=0; i< list.Length; i++)
            {
                if (list[i] == element) //- här kollas om referenserna är samma dvs. samma objekt.
                                        //- även strängar kontrolleras på detta sätt här (ej jämförelse på innehållet i strängarna)
                {
                    list[i] = null;
                    return true;
                }
            }
            return false;
        } //- of method Remove





        public int Count()
        {
            int count = 0;
            foreach(var element in this) { count++; }   //- this syftar till detta objekt

            // without GetEnumerator
            //for (int i = 0; i < list.Length; i++)
            //{
            //    if (list[i] != null)
            //    { count++; }
            //}
            return count;
        }






        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                { yield return list[i]; }  //- yield betyder returnera det du har och vänta.
            }
        }

        IEnumerator IEnumerable.GetEnumerator()    // ej utskrivet: public, är dock public.
                                                   // explicit implementationsdefinition.
        {
            return GetEnumerator();
        }

        //- eller ----> IEnumerator IEnumerable.GetEnumerator()   return GetEnumerator();



    } //- of class ------------------------------------------------------------







    public class Test
    {
        void LimitedListTest()
        {
            var list = new LimitedList<string>(capacity: 3);
            var cap = list.Capacity; //dvs 3
            bool firstAdd = list.Add("first");

            string second = "second";
            bool secondAdd = list.Add(second);

            var count = list.Count();


            foreach (var element in list)
            {
                var e = element;
            }


            bool removed  = list.Remove(second);
           // bool removed2 = list.RemoveAt(1);


        }








    } //- of class Test
}
