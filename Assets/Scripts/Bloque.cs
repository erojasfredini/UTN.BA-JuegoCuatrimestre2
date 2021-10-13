using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    public enum TipoBloque { Destruible, Indestructible };
    public TipoBloque tipoBloque = TipoBloque.Destruible;
}
