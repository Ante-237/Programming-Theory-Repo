using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    //points change box
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

    //defualt value for pillars swapping
    float swap_Value = 100.0f;


    private void Start()
    {
        createPlayer(choice);
        createPillars(pillars_To_leave());
        InvokeRepeating("create_point_box", 10,repeatRate);
        //test method
        
    }

    private void LateUpdate()
    {
        move_To_newPost(true);

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
    }

    //method makes pillars to swap positions by moving around.
    void move_To_newPost(bool swap_us)
    {
        //speed for swapping
        //if (swap_us)
       // {
            float step = swap_Value * Time.deltaTime;
            //we first get all the pillars in the scene
            GameObject[] pillars_inScene = GameObject.FindGameObjectsWithTag("pillar");

            Transform[] positions_pillars = new Transform[pillars_inScene.Length];
            for (int i = 0; i < pillars_inScene.Length; i++)
            {
                positions_pillars[i] = pillars_inScene[pillars_inScene.Length - i].transform;
            }
            //take each object and move it.
            int count = 0;
            foreach (GameObject pillar in pillars_inScene)
            {
                moveObject(pillar, step, positions_pillars[count]);
                Debug.Log("Method is called ${count}");
                count++;
            }
     //   }


    }

    //move object base on the speed and target received
    void moveObject(GameObject objectToMove, float speed, Transform target)
    {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, target.position, speed);
    }

    //method to test method
 
    

}
