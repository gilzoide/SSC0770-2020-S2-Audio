using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopicoButton : MonoBehaviour
{
    public TopicoScene topico;
    public Text title;

    void Awake()
    {
        if (!title)
        {
            title = GetComponentInChildren<Text>();
        }
    }

    [ContextMenu("Setup")]
    void Start()
    {
        string format = SceneManager.GetActiveScene().buildIndex == topico.indexCena
            ? "<b>{0} - {1}</b>"
            : "{0} - {1}";
        title.text = string.Format(format, transform.GetSiblingIndex() + 1, topico.description);
    }

    public void GoToTopico()
    {
        SceneManager.LoadScene(topico.indexCena);
    }
}
