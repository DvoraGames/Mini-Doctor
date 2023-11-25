using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DashBTNScript : MonoBehaviour
{
    [Header("Dash BTN Configs")]
    [SerializeField] private Button dashBTN;
    [SerializeField] private TextMeshProUGUI dashText;
    [SerializeField] private float dashTimer;
    [SerializeField] private float dashCoolDown;

    public static bool canDash = true;
    public static bool isDashing = false;

    private void Update()
    {
        if (canDash)
        {
            dashBTN.interactable = true;
        }
        else if (!canDash)
        {
            dashBTN.interactable = false;
        }
    }

    public IEnumerator DashTimer()
    {
        canDash = false;
        isDashing = true;
        yield return new WaitForSeconds(dashTimer);
        isDashing = false;
        StartCoroutine(CoolDownDash());
    }

    private IEnumerator CoolDownDash()
    {
        float i = dashCoolDown;

        while (i > 0)
        {
            dashBTN.GetComponentInChildren<TMP_Text>().text = $"{i}";
            yield return new WaitForSeconds(1.0f);
            i--;
        }

        dashBTN.interactable = true;
        canDash = true;
        dashBTN.GetComponentInChildren<TMP_Text>().text = $"Dash";
    }
}
