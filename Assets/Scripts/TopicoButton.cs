using System.Collections;
using System.Collections.Generic;
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
        title.text = string.Format("{0} - {1}", transform.GetSiblingIndex() + 1, topico.description);
    }

    public void GoToTopico()
    {
        SceneManager.LoadScene(topico.indexCena);
    }
}
