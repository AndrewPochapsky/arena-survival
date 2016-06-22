using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

    [SerializeField]
    private RectTransform healthBarRect;
    [SerializeField]
    private Text healthText;

    void Start()
    {
        if (healthBarRect == null)
        {
            Debug.LogError("STATUS INDICATOR: No HealthBar object referenced.");
        }
        if (healthText == null)
        {
            Debug.LogError("STATUS INDICATOR: No HealthText object referenced.");
        }
    }

    public void SetHealth(int _current, int _max)
    {
        float _value = (float)_current / _max;

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);
        healthText.text = _current + "/" + _max + " HP";
    }

}
