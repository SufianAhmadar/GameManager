using UnityEngine;
public enum States
{
    gamecheck,
    gamestart,
    gameplay,
    gamepause,
    gameover
}
public class GameManager : MonoBehaviour
{
    public static event gameDelegate gameStart;
    public static event gameDelegate gamePlay;
    public static event gameDelegate gamePause;
    public static event gameDelegate gameOver;
  
    
    public static States gameStates;
    void Start()
    {
        gameStates = States.gamestart;
    }
    private void Update()
    {
        if (gameStates == States.gamecheck)
        {
            return;
        }
        else if (gameStates == States.gamestart)
        {
            if (gameStart != null)
            {
                gameStart();
            }
            gameStates = States.gamecheck;
        }
        else if (gameStates == States.gameplay)
        {
            if (gamePlay != null)
                gamePlay();
        }
        else if (gameStates == States.gamepause)
        {
            if (gamePause != null)
            {
                gamePause();
                gameStates = States.gamecheck;
            }
        }
        else if (gameStates == States.gameover)
        {
            if (gameOver != null)
            {
                gameOver();
                gameStates = States.gamecheck;
            }
        }
    }
}
