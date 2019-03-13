using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSwitcher : MonoBehaviour
{
    UnitySceneSwitch _switch;

    void Awake()
    {
        _switch = GetComponent<UnitySceneSwitch>();
    }

    public void LoadA()
    {
        LoadAndUnload(new SceneType[] { SceneType.A }, null);
    }

    public void UnloadA()
    {
        LoadAndUnload(null, new SceneType[] { SceneType.A });
    }

    public void LoadAUnloadB()
    {
        LoadAndUnload(new SceneType[] { SceneType.A }, new SceneType[] { SceneType.B });
    }

    public void LoadB()
    {
        LoadAndUnload(new SceneType[] { SceneType.B }, null);
    }

    public void UnloadB()
    {
        LoadAndUnload(null, new SceneType[] { SceneType.B });
    }

    public void LoadBUnloadA()
    {
        LoadAndUnload(new SceneType[] { SceneType.B }, new SceneType[] { SceneType.A });
    }

    public void LoadAndUnload(SceneType[] loadedSceneTypes, SceneType[] unloadedSceneTypes)
    {
        if (loadedSceneTypes != null)
        {
            foreach (var sceneType in loadedSceneTypes)
            {
                Debug.LogFormat("Load: {0}", sceneType);
                _switch.Load(GetUnitySceneSwitchData(sceneType));
            }
        }
        if (unloadedSceneTypes != null)
        {
            foreach (var sceneType in unloadedSceneTypes)
            {
                Debug.LogFormat("Unload: {0}", sceneType);
                _switch.Unload(GetUnitySceneSwitchData(sceneType));
            }
        }
    }

    UnitySceneSwitchData GetUnitySceneSwitchData(SceneType sceneType)
    {
        return new UnitySceneSwitchData(
            (int)sceneType,
            () =>
            {
                Debug.LogFormat("in progress: {0}", sceneType);
            },
            () =>
            {
                Debug.LogFormat("check finish: {0}", sceneType);
                return true;
            }
        );
    }
}
