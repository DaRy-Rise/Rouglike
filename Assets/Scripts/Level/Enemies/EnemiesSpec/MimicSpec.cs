using UnityEngine;

public class MimicSpec : MonoBehaviour
{
    private PlayerMovement player;
    private float distToShow = 5, opDist, distToHide = 20;
    [SerializeField]
    private Sprite[] hideForms;
    [SerializeField]
    private Sprite realForm;
    private Sprite choosenHideForm;
    private EnemyMovement movement;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        movement = gameObject.GetComponent<EnemyMovement>();
    }
    private void Start()
    {
        int i = Random.Range(0, hideForms.Length);
        choosenHideForm = hideForms[i];
        Hide();
    }
    private void FixedUpdate()
    {
        CheckVisibility();
    }
    private void CheckVisibility()
    {
        opDist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (opDist > distToHide)
        {
            Hide();
        }
        else if (opDist <= distToShow)
        {
            ShowYourself();
        }
    }
    private void ShowYourself()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = realForm;
        //œŒ“ŒÃ ”¡–¿“‹
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        //œŒ“ŒÃ ”¡–¿“‹
        movement.enabled = true;
    }
    private void Hide()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = choosenHideForm;
        //œŒ“ŒÃ ”¡–¿“‹
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //œŒ“ŒÃ ”¡–¿“‹
        movement.enabled = false;
    }
}
