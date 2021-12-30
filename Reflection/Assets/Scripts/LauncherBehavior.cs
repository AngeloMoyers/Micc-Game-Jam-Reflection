using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LauncherBehavior : MonoBehaviour
{
    [Header("Map")]
    [SerializeField] Tilemap m_walkableTilemap;
    [SerializeField] GameObject m_scaler;

    [Header("Launch Details")]
    [SerializeField] float m_launchSpeed = 5.0f;

    private bool m_hasLaunched = false;

    
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (m_hasLaunched)
            return;
        var character = collision.GetComponent<GridMovementBase>();
        if (character != null && character.GetCanMove())
        {
            Launch(character);
            m_hasLaunched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_hasLaunched = false;
    }

    private void Launch(GridMovementBase character)
    {
        Vector3 targetPos = m_walkableTilemap.GetCellCenterWorld(m_walkableTilemap.WorldToCell(transform.position));
        TileBase tempTile = m_walkableTilemap.GetTile(m_walkableTilemap.WorldToCell(transform.position));
        Vector3 lastValidTilePos = m_walkableTilemap.GetCellCenterWorld(m_walkableTilemap.WorldToCell(transform.position));

        Vector3 dir;
        if (m_scaler != null)
            dir = transform.up * m_scaler.transform.localScale.x;
        else
            dir = transform.up;

        int it = 0;
        while (tempTile != null)
        {
            tempTile = m_walkableTilemap.GetTile(m_walkableTilemap.WorldToCell(transform.position + (dir * it)));
            if (tempTile != null)
            {
                lastValidTilePos = m_walkableTilemap.GetCellCenterWorld(m_walkableTilemap.WorldToCell(transform.position + (dir * it)));
            }
            it++;
        }


        character.SetCanMove(false);
        character.SetTargetPosition(lastValidTilePos);
        character.Spin();

    }
}
