using UnityEngine;

public class PlayerTalk : MonoBehaviour
{
    public string[] lines = { "Hello", "I am walking", "Nice weather", "I need loot" };
    public float speakEverySeconds = 5f; // set to 60 later

    private string currentLine = "";
    private float nextTime;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        currentLine = lines[0];
        nextTime = Time.time + speakEverySeconds;
    }

    void Update()
    {
        if (Time.time >= nextTime)
        {
            currentLine = lines[Random.Range(0, lines.Length)];
            nextTime = Time.time + speakEverySeconds;
        }
    }

    void OnGUI()
    {
        if (cam == null) return;

        // THIS is the key line — ALWAYS above player
        Vector3 worldPos = transform.position + Vector3.up * 2f;

        Vector3 screenPos = cam.WorldToScreenPoint(worldPos);

        if (screenPos.z <= 0f) return;

        float x = screenPos.x - 100;
        float y = Screen.height - screenPos.y;

        GUI.Label(new Rect(x, y, 200, 30), currentLine);
    }
}