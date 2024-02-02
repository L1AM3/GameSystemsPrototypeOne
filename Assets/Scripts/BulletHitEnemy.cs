using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitEnemy : MonoBehaviour
{
    public Animator Animator;

    private void OnCollisionEnter(Collision collision)
    {
        Animator.SetBool("IsShot", true);
    }
}
