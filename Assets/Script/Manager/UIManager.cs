using System;
using UnityEngine;
using TMPro;
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
            _gameOverWindow.SetActive(false);
            _pauseWindow.SetActive(false);
            _HUDWindow.SetActive(true);
        }

        private void Update()
        {
            _flagManager._pointBlue = _uiPointBlue;
            _flagManager._pointRed = _uiPointRed;

            GameOver();
        }

        private void GameOver()
        {
            if (_timer.timer <= 0)
            {
                _HUDWindow.SetActive(false);
                _gameOverWindow.SetActive(true);
            }
        }

        public void Counter()
        {
            _pointsRed.text = _uiPointRed.ToString();
            _pointsBlue.text = _uiPointBlue.ToString();
        }
    }
}