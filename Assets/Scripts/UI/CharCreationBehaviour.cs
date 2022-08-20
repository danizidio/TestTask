using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCreationBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _femaleBody, _maleBody;

    [SerializeField] SpriteRenderer[] _femaleHair, _maleHair;
    [SerializeField] SpriteRenderer[] _femaleFace, _maleFace;
    [SerializeField] SpriteRenderer[] _femaleSkin, _maleSkin;

    [SerializeField] SpriteRenderer _femaleShirt, _femaleLegs, _maleShirt, _maleLegs;

    [SerializeField] bool _isFemale;

    int _valueHair, _valueFace, _valueBody, _valueShirt, _valueLegs, _valueHairColor;

    private void Start()
    {
        _isFemale = false;
        _valueHair = 0;
        _valueHairColor = 0;
        _valueFace = 0;
        _valueBody = 0;
        _valueShirt = 0;
        _valueLegs = 0;
    }
    #region - UI Button Events

    public void GenderChange(bool a)
    {
        if(a)
        {
            _femaleBody.SetActive(true);
            _maleBody.SetActive(false);
        }
        else
        {
            _femaleBody.SetActive(false);
            _maleBody.SetActive(true);
        }

        _isFemale = a;
    }

    public void HairChange(int a)
    {
        _valueHair += a;

        if (_valueHair > 2)
        {
            _valueHair = 0;
        }
        if (_valueHair < 0)
        {
            _valueHair = 2;
        }

        if (!_isFemale)
        {
            SelectItem(_maleHair);
        }
        else
        {
            SelectItem(_femaleHair);
        }
    }

    public void FaceChange(int a)
    {
        _valueFace += a;

        if (_valueFace > 2)
        {
            _valueFace = 0;
        }
        if (_valueFace < 0)
        {
            _valueFace = 2;
        }

        if (!_isFemale)
        {
            SelectItem(_maleFace);
        }
        else
        {
            SelectItem(_femaleFace);
        }
    }

    public void HairColor(int a)
    {
        _valueHairColor += a;

        if (_valueHairColor > 2)
        {
            _valueHairColor = 0;
        }
        if (_valueHairColor < 0)
        {
            _valueHairColor = 2;
        }

        if (!_isFemale)
        {
            foreach (var item in _maleHair)
            {
                switch (_valueHairColor)
                {
                    case 0:
                        {
                            item.color = new Color32(255, 100, 150, 255);

                            break;
                        }
                    case 1:
                        {
                            item.color = new Color32(0, 0, 0, 255);

                            break;
                        }
                    case 2:
                        {
                            item.color = new Color32(255, 255, 255, 255);

                            break;
                        }
                }
            }
        }
        else
        {
            foreach (var item in _femaleHair)
            {
                switch (_valueHairColor)
                {
                    case 0:
                        {
                            item.color = new Color32(255, 100, 150, 255);

                            break;
                        }
                    case 1:
                        {
                            item.color = new Color32(0, 0, 0, 255);

                            break;
                        }
                    case 2:
                        {
                            item.color = new Color32(255, 255, 255, 255);

                            break;
                        }
                }
            }
        }
    }
    public void SkinColor(int a)
    {
        _valueBody += a;

        if (_valueBody > 2)
        {
            _valueBody = 0;
        }
        if (_valueBody < 0)
        {
            _valueBody = 2;
        }

        if(!_isFemale)
        {
            foreach (var item in _maleSkin)
            {
                switch (_valueBody)
                {
                    case 0:
                        {
                            item.color = new Color32(255, 245, 230, 255);

                            break;
                        }
                    case 1:
                        {
                            item.color = new Color32(185, 141, 141, 255);

                            break;
                        }
                    case 2:
                        {
                            item.color = new Color32(255, 218, 231, 255);

                            break;
                        }
                }
            }
        }
        else
        {
            foreach (var item in _femaleSkin)
            {
                switch (_valueBody)
                {
                    case 0:
                        {
                            item.color = new Color32(255, 245, 230, 255);

                            break;
                        }
                    case 1:
                        {
                            item.color = new Color32(185, 141, 141, 255);

                            break;
                        }
                    case 2:
                        {
                            item.color = new Color32(255, 218, 231, 255);

                            break;
                        }
                }
            }
        }
    }
    public void ShirtColor(int a)
    {
        _valueShirt += a;

        if (_valueShirt > 2)
        {
            _valueShirt = 0;
        }
        if (_valueShirt < 0)
        {
            _valueShirt = 2;
        }

        switch (_valueShirt)
        {
            case 0:
                {
                    _maleShirt.color = new Color32(255, 255, 255, 255);

                    break;
                }
            case 1:
                {
                    _maleShirt.color = new Color32(207, 38, 41, 255);

                    break;
                }
            case 2:
                {
                    _maleShirt.color = new Color32(100, 0, 255, 255);

                    break;
                }
        }
    }

    public void LegsColor(int a)
    {
        _valueLegs += a;

        if (_valueLegs > 2)
        {
            _valueLegs = 0;
        }
        if (_valueLegs < 0)
        {
            _valueLegs = 2;
        }

        switch (_valueLegs)
        {
            case 0:
                {
                    _maleLegs.color = new Color32(255, 255, 255, 255);

                    break;
                }
            case 1:
                {
                    _maleLegs.color = new Color32(207, 38, 41, 255);

                    break;
                }
            case 2:
                {
                    _maleLegs.color = new Color32(100, 0, 255, 255);

                    break;
                }
        }
    }
    #endregion


    void SelectItem(SpriteRenderer[] sr)
    {
        for (int n = 0; n < sr.Length; n++)
        {
            if (n != _valueFace)
            {
                sr[n].gameObject.SetActive(false);
            }
            else
            {
                sr[n].gameObject.SetActive(true);
            }
        } 
    }
}
