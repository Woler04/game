using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    public GameObject originRoom;
    public GameObject[] rooms;
    private int roomCount;
    private bool[] roomsNeigh;
    private HashSet<Vector3> occupiedPositions = new HashSet<Vector3>(); 

    void Start()
    {
        roomCount = rooms.Length - 1;
        roomsNeigh = new bool[4];
        occupiedPositions.Add(originRoom.transform.position); 
        GenerateNeighbours(originRoom);
    }

    private void GenerateNeighbours(GameObject room)
    {
        if (roomCount < 0) return; 
		bool hasRoom = false;
		
        SetRoom(room);
    }

    private void SetRoom(GameObject room)
    {
        Vector3[] directions = { Vector3.forward * 31, Vector3.left * 31, Vector3.right * 31, Vector3.back * 31};

        for (int i = 0; i < 4; i++)
        {
            if (roomsNeigh[i] && roomCount >= 0) 
            {
                Vector3 newPosition = room.transform.position + directions[i];
				newPosition.y = 0;

                if (occupiedPositions.Contains(newPosition)) continue;

                rooms[roomCount].transform.position = newPosition;
                occupiedPositions.Add(newPosition);
                roomCount--;

                GenerateNeighbours(rooms[roomCount]);
            }
        }
    }
}
