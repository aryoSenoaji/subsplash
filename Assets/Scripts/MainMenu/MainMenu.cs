using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credit;
    public GameObject mainMenu;
    public string startScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void Credits()
    {
        credit.SetActive(true);
        mainMenu.SetActive(false);
    }

    
}
