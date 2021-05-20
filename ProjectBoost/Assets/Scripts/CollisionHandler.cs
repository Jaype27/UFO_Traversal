using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField] float _delayAmount = 1f;
    [SerializeField] AudioClip _winSound;
    [SerializeField] AudioClip _crashSound;

    [SerializeField] ParticleSystem _winParticles;
    [SerializeField] ParticleSystem _crashParticles;

    AudioSource _audio;

    bool _isTransitioning = false;
    bool _isCollisionDisabled = false;

    void Start() {
        _audio = GetComponent<AudioSource>();
    }

    void Update() {
        CheatNextLevel();
    }

    void CheatNextLevel() { // TODO: DELETE LATER
        if(Input.GetKeyDown(KeyCode.L)) {
            NextLevel();
        }
    }
    
    void OnCollisionEnter(Collision other) {
        
        if(_isTransitioning || _isCollisionDisabled) { return; }

        switch(other.gameObject.tag) {
           case "Finish":
                VictorySequence();
                break;
            case "Friendly":
                break;
            default:
                CrashSequence();
                break;
        }
    }

    void CrashSequence() {
        _isTransitioning = true;
        _audio.Stop();
        GetComponent<Movement>().enabled = false;
        _crashParticles.Play();
        _audio.PlayOneShot(_crashSound);
        Invoke("RestartLevel", _delayAmount);

    }
    void RestartLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


    void VictorySequence() {
        _isTransitioning = true;
        _audio.Stop();
        GetComponent<Movement>().enabled = false;
        _winParticles.Play();
        _audio.PlayOneShot(_winSound);
        Invoke("NextLevel", _delayAmount);
    }
    void NextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

        if(nextSceneIndex > PlayerPrefs.GetInt("levelUnlocked")) {
            PlayerPrefs.SetInt("levelUnlocked", nextSceneIndex);
        }
    }
}
