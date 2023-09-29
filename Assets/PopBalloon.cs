using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopBalloon : MonoBehaviour
{
    public GameObject balloon;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            // If the balloon collides with a bullet, pop the balloon and destroy the bullet.
            PopsBalloon();
            Destroy(other.gameObject);
        }
    }
    private void PopsBalloon()
    {
        

        // Destroy the balloon game object.
        Destroy(balloon);

     
    }
}
