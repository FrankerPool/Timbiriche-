using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Size
{
    Short,Medium,Big
}
public class GeneratorDots : MonoBehaviour
{
    public static GeneratorDots generatorDotsInstance;
    public Size sizeTimbiriche = Size.Short;
    public GameObject currentDotSelected, prevDotSelected;
    public List<NodeTimbiriche> nodesMaze;
    public NodeTimbiriche prefabMazeNode;
    public int totalNumberOfCubes;
    public int currentNumberOfCubes;
    private void Awake()
    {
        generatorDotsInstance = this;
    }
    private void Start()
    {
    }
    public void setTotalNumberOfCubes(int total)
    {
        totalNumberOfCubes = total;
    }
    public void addCurrentTotalCubes()
    {
        currentNumberOfCubes++;
    }
    public void generateDots(int size)
    {
        setTotalNumberOfCubes(size * size);
        //lista donde guardo los nodos temporalmente
        List<NodeTimbiriche> nodes = new List<NodeTimbiriche>();
        Vector2Int sizeMaze = new Vector2Int(size,size);

        for (int x = 0; x < sizeMaze.x; x++)
        {
            for (int y = 0; y < sizeMaze.y; y++)
            {
                Vector3 nodePos;
                nodePos = new Vector3(x - (sizeMaze.x / 2f), y - (sizeMaze.y / 2f), 0);
                //
                NodeTimbiriche newMazeNode = Instantiate(prefabMazeNode, nodePos, Quaternion.identity, transform);
                nodes.Add(newMazeNode);
                nodesMaze.Add(newMazeNode);
            }
        }
    }
}
