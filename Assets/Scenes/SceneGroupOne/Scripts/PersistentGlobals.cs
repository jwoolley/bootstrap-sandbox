using UnityEngine;

public class PersistentGlobals : MonoBehaviour {
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}