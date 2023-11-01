using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeComprobator : MonoBehaviour
{
    public int counterLines = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Line"))
            if (collision.gameObject.GetComponent<WayBehaviour>().wayActive)
                counterLines++;
    }
}
