using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutAutoResize : MonoBehaviour
{
    internal void Awake() {
        GridLayoutGroup gridLayout = gameObject.GetComponent<GridLayoutGroup>();
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 newSize = new Vector2(rectTransform.rect.width / 2, rectTransform.rect.height / 2);
        gridLayout.cellSize = newSize;
    }
}
