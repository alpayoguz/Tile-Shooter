using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField] Transform tilePrefab;
    [SerializeField] Vector2 mapSize;

    [Range(0,1)]
    [SerializeField] float tileOffset;
    





    private void Start()
    {
        
         
        GenerateMap();
    }

    public void GenerateMap()
    {

        


        string holderName = "Generated Map";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }


       
        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;
     

        for (int x = 0; x < mapSize.x; x++)
        {

            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90));
                newTile.localScale = transform.localScale * tileOffset;
                newTile.parent = mapHolder;


            }
        }
    }


    public struct Coord
    {
       public int x, y;

        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

    }



}
