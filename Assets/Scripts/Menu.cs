#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameManager gameManager_Script;
    public TextMeshProUGUI player_Name;
    public TextMeshProUGUI bestScore_Text;

    private void Awake()
    {
        gameManager_Script = FindObjectOfType<GameManager>();
        gameManager_Script.Load_PlayerData();
        bestScore_Text.text = "Best Score : " + gameManager_Script.p_bestName + " : "
                                              + gameManager_Script.p_bestScore.ToString();
    }


    public void Start_Game()
    {
        gameManager_Script.p_Name = player_Name.text.ToString();
        SceneManager.LoadScene(1);
    }


    public void Exit_Game()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
