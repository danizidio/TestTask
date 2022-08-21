using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;

public class GameBehaviour : GamePlayBehaviour
{

    PlayerBehaviour _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    private void Start()
    {
        OnNextGameState(GamePlayStates.INITIALIZING);
    }

    private void Update()
    {
        StateBehaviour(GamePlayCurrentState);

        UpdateState();
    }

    void StateBehaviour(GamePlayStates state)
    {
        switch(state)
        {
            case GamePlayStates.INITIALIZING:
                {
                    CameraBehaviour.OnSearchingPlayer?.Invoke();
                    
                    break;
                }
            case GamePlayStates.START:
                {

                    OnNextGameState.Invoke(GamePlayStates.GAMEPLAY);

                    break;
                }
            case GamePlayStates.GAMEPLAY:
                {
                    Time.timeScale = 1;

                    break;
                }
            case GamePlayStates.PAUSE:
                {
                    Time.timeScale = 0;

                    break;
                }
            case GamePlayStates.GAMEOVER:
                {
                    Time.timeScale = 0;

                    break;
                }
        }
    }

    //METHOD TO BE CALLED ON PLAYER ACTION 'ON PAUSING'
    void PauseGame()
    {
        if (GetCurrentGameState() != GamePlayStates.PAUSE)
        {
            OnNextGameState?.Invoke(GamePlayStates.PAUSE);
        }
        else
        {
            OnNextGameState?.Invoke(GamePlayStates.GAMEPLAY);
        }
    }

    private void OnEnable()
    {
        OnNextGameState += NextGameStates;
        _player.OnPausing += PauseGame;
    }
    private void OnDisable()
    {
        OnNextGameState -= NextGameStates;
        _player.OnPausing -= PauseGame;
    }
}
