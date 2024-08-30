using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Straight Projectile",menuName ="Straight Projectile")]
public class ProjectileData :ScriptableObject
{

    public string Name;
    public int Damage;
    public float ProjectileSpeed;

}
