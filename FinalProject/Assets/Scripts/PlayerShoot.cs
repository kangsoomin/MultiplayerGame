using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;

    private float range = 100f;
    [SerializeField]
    LayerMask whatToHit;

    public float fireRate;
    private float timeToFire = 0;

    // Update is called once per frame
    void Update()
    {

        Shoot();
        if(fireRate == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();

            }
        }
        else
        {
            if (Input.GetMouseButton(0) && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
        
        


    }

    void Shoot()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(firePointPos, mousePos-firePointPos, range, whatToHit);
        Debug.DrawLine(firePointPos, mousePos);
        if(hit.collider != null)
        {
            
            Debug.DrawLine(firePointPos, mousePos, Color.red);
        }
    }
}
