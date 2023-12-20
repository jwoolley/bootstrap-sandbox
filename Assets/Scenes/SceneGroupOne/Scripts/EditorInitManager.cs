using org.pseudochaos.EditorScripts;
using GameUtils;
using UnityEngine;

public class EditorInitManager : MonoBehaviour {
    private static readonly CustomLogger Logger = LogManager.getTypeLogger(typeof(EditorInitManager));

    private void Awake() {
        Logger.Log($"[EditorSceneStateManager (ScriptableSingleton)] isAutoSceneRedirectionEnabled: {RuntimeSafeEditorSceneStateManager.isAutoSceneRedirectionEnabled()}"
          + $"  isSceneRedirectQueued: {RuntimeSafeEditorSceneStateManager.isAutoSceneRedirectionEnabled()}"
          + $"  getRedirectSceneAssetPath: {RuntimeSafeEditorSceneStateManager.getRedirectSceneAssetPath()}");

        // TODO: this does *NOT* belong here. the real call should go in an InitializeOnLoad script. just testing!ss
        // RuntimeSafeEditorSceneStateManager.queueRedirectToCurrentScene();
        if (RuntimeSafeEditorSceneStateManager.isAutoSceneRedirectionEnabled() && RuntimeSafeEditorSceneStateManager.isSceneRedirectQueued()) {
            RuntimeSafeEditorSceneStateManager.redirectToSceneInPlayMode(RuntimeSafeEditorSceneStateManager.getRedirectSceneAssetPath());
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
