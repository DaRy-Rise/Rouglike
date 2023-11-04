using System.Collections;
using UnityEngine;


public class PhrasesManager : MonoBehaviour
{
    [SerializeField]
    private ParsingJson reader;
    private Phrases phrases;
    private string phrasesJsonPath = "Assets/Resources/Json/masterPhrases.json";

    private void Awake()
    {
        phrases = reader.GetInfo<Phrases>(phrasesJsonPath);
    }
    void Start()
    {
       // phrases.mastersPhrases.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
