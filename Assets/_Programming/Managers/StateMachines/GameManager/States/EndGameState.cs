using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameState : IGameManagerState
{
    private float timer;

    public void Enter(GameManager gameManager)
    {
        timer = 2f;
    }

    public void Execute(GameManager gameManager)
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            ReloadScene();
    }

    public void Exit(GameManager gameManager)
    {
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}