using UnityEngine;

public class Paddle : MonoBehaviour
    
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    // cached references
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        //float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        //Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp (GetXPos() /*mousePosInUnits*/, minX, maxX);
        transform.position = paddlePos;
    }
    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnable())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
