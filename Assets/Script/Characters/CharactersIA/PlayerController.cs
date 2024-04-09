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

        //private void Update()
        //{
        //    //Position();
        //}

        public void WhoHadFlag()
        {
            //_flag = true;
            _flagPlayer.SetActive(true); 
            Debug.Log("yo tengo la bandera");
        }
        public void Position()
        {
            _player.transform.parent = this.transform;
            Debug.Log("yo soy el padre");
        }
    }

    
}