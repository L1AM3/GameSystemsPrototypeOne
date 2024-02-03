using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    private int DecisionCount = 0;
    private int MaxDecisionCount;
    public Gundraw PlayerDraw;
    public Vector2Int MaxDecisionRange;
    public float MoveSpeed;
    public float DecisionTime;
    public Animator EnemyAnimator;
    private float Timer = 0;
    private Vector3 moveDir;

    private void Start()
    {
        MaxDecisionCount = Random.Range(MaxDecisionRange.x, MaxDecisionRange.y);
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

        if (DecisionCount >= MaxDecisionCount)
        {
            moveDir = Vector3.zero;
            StartCoroutine(DrawGunDelay());
        }

        transform.position += moveDir.normalized * MoveSpeed * Time.deltaTime;
    }

    private void MakeDecision()
    {
        int Decision = Random.Range(0, 5);

        switch (Decision)
        {
            case 0:
                moveDir = -transform.right;
                break;

            case 1:
                moveDir = transform.right;
                break;

            case 2:
                moveDir = -transform.forward;
                break;

            case 3:
                moveDir = transform.forward;
                break;

            default: moveDir = Vector3.zero;
                break;
        }
    }
}
