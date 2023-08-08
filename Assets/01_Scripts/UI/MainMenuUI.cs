using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _versionDisplay;

        private void Start()
        {
            _versionDisplay.text = "v" + Application.version;
        }

        public void OnPlayHumanVsHuman()
        {
            SceneManager.LoadScene("Main Level");
        }

        public void OnPlayHumanVsAI()
        {
            SceneManager.LoadScene("Main Level");
        }

        public void OnQuit()
        {
            Application.Quit();
        }
    }
}