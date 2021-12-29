using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneScript : MonoBehaviour
{
    [SerializeField] GridMovementBase m_assignedCharacter;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == m_assignedCharacter.gameObject)
        {
            m_assignedCharacter.SetAtGoal(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == m_assignedCharacter.gameObject)
        {
            m_assignedCharacter.SetAtGoal(false);
        }
    }
}
