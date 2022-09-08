using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpielSitzung : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        int numSpielSitzungen = FindObjectsOfType<SpielSitzung>().Length;
        if(numSpielSitzungen>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        //Übergibt die Anzahl der Leben und Punkte an die UI Elemente
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    //Diese Funktion beendet das Spiel sobald der Spieler alle Leben verliert
    public void ProcessPlayerDeath()
    {
        if(playerLives>1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    //Funktion um Leben abzuziehen
    private void TakeLife()
    {
        //Zieht ein Leben ab
        playerLives--;
        //Aktuelles Level wird neu geladen
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    //Setzt das Spiel zurück
    private void ResetGameSession()
    {
        FindObjectOfType<LevelÜbergreifend>().ResetLevelÜbergreifend();
        //Lädt das Level mit dem Index 0, also das Hauptmenü
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
