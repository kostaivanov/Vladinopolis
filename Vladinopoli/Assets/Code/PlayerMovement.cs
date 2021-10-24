using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private List<Transform> wayPoints;
    private int currentWP = 0;
    int previousWP = 0;

    public float speed = 10.0f;
    public float rotSpeed = 10.0f;
    //public float lookAhead = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject waypointsObject = GameObject.FindGameObjectWithTag("Waypoints");
        wayPoints = new List<Transform>();
        foreach (Transform wp in waypointsObject.transform)
        {
            wayPoints.Add(wp);
        }
        Debug.Log(wayPoints.Count);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("current waypoint = " + currentWP);
        if (StaticFunctions.instance.goLeft == true)
        {
            if (Vector3.Distance(this.transform.position, wayPoints[currentWP].transform.position) < 0.1f)
            {
                previousWP = currentWP;
                if (currentWP % 2 == 0)
                {
                    currentWP += 2;
                }
                else if (currentWP % 2 == 0)
                {
                    currentWP += 3;
                }
                StaticFunctions.instance.goLeft = false;
                StaticFunctions.instance.goRight = false;
            }
            if (currentWP >= wayPoints.Count)
            {
                currentWP = 0;
            }

            Quaternion lookatWP = Quaternion.LookRotation(wayPoints[currentWP].transform.position - this.transform.position);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        } 
        else if(StaticFunctions.instance.goRight == true)
        {
        

            if (Vector3.Distance(this.transform.position, wayPoints[currentWP].transform.position) < 0.1f)
            {
                if (currentWP % 2 == 1)
                {
                    currentWP += 2;
                }
                else if (currentWP % 2 == 0)
                {
                    currentWP += 1;
                }
                StaticFunctions.instance.goLeft = false;
                StaticFunctions.instance.goRight = false;
            }
            if (currentWP >= wayPoints.Count)
            {
                currentWP = 0;
            }

            Quaternion lookatWP = Quaternion.LookRotation(wayPoints[currentWP].transform.position - this.transform.position);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }

        if (currentWP != previousWP)
        {
            previousWP = currentWP;
            StaticFunctions.instance.choiceMade = false;
        }
    }
}
