using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gundraw : MonoBehaviour
{
    public Action ShotGun;
    public ReticalMovement retical;
    public Image Retical;
    public Animator Animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShotGun?.Invoke();

            Animator.SetBool("HasDrawn", true);
            Retical.color = Color.red;
            retical.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
}
