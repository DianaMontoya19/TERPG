using HadFlag;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PlayerController1
{
    [Serializable]
    public class PlayerController : MonoBehaviour, IHadFlag
    {
        [SerializeField] private bool _flag = false;
        [SerializeField] private GameObject _flagPlayer;
        public GameObject _player;

        private void Update()
        {
            var player = FindObjectOfType<Flag>();

            if(player.follow == true)
            {
              _player.transform.position = gameObject.transform.position;
            }
        }

        public void WhoHadFlag()
        {
            _flag = true;
            _flagPlayer.SetActive(true); 

            

            Debug.Log("yo tengo la bandera");
        }
    }

    
}