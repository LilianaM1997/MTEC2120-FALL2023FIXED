using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.OnCubeHit += HandleCubeHit;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        Player.OnCubeHit -= HandleCubeHit;
    }

    void HandleCubeHit( GameObject hitObject)
    {
        if (hitObject != null)
        {
            Destroy(hitObject);
        } 
    }
}
