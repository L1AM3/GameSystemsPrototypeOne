using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawDetection : MonoBehaviour
{
    public Gundraw player;
    public Enemymovement enemy;
    private bool oneHasShot = false;

    private void Start()
    {
        player.ShotGun += DetectDraw;
        enemy.EnemyDraw += DetectDraw;
    }

    private void DetectDraw()
    {
        if (oneHasShot)
        {
            StartCoroutine(SceneReset());
        }
        else
        {
            oneHasShot = true;
        }
    }

    public IEnumerator SceneReset()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Gunslinger");

    }
}
