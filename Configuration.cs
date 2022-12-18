using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Configuration : MonoBehaviour
{
    #region Variaveis
    [SerializeField] private int _buttonNumber, _sequenceSize;
    //[SerializeField] private string 
    [SerializeField] private int _speed, _backgroundGameColor, _sonds;


    private static Configuration _instance = null;
    #endregion

    #region Properties
    public int BackgroundGameColor
    {
        get
        {
            return _backgroundGameColor;
        }

        set
        {
            _backgroundGameColor = value;
        }
    }

    public int Sonds
    {
        get
        {
            return _sonds;
        }

        set
        {
            _sonds = value;
        }
    }

    public int ButtonNumber
    {
        get
        {
            return _buttonNumber;
        }

        set
        {
            _buttonNumber = value;
        }
    }

    public int Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = value;
        }
    }

    public int SequenceSize
    {
        get
        {
            return _sequenceSize;
        }

        set
        {
            _sequenceSize = value;
        }
    }

    public static Configuration Instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
    #endregion

    private void InitializeIndex()
    {
        ButtonNumber = 0;
        Speed = 0;
        SequenceSize = 1;
        BackgroundGameColor = 0;

    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeIndex();
        
    }

    public void SelectSequenceSize()
    {
        SequenceSize = VisualItemsConfiguration.Instance.DropdownSequenceSize.value + 1;
    }

    public void SelectButtonNumber()
    {
        ButtonNumber = VisualItemsConfiguration.Instance.DropdownButtonNumber.value;
    }


    public void SelectSpeed()
    {
        Speed = VisualItemsConfiguration.Instance.DropdownSpeed.value;
    
    }

    public void SelectBackgroundGameColor()
    {
        BackgroundGameColor = VisualItemsConfiguration.Instance.DropdownBackgroundColor.value;
    }

    public void SelectSonds()
    {
        Sonds = VisualItemsConfiguration.Instance.DropdownSonds.value;

    }
    /*
    private void Update()
    {
        SelectButtonNumber();
        SelectSequenceSize();
        SelectSpeed();

    }

    /*public void SelectLabelColor()
    {
        StringLabelColor = VisualItemsConfiguration.Instance.DropdownLabelCardsColor.options[VisualItemsConfiguration.Instance.DropdownLabelCardsColor.value].text;
        LabelColorIndex = VisualItemsConfiguration.Instance.DropdownLabelCardsColor.value;
        if (LabelColorIndex == 1)
            ColorLabel = Color.white;
        else if (LabelColorIndex == 2)
            ColorLabel = Color.green;
        else if (LabelColorIndex == 3)
            ColorLabel = Color.blue;
        else if (LabelColorIndex == 4)
            ColorLabel = Color.gray;
        else if (LabelColorIndex == 5)
            ColorLabel = Color.yellow;
        else if (LabelColorIndex == 6)
            ColorLabel = Color.red;
        else
            ColorLabel = Color.black;
    }*/
}
