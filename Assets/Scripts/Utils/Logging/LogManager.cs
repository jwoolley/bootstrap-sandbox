using System;
using System.Collections.Generic;

namespace GameUtils {
    public static class LogManager {

        public static CustomLogger getTypeLogger(Type type) {
            if (!typeLoggers.ContainsKey(type)) {
                typeLoggers.Add(type, new CustomLogger($"[{type.Name}] "));
            }
            return typeLoggers[type];
        }

        public static CustomLogger getPrefixLogger(String customPrefix) {
            if (!customPrefixLoggers.ContainsKey(customPrefix)) {
                customPrefixLoggers.Add(customPrefix, new CustomLogger($"[{customPrefix}] "));
            }
            return customPrefixLoggers[customPrefix];
        }

        private static Dictionary<Type, CustomLogger> typeLoggers = new Dictionary<Type, CustomLogger>();

        private static Dictionary<string, CustomLogger> customPrefixLoggers = new Dictionary<string , CustomLogger>();

        public static CustomLogger DebugLogger = new CustomLogger("DebugLogger");
    }
}