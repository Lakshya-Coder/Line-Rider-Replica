using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject lineNormalPrefab;
    public GameObject lineBouncyPrefab;
    public GameObject lineBoostPrefab;

    [SerializeField] private GameObject currentLinePrefab;
    

    private Line activeLine;
    private GameObject lineGo;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            currentLinePrefab = lineNormalPrefab;
        else if (Input.GetKey(KeyCode.Alpha2))
            currentLinePrefab = lineBouncyPrefab;
        else if (Input.GetKey(KeyCode.Alpha3))
            currentLinePrefab = lineBoostPrefab;
        
        if (Input.GetMouseButtonDown(Constants.LEFT_MOUSE_BUTTON))
        {
            lineGo = Instantiate(currentLinePrefab);
            activeLine = lineGo.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(Constants.LEFT_MOUSE_BUTTON))
        {
            activeLine = null;
            lineGo = null;
        }

        if (Input.GetKey(KeyCode.Escape) && lineGo != null)
        {
            lineGo.SetActive(false);
        }

        if (activeLine != null)
            activeLine.UpdateLine(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        if (Camera.main == null)
            return Vector2.zero;
        
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
} // class
