using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IShootable
{
    void Shoot(Vector3 position, Quaternion rotation, PlayerStatsModifier modifier);
}
