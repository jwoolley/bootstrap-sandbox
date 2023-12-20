using GameUtils;
using UnityEditor;
using UnityEngine;
namespace com.pseudochaos.EditorScripts {
#if UNITY_EDITOR
    [FilePath("Experimental/SceneState.editorprefs", FilePathAttribute.Location.PreferencesFolder)]
    class EditorSceneStateManager : ScriptableSingleton<EditorSceneStateManager> {

        private static readonly CustomLogger Logger = LogManager.getTypeLogger(typeof(EditorSceneStateManager));

        [SerializeField]
        private bool isRedirectionEnabled;

        [SerializeField]
        private string redirectSceneAssetPath;

        [SerializeField]
        private bool isRedirectQueued;

        public bool isAutoSceneRedirectionEnabled() {
            return isRedirectionEnabled;
        }

        public bool isSceneRedirectQueued() {
            return isRedirectQueued;
        }

        public string getRedirectSceneAssetPath() {
            return redirectSceneAssetPath;
        }
        public void queueSceneRedirect(string redirectSceneAssetPath) {
            Logger.Log($"Queuing scene redirect {redirectSceneAssetPath}");
            this.redirectSceneAssetPath = redirectSceneAssetPath;
            isRedirectQueued = true;
        }

        public void clear() {
            this.redirectSceneAssetPath = string.Empty;
            isRedirectQueued = false;
        }
    }
#endif

    public static class RuntimeSafeEditorSceneStateManager {

        private static readonly CustomLogger Logger = LogManager.getTypeLogger(typeof(RuntimeSafeEditorSceneStateManager));
        public static bool isAutoSceneRedirectionEnabled() {
#if UNITY_EDITOR
            return EditorSceneStateManager.instance.isAutoSceneRedirectionEnabled();
#else
            return false;
#endif
        }

        public static bool isSceneRedirectQueued() {
#if UNITY_EDITOR
            return EditorSceneStateManager.instance.isSceneRedirectQueued();
#else
            Logger.LogWarning("Unexpected call to isSceneRedirectQueued(): not in editor mode");
            return false;
#endif
        }

        public static string getRedirectSceneAssetPath() {
#if UNITY_EDITOR
            return EditorSceneStateManager.instance.getRedirectSceneAssetPath();
#else
            Logger.LogWarning("Unexpected call to getRedirectSceneAssetPath(): not in editor mode");
            return string.Empty;
#endif
        }
        public static void queueSceneRedirect(string redirectSceneAssetPath) {
#if UNITY_EDITOR
            EditorSceneStateManager.instance.queueSceneRedirect(redirectSceneAssetPath);
#else
            Logger.LogWarning("Unable to queue scene redirect: not in editor mode");
#endif
        }

        public static void clear() {
#if UNITY_EDITOR
            EditorSceneStateManager.instance.clear();
#else
            Logger.LogWarning("Unable to clear state: not in editor mode");
#endif
        }
    }
}
