using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CuboRubik : MonoBehaviour
{
    [Header("Dimensiones")]
    [SerializeField]
    Vector3 dimensionesRubik;

    [Space(20)]
    [Header("Objetos")]
    [SerializeField]
    GameObject cubo;
    [SerializeField]
    GameObject plano;

    [Space(20)]
    [Header("Select Obj")]
    [SerializeField]
    int obj;

    [Space(20)]
    [Header("Materiales")]
    [SerializeField]
    Material[] material;

    GameObject caraIzq, caraDer, caraInf, caraFront, caraSup, caraBack;

    int contadorRotacion;

    List<GameObject> cFront;
    List<GameObject> cIzq;
    List<GameObject> cDer;
    List<GameObject> cSup;
    List<GameObject> cInf;
    List<GameObject> cBack;
    List<GameObject> cubos;
    List<int> nMovNew;

    public Text textContMov;
    int contMov = 0;

    [SerializeField]
    Text [] showMov;

    bool girando;

    public void Mov()
    {
        contMov = contMov + 1;
        textContMov.text = contMov.ToString();

        for (int i = 0; i < showMov.Length ; i++)
        {
            showMov[i].text = contMov.ToString();
        }
    }

    public IEnumerator GirarCara(int giro)
    {
        girando = true;

        float timeToSpin=0.5f;

        Quaternion qIni = new Quaternion();
        Quaternion qDes = new Quaternion();
        switch(giro)
        {

            case 1:

                qIni = caraFront.transform.rotation;
                qDes = caraFront.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -90));
                print(qDes);

                break;

            case 2:

                qIni = caraBack.transform.rotation;
                qDes = caraBack.transform.rotation * Quaternion.Euler(new Vector3(0, 0, -90));
                break;

            case 3:

                qIni = caraDer.transform.rotation;
                qDes = caraDer.transform.rotation * Quaternion.Euler(new Vector3(-90, 0, 0));
                break;

            case 4:

                qIni = caraIzq.transform.rotation;
                qDes = caraIzq.transform.rotation * Quaternion.Euler(new Vector3(-90, 0, 0));
                break;

            case 5:

                qIni = caraSup.transform.rotation;
                qDes = caraSup.transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0));
                break;

            case 6:

                qIni = caraInf.transform.rotation;
                qDes = caraInf.transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0));
                break;

            case 7:

                qIni = caraFront.transform.rotation;
                qDes = caraFront.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 90));
                print(qDes);

                break;

            case 8:

                qIni = caraBack.transform.rotation;
                qDes = caraBack.transform.rotation * Quaternion.Euler(new Vector3(0, 0, 90));
                break;

            case 9:

                qIni = caraDer.transform.rotation;
                qDes = caraDer.transform.rotation * Quaternion.Euler(new Vector3(90, 0, 0));
                break;

            case 10:

                qIni = caraIzq.transform.rotation;
                qDes = caraIzq.transform.rotation * Quaternion.Euler(new Vector3(90, 0, 0));
                break;

            case 11:

                qIni = caraSup.transform.rotation;
                qDes = caraSup.transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
                break;

            case 12:

                qIni = caraInf.transform.rotation;
                qDes = caraInf.transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
                break;
        }

        for (float i =0; i< timeToSpin; i += Time.deltaTime)
        {
            yield return 0;
            switch (giro)
            {
                case 1:
                    
                    Quaternion v3 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraFront.transform.rotation = v3;
                    break;
                    
                case 2:

                    Quaternion v3_1 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraBack.transform.rotation = v3_1;
                    break;

                case 3:

                    Quaternion v3_2 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraDer.transform.rotation =v3_2;
                    break;

                case 4:

                    Quaternion v3_3 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraIzq.transform.rotation = v3_3;
                    break;

                case 5:

                    Quaternion v3_4 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraSup.transform.rotation = v3_4;
                    break;

                case 6:

                    Quaternion v3_5 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraInf.transform.rotation = v3_5;
                    break;

                case 7:

                    Quaternion v3_6 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraFront.transform.rotation = v3_6;
                    break;

                case 8:

                    Quaternion v3_7 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraBack.transform.rotation = v3_7;
                    break;

                case 9:

                    Quaternion v3_8 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraDer.transform.rotation = v3_8;
                    break;

                case 10:

                    Quaternion v3_9 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraIzq.transform.rotation = v3_9;
                    break;

                case 11:

                    Quaternion v3_10 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraSup.transform.rotation = v3_10;
                    break;

                case 12:

                    Quaternion v3_11 = Quaternion.Lerp(qIni, qDes, i / timeToSpin);
                    caraInf.transform.rotation = v3_11;
                    break;
            }
        }

        switch (giro)
        {
            case 1:
                caraFront.transform.rotation = qDes;

                for (int i = 0; i < cFront.Count; i++)
                {
                    cFront[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 2:
                caraBack.transform.rotation = qDes;

                for (int i = 0; i < cBack.Count; i++)
                {
                    cBack[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 3:
                caraDer.transform.rotation = qDes;

                for (int i = 0; i < cDer.Count; i++)
                {
                    cDer[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 4:
                caraIzq.transform.rotation = qDes;

                for (int i = 0; i < cIzq.Count; i++)
                {
                    cIzq[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 5:
                caraSup.transform.rotation = qDes;

                for (int i = 0; i < cSup.Count; i++)
                {
                    cSup[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 6:
                caraInf.transform.rotation = qDes;

                for (int i = 0; i < cInf.Count; i++)
                {
                    cInf[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 7:
                caraFront.transform.rotation = qDes;

                for (int i = 0; i < cFront.Count; i++)
                {
                    cFront[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 8:
                caraBack.transform.rotation = qDes;

                for (int i = 0; i < cBack.Count; i++)
                {
                    cBack[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 9:
                caraDer.transform.rotation = qDes;

                for (int i = 0; i < cDer.Count; i++)
                {
                    cDer[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 10:
                caraIzq.transform.rotation = qDes;

                for (int i = 0; i < cIzq.Count; i++)
                {
                    cIzq[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 11:
                caraSup.transform.rotation = qDes;

                for (int i = 0; i < cSup.Count; i++)
                {
                    cSup[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;

            case 12:
                caraInf.transform.rotation = qDes;

                for (int i = 0; i < cInf.Count; i++)
                {
                    cInf[i].transform.SetParent(null);
                }
                ListaCubos();
                Mov();
                nMovNew.Add(giro);

                break;
        }
        girando = false;
    }

    private void Start()
    {
        cFront = new List<GameObject>();
        cBack = new List<GameObject>();
        cIzq = new List<GameObject>();
        cDer = new List<GameObject>();
        cSup = new List<GameObject>();
        cInf = new List<GameObject>();
        cubos = new List<GameObject>();
        nMovNew = new List<int>();
        Rubik(dimensionesRubik.x, dimensionesRubik.y, dimensionesRubik.z);
        ListaCubos();
    }

    public void Load()
    {
        SceneManager.LoadScene("Juego");
    }

    private void Update()
    {
        if (!girando)
        {
            if (!Input.GetKey(KeyCode.RightShift))
            {
                if (Input.GetKeyDown(KeyCode.L))
                {

                    for (int i = 0; i < cIzq.Count; i++)
                    {
                        cIzq[i].transform.SetParent(caraIzq.transform);
                    }

                    StartCoroutine(GirarCara(4));

                }

                if (Input.GetKeyDown(KeyCode.R))
                {

                    for (int i = 0; i < cDer.Count; i++)
                    {
                        cDer[i].transform.SetParent(caraDer.transform);
                    }

                    StartCoroutine(GirarCara(3));

                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    for (int i = 0; i < cFront.Count; i++)
                    {
                        cFront[i].transform.SetParent(caraFront.transform);
                    }

                    StartCoroutine(GirarCara(1));

                }

                if (Input.GetKeyDown(KeyCode.B))
                {
                    for (int i = 0; i < cBack.Count; i++)
                    {
                        cBack[i].transform.SetParent(caraBack.transform);
                    }

                    StartCoroutine(GirarCara(2));
                }

                if (Input.GetKeyDown(KeyCode.U))
                {
                    for (int i = 0; i < cSup.Count; i++)
                    {
                        cSup[i].transform.SetParent(caraSup.transform);
                    }

                    StartCoroutine(GirarCara(5));
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    for (int i = 0; i < cInf.Count; i++)
                    {
                        cInf[i].transform.SetParent(caraInf.transform);
                    }

                    StartCoroutine(GirarCara(6));

                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.L))
                {

                    for (int i = 0; i < cIzq.Count; i++)
                    {
                        cIzq[i].transform.SetParent(caraIzq.transform);
                    }

                    StartCoroutine(GirarCara(10));

                }

                if (Input.GetKeyDown(KeyCode.R))
                {

                    for (int i = 0; i < cDer.Count; i++)
                    {
                        cDer[i].transform.SetParent(caraDer.transform);
                    }

                    StartCoroutine(GirarCara(9));

                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    for (int i = 0; i < cFront.Count; i++)
                    {
                        cFront[i].transform.SetParent(caraFront.transform);
                    }

                    StartCoroutine(GirarCara(7));

                }

                if (Input.GetKeyDown(KeyCode.B))
                {
                    for (int i = 0; i < cBack.Count; i++)
                    {
                        cBack[i].transform.SetParent(caraBack.transform);
                    }

                    StartCoroutine(GirarCara(8));
                }

                if (Input.GetKeyDown(KeyCode.U))
                {
                    for (int i = 0; i < cSup.Count; i++)
                    {
                        cSup[i].transform.SetParent(caraSup.transform);
                    }

                    StartCoroutine(GirarCara(11));
                }

                if (Input.GetKeyDown(KeyCode.D))
                {
                    for (int i = 0; i < cInf.Count; i++)
                    {
                        cInf[i].transform.SetParent(caraInf.transform);
                    }

                    StartCoroutine(GirarCara(12));

                }

            }
        }
         
    }

    public GameObject CrearObjeto(int obje)
    {
        GameObject objeto = null;

        switch (obje)
        {
            case 0:
                objeto = cubo;
                break;
            case 1:
                objeto = plano;
                break;
        }
        return objeto;
    }

    void Rubik(float ancho, float alto, float profundo)
    {


        caraInf = new GameObject("caraInf");
        caraInf.transform.position = new Vector3(ancho / 2f, 0.5f, profundo / 2f);

        caraFront = new GameObject("caraFront");
        caraFront.transform.position = new Vector3(1.5f, 1.5f, 0.5f);

        caraSup = new GameObject("caraSup");
        caraSup.transform.position = new Vector3(ancho / 2f, 2.5f, profundo / 2f);

        caraIzq = new GameObject("caraIzq");
        caraIzq.transform.position = new Vector3(0.5f, alto / 2f, profundo/2.0f);

        caraBack = new GameObject("caraBack");
        caraBack.transform.position = new Vector3(1.5f, alto / 2f, profundo / 2f);

        caraDer = new GameObject("caraDer");
        caraDer.transform.position = new Vector3(2.5f, alto / 2f, profundo / 2f);

        for (int i = 0; i < profundo; i++)
        {
            for (int j = 0; j < alto; j++)
            {
                for (int k = 0; k < ancho; k++)
                {
                    GameObject aux = Instantiate(CrearObjeto(obj), new Vector3(0.5f + k, 0.5f + j, 0.5f + i), Quaternion.identity);
                    cubos.Add(aux);

                    aux.name = i +"-" +j +"-"+ k;
                    aux.transform.localScale = new Vector3(1, 1, 1) * 0.95f;

                    if (j == 0)
                    {
                        aux.transform.SetParent(caraInf.transform);
                        //CARA INFERIOR
                        // 0 = BLUE | 1 = GREEN | 2 = ORANGE | 3 = RED | 4 = WHITE | 5 = YELLOW
                        aux.transform.GetChild(4).GetComponent<MeshRenderer>().material = material[0];
                        aux.transform.GetChild(1).GetComponent<MeshRenderer>().material = material[5];
                        aux.transform.GetChild(3).GetComponent<MeshRenderer>().material = material[3];
                        aux.transform.GetChild(2).GetComponent<MeshRenderer>().material = material[1];
                        aux.transform.GetChild(5).GetComponent<MeshRenderer>().material = material[2];
                        aux.transform.GetChild(0).GetComponent<MeshRenderer>().material = material[4];
                        aux.transform.SetParent(null);

                    }

                    if (j == 1)
                    {
                        aux.transform.SetParent(caraFront.transform);
                        //CARA MEDIA
                        // 0 = BLUE | 1 = GREEN | 2 = ORANGE | 3 = RED | 4 = WHITE | 5 = YELLOW
                        aux.transform.GetChild(4).GetComponent<MeshRenderer>().material = material[0];
                        aux.transform.GetChild(1).GetComponent<MeshRenderer>().material = material[5];
                        aux.transform.GetChild(3).GetComponent<MeshRenderer>().material = material[3];
                        aux.transform.GetChild(2).GetComponent<MeshRenderer>().material = material[1];
                        aux.transform.GetChild(5).GetComponent<MeshRenderer>().material = material[2];
                        aux.transform.GetChild(0).GetComponent<MeshRenderer>().material = material[4];
                        aux.transform.SetParent(null);
                    }

                    if (j == 2)
                    {
                        aux.transform.SetParent(caraSup.transform);
                        //CARA SUPERIOR
                        // 0 = BLUE | 1 = GREEN | 2 = ORANGE | 3 = RED | 4 = WHITE | 5 = YELLOW
                        aux.transform.GetChild(4).GetComponent<MeshRenderer>().material = material[0];
                        aux.transform.GetChild(1).GetComponent<MeshRenderer>().material = material[5];
                        aux.transform.GetChild(3).GetComponent<MeshRenderer>().material = material[3];
                        aux.transform.GetChild(2).GetComponent<MeshRenderer>().material = material[1];
                        aux.transform.GetChild(5).GetComponent<MeshRenderer>().material = material[2];
                        aux.transform.GetChild(0).GetComponent<MeshRenderer>().material = material[4];
                        aux.transform.SetParent(null);
                    }

                    if (k == 0)
                    {
                        aux.transform.SetParent(caraIzq.transform);
                        
                        //CARA IZQUIERDA
                        // 0 = BLUE | 1 = GREEN | 2 = ORANGE | 3 = RED | 4 = WHITE | 5 = YELLOW
                        aux.transform.GetChild(4).GetComponent<MeshRenderer>().material = material[0];
                        aux.transform.GetChild(1).GetComponent<MeshRenderer>().material = material[5];
                        aux.transform.GetChild(3).GetComponent<MeshRenderer>().material = material[3];
                        aux.transform.GetChild(2).GetComponent<MeshRenderer>().material = material[1];
                        aux.transform.GetChild(5).GetComponent<MeshRenderer>().material = material[2];
                        aux.transform.GetChild(0).GetComponent<MeshRenderer>().material = material[4];
                        aux.transform.SetParent(null);
                    }

                    if (k == 1)
                    {
                        aux.transform.SetParent(caraBack.transform);
                        
                        //CARA MIDTOP
                        // 0 = BLUE | 1 = GREEN | 2 = ORANGE | 3 = RED | 4 = WHITE | 5 = YELLOW
                        aux.transform.GetChild(4).GetComponent<MeshRenderer>().material = material[0];
                        aux.transform.GetChild(1).GetComponent<MeshRenderer>().material = material[5];
                        aux.transform.GetChild(3).GetComponent<MeshRenderer>().material = material[3];
                        aux.transform.GetChild(2).GetComponent<MeshRenderer>().material = material[1];
                        aux.transform.GetChild(5).GetComponent<MeshRenderer>().material = material[2];
                        aux.transform.GetChild(0).GetComponent<MeshRenderer>().material = material[4];
                        aux.transform.SetParent(null);
                    }

                    if (k == 2)
                    {
                        aux.transform.SetParent(caraDer.transform);
                        
                        //CARA DERECHA
                        // 0 = BLUE | 1 = GREEN | 2 = ORANGE | 3 = RED | 4 = WHITE | 5 = YELLOW
                        aux.transform.GetChild(4).GetComponent<MeshRenderer>().material = material[0];
                        aux.transform.GetChild(1).GetComponent<MeshRenderer>().material = material[5];
                        aux.transform.GetChild(3).GetComponent<MeshRenderer>().material = material[3];
                        aux.transform.GetChild(2).GetComponent<MeshRenderer>().material = material[1];
                        aux.transform.GetChild(5).GetComponent<MeshRenderer>().material = material[2];
                        aux.transform.GetChild(0).GetComponent<MeshRenderer>().material = material[4];
                        aux.transform.SetParent(null);
                    }
                }
            }
        }
    }

    void ListaCubos()
    {

        cFront.Clear();
        cBack.Clear();
        cDer.Clear();
        cIzq.Clear();
        cSup.Clear();
        cInf.Clear();

        foreach(GameObject g in  cubos)
        {

            if (g.transform.position.z >= 0.45f && g.transform.position.z <= 0.55f)
            {
                cFront.Add(g);
            }

            if (g.transform.position.z >= 2.45f && g.transform.position.z <= 2.55f)
            {
                cBack.Add(g);
            }

            if (g.transform.position.x >= 0.45f && g.transform.position.x <= 0.55f)
            {
                cIzq.Add(g);
            }

            if (g.transform.position.x >= 2.45f && g.transform.position.z <= 2.55f)
            {
                cDer.Add(g);
            }

            if(g.transform.position.y >= 0.45f && g.transform.position.y <= 0.55f)
            {
                cInf.Add(g);
            }

            if(g.transform.position.y >= 2.45f && g.transform.position.y <= 2.55f)
            {
                cSup.Add(g);
            }

        }
        ImprimirCara(cFront);
    }

    void ImprimirCara(List<GameObject> c)
    {
        string str = "";
        for(int i = 0; i< c.Count; i++)
        {
            if (c[i]!=null){
                str += "\n" + c[i].name;
            }
            else
            {
                str += "\nVacio";
            }

            
        }
        print(str);
    }
}
