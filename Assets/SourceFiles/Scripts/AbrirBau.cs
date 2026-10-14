using UnityEngine;
using UnityEngine.InputSystem;

public class AbrirBau : MonoBehaviour
{

    [Header("Configurações Baú")]
    [SerializeField] private Transform tampaBau;
    [SerializeField] private float velocideAbertura = 2f;
     
    private bool bauAberto = false;
    private bool jogadorProximo = false;

    [Header("Interface (Texto)")]
    [SerializeField] private GameObject textoInteracao;


    private Quaternion posicaoAberta = Quaternion.Euler(0f, -90f, -100f);
    private Quaternion posicaoFechada = Quaternion.Euler(0f, -90f, 0f);

    void Start()
    {
        textoInteracao.SetActive(false);
        Debug.Log("Texto de interação desativado");
    }


    void Update()
    {
        if (jogadorProximo == true && bauAberto == false && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("E key pressed");
            Abrir();
        }

        if (jogadorProximo == true && bauAberto == true && Keyboard.current.qKey.wasPressedThisFrame)
        {
            Debug.Log("Q key pressed");
            Fechar();
        }

        if (bauAberto)
        {
            tampaBau.localRotation = Quaternion.Lerp(tampaBau.localRotation, posicaoAberta, velocideAbertura * Time.deltaTime);
        }
        if (bauAberto == false)
        {
            tampaBau.localRotation = Quaternion.Lerp(tampaBau.localRotation, posicaoFechada, velocideAbertura * Time.deltaTime);
        }


    }

    private void Abrir()
    {
        // Rotaciona a tampa do baú para abrir0
        bauAberto = true;

    }
    private void Fechar()
    {
        // Rotaciona a tampa do baú para abrir0
        bauAberto = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textoInteracao.SetActive(true);
            Debug.Log("Texto de interação ativado");
            jogadorProximo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textoInteracao.SetActive(false);
            Debug.Log("Texto de interação desativado");
            jogadorProximo = false;
        }
    }








}