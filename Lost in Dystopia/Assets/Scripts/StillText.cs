using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class StillText
    {
        public bool active;
        public GameObject go;
        public Text txt;


        public void Show()
        {
            active = true;
            go.SetActive(true);
        }

        public void Hide()
        {
            active = false;
            go.SetActive(false);
        }
    }
}
