using GameUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePersistedButtonController : MonoBehaviour {

    private static readonly CustomLogger Logger = LogManager.getTypeLogger(typeof(ExamplePersistedButtonController));

    public void onClick() {
        Logger.Log("Test");
    }
}
