using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Background Configs")]
    [SerializeField] private Renderer bgRenderer;
    [SerializeField] private float bgSpeed;

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            bgRenderer.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0);
        }
    }
}