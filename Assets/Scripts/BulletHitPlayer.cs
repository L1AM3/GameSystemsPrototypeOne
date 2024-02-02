using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitPlayer : MonoBehaviour
{
    public Animator Animator;

    private void OnCollisionEnter(Collision collision)
    {
            Animator.SetBool("IsShot", true);
    }
}
