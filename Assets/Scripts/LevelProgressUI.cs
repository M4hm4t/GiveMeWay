
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelProgressUI : MonoBehaviour
{

    [Header("UI references :")]
    [SerializeField] private Image uiFillImage;
    [SerializeField] private Text uiStartText;
    [SerializeField] private Text uiEndText;
    

   [Header("Player & Endline references :")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endLineTransform;
    private Vector3 endLinePosition;
    private float fullDistance;
    public int level1;
    public int level2 = 1;


    private void Start()
    {
        level1 = PlayerPrefs.GetInt("HighScore1", 0);
        level2 = PlayerPrefs.GetInt("HighScore2", 1);
        uiStartText.text = PlayerPrefs.GetInt("HighScore1", 0).ToString();
        uiEndText.text = PlayerPrefs.GetInt("HighScore2", 1).ToString();
        Invoke("SetLevelTexts", 9f);
        endLinePosition = endLineTransform.position;
        fullDistance = GetDistance();
    }


    public void HighScorerAdd()
    {
        //uiStartText.text = level1.ToString();
        //uiEndText.text = (level2+1).ToString();
        PlayerPrefs.SetInt("HighScore1", level1);
        PlayerPrefs.SetInt("HighScore2", level2);
        uiStartText.text = PlayerPrefs.GetInt("HighScore1", 0).ToString();
        uiEndText.text = PlayerPrefs.GetInt("HighScore2", 1).ToString();
    }

    public void SetLevelTexts()
    {

        level1++;
        level2++;
        uiStartText.text = level1.ToString();
        uiEndText.text = level2.ToString();
        HighScorerAdd();
    }


    private float GetDistance()
    {
        return (endLinePosition - playerTransform.position).sqrMagnitude;
    }


    private void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
    }


    private void Update()
    {

        if (playerTransform.position.z <= endLinePosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);
            UpdateProgressFill(progressValue);
        }
    }
}