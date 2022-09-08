using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    //Verz�gert das Laden des n�chsten Levels
    [SerializeField] float levelLoadDelay = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    //Funktion um das n�chste Level zu laden
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(levelLoadDelay);
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

        if(nextLevelIndex==SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }

        FindObjectOfType<Level�bergreifend>().ResetLevel�bergreifend();

        SceneManager.LoadScene(nextLevelIndex);
    }
}
