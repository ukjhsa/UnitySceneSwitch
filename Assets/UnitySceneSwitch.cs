using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitySceneSwitch : MonoBehaviour
{
    public void Load(UnitySceneSwitchData data)
    {
        var ao = SceneManager.LoadSceneAsync(data.SceneIndex, LoadSceneMode.Additive);
        Common(ao, data);
    }

    public void Unload(UnitySceneSwitchData data)
    {
        if (IsSceneExist(data.SceneIndex))
        {
            var ao = SceneManager.UnloadSceneAsync(data.SceneIndex, UnloadSceneOptions.None);
            Common(ao, data);
        }
    }

    void Common(AsyncOperation ao, UnitySceneSwitchData data)
    {
        ao.allowSceneActivation = false;
        ao.priority = data.Priority;

        StartCoroutine(Run(ao, data));
    }

    bool IsSceneExist(int buildIndex)
    {
        for (int i = 0; i < SceneManager.sceneCount; ++i)
        {
            var scene = SceneManager.GetSceneAt(i);
            if (scene.buildIndex == buildIndex)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator Run(AsyncOperation ao, UnitySceneSwitchData data)
    {
        while (!ao.isDone)
        {
            // Check if the progress has finished
            if (ao.progress >= 0.9f)
            {
                data.CallbackInProgress?.Invoke();

                var allowSceneActivation = false;
                if (data.CallbackWhenFinish != null)
                {
                    // Activate scene if condition returns true
                    if (data.CallbackWhenFinish())
                    {
                        allowSceneActivation = true;
                    }
                }
                else
                {
                    // Activate scene if no condition
                    allowSceneActivation = true;
                }

                ao.allowSceneActivation = allowSceneActivation;
            }

            yield return null;
        }
    }
}
