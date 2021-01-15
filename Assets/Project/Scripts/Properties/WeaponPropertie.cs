using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/properties")]
public class WeaponPropertie : ScriptableObject
{
    public Vector3 rHandPos, rHandRot;
    public GameObject weaponPrefab;
}
