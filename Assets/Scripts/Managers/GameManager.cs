using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager gameManagerInstancie;
    public PlayerDataBase dataPlayers;
    public List<PlayerDataInGame> dataPlayerInGame;
    public PlayerDataInGame currentPlayerData;
    public int currentTurn;
    public GameObject canvasFinishGame;
    private void Awake()
    {
        gameManagerInstancie = this;
    }
    private void Start()
    {

    }
    public void finishGame()
    {
        canvasFinishGame.SetActive(true);
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OnClickstartGame()
    {
        initializedPlayersInfo();
        GeneratorDots.generatorDotsInstance.generateDots(8);
    }
    public void passTurn()
    {
        currentPlayerData = dataPlayerInGame[currentTurn];
        PlayerInfoUI.playerInfoUIInstance.setInfoUI(
    dataPlayerInGame[currentTurn].playerData.playerName,
    dataPlayerInGame[currentTurn].playerPoints,
    dataPlayerInGame[currentTurn].playerData.playerIage,
    dataPlayerInGame[currentTurn].playerData.colorPlayer);
    }
    public void comprobateTurn()
    {
        currentTurn = currentTurn + 1;
        if (currentTurn > dataPlayerInGame.Count - 1)
        {
            currentTurn = 0;
        }
    }
    public void addPointsToCurrentPlayer()
    {
        dataPlayerInGame[currentTurn].playerPoints++;
    }
    public void initializedPlayersInfo()
    {
        currentTurn = 0;
        for (int i = 0; i < dataPlayers.playersDataBase.Length; i++)
        {
            dataPlayerInGame.Add(new PlayerDataInGame(0, dataPlayers.playersDataBase[i]));
        }
        PlayerInfoUI.playerInfoUIInstance.setInfoUI(
    dataPlayerInGame[currentTurn].playerData.playerName,
    dataPlayerInGame[currentTurn].playerPoints,
    dataPlayerInGame[currentTurn].playerData.playerIage,
    dataPlayerInGame[currentTurn].playerData.colorPlayer);
    }
}
