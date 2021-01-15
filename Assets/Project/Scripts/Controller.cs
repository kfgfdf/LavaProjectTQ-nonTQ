using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public CharacterMovement charactermovement;
    public CharacterAnimation characterAnimation;
    public CharacterInput characterInput;
    
    void Update()
    {
        charactermovement.MoveUpdate();
        characterAnimation.AnimationUpdate();
        characterInput.InputUpdate();
    }
}
