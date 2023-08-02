using Artemida.Tools;
using System;

public class GameManager : PersistentSingleton<GameManager>
{
    private GameState _currentState;
    private event Action<GameState> _onGameStateChanged;

    public GameState GetGameState() => _currentState;

    public void Initialize()
    {
        _currentState = GameState.Start;
        _onGameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        print("Game State chagned to " + state.ToString());
    }

    public void UpdateGameState(GameState state)
    {
        if (_currentState == state) return;
        _currentState = state;
        _onGameStateChanged?.Invoke(state);

        switch(state)
        {
            case GameState.Start:
                break;
            case GameState.MainMenu:
                break;
            case GameState.OpenLevel:
                break;
            case GameState.Game:
                //if (!Player.Instance)
                    Player.Instance.Initialize();
                break;
            case GameState.Pause:
                break;
            case GameState.Inventory:
                break;
        }
    }
}
