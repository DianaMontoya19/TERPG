using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotthonFuntion : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CharacterSelectionManager _charaterSelect;    
    public GameObject targetObject; 
    public Animator animator;
    public GameObject PrefabCharacterAsing;

    private void Start()
    {
        animator = targetObject.GetComponent<Animator>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        _charaterSelect = FindObjectOfType<CharacterSelectionManager>();
    }

    public void OnButtonClick()
    {
        _charaterSelect.AsingnateCharacter(PrefabCharacterAsing);
        _charaterSelect.StarGame();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Cheer", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Cheer", false);
    }
}
