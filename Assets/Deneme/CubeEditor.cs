using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Cube))]
public class CubeEditor : Editor
{


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        Cube cube = (Cube)target;
        Cube cube2 = target as Cube;




        EditorGUILayout.BeginHorizontal();

        if(GUILayout.Button("Random Color"))
        {
            cube.ChangeCubeColor();
        }

        if(GUILayout.Button("Enlarge Cube"))
        {
            
            cube.transform.localScale +=   Vector3.one * cube.scaleFactor;
        }

        if(GUILayout.Button("Shrink Cube"))
        {
            cube.transform.localScale -= Vector3.one * cube.scaleFactor;
        }

        EditorGUILayout.EndHorizontal();

    }


}
