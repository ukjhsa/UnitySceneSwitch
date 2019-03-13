using System;

public class UnitySceneSwitchData
{
    public int SceneIndex { get; }
    public Action CallbackInProgress { get; }
    public Func<bool> CallbackWhenFinish { get; }
    public int Priority { get; }

    public UnitySceneSwitchData(int buildIndex, Action inProgress = null, Func<bool> whenFinish = null, int priority = 1)
    {
        SceneIndex = buildIndex;
        CallbackInProgress = inProgress;
        CallbackWhenFinish = whenFinish;
        Priority = priority;
    }
}
