using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class game_manager : MonoBehaviour
{
    //game manager will do loading of the prefab.

    [SerializeField]
    private GameObject[] playerPrefab;
    [SerializeField]
    private Transform[] playerStart_point;
    [SerializeField]
    private GameObject pillarPrefab;
    [SerializeField]
    private Transform[] pillarWay_points;
    [SerializeField]
    private Transform[] box_way_point;
    [SerializeField]
    private TMP_Text text_Points;
    [SerializeField]
    private TMP_Text text_health;

    //box prefab
    [SerializeField]
    private GameObject box_prefab;


    //default value for choice
    int choice = 0;
    //defualt value for pillars to create
    int pillars = 4;
    //defualt play mode
    int playMode = 0;
    //defualt value for box appearing
    int repeatRate = 20;

 


    private void Start()
    {
        createPlayer(choice);
        createPillars(pillars_To_leave());
        InvokeRepeating("create_point_box", 10,repeatRate);
        //test method
        
    }

    private void Update()
    {
        //points updated here
        updatePoints();
    }

    //method creates and instantiate player depending on the choice which indicates stroing or fast player
    void createPlayer(int choice)
    {
        GameObject lifePlayer = Instantiate(playerPrefab[choice], playerStart_point[choice].position, playerPrefab[choice].transform.rotation);
    }
    
    //method creates pillars base on the number of pillars to be instantiated and the playmode currently in action
    void createPillars(int amount)
    {
       for(int i = 0; i < amount; i++)
        {
            switch (playMode)
            {
                case 0:
                    instance_Pillar(pillarWay_points[i]);
                    break;
                case 1:
                    //nothing for now
                    break;
                default:
                    Debug.Log("error in game_manager , mode not possible");
                    break; 
            }
        }
    }

    //METHOD OVERLOADING
    private GameObject instance_Pillar(Transform way_points)
    {
        return Instantiate(pillarPrefab, way_points.position, pillarPrefab.transform.rotation);
    }
    //METHOD OVERLOADING
    private GameObject instance_Pillar(Transform way_points, Transform rotationP)
    {
        return Instantiate(pillarPrefab, way_points.position, rotationP.rotation);
    }

    //method returns a value within the array range as not to access out of bounce
    int pillars_To_leave()
    {
        if(pillars > pillarWay_points.Length)
        {
            pillars = pillarWay_points.Length;
            return pillars;
        }
        else
        {
            return pillars;
        }
    }


    //fumction creats the coin 
    private void create_point_box()
    {
        int value = Random.Range(0, box_way_point.Length) ;
        float rotateR = Random.Range(0, 180);
        Instantiate(box_prefab, box_way_point[value].position, box_prefab.transform.rotation);
        if (GameObject.FindGameObjectWithTag("pillar") != null)
        {
            GameObject.FindGameObjectWithTag("pillar").GetComponent<pillars>().changePos();
        }
        //swaping pillars
    }

    //method makes pillars to swap positions by moving around.


    public Vector3 generatePosition()
    {
        float xRangeN = -392.0f;
        float xRangeP = 325.0f;
        float zRangeN = -360.0f;
        float zRangeP = 375.0f;
        float yDefualt = 12.5f;
        float randomX = Random.Range(xRangeN, xRangeP);
        float randomZ = Random.Range(zRangeN, zRangeP);

        Vector3 newPos = new Vector3(randomX, yDefualt, randomZ);
        return newPos;
    }


    //get game Objecct check ifs its alive and return it
    public GameObject getGameObject(string tag)
    {
        if(GameObject.FindGameObjectWithTag(tag) != null)
        {
            return GameObject.FindGameObjectWithTag(tag);
        }
        return null;
    }

    //methods updates player points with TextMesh pro
    public void updatePoints()
    {
        if(getGameObject("fast_player") != null)
        {
            text_Points.text = "Fast Points: "+getGameObject("fast_player").GetComponent<fast_player>().fast_points_u;
            text_health.text = "Fast HP:" + getGameObject("fast_player").GetComponent<fast_player>().fast_player_health_u;

        }

        if (getGameObject("strong_player") != null)
        {
            text_Points.text = "Strong Points: " + getGameObject("strong_player").GetComponent<strong_player>().strong_points_u;
            text_health.text = "Strong HP:" + getGameObject("strong_player").GetComponent<strong_player>().strong_player_health_u;
        }
    }
  

 
    

}
