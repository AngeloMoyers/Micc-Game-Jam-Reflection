using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButtonScript : MonoBehaviour
{
    [Header("Logic")]
    [SerializeField] RetrractableWallScript m_partnerWall;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_partnerWall == null) return;

        if (collision.tag == "Player")
        {
            m_partnerWall.Retract();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (m_partnerWall == null) return;

        if (collision.tag == "Player")
        {
            m_partnerWall.Extend();
        }
    }
}
