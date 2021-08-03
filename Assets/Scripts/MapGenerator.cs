﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField] Transform tilePrefab;
    [SerializeField] Vector2 mapSize;
    public Transform obstaclePrefab;

    [Range(0,1)]
    [SerializeField] float tileOffset;


    public List<Coord> allTileCoords;
    Queue<Coord> shufledTileCoords;


    public int seed = 10;



    private void Start()
    {
        
         
        GenerateMap();
    }

    public void GenerateMap()
    {

        allTileCoords = new List<Coord>();

        for (int x = 0; x < mapSize.x; x++)
        {

            for (int y = 0; y < mapSize.y; y++)
            {
                allTileCoords.Add(new Coord(x, y));

            }

        }

        shufledTileCoords = new Queue<Coord>(Utility.ShuffleArray(allTileCoords.ToArray(), seed));




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
                Vector3 tilePosition = CoordToPosition(x, y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90));
                newTile.localScale = transform.localScale * tileOffset;
                newTile.parent = mapHolder;


            }
        }


        int obstacleCount = 10;
        for (int i = 0; i < obstacleCount; i++)
        {
            Coord randomCoord = GetRandomCoord();
            Vector3 obstaclePosition = CoordToPosition(randomCoord.x, randomCoord.y);
            Transform newObstacle = Instantiate(obstaclePrefab, obstaclePosition + Vector3.up * 0.5f, Quaternion.identity) as Transform;
            newObstacle.parent = mapHolder;


        }

    }


    Vector3 CoordToPosition(int x, int y)
    {
        return new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
    }


    public Coord GetRandomCoord()
    {
        Coord randomCoord = shufledTileCoords.Dequeue();
        shufledTileCoords.Enqueue(randomCoord);
        return randomCoord;
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
