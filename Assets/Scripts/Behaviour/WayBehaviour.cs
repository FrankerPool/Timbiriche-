using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WayBehaviour : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public DotBehaviour DotScript;
    public bool wayActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!wayActive)
            DotScript.makeWall(this.gameObject);
        else
            print("seleccione otra linea porfavor");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        print("pointer up");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        print("pointer down");
    }
}
