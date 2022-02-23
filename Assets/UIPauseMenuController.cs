using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class UIPauseMenuController : MonoBehaviour
{
    public Button resumeButton;
    public Button exitButton;
    public VisualElement pauseMenu;

    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        resumeButton = root.Q<Button>("resume-button");
        exitButton = root.Q<Button>("exit-button");
        pauseMenu = root.Q<VisualElement>("pause-menu");

        resumeButton.clicked += Resume;
        exitButton.clicked += Exit;

    }

    private void Exit()
    {
        SceneManager.LoadScene(0);
    }

    private void Resume()
    {
        pauseMenu.style.display = DisplayStyle.None;
    }

    



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&isPaused==false)
        {
            pauseMenu.style.display = DisplayStyle.Flex;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            pauseMenu.style.display = DisplayStyle.None;
            isPaused = false;
        }


    }
        
 

    

    
}
