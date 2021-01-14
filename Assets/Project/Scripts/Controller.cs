using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public CharacterMovement charactermovement;
    
    void FixedUpdate()
    {
        charactermovement.MoveUpdate();
    }
}
