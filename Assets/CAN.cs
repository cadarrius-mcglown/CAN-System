using UnityEngine;
using System.Collections;


public class CAN : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddNode()
    {
        Debug.Log("HI");

        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //Vector2 position = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        //sphere.transform.position = position;

        GameObject Node = (GameObject)Instantiate(Resources.Load("Node"));
        Vector2 position = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        Node.transform.position = position;

        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
        int i = 0;
        foreach (GameObject o in obj)
        {
            i++;
            if((o.name == "Node" || o.name == "Node(Clone)") && (o != Node))
            {
               // Debug.Log(o.name + i);

                if (ExistsWithin(Node, o))
                {
                    SeperateNodes(Node, o);

                    //Debug.Log(ExistsWithin(Node, o));
                }

            }
        }

    }

    public bool ExistsWithin(GameObject g1, GameObject g2)
    {
       // float num = g1.transform.position.x;
       // float num2 = g2.GetComponent<SphereObject>().alottedXLeft;
       
        if (g1.transform.position.x > g2.GetComponent<SphereObject>().alottedXLeft && g1.transform.position.x < g2.GetComponent<SphereObject>().alottedXRight)
        {
            if (g1.transform.position.y > g2.GetComponent<SphereObject>().alottedYBottom && g1.transform.position.x < g2.GetComponent<SphereObject>().alottedYTop)
            {
                
                return true;
            }
        }
        
        return false;
    }

    public void SeperateNodes(GameObject g1, GameObject g2)
    {
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //Vector2 position = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));

        //if new node is to the right of existing node then the left boundary of the new node is halfway between the new and existing node 
        int halfwayPointHorzontal = (int)((g1.transform.position.x + g2.transform.position.x) / 2);

        if (g1.transform.position.x > g2.transform.position.x)
        {
            g1.GetComponent<SphereObject>().alottedXLeft = halfwayPointHorzontal;
            g2.GetComponent<SphereObject>().alottedXRight = halfwayPointHorzontal;
        }
        else
        {
            g1.GetComponent<SphereObject>().alottedXRight = halfwayPointHorzontal;
            g2.GetComponent<SphereObject>().alottedXLeft = halfwayPointHorzontal;
        }
           
        
        GameObject divider = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Place divider vertically between each Node
        Vector2 position = new Vector2(halfwayPointHorzontal, Random.Range(-10, 10));
        divider.transform.position = position;
    }


}
