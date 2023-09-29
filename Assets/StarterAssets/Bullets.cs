using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Bullet hit " + other.gameObject.name);
        Destroy(gameObject, 2f);
    }

 




}
