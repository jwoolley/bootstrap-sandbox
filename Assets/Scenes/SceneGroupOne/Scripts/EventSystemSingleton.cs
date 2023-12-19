using GameUtils;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemSingleton : MonoBehaviour {
    [SerializeField]
    EventSystem eventSystem;

    private static readonly CustomLogger Logger = LogManager.getTypeLogger(typeof(EventSystemSingleton));

    public static EventSystemSingleton Instance { get => _instance; }
    private static EventSystemSingleton _instance;

    private void Awake() {
        Logger.Log("Awake() called", gameObject);
        if (_instance == null) {
            _instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
