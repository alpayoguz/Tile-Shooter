using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [Range(0,1)]
    public float scaleFactor = 0;


    void Start()
    {
        ChangeCubeColor();
    }



   public  void ChangeCubeColor()
    {
        this.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }


    public void ResetColor()
    {
        this.GetComponent<Renderer>().material.color = Color.white;
    }
}
