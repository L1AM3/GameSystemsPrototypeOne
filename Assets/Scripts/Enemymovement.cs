using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    public Action EnemyDraw;
    private int DecisionCount = 0;
    private int MaxDecisionCount;
    public Gundraw PlayerDraw;
    public Vector2Int MaxDecisionRange;
    public float MoveSpeed;
    public float DecisionTime;
    public Animator EnemyAnimator;
    private float Timer = 0;
    private Vector3 moveDir;
    private bool HasShot = false;

    private void Start()
    {
        MaxDecisionCount = UnityEngine.Random.Range(MaxDecisionRange.x, MaxDecisionRange.y);
        PlayerDraw.ShotGun += PlayerGunShoot;
    }

    private void PlayerGunShoot()
    {
        DecisionCount = MaxDecisionCount + 1;
    }

    private IEnumerator DrawGunDelay()
    {
        yield return new WaitForSeconds(0.66f);
        EnemyAnimator.SetBool("HasDrawn", true);
        EnemyDraw?.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0 && DecisionCount < MaxDecisionCount)
        {
            MakeDecision();
            Timer = DecisionTime;
            DecisionCount++;
        }

        if (DecisionCount >= MaxDecisionCount && !HasShot)
        {
            moveDir = Vector3.zero;
            StartCoroutine(DrawGunDelay());
            HasShot = true;
        }

        transform.position += moveDir.normalized * MoveSpeed * Time.deltaTime;
    }

    private void MakeDecision()
    {
        int Decision = UnityEngine.Random.Range(0, 7);

        switch (Decision)
        {
            case 0:
                moveDir = -transform.right + transform.forward;
                break;

            case 1:
                moveDir = transform.right + transform.forward; ;
                break;

            case 2:
                moveDir = -transform.forward;
                break;

            case 3:
                moveDir = transform.forward;
                break;

            case 4:
                moveDir = -transform.right - transform.forward;
                break;

            case 5:
                moveDir = transform.right - transform.forward; ;
                break;

            default: moveDir = Vector3.zero;
                break;
        }
    }
}
