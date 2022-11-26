using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroyPricaRange;

    private int _destroyPrice;
    private int _filling;

    public int LeftToFiil => _destroyPrice - _filling;
    
    public event UnityAction<int> FillingProgress; 

    private void Start()
    {
        _destroyPrice = Random.Range(_destroyPricaRange.x, _destroyPricaRange.y);
        
        FillingProgress?.Invoke(LeftToFiil);
    }

    public void Fill()
    {
        _filling++;
        FillingProgress?.Invoke(LeftToFiil);

        if (_filling == _destroyPrice) Destroy(gameObject);
    }
}
