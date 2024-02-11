using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject player;
    
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameWonUI;
    [SerializeField] GameObject gameLostUI;

    [SerializeField] FloatVariable health;

    public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_WON,
        GAME_OVER
    }
    public State state = State.TITLE;

    void Start()
    {
        
    }

    void Update()
    {
		switch (state)
		{
			case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.GetComponent<PathFollower>().tdistance = 0;
				break;
			case State.START_GAME:
                Debug.Log("Game Start!");
                titleUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                state = State.PLAY_GAME;
				break;
			case State.PLAY_GAME:
				break;
			case State.GAME_WON:
				break;
			case State.GAME_OVER:
				break;
		}
	}

    public void OnStartGame()
    {
        state = State.START_GAME;
    }
}
