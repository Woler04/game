using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    public GameObject originRoom;
    public GameObject[] rooms;
    private int roomCount;
    private HashSet<Vector3> occupiedPositions = new HashSet<Vector3>(); 
	


    void Awake()
    {
        roomCount = rooms.Length - 1;
        occupiedPositions.Add(originRoom.transform.position);
        GenerateDungeon();
    }

    private void GenerateDungeon()
    {
        Stack<GameObject> roomStack = new Stack<GameObject>();
        roomStack.Push(originRoom);

        Vector3[] directions = { Vector3.forward * 30, Vector3.left * 30, Vector3.right * 30, Vector3.back * 30 };

        while (roomStack.Count > 0 && roomCount >= 0)
        {
            GameObject currentRoom = roomStack.Pop();

            // Shuffle directions efficiently (Fisher-Yates)
            for (int i = directions.Length - 1; i > 0; i--)
            {
                int randomIndex = Random.Range(0, i + 1);
                (directions[i], directions[randomIndex]) = (directions[randomIndex], directions[i]);
            }

            Vector3 roomPos = currentRoom.transform.position; // Cache position to reduce transform access

            for (int i = 0; i < 4; i++)
            {
                if (roomCount < 0) break;

                Vector3 newPosition = roomPos + directions[i];
                newPosition.y = 0;

                if (occupiedPositions.Add(newPosition)) // HashSet.Add() returns false if already exists
                {
                    rooms[roomCount].transform.position = newPosition;
                    roomStack.Push(rooms[roomCount]); // Push instead of enqueue for better cache locality
                    roomCount--;
                }
            }
        }
    }
}