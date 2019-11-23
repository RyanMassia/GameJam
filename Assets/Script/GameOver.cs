using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public playerlives playerLives;
    public float restartDelay = 5f;

    Animator anim;
    float restartTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLives == 0)
        {
            Debug.Log "GameOver";

            restartTimer += Time.deltaTime;
            if(restartTimer >= restartDelay)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
