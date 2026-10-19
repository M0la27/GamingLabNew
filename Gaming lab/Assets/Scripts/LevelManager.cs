using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;

    void Start()
    {
        CurrentCheckpoint = null;
    }

    void Update()
    {
    }

    public void RespawnPlayer()
    {
        FindObjectOfType<Movement>().transform.position =
            CurrentCheckpoint.transform.position;
    }
}