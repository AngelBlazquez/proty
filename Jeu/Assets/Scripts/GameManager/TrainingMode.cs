using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrainingMode
{

    private static bool isTraining = false;
    private static int saveDelaySeconds = 2;

    public static Vector3 lastPosition;
    public static bool canSavePosition = true;

    public static void SetTrainingMode(bool train)
    {
        isTraining = train;
    }

    public static bool GetIsTraining() { return isTraining; }

    public static int GetSeconds() { return saveDelaySeconds; }

}
