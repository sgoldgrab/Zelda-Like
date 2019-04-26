//Copyright (c) Ewan Argouse - http://narudgi.github.io/

//using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystem
{
    public class Truc2UI : MonoBehaviour
    {
        [SerializeField] private Truc2 truc2 = default;
        [SerializeField] private Text text = default;

        private void Update()
        {
            text.text = truc2.Truc.ToString();
        }
    }
}
