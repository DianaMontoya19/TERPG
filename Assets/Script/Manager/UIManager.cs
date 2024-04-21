using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        
        [Header("Windows")] //Windows
        [SerializeField] private GameObject _HUDWindow;
        [SerializeField] private GameObject _pauseWindow;
        [SerializeField] private GameObject _gameOverWindow;
        
        [Header("Game Over Counter")] //Game Over Counter
        [SerializeField] private FlagManager _flagManager;
        [SerializeField] private TextMeshProUGUI _pointsBlue;
        [SerializeField] private TextMeshProUGUI _pointsRed;
        private int _uiPointBlue;
        private int _uiPointRed;
        

        private void Start()
        {
            // _flagManager = GetComponent<FlagManager>();
            _gameOverWindow.SetActive(false);
            _pauseWindow.SetActive(false);
            _HUDWindow.SetActive(true);
        }

        private void Update()
        {
            
            
            // _uiPointBlue = -_flagManager._pointBlue;
            // _uiPointRed =_flagManager._pointRed ;
            

            GameOver();
        }

        private void GameOver()
        {
            if (_timer.timer <= 0)
            {
                _HUDWindow.SetActive(false);
                _gameOverWindow.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        public void Counter()
        {
            var Blue = FlagManager.Instance;
            Blue._teamBlue.text = Blue._pointBlue.ToString("f0");
            // _pointsRed.text = _uiPointRed.ToString();
            // _pointsBlue.text = _uiPointBlue.ToString();
        }
        
        public void ReturnMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        public void ReturnSelectCharacters()
        {
            _timer.RestartTimer();
            SceneManager.LoadScene(1);
            
            
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        
        }
    
}