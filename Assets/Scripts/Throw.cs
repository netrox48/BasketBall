using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject projectile, projectileSample1, projectileSample2, projectileSample3;
    public bool shoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shoot == true)
        {
            shoot = false;
            projectile.transform.parent = null;
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            Invoke(nameof(CreateProjectile),0.25f);
        }
    }
    public void CreateProjectile()
    {
        int x = Random.Range(1, 4);
        GameObject newProjectile = null;
        if(x == 1)
            newProjectile = Instantiate(projectileSample1, transform);
        if(x == 2)
            newProjectile = Instantiate(projectileSample2, transform);
        if(x == 3)
            newProjectile = Instantiate(projectileSample3, transform);

        newProjectile.SetActive(true);
        projectile = newProjectile;
        shoot = true;
    }
}
