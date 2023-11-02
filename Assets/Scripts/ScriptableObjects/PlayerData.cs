using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public string playerName;
    public Sprite playerIage;
    public Color32 colorPlayer;
}
[System.Serializable]
public class PlayerDataInGame
{
    public PlayerData playerData;
    public int playerPoints;
    public PlayerDataInGame(int playerPoints, PlayerData playerData)
    {
        this.playerPoints = playerPoints;
        this.playerData = playerData;
    }
}