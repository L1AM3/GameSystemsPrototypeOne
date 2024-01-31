using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshoot : MonoBehaviour
{
    public GameObject Bullet;
    [HideInInspector] public Vector3 ShootPosition;
    public Transform BulletSpawn;
    public float BulletSpeed;

    public void GunShot()
    {
        Vector3 dir = BulletSpawn.transform.position - ShootPosition;
        GameObject SpawnedBullet = Instantiate(Bullet, BulletSpawn.transform.position, Quaternion.identity);
        SpawnedBullet.GetComponent<Rigidbody>().velocity = dir.normalized * BulletSpeed * Time.deltaTime;
    }
}
