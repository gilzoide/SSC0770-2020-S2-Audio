using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TopicoScene", menuName = "ScriptableObjects/TopicoScene")]
public class TopicoScene : ScriptableObject
{
    public Object scene;
    public string description;
}

[CreateAssetMenu(fileName = "TableOfContents", menuName = "ScriptableObjects/TableOfContents")]
public class TableOfContents : ScriptableObject
{
    public TopicoScene[] topicos;
}
