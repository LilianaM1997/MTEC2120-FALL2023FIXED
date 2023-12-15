using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int damageAmount = 20;

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet hit " + other.gameObject.name);
        Destroy(transform.GetComponent<Rigidbody>());
        if (other.tag == "Dragon")
        {
            transform.parent = other.transform;
            other.GetComponent<Dragon>().TakeDamage(damageAmount);
        }
    }

 




}
