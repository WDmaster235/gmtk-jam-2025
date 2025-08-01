using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausescreen : MonoBehaviour
{

    GameObject pauseScreen;
    bool work = false;

    private void Awake()
    {
        pauseScreen = GameObject.Find("PauseScreen");
    }

    // ???? ?? ??? ???????? ?????
    void Start()
    {
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!work)
            {
                pauseScreen.SetActive(true);
                work = !work;
            }
            else
            {
                pauseScreen.SetActive(false);
                work = !work;
            }
        }
    }

    private void FixedUpdate()
    {

    }

    public void ResumeButton()
    {
        pauseScreen.SetActive(false);
    }

    public void LevelSelectButton()
    {
        SceneManager.LoadScene("Level Select", LoadSceneMode.Single);
    }

    public void MainManue()
    {
        SceneManager.LoadScene("Main Manue", LoadSceneMode.Single);
    }


}
