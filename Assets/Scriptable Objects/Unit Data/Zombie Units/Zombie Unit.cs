using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Zombie Unit",menuName ="Zombie Unit")]
public class ZombieUnit : ScriptableObject
{
    public string Name;
    public int HP;
    public float MovementSpeed;
    public float AttackSpeedDelay;
    public float SpecialTimer;
    public float animation_time = 0.25F;

    public Sprite[] IdleAnimation;
    public Sprite[] WalkAnimationSet1;
    public Sprite[] WalkAnimationSet2;
    public Sprite[] AttackAnimationSet1;
    public Sprite[] AttackAnimationSet2;


}
