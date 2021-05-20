using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePrefs : MonoBehaviour
{
    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Tab)) {
            PlayerPrefs.DeleteKey("levelUnlocked");
            Debug.Log("levelUnlocked Deleted");
        }
    }
}
