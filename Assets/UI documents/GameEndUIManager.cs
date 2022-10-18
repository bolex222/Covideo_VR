using UI_documents;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Interfaces;

public class GameEndUIManager : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;

    private Label _winnerTeam;
    private Label _draw;
    private Button _playAgainButton;
    private Button _mainMenuButton;

    private VisualElement _gameEndUIElement;

    private void Setup()
    {
        _gameEndUIElement = uiDocument.rootVisualElement;
        _playAgainButton = _gameEndUIElement.Q<Button>("play-again-button");
        _mainMenuButton = _gameEndUIElement.Q<Button>("main-menu-button");
        _winnerTeam = _gameEndUIElement.Q<Label>("winner-team");
        _draw = _gameEndUIElement.Q<Label>("draw");

        _playAgainButton.clicked += PlayAgainButtonPressed;
        _mainMenuButton.clicked += MainMenuButtonPressed;
    }

    private void PlayAgainButtonPressed()
    {
        SceneManager.LoadScene("Matchmaking");
    }

    private void MainMenuButtonPressed()
    {
        SceneManager.LoadScene("Lobby");
    }

    private void OnEnable()
    {
        Setup();
    }

    public void GameEndTeamWin(AllGenericTypes.Team winnerTeam)
    {
        _winnerTeam.text = winnerTeam.ToString().Insert(4, " ");
    }

    public void GameEndDraw(AllGenericTypes.Team winnerTeam)
    {
        _draw.text = winnerTeam.ToString();
    }
}
