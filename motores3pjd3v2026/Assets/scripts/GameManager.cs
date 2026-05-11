using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum EstadoJogo
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public EstadoJogo estadoAtual;

    public PlayerInput playerInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MudarEstado(EstadoJogo.Iniciando);

        CarregarCena("Splash");
    }

    public void MudarEstado(EstadoJogo novoEstado)
    {
        estadoAtual = novoEstado;

        Debug.Log("Estado atual: " + estadoAtual);
    }

    public void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);

        switch (nomeCena)
        {
            case "Splash":
                MudarEstado(EstadoJogo.Iniciando);
                break;

            case "MenuPrincipal":
                MudarEstado(EstadoJogo.MenuPrincipal);
                break;

            case "Jogo":
                MudarEstado(EstadoJogo.Gameplay);
                break;
        }
    }

    public void ConfigurarInput(PlayerInput input)
    {
        playerInput = input;

        Debug.Log("Input configurado!");
    }

    public void SairDoJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}