using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    static public PlayerInfoUI playerInfoUIInstance;
    public TextMeshProUGUI currentPlayerPointsTXT;
    public TextMeshProUGUI playerNameTXT;
    public Image playerAvatarIMG;
    private void Awake()
    {
        playerInfoUIInstance = this;
    }
    public void setInfoUI(string nameplayer, int pointsPlayer, Sprite playerAvatarIMG, Color32 colorPlayer)
    {
        currentPlayerPointsTXT.text = pointsPlayer.ToString();
        playerNameTXT.text = nameplayer;
        this.playerAvatarIMG.sprite = playerAvatarIMG;

        playerNameTXT.color = colorPlayer;
        currentPlayerPointsTXT.color = colorPlayer;
        this.playerAvatarIMG.color = colorPlayer;
    }
}
