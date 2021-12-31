using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RetrractableWallScript : MonoBehaviour
{
    [Header("Logic")]
    [SerializeField] WallButtonScript m_partnerButton;
    [SerializeField] Tilemap m_walkableTilemap;
    [SerializeField] Tile m_tileToSet;

    [Header("Sprites")]
    [SerializeField] Sprite m_upSprite;
    [SerializeField] Sprite m_downSprite;

    [Header("Audio")]
    [SerializeField] AudioClip m_upSound;
    [SerializeField] AudioClip m_downSound;

    SpriteRenderer m_spriteRenderer;
    AudioSource m_audioSource;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_walkableTilemap.SetTile(m_walkableTilemap.WorldToCell(transform.position), null);
    
        m_audioSource = GetComponent<AudioSource>(); 
    }

    public void Retract()
    {
        m_audioSource.PlayOneShot(m_downSound);

        m_spriteRenderer.sprite = m_downSprite;
        AdjustWalkableTilemap(true);

    }

    public void Extend()
    {
        m_audioSource.PlayOneShot(m_upSound);

        m_spriteRenderer.sprite = m_upSprite;
        AdjustWalkableTilemap(false);
    }

    private void AdjustWalkableTilemap(bool canWalk)
    {
        if (canWalk)
            m_walkableTilemap.SetTile(m_walkableTilemap.WorldToCell(transform.position), m_tileToSet);
        else
            m_walkableTilemap.SetTile(m_walkableTilemap.WorldToCell(transform.position), null);

    }
}
