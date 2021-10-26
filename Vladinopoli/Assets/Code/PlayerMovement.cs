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
    internal bool indexChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject waypointsObject = GameObject.FindGameObjectWithTag("Waypoints");
        wayPoints = new List<Transform>();
        foreach (Transform wp in waypointsObject.transform)
        {
            wayPoints.Add(wp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticFunctions.instance.goLeft == true)
        {
            if (indexChanged == false)
            {
                previousWP = currentWP;
                if (currentWP == wayPoints.Count - 1 || currentWP == wayPoints.Count - 2)
                {
                    currentWP = 1;
                }
                else
                {

                    if (currentWP % 2 == 0)
                    {
                        currentWP += 3;
                    }

                    else if (currentWP % 2 == 1)
                    {
                        currentWP += 2;
                    }
                }
               
                indexChanged = true;
            }

            MovePlayer();
        }

        else if (StaticFunctions.instance.goRight == true)
        {
            if (indexChanged == false)
            {
                previousWP = currentWP;
                if (currentWP == wayPoints.Count - 1 || currentWP == wayPoints.Count - 2)
                {
                    currentWP = 0;
                }
                else
                {
                    if (currentWP % 2 == 0)
                    {
                        currentWP += 2;
                    }

                    else if (currentWP % 2 == 1)
                    {
                        currentWP += 1;
                    }
                }
             
                indexChanged = true;
            }

            MovePlayer();
        }

        if (indexChanged == false && currentWP != previousWP)
        {
            previousWP = currentWP;
            StaticFunctions.instance.choiceMade = false;
        }
    }

    private void MovePlayer()
    {
        if (indexChanged == true)
        {
            Quaternion lookatWP = Quaternion.LookRotation(wayPoints[currentWP].transform.position - this.transform.position);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }

        if (indexChanged == true && Vector3.Distance(this.transform.position, wayPoints[currentWP].transform.position) < 0.1f)
        {
            StaticFunctions.instance.goLeft = false;
            StaticFunctions.instance.goRight = false;
            indexChanged = false;
        }      
    }
}
