using TMPro;
using UnityEngine;

[RequireComponent(typeof(Block))]
public class BlockView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    
    private Block _block;

    private void Awake() => _block = GetComponent<Block>();
    private void OnEnable() => _block.FillingProgress += OnFillingProgress;
    private void OnDisable() => _block.FillingProgress -= OnFillingProgress;
    private void OnFillingProgress(int progress) => _view.text = progress.ToString();
}
