using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeTimbiriche : MonoBehaviour
{
    public TextMeshProUGUI countLines;
    public int countwallsInCube = 0;
    public List<GameObject> wallsInCube;
    public Image nodeImage;
    public SpriteRenderer colorImageNode;
    public void customizeNode(Sprite playerAvatar, Color32 colorPlayer)
    {
        nodeImage.sprite = playerAvatar;
        colorImageNode.color = colorPlayer;
    }
    public void addWallInCount()
    {
        countwallsInCube++;
        updateCountTXT();
    }
    public void updateCountTXT()
    {
        countLines.text = countwallsInCube.ToString();
    }
    public void addDot(GameObject wall)
    {
        wallsInCube.Add(wall);
    }
    public void removeDot(GameObject wall)
    {
        wallsInCube.Remove(wall);
    }
    public void clearDotList()
    {
        wallsInCube.Clear();
    }
}
