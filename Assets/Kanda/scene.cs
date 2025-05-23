using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //任意のシーン名に切り替える
    public static void LoadSceneByName(string ScneName)
    {
        SceneManager.LoadScene(ScneName);
    }

    //シーン番号で切り替え(ビルド準)
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    //現在のシーンをリロード
    public void ReLoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
