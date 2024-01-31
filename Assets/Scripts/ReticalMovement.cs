using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticalMovement : MonoBehaviour
{
    public Gunshoot shooted;
    public Image Retical;
    public float AimSpeed;
    private Vector3 lastMousePosition;
    private Vector3 dir = Vector3.zero;
    private bool ShouldMove = true;

    // Start is called before the first frame update
    void Start()
    {
        lastMousePosition = Input.mousePosition;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ShouldMove) return;

        dir += (Input.mousePosition - lastMousePosition);
        Retical.transform.position += dir.normalized * AimSpeed * Time.deltaTime;
        lastMousePosition = Input.mousePosition;
    }

    public void Shoot()
    {
        ShouldMove = false;
        dir = Vector3.zero;
        shooted.ShootPosition = Camera.main.ViewportToWorldPoint(Retical.transform.position);

        Debug.Log(shooted.ShootPosition);
    }
}
