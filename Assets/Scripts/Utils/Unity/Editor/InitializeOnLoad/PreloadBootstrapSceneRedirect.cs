using org.pseudochaos.EditorScripts;
using GameUtils;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class PreloadBootstrapSceneRedirect {

    private static readonly CustomLogger Logger = LogManager.getTypeLogger(typeof(PreloadBootstrapSceneRedirect));
    static PreloadBootstrapSceneRedirect() {
        EditorApplication.playModeStateChanged += LoadBootstrapScene;
    }


    static void LoadBootstrapScene(PlayModeStateChange state) {
        string bootstrapSceneAssetPath = $"{RuntimeSafeEditorSceneStateManager.getBootstrapSceneAssetPath()}";
        if (!RuntimeSafeEditorSceneStateManager.isAutoSceneRedirectionEnabled()) {
            RuntimeSafeEditorSceneStateManager.clear();
            return;
        }
        if (state == PlayModeStateChange.ExitingEditMode) { // ===> entering play mode
            Logger.Log($"ExitingEditMode. (EditorApplication.isPlaying: {EditorApplication.isPlaying})");

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().path != bootstrapSceneAssetPath) {
                Logger.Log($"Redirecting to bootstrap scene: {bootstrapSceneAssetPath} (current scene: {EditorSceneManager.GetActiveScene().path})");

                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

                EditorApplication.delayCall += () => {
                    RuntimeSafeEditorSceneStateManager.queueRedirectToCurrentScene();
                    Logger.Log($"Delayed call for ExitingEditMode. (EditorApplication.isPlaying: {EditorApplication.isPlaying})");
                    EditorSceneManager.OpenScene(bootstrapSceneAssetPath);
                    EditorApplication.isPlaying = true;
                };

                EditorApplication.isPlaying = false;
            }
        } else if (state == PlayModeStateChange.EnteredEditMode) { // ===> returning to edit mode
            string editorSceneAssetPath = RuntimeSafeEditorSceneStateManager.getRedirectSceneAssetPath();
            RuntimeSafeEditorSceneStateManager.clear();

            if (RuntimeSafeEditorSceneStateManager.isAutoSceneRedirectionEnabled() && editorSceneAssetPath != null && editorSceneAssetPath != string.Empty) {
                EditorSceneManager.OpenScene(editorSceneAssetPath);
                RuntimeSafeEditorSceneStateManager.clear();
            }
        }
    }
}