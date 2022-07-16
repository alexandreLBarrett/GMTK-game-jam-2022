using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager
{
    GameObject CurrentMap;
    DiceDoor[] Doors;
    int MapId;

    public void EnterDoor(GameObject startingMap)
    {
        MapId = int.Parse(startingMap.name.Substring(4));
        CurrentMap = startingMap;
        Doors = CurrentMap.GetComponentsInChildren<DiceDoor>();
    }

    public void OpenRandomClosedDoor()
    {
        List<DiceDoor> closeDoors = new List<DiceDoor>();
        foreach (DiceDoor door in Doors)
        {
            if (!door.isOpened)
                closeDoors.Add(door);
        }

        if (closeDoors.Count == 0)
            return;

        var doorToOpen = Random.Range(0, closeDoors.Count);
        closeDoors[doorToOpen].Open();

        int nextFace = closeDoors[doorToOpen].diceSide;
        var nextMap = CurrentMap.transform.parent.Find("Map_" + nextFace).gameObject;

        var nextDiceDoors = nextMap.GetComponentsInChildren<DiceDoor>();
        foreach (var diceDoor in nextDiceDoors)
        {
            if (diceDoor.diceSide == MapId)
            {
                diceDoor.Open();
            }
        }
    }
}
