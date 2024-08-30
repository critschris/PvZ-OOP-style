using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Map Data", menuName = "Map Data")]
public class MapData : ScriptableObject
{

    public enum Map{Day,Night, Pool, NightPool, Roof};
    public Map map;

    public int [] zombieAmount;
    public float [] MinWaittime;
    public float [] MaxWaittime;
    public float [] delay_Between_Spawns;
    
}

