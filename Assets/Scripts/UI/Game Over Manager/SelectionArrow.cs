using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    private RectTransform rect;
    private int currentPosition;
    [SerializeField] private RectTransform[] options;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        //Change Position of the Selection Arrow
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            changePosition(-1);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            changePosition(1);

        //To Interact With Options
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            Interact();
    }

    private void changePosition(int change)
    {
        currentPosition += change;

        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
            currentPosition = 0;

        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
    }

    private void Interact()
    {
        options[currentPosition].GetComponent<Button>().onClick.Invoke();
    }
}


