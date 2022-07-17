using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Reflection;

public class PlayerStatsValueWatcher : MonoBehaviour
{
    public PlayerStatsModifier modifiers;

    [Serializable]
    public class StatWatcher
    {
        public string propertyName;
        public TMPro.TMP_Text text;
    }

    public StatWatcher[] Watchers;

    public void Update()
    {
        foreach (var watcher in Watchers)
        {
            var protertyInfo = (FieldInfo)modifiers.GetType().GetMember(watcher.propertyName)[0];
            float value = (float)protertyInfo.GetValue(modifiers);
            watcher.text.text = "x" + value.ToString("F2");

            if (value > 1)
            {
                watcher.text.color = Color.green;
            }
            else if (value < 1)
            {
                watcher.text.color = Color.red;
            }
            else
            {
                watcher.text.color = Color.white;
            }

        }
    }
}
