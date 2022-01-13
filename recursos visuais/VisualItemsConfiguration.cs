using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualItemsConfiguration : MonoBehaviour
{
    #region Variables
    
    [SerializeField] private Dropdown _dropdownBackgroundColor, _dropdownSpeed;
    [SerializeField] private Dropdown _dropdownSequenceSize, _dropdownButtonNumber, _dropdownSonds;


   private static VisualItemsConfiguration _instance = null;

    private List<string> _buttonQuantityList;
    private List<string> _colorsList;
    private List<string> _timeList;
    private List<string> _speedList;
    private List<string> _suequenceSizeList;
    private List<string> _sondsList;
    //private IDictionary<string, double> _speedList;


    #endregion

    private void Start()
    {
        InitializeLists();
        InitializeDropdown();
        AddListeners();
        UpdateIndex();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    #region Getters and Setters
    public Dropdown DropdownBackgroundColor
    {
        get
        {
            return _dropdownBackgroundColor;
        }

        set
        {
            _dropdownBackgroundColor = value;
        }
    }  


    public Dropdown DropdownSequenceSize
    {
        get
        {
            return _dropdownSequenceSize;
        }

        set
        {
            _dropdownSequenceSize = value;
        }
    }

    public Dropdown DropdownSpeed
    {
        get
        {
            return _dropdownSpeed;
        }

        set
        {
            _dropdownSpeed = value;
        }
    }

    public Dropdown DropdownButtonNumber
    {
        get
        {
            return _dropdownButtonNumber;
        }

        set
        {
            _dropdownButtonNumber = value;
        }
    }

    public Dropdown DropdownSonds
    {
        get
        {
            return _dropdownSonds;
        }

        set
        {
            _dropdownSonds = value;
        }
    }


    public static VisualItemsConfiguration Instance
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

    private void InitializeLists()
    {
        //_buttonQuantityList = new List<string>() {"7", "6", "5", "4", "3" };
        _colorsList = new List<string> { "Branco", "Preto" };
        //_speedList = new List<string> { "Rápido", "Normal", "Lento" };
        //_suequenceSizeList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        //_sondsList = new List<string> { "Piano", "Digital", "Flauta" };
        //_speedList = new Dictionary<string, double>();
        //_speedList.Add("Rapido", 0.3);
        //_speedList.Add("Nomal", 0.5);
        //_speedList.Add("Lento", 0.9);
    }
    
    private void InitializeDropdown()
    {
        //DropdownButtonNumber.AddOptions(_buttonQuantityList);
        //DropdownSequenceSize.AddOptions(_suequenceSizeList);
        DropdownBackgroundColor.AddOptions(_colorsList);
        //DropdownSpeed.AddOptions(_speedList);
        //DropdownSonds.AddOptions(_sondsList);
    }

    private void AddListeners()
    {
        //DropdownButtonNumber.onValueChanged.AddListener((value) => { Configuration.Instance.SelectButtonNumber(); });
        //DropdownSpeed.onValueChanged.AddListener((value) => { Configuration.Instance.SelectSpeed(); });
        //DropdownSequenceSize.onValueChanged.AddListener((value) => { Configuration.Instance.SelectSequenceSize(); });
        //DropdownSonds.onValueChanged.AddListener((value) => { Configuration.Instance.SelectSonds(); });
        DropdownBackgroundColor.onValueChanged.AddListener((value) => { Configuration.Instance.SelectBackgroundGameColor(); });
    }

    private void UpdateIndex()
    {

        //DropdownButtonNumber.value = Configuration.Instance.ButtonNumber;
        //DropdownSequenceSize.value = Configuration.Instance.SequenceSize;
        //DropdownBackgroundColor.value = Configuration.Instance.BackgroundGameColor;
        //DropdownSpeed.value = Configuration.Instance.Speed;
    
    }
}