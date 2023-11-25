using UnityEngine;
using UnityEngine.UI;

public class MusicBTNScript : MonoBehaviour
{
    [Header("Dependências")]

    [SerializeField] private Button musicButton;
    [SerializeField] private Sprite onImage;
    [SerializeField] private Sprite offImage;
    [SerializeField] private AudioSource audioSource;

    private bool isOn;

    private void Start()
    {
        isOn = true;
    }

    public void MuteUnmute()
    {
        if (isOn)
        {
            musicButton.image.sprite = offImage;
            isOn = false;
            audioSource.mute = true;
        }
        else if (!isOn)
        {
            musicButton.image.sprite = onImage;
            isOn = true;
            audioSource.mute = false;
        }
    }

}
