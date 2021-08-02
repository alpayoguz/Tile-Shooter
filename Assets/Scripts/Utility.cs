using System.Collections;
using System.Collections.Generic;


public static class Utility 
{


   
   public static  T[] ShuffleArray<T>(T[] array, int seed)
    {
        System.Random rnd = new System.Random(seed);

        for(int i = 0; i < array.Length - 1; i++)
        {
            var randomIndex = rnd.Next(array.Length);
            var tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem; 
        }


        return array;
    }


   
}
