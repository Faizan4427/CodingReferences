using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodingReferences
{
    public class UnityUIToolkit_BindingListViewAtRuntime : MonoBehaviour
    {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private List<int> _list;
        
        private void Start()
        {
            var root = new VisualElement();
            var listView = new ListView {
                dataSource = this,
                itemsSource = _list,
                makeItem = () => new Label(),
                bindItem = (e, i) => {
                    var label = (Label)e;
                    label.text = _list[i].ToString();
                },
                unbindItem = (e, i) => {
                },
                destroyItem = e => {
                }
            };
            
            root.Add(listView);
            _uiDocument.rootVisualElement.Add(root);
        }
    }
}