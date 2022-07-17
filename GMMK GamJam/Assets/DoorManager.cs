using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;

public class DoorManager
{
    GameObject CurrentMap;
    DiceDoor[] Doors;
    int MapId;
    int diceTotalFaces;

    HashSet<int> clearedFaces = new HashSet<int>();

    public DoorManager(int diceSides)
    {
        diceTotalFaces = diceSides;
    }

    public void EnterDoor(GameObject startingMap)
    {
        MapId = int.Parse(startingMap.name.Substring(4));
        CurrentMap = startingMap;

        Doors = CurrentMap.GetComponentsInChildren<DiceDoor>();

        if (!clearedFaces.Contains(MapId))
        {
            foreach (var door in Doors)
            {
                door.Locked = true;
            }
        }
    }


    public void OpenRandomClosedDoor()
    {
        clearedFaces.Add(MapId);

        if (clearedFaces.Count == diceTotalFaces)
        {
            DiceHasBeenCleared();
            return;
        }

        foreach (var door in Doors)
        {
            door.Locked = false;
        }

        List<DiceDoor> closeDoors = new List<DiceDoor>();
        foreach (DiceDoor door in Doors)
        {
            if (!door.Opened && !clearedFaces.Contains(door.diceSide))
                closeDoors.Add(door);
        }

        if (closeDoors.Count == 0)
            return;

        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        var doorToOpen = UnityEngine.Random.Range(0, closeDoors.Count);
        closeDoors[doorToOpen].Opened = true;

        int nextFace = closeDoors[doorToOpen].diceSide;
        var nextMap = CurrentMap.transform.parent.Find("Map_" + nextFace).gameObject;

        var nextDiceDoors = nextMap.GetComponentsInChildren<DiceDoor>();
        foreach (var diceDoor in nextDiceDoors)
        {
            if (diceDoor.diceSide == MapId)
            {
                diceDoor.Opened = true;
            }
        }
    }

    void DiceHasBeenCleared()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
