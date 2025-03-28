using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Test");
    }

    public void Exit()
    {
		Application.Quit();
	}
}
