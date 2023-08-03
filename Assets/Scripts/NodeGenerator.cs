using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{

    [SerializeField] NodeScript nodeObject;      
    public int mazeXAmount; // Amount of nodes in x axis
    public int mazeZAmount; // Amount of nodes in z axis
    public GameObject maze; 
    public GameObject image;  
    Vector3 imageScale;
    Vector3 mazeSize;   

    public List<NodeScript> listOfNodes;

    private void Awake()
    {
        listOfNodes = GenerateNodes(mazeXAmount, mazeZAmount); 
    }
    
    // GENERATE MAZE METHOD
    // Return nodeList
    List<NodeScript> GenerateNodes(int xNum, int zNum){

        List<NodeScript> nodeList = new List<NodeScript>();
        Transform mazeTransform = maze.transform;      

        for(int i = 0; i < xNum; i++){       
            for(int j = 0; j < zNum; j++){                
                // Get Position of next Node position
                Vector3 nextPosition = new Vector3(i, 0, j); // 1 is x, 2 is y, 3 is z

                // Create new node with updated position
                NodeScript node = Instantiate(nodeObject, nextPosition, Quaternion.identity, mazeTransform); 

                // Add to List
                nodeList.Add(node);                
            }
        }

        mazeTransform.Rotate(-2f, 0f, 0f); // Rotate entire maze slightly

        /*=====================================================*/
        /*================ Depth-First search =================*/
        List<NodeScript> path = new List<NodeScript>();
        List<NodeScript> visitedList = new List<NodeScript>();

        // Start Node
        System.Random randomNum = new System.Random();
        
        int randIndex = randomNum.Next(0, nodeList.Count); // random number between 0 and the nodeList length

        path.Add(nodeList[randIndex]); // Add node with random index as start of the path

        // Find available nodes
        int areaOfMaze = xNum * zNum;

        Debug.Log("Area of Maze: ");
        Debug.Log(xNum * zNum);

        int count = 0;
        // The loop ends when every node has been visited
        while(visitedList.Count < areaOfMaze){ 
            
            List<int> adjacentNodes = new List<int>(); // each int refers to an index value
            List<int> availableDirections = new List<int>();

            // IndexOf method to find index of current node
            int currentIndex = nodeList.IndexOf(path[path.Count - 1]); // path.Count -1 just refers to last item in list            
            int currentXLevel = currentIndex / zNum; // 0 for up, 1 for right, 2 for down, 3 for left
            int currentYLevel = currentIndex % zNum; // remainder gives y level

            // UP
            if(currentYLevel < (zNum - 1)){ // if your z position is at least 1 less than the max z position
                // Check that current node is not in visited or path lists
                if(!path.Contains(nodeList[currentIndex + 1]) && !visitedList.Contains(nodeList[currentIndex + 1]))
                {                    
                    adjacentNodes.Add(currentIndex + 1);
                    availableDirections.Add(1); // 1 - UP    
                }
            }

            // RIGHT
            if(currentXLevel < (xNum - 1)){ // if your x position is at least 1 less the max x position
                if(!path.Contains(nodeList[currentIndex + zNum]) && !visitedList.Contains(nodeList[currentIndex + zNum])){                    
                    adjacentNodes.Add(currentIndex + zNum);
                    availableDirections.Add(2); // Right
                }
            }

            // DOWN
            if(currentYLevel > 0){                 
                if(!path.Contains(nodeList[currentIndex - 1]) && !visitedList.Contains(nodeList[currentIndex - 1])){                    
                    adjacentNodes.Add(currentIndex - 1); // + 1 of current index refers to node 1 below
                    availableDirections.Add(3); // Down
                }
            }

            // LEFT
            if(currentXLevel > 0){                 
                if(!path.Contains(nodeList[currentIndex - zNum]) && !visitedList.Contains(nodeList[currentIndex - zNum])){                    
                    adjacentNodes.Add(currentIndex - zNum);
                    availableDirections.Add(4); // Left
                }
            }            
            // Possible outofbounds bug here, but maybe not. Just a note the bug might be here if still present.
            // Choosing next node at Random
            
            if (availableDirections.Count > 0)
            {
                int randomDirection = Random.Range(0, availableDirections.Count);
                NodeScript chosenNode = nodeList[adjacentNodes[randomDirection]];

                if (availableDirections[randomDirection] == 1){
                    chosenNode.deleteWall(3);
                    path[path.Count - 1].deleteWall(1);
                }
                if(availableDirections[randomDirection] == 2){
                    chosenNode.deleteWall(4);
                    path[path.Count - 1].deleteWall(2);
                }
                if(availableDirections[randomDirection] == 3){
                    chosenNode.deleteWall(1);
                    path[path.Count - 1].deleteWall(3);
                }
                if(availableDirections[randomDirection] == 4){
                    chosenNode.deleteWall(2);
                    path[path.Count - 1].deleteWall(4);
                }
                path.Add(chosenNode);                
            }
            else
            {
                visitedList.Add(path[path.Count - 1]);                
                path.RemoveAt(path.Count - 1);
            }
            count = count + 1;              
        }
        return nodeList; // Return nodeList              
    }             
}