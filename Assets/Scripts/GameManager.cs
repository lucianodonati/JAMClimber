using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }
        public        TMP_Text    txt;

        private void Awake()
        {
            Instance = this;
        }

        public void Lose(bool loserP1)
        {
            txt.text = loserP1? "GANO VERDE!" : "GANO AZUL!";
        }
    }
}