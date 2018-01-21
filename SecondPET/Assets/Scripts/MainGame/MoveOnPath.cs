using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour {

    public MakePath PathToFollow;
    public AudioSource AS;
    public AudioClip levelComplete;
    public int CurrentWayPointID = 0;
    public float Speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;

    Vector2 last_position;
    Vector2 current_position;


    public enum acceleration{
        increase,
        decrease,
        normal
    }

    public acceleration acc;

	void Start () {
        last_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position,Speed * Time.deltaTime);

        if(distance <= reachDistance)
        {
            CurrentWayPointID++;
        }
        if (CurrentWayPointID == PathToFollow.path_objs.Count)
        {
            FindObjectOfType<GameOverController>().isFinish = true;
            FindObjectOfType<PlayerBehav>().GameOver();
            AS.PlayOneShot(levelComplete);
            if (Application.loadedLevel == 5 && PlayerPrefs.GetInt("Level") < 2){
                PlayerPrefs.SetInt("Level", 2);
            }
            if (Application.loadedLevel == 6 && PlayerPrefs.GetInt("Level") < 3)
            {
                PlayerPrefs.SetInt("Level", 3);
            }
        }
	}
}
