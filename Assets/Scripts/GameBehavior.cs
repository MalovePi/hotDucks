using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    private string _labelText = "Collect all 4 HotDog and win your freedom!";
    [SerializeField] private GUIStyle textStyle;    
    [SerializeField] private int maxItems = 4;

    private bool _showWinScreen = false;
    private bool _showLossScreen = false;
    private int _playerHP = 3;
    private int _itemsCollected;
      
    public int Items
    {
        get
        {
            return _itemsCollected;
        }
        set
        {
            _itemsCollected = value;            
            if (_itemsCollected >= maxItems)
            {
                _showWinScreen = ShowScreen("You've found all the HotDog");                            
            }
            else
            {
                _labelText = "HotDog found, only " + (maxItems - _itemsCollected) + " more to go";
            }
        }
    }

    public int PlayerHP
    {
        get
        {
            return _playerHP;
        }
        set
        {
            _playerHP = value;            
            if (_playerHP <= 0)
            {
                _showLossScreen = ShowScreen("You want another life with thet?");                          
            }
            else
            {
                _labelText = "Ouch...";
            }          
       }
    }
       
    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Healse: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "HotDog Collected: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width/2 - 100, Screen.height-50, 300,50), _labelText, textStyle);
        
        if (_showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "YOU WON!"))
            {
                Utilities.RestartLevel(0);
            }
        }

        if (_showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel();
            }
        }
    }

    bool ShowScreen(string text)
    {
        _labelText = text;
        Time.timeScale = 0f;
        return true;
    }

}
