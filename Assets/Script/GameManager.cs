using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lives;
    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance !=this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPointSave()
    {
        var times = LoadCheckPoint();

        var newTime = new SpawnPoint();
        newTime.entryDate = DateTime.Now;
        newTime.Time = Time;
    }

    private object LoadCheckPoint()
    {
        throw new NotImplementedException();
    }

    private class SpawnPoint
    {
        internal DateTime entryDate;

        public SpawnPoint()
        {
        }
    }

    public void Gameover()
    {
        if (lives == 0)
        Debug.Log "Gameover";
         
    }
}
