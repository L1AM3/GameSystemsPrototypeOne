using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletHit : MonoBehaviour
{
    public Animator Animator;
    public Animator AnimatorTwo;

    private void OnCollisionEnter(Collision collision)
    {
        Animator.SetBool("IsShot", true);
        AnimatorTwo.SetBool("HasDied", true);
        Destroy(collision.gameObject);

        StartCoroutine(Delay());
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Gunslinger");
    }

}
