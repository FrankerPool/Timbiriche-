using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager gameManagerInstancie;
    public PlayerDataBase dataPlayers;
    public List<PlayerDataInGame> dataPlayerInGame;
    public PlayerDataInGame currentPlayerData;
    public int currentTurn;
    private void Awake()
    {
        gameManagerInstancie = this;
    }
    private void Start()
    {
        initializedPlayersInfo();
    }
    public void OnClickstartGame()
    {
        initializedPlayersInfo();
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
