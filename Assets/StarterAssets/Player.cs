using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask clickLayer;

    public delegate void CubeHitEvent(GameObject hitObject);
    public static event CubeHitEvent OnCubeHit;
    
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickLayer))
            {
                GameObject hitObject = hit.collider.gameObject;
                
                if (OnCubeHit != null)
                {
                    OnCubeHit(hitObject);
                }
            }
        }
        
    }
}
