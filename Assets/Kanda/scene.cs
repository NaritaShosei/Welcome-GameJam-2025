using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //�C�ӂ̃V�[�����ɐ؂�ւ���
    public static void LoadSceneByName(string ScneName)
    {
        SceneManager.LoadScene(ScneName);
    }

    //�V�[���ԍ��Ő؂�ւ�(�r���h��)
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    //���݂̃V�[���������[�h
    public void ReLoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
