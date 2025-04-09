using UnityEngine;
using UnityEngine.UI;

public class UISystemHP : MonoBehaviour
{
	private Vector2 _startPosition;

	private Slider _hpSlider;

	private HPSystem _hpSystem;

	private void Awake()
	{
		this._startPosition = new Vector2(100, 50);
		this._hpSystem = this.GetComponent<HPSystem>();
	}

	private void Init()
	{
		GameObject sliderPrefab = Resources.Load<GameObject>("HPSlider");
		GameObject sliderInstance = Instantiate(sliderPrefab, this._startPosition, Quaternion.identity);
		this._hpSlider = sliderInstance.GetComponent<Slider>();

		GameObject canvas = GameObject.Find("Canvas");
		this._hpSlider.transform.SetParent(canvas.transform);
	}

	private void Start()
	{
		this.Init();

		this._hpSlider.minValue = this._hpSystem.GetMinHp();
		this._hpSlider.maxValue = this._hpSystem.GetCurrentHp();

		this._hpSlider.value = this._hpSlider.maxValue;
	}

	private void FixedUpdate()
	{
		this._hpSlider.value = this._hpSystem.GetCurrentHp();
	}
}
