using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    [SerializeField] Button[] _levelButtons;

    // Start is called before the first frame update
    void Start() {
        int levelUnlocked = PlayerPrefs.GetInt("levelUnlocked", 2);

        for(int i = 0; i < _levelButtons.Length; i++) {
            if(i + 2 > levelUnlocked) {
                _levelButtons[i].interactable = false;
            }
        }
    }

    public void SelectLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }
}
