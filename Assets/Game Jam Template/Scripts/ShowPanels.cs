using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 
    public GameObject rolePanel;                            //Store a reference to the Game Object RolePanel
    public GameObject winPanel;                            //Store a reference to the Game Object RolePanel
    public GameObject losePanel;                            //Store a reference to the Game Object RolePanel

    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
		optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}

    public void ShowRoleSelction()
    {
        rolePanel.SetActive(true);
        optionsTint.SetActive(true);
    }

    public void HideRoleSelection()
    {
        rolePanel.SetActive(false);
        optionsTint.SetActive(false);
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        optionsTint.SetActive(false);
    }

    public void HideWinPanel()
    {
        winPanel.SetActive(false);
        optionsTint.SetActive(false);
    }

    public void ShowLosePanel()
    {
        winPanel.SetActive(true);
        optionsTint.SetActive(false);
    }

    public void HideLosePanel()
    {
        winPanel.SetActive(false);
        optionsTint.SetActive(false);
    }

    public void BackToMenu()
    {
        HideWinPanel();
        HidePausePanel();
        ShowMenu();
    }
}
