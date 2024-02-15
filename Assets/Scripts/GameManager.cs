using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Splines;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject player;
    
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject gameWonUI;
    [SerializeField] GameObject gameLostUI;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] IntEvent scoreEvent;

    [SerializeField] FloatVariable health;

	private int score = 0;
	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			scoreText.text = score.ToString();
		}
	}

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
        scoreEvent.Subscribe(OnAddPoints);
    }

    void Update()
    {
		switch (state)
		{
			case State.TITLE:
                titleUI.SetActive(true);
                gameUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.GetComponent<PathFollower>().tdistance = 0;
				break;
			case State.START_GAME:
                Debug.Log("Game Start!");
                titleUI.SetActive(false);
                gameUI.SetActive(true);
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

    public void OnGameOver()
    {
        state = State.GAME_OVER;
    }

    public void OnAddPoints(int points)
    {
		this.Score += points;
    }
}
