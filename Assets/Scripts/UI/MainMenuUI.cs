using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject highScoresButton;
    [SerializeField] private GameObject returnToMainMenuButton;

    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject instructionsButton;

    private bool isInstructionSceneLoaded = false;
    private bool isHighScoresSceneLoaded = false;

    private void Start()
    {
        // Play Music
        MusicManager.Instance.PlayMusic(GameResources.Instance.mainMenuMusic, 0f, 2f);

        // Load Character selector scene additively
        SceneManager.LoadScene("CharacterSelectorScene", LoadSceneMode.Additive);

        returnToMainMenuButton.SetActive(false);

    }

    /// <summary>
    /// Called from the Play Game / Enter The Dungeon Button
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    /// <summary>
    /// Called from the High Scores Button
    /// </summary>
    public void LoadHighScores()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        highScoresButton.SetActive(false);
        instructionsButton.SetActive(false);
        isHighScoresSceneLoaded = true;

        SceneManager.UnloadSceneAsync("CharacterSelectorScene");

        returnToMainMenuButton.SetActive(true);

        // Load High Score scene additively
        SceneManager.LoadScene("HighScoreScene", LoadSceneMode.Additive);
    }

    /// <summary>
    /// Called from the Return To Main Menu Button
    /// </summary>
    public void LoadCharacterSelector()
    {
        returnToMainMenuButton.SetActive(false);

        if (isHighScoresSceneLoaded)
        {
            SceneManager.UnloadSceneAsync("HighScoreScene");
            isHighScoresSceneLoaded = false;
        }
        else if (isInstructionSceneLoaded)
        {
            SceneManager.UnloadSceneAsync("InstructionsScene");
            isInstructionSceneLoaded = false;
        }


        playButton.SetActive(true);
        quitButton.SetActive(true);
        instructionsButton.SetActive(true);
        highScoresButton.SetActive(true);

        // Load character selector scene additively
        SceneManager.LoadScene("CharacterSelectorScene", LoadSceneMode.Additive);
    }

    /// <summary>
    /// Called from the Instructions Button
    /// </summary>
    public void LoadInstructions()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        highScoresButton.SetActive(false);
        instructionsButton.SetActive(false);
        isInstructionSceneLoaded = true;

        SceneManager.UnloadSceneAsync("CharacterSelectorScene");

        returnToMainMenuButton.SetActive(true);

        // Load instructions scene additively
        SceneManager.LoadScene("InstructionsScene", LoadSceneMode.Additive);
    }

    /// <summary>
    /// Quit the game - this method is called from the onClick event set in the inspector
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}