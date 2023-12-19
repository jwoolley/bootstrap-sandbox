using System;
using UnityEngine;

public class CustomLogger : Logger {

    public CustomLogger(string prefix) : this(prefix, new DeafultLogHandler()) { }

    public CustomLogger(string prefix, ILogHandler logHandler) : base(logHandler) {
        _prefix = prefix;
    }

    private object prefix(object message) {
        return $"{_prefix}: {message}";
    }

    private readonly string _prefix;
    private bool _enabled = true;

    public void enable() {
        _enabled = true;
    }
    public void disable() {
        _enabled = false;
    }

    new public void Log(LogType logType, object message) {
        if (_enabled) {
            base.Log(logType, message);
        }
    }

    new public void Log(LogType logType, object message, UnityEngine.Object context) {
        if (_enabled) {
            base.Log(logType, prefix(message), context);
        }
    }

    new public void Log(LogType logType, string tag, object message) {
        if (_enabled) {
            base.Log(logType, tag, prefix(message));
        }
    }

    new public void Log(LogType logType, string tag, object message, UnityEngine.Object context) {
        if (_enabled) {
            base.Log(logType, tag, prefix(message), context);
        }
    }

    new public void Log(object message) {
        if (_enabled) {
            base.Log(prefix(message));
        }
    }

    new public void Log(string tag, object message) {
        if (_enabled) {
            base.Log(tag, prefix(message));
        }
    }

    new public void Log(string tag, object message, UnityEngine.Object context) {
        if (_enabled) {
            base.Log(tag, prefix(message), context);
        }
    }

    public void LogWarning(object message) {
        if (_enabled) {
            base.Log(LogType.Warning, prefix(message));
        }
    }

    new public void LogWarning(string tag, object message) {
        if (_enabled) {
            base.LogWarning(tag, prefix(message));
        }
    }

    new public void LogWarning(string tag, object message, UnityEngine.Object context) {
        if (_enabled) {
            base.LogWarning(tag, prefix(message), context);
        }
    }
    public void LogError(object message) {
        if (_enabled) {
            base.Log(LogType.Error, prefix(message));
        }
    }
    new public void LogError(string tag, object message) {
        if (_enabled) {
            base.LogError(tag, prefix(message));
        }
    }

    new public void LogError(string tag, object message, UnityEngine.Object context) {
        if (_enabled) {
            base.LogError(tag, prefix(message), context);
        }
    }

    new public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args) {
        if (_enabled) {
            base.LogFormat(logType, context, format, args);
        }
    }

    new public void LogException(Exception exception) {
        if (_enabled) {
            base.LogException(exception);
        }

    }

    new public void LogException(Exception exception, UnityEngine.Object context) {
        if (_enabled) {
            logHandler.LogException(exception, context);
        }
    }

    // ===== end boilerplate wrapper code ====

    public class DeafultLogHandler : ILogHandler {
        public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args) {
            Debug.unityLogger.logHandler.LogFormat(logType, context, format, args);
        }

        public void LogException(Exception exception, UnityEngine.Object context) {
            Debug.unityLogger.LogException(exception, context);
        }
    }
}