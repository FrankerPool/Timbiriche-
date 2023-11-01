using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NodeTimbiriche : MonoBehaviour
{
    public TextMeshProUGUI countLines;
    public int wallInCube = 0;
    public List<GameObject> dotsOfNode;
    
    public void addWallInCount()
    {
        wallInCube++;
        updateCountTXT();
    }
    public void updateCountTXT()
    {
        countLines.text = wallInCube.ToString();
    }
    public void addDot(GameObject dot)
    {
        dotsOfNode.Add(dot);
    }
    public void removeDot(GameObject dot)
    {
        dotsOfNode.Remove(dot);
    }
    public void clearDotList()
    {
        dotsOfNode.Clear();
    }
}
