using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    public GameObject ammo = null;
    public GameObject target;
    public LayerMask mask;
    //public float shootTimer = 0;
    //public float rate = 0;
    public float force = 50;
    public float distance = 20;
    public Transform spawnPoint = null;
    public bool equipped = false;
    public bool thrown = false;
    WeaponThrow weaponThrow;

    void Awake()
    {
        if (transform.parent.tag == "Player")
        {
            equipped = true;
            return;
        }
        else
        {
            equipped = false;
        }
    }

    void Update()
    {
        if (equipped)
        {
            RaycastHit hit;
            Ray ray = new Ray(spawnPoint.position, spawnPoint.forward);
            if(Physics.Raycast(ray, out hit, distance, mask))
            {
                if (Input.GetKey(KeyCode.Alpha2) && hit.collider.tag == "Enemy")
                {
                    target = hit.collider.gameObject;
                }
            }

            if(target != null)
            {
                transform.LookAt(target.transform);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ShootProjectile();
            }
        }
    }

    void ShootProjectile()
    {
        GameObject bullet = Instantiate(ammo, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * force;
        //shootTimer += Time.deltaTime;
        //if (shootTimer >= rate)
        //{
        //    GameObject bullet = Instantiate(ammo, spawnPoint.position, spawnPoint.rotation);
        //    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * force;
        //    shootTimer = 0;
        //}
    }
}
