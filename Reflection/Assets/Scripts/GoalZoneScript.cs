using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneScript : MonoBehaviour
{
    [Header("Logic")]
    [SerializeField] GridMovementBase m_assignedCharacter;

    [Header("Audio")]
    [SerializeField] AudioClip m_stepOn;
    [SerializeField] AudioClip m_stepOff;

    private AudioSource m_audioSource;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == m_assignedCharacter.gameObject)
        {
            m_assignedCharacter.SetAtGoal(true);
            m_audioSource.PlayOneShot(m_stepOn);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == m_assignedCharacter.gameObject)
        {
            m_assignedCharacter.SetAtGoal(false);
            m_audioSource.PlayOneShot(m_stepOff);
        }
    }
}
