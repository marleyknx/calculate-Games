using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplicator : MonoBehaviour
{

    public int facterA, facterB;
    public int result;
    
   public  List<int> previousResult = new List<int>();


   

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.E))
        {
            ChangeFactors();
           

        }
       

      
        
       

        result = multiplier();
       
        //Debug.Log(multiplier());

    }

   public void ChangeFactors()
    {
        facterA = Random.Range(1, 11);
        facterB = Random.Range(1, 11);
    }
    public  int multiplier()
    {
        return facterA * facterB;
    }
}
