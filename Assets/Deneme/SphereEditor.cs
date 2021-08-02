using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(Sphere))]
public class SphereEditor : Editor
{
    public override void OnInspectorGUI()
    {
       



        

        Sphere sph = (Sphere)target;
        sph.baseSize = EditorGUILayout.Slider("Ball Size", sph.baseSize, 1f, 5f);
        sph.transform.localScale = Vector3.one * sph.baseSize;
        

        


    }
}
