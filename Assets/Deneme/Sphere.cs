using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [Range(1,5)]
    public float baseSize = 1;

    private void Update()
    {
        ScaleByTime();
    }



    public void ScaleByTime()
    {
        
        float animation = baseSize + Mathf.Sin(Time.time * 5) * baseSize / 3;

        transform.localScale = Vector3.one * animation;
    }
}
