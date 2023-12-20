using com.pseudochaos.EditorScripts;
using GameUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorInitManager : MonoBehaviour {
    private static readonly CustomLogger Logger = LogManager.getTypeLogger(typeof(EditorInitManager));

    private void Awake() {
        Logger.Log($"[EditorSceneStateManager (ScriptableSingleton)] isAutoSceneRedirectionEnabled: {RuntimeSafeEditorSceneStateManager.isAutoSceneRedirectionEnabled()}"
          + $"  isSceneRedirectQueued: {RuntimeSafeEditorSceneStateManager.isAutoSceneRedirectionEnabled()}"
          + $"  getRedirectSceneAssetPath: {RuntimeSafeEditorSceneStateManager.getRedirectSceneAssetPath()}");

        RuntimeSafeEditorSceneStateManager.queueSceneRedirect("SOME/OTHER/FAKE/PATH");
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
