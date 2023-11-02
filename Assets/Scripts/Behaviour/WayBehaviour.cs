using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WayBehaviour : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public DotBehaviour DotScript;
    public bool wayActive;
    public List<GameObject> cubesInfluence;
    public int numberOfCubesFinish = 0;
    private LineRenderer lineColour;
    // Start is called before the first frame update
    void Start()
    {
        lineColour = this.gameObject.GetComponent<LineRenderer>();
    }
    private void OnDisable()
    {
        cubesInfluence.Clear();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Line"))
            if (this.wayActive)
                collision.gameObject.SetActive(false);
        if (collision.name.Contains("Node"))
            cubesInfluence.Add(collision.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!wayActive && this.gameObject.activeInHierarchy)
        {
            DotScript.makeWall(this.gameObject);
            Color c1 = GameManager.gameManagerInstancie.currentPlayerData.playerData.colorPlayer;
            Color c2 = new Color(1, 1, 1, 1);
            lineColour.material = new Material(Shader.Find("Sprites/Default"));
            lineColour.SetColors(c1, c2);
            for (int i = 0; i < cubesInfluence.Count; i++)
            {
                cubesInfluence[i].gameObject.GetComponent<NodeTimbiriche>().addWallInCount();
            }
            comprobateCubes();
            comprobateTurn();
        }
        else
            print("seleccione otra linea porfavor");
    }
    public void comprobateTurn()
    {
        if (GeneratorDots.generatorDotsInstance.currentNumberOfCubes == GeneratorDots.generatorDotsInstance.totalNumberOfCubes)
            GameManager.gameManagerInstancie.finishGame();
        if(numberOfCubesFinish<1)
            GameManager.gameManagerInstancie.comprobateTurn();
            GameManager.gameManagerInstancie.passTurn();
    }
    public void comprobateCubes()
    {
        for (int i = 0; i < cubesInfluence.Count; i++)
        {
            if (cubesInfluence[i].gameObject.GetComponent<NodeTimbiriche>().countwallsInCube == 4)
            {
                GameManager.gameManagerInstancie.addPointsToCurrentPlayer();
                numberOfCubesFinish++;
                GeneratorDots.generatorDotsInstance.addCurrentTotalCubes();
                cubesInfluence[i].gameObject.GetComponent<NodeTimbiriche>().customizeNode(
                    GameManager.gameManagerInstancie.currentPlayerData.playerData.playerIage,
                    GameManager.gameManagerInstancie.currentPlayerData.playerData.colorPlayer);
            }
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }
}
