using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public CharacterStatus characterStatus;
    public Weapon weapon;
    public bool debugAiming, isAiming;

    public void InputUpdate()
    {
        if(!debugAiming)
        characterStatus.isAiming = Input.GetMouseButton(1);
        else
        characterStatus.isAiming = isAiming;

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Shoot();
        }
    }
}
