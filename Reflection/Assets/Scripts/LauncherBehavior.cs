using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherBehavior : MonoBehaviour
{
    [SerializeField] float m_launchSpeed = 5.0f;

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var character = collision.GetComponent<GridMovementBase>();
        if (character != null)
        {
            Launch(character);
        }
    }

    private void Launch(GridMovementBase character)
    {
        Debug.Log("Launched");
    }
}
