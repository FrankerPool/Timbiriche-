using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DotBehaviour : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler,IDeselectHandler
{
    public GameObject lineLeft, lineRight, lineUp, lineDown;
    public List<GameObject> waysList;
    private void Start()
    {
        waysList = new List<GameObject> { lineLeft,lineRight,lineUp,lineDown};
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Dot"))
        {
            //en caso de ser verdad oculto uno de los dos
            if (this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                this.gameObject.SetActive(false);
            else
                collision.gameObject.SetActive(false);
        }
    }
    void Update()
    {
    }
    public void OnClickDot()
    {
        // Cast a ray straight down.
        //resto la diferencia en cada caso para que no sea ese mismo objeto el primero que collisione con el raycast
        RaycastHit2D hitUp = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y + .5f), Vector2.up, .5f);
        RaycastHit2D hitDown = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y - .5f), Vector2.down, .5f);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(this.transform.position.x - .5f, this.transform.position.y), Vector2.left, .5f);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(this.transform.position.x + .5f, this.transform.position.y), Vector2.right, .5f);
        // If it hits something...
        if (hitUp.collider)
            activeGhostLine(lineUp);
        if (hitDown.collider)
            activeGhostLine(lineDown);
        if (hitLeft.collider)
            activeGhostLine(lineRight);
        if (hitRight.collider)
            activeGhostLine(lineLeft);
    }
    public void hideAllWAlls()
    {
        for (int i = 0; i < waysList.Count; i++)
        {
            if (waysList[i].activeInHierarchy)
                if (!waysList[i].GetComponent<WayBehaviour>().wayActive)
                    waysList[i].SetActive(false);
        }
    }
    public void makeWall(GameObject line)
    {
        line.GetComponent<WayBehaviour>().wayActive = true;
        for (int i = 0; i < waysList.Count; i++)
        {
            if (waysList[i].activeInHierarchy)
                if (!waysList[i].GetComponent<WayBehaviour>().wayActive)
                    waysList[i].SetActive(false);
        }
    }
    public void activeGhostLine(GameObject line)
    {
        if (!line.activeInHierarchy && !line.GetComponent<WayBehaviour>().wayActive)
        {
            line.SetActive(true);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GeneratorDots.generatorDotsInstance.currentDotSelected == null)
        {
            GeneratorDots.generatorDotsInstance.currentDotSelected = this.gameObject;
        }
        GeneratorDots.generatorDotsInstance.currentDotSelected.GetComponent<DotBehaviour>().hideAllWAlls();
        GeneratorDots.generatorDotsInstance.currentDotSelected = this.gameObject;
        OnClickDot();
    }

    public void OnDeselect(BaseEventData eventData)
    {
    }
}
