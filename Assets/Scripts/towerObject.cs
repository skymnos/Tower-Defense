using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameobject/TowerObject")]
public class towerObject : ScriptableObject
{
    public Sprite image;
    public TowerType towerType;
    public float range;
    public float fireRate;
    public float damage;
    public GameObject ammo;
    public Transform firePosition;
}

public enum TowerType
{
    archer,
    magic,
    canon,
    rock
}

public enum DamageZone
{
    one,
    multiple
}

public enum DamageType
{
    slash,
    magic,
    explosive,
    piercing,
    blunt
}