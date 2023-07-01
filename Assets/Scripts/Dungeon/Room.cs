using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public string id;
    public string templateID;
    public GameObject prefab;
    public RoomNodeTypeSO roomNodeType;
    public Vector2Int lowerBounds;
    public Vector2Int upperBounds;
    public Vector2Int templateLowerBounds;
    public Vector2Int templateUpperBounds;
    public Vector2Int[] spawnPositionArray;
    public List<string> childRoomIDList;
    public string parentID;
    public List<Doorway> doorwayList;
    public bool isPositioned = false;
    public InstantiatedRoom instantiatedRoom;
    public bool isLit = false;
    public bool isClearOfEnemies = false;
    public bool isPreviouslyVisited = false;

    public Room()
    {
        childRoomIDList = new List<string>();
        doorwayList = new List<Doorway>();
    }
}
