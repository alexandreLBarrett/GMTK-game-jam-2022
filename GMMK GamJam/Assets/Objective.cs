using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    protected WinCondition condition;

    public bool completed;

    protected void Completed()
    {
        if (completed)
            return;

        completed = true;
        condition.ConditionUpdated();
    }

    protected void Start()
    {
        condition = GetComponentInParent<WinCondition>();
    }

    protected void OnEnable()
    {
        condition = GetComponentInParent<WinCondition>();
    }
}
