using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueDisplay : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _currentValue;
    [SerializeField] private Text _textMinValue;
    [SerializeField] private Text _textMaxValue;

    private float _value;
    private float _lastValue;
    private float _minValue;
    private float _maxValue;
    private float _minSpeed;
    private float _speed;

    private void Start()
    {
        _value = 50;
        _lastValue = _value;
        _minValue = -20;
        _maxValue = 120;
        _minSpeed = 10;

        _currentValue.text = _value + " hp";
        _textMinValue.text = _minValue.ToString();
        _textMaxValue.text = _maxValue.ToString();
        _slider.value = (_value - _minValue) / (_maxValue - _minValue);        
    }

    private void Update()
    {
        if (_lastValue != _value)
        {
            _speed = Mathf.Abs(_lastValue - _value);
            _speed = Mathf.Clamp(_speed, _minSpeed, float.MaxValue);
            _speed *= (_lastValue < _value) ? 1 : -1;
            
            _lastValue += _speed * Time.deltaTime;
            if (Mathf.Abs(_lastValue - _value) < 0.1)
                _lastValue = _value;

            _slider.value = (_lastValue - _minValue) / (_maxValue - _minValue);
        }
    }

    public void ChangeValue(float value)
    {
        _value += value;
        _value = Mathf.Clamp(_value, _minValue, _maxValue);

        _currentValue.text = _value + " hp";
    }    
}
