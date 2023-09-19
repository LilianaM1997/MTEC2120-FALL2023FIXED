using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform gunBarrel;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(bulletPrefab);

            Debug.Log(gunBarrel);
            
            GameObject go = Instantiate(bulletPrefab, gunBarrel.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(gunBarrel.forward * 1000f);
        }

    }
}
