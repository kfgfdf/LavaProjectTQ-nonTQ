using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    private Animator anim;
    public Rigidbody[] rigid;
    public int health;

    //private bool isDead;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeAwayHealth(int TakeAway)
    {
        health -= TakeAway;

        if(health <= 0)
        {
            Dead();
            //isDead = true;
        }
    }

    public void Dead()
    {
        foreach(Rigidbody rb in rigid)
        {
            rb.isKinematic = false;
        }
        anim.enabled = false;
    }

    // public void ImpulseDead(RaycastHit hit)
    // {
    //     if(isDead)
    //     {
            
    //     }
    // }
}
