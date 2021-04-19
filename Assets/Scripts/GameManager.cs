using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gamingPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject winGamePanel;    

    public static bool isGaming;
    public static bool win;

    void Start()
    {
        NewGame();
        Timer.timerInstance.timeExpired += LoseGame; //подписываемся на события истечения времени в методе Start!
        PinTools.pinToolsInstance.winning += () => StartCoroutine("WinGame"); //и выигрыша
    }
    
    private void LoseGame()
    {
        isGaming = false;
        gameOverPanel.SetActive(true);
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        win = false;       
        PinTools.pinToolsInstance.PutPinsAtStartPosition();
        Timer.timerInstance.NewGameTimer();        
        gameOverPanel.SetActive(false);
        winGamePanel.SetActive(false);
    }
    IEnumerator WinGame()
    {
        isGaming = false;
        win = true;
        yield return new WaitForSeconds(0.5f);
        winGamePanel.SetActive(true);        
    }
}
