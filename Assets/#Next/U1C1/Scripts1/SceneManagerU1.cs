using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace crim
{
    public class SceneManagerU1 : MonoBehaviour
    {
        private void Start()
        {

        }
        private void Update()
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TEST")
            {

            }
        }

        public void Challenge()
        { UnityEngine.SceneManagement.SceneManager.LoadScene("Challenge 1"); }
        public void Protorype()
        { UnityEngine.SceneManagement.SceneManager.LoadScene("Prototype 1"); }



    }
}