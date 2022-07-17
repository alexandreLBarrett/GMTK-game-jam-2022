using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    DiceRotator rotator;
    Objective[] Objectives;

    private void Start()
    {
        Objectives = GetComponentsInChildren<Objective>();
        rotator = GetComponentInParent<DiceRotator>();
    }

    public void ConditionUpdated()
    {
        foreach (Objective obj in Objectives)
        {
            if (!obj.completed)
                return;
        }

        rotator.RoomCleared();
    }
}
