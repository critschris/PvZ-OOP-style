using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Plant Unit",menuName ="Plant Unit")]
public class PlantUnit : ScriptableObject
{
    public string Name;
    public int HP;
    public float Action_delay;
    public float animation_time = 0.25F;

    public enum Type {Support, Offense};

    public Type type;

    public Sprite UnitPic;
    public Sprite[] IdleAnimation;
    public Sprite[] ActionAnimation;

}
