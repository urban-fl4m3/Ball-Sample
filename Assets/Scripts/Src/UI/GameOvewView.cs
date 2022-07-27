using UnityEngine;
using UnityEngine.UI;

namespace Src.UI
{
    //basically it's both view and controller
    public class GameOvewView : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Text _endText;
        [SerializeField] private string _winDesc;
        [SerializeField] private string _loseDesc;
        
        public void Init(GameOverViewModel model)
        {
            _endText.text = model.IsWon ? _winDesc : _loseDesc;
            
            _restartButton.onClick.AddListener(() =>
            {
                model.RestartPressed();
                Clear();
            });
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Clear()
        {
            Hide();
            _restartButton.onClick.RemoveAllListeners();
        }
    }
}