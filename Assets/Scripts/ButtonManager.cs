using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] List<Button> buttons;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var button in buttons) 
        { 
            if (button.name=="StartGameButton")
            {
                button.onClick.AddListener(StartGame);
            }
            if (button.name=="ExitGameButton")
            {
                button.onClick.AddListener(QuitGame);
            }
        }
    }

   void StartGame()
    {
        Debug.Log("You have clicked the start button");
        SceneManager.LoadScene("GameScene");
    }

    void QuitGame()
    {
        Debug.Log("You have clicked the exit button");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
    
#endif
    }

}
