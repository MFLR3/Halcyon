using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{    
    public void ExitToMenuOnClick(){
		SceneManager.LoadScene("Menu");

	}
	public void MenuStartGameOnClick(){
		SceneManager.LoadScene("Level_1_1");

	}
	public void MenuExitGameOnClick(){
		Application.Quit(); 
	}
	public void MenuOptionsOnClick(){
		SceneManager.LoadScene("Options");

	}
	public void Continue(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}

}