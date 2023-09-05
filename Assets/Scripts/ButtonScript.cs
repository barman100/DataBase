using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool Correct;
    public string Text;


 
    void Update()
    {
        
    }

    public void Clicked()
    {
        if (Correct == true)
        { Debug.Log("Correct Answer"); }
        else { Debug.Log("Wrong Answer"); }
    }
}
