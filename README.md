# UnitySceneSwitch
UnitySceneSwitch encapsulate operations of loading or unloading scene asynchronously

see [UnitySceneSwitch.cs](Assets/UnitySceneSwitch.cs) and [UnitySceneSwitchData.cs](Assets/UnitySceneSwitchData.cs)

## Run

Tested on Unity 2018.3.8f1

## Usage

Construct `UnitySceneSwitchData` by:
1. `SceneIndex`: the scene index in build setting
1. `CallbackInProgress`: the delegate called in each progress
1. `CallbackWhenFinish`: the delegate called in each progress finish checking
1. `Priority`" the priority used by `UnityEngine.AsyncOperation`

```csharp
UnitySceneSwitchData _loadedData = new UnitySceneSwitchData(
    sceneBuildIndex,                                    // scene index
    () => { Debug.Log("in progress"); },                // progress delegate
    () => { Debug.Log("check finish"); return true; },  // check delegate
    1                                                   // priority
);
```

Then call `UnitySceneSwitch.Load` or `UnitySceneSwitch.Unload`

```csharp
UnitySceneSwitch _switch = GetComponent<UnitySceneSwitch>();

_switch.Load(_loadedData);
```

## Note

If the scene to unload doesn't exist in current scenes, it has nothing to do.
