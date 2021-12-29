using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviorManager : MonoBehaviour
{
    [SerializeField] GridMovementBase[] m_characters;


    private int m_totalScenes;
    void Start()
    {
        m_totalScenes = SceneManager.sceneCount;
    }
    void Update()
    {
        if (TestAtGoal())
            LoadNextLevel();
    }

    private bool TestAtGoal()
    {
        foreach (var character in m_characters)
        {
            if (character == null)
                return false;

            if (!character.GetAtGoal())
                return false;
        }

        return true;
    }

    private void LoadNextLevel()
    {
        if (!(SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCountInBuildSettings - 1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
