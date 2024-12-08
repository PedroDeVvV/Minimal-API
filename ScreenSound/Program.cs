using ScreenSound.Menus;
using ScreenSound.Modelos;
using ScreenSound.Database;

var context = new ScreenSoundContext();
var coldplay = new Artista("Coldplay", "Viva la vida");
var artistaDAL = new DAL<Artista>(context);


var musicaDAL = new MusicaDAL(context);

Musica vivaLaVida = new Musica("Viva la Vida");
musicaDAL.Adicionar(vivaLaVida);
var list = musicaDAL.Listar();
foreach (var item in list)
{
    Console.WriteLine(item);
}

//Dictionary<int, Menu> opcoes = new();
//opcoes.Add(1, new MenuRegistrarArtista());
//opcoes.Add(2, new MenuRegistrarMusica());
//opcoes.Add(3, new MenuMostrarArtistas());
//opcoes.Add(4, new MenuMostrarMusicas());
//opcoes.Add(-1, new MenuSair());

//void ExibirLogo()
//{
//    Console.WriteLine(@"

//░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
//██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
//╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
//░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
//██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
//╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
//");
//    Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
//}

//void ExibirOpcoesDoMenu()
//{
//    ExibirLogo();
//    Console.WriteLine("\nDigite 1 para registrar um artista");
//    Console.WriteLine("Digite 2 para registrar a música de um artista");
//    Console.WriteLine("Digite 3 para mostrar todos os artistas");
//    Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
//    Console.WriteLine("Digite -1 para sair");

//    Console.Write("\nDigite a sua opção: ");
//    string opcaoEscolhida = Console.ReadLine()!;
//    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

//    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
//    {
//        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
//        menuASerExibido.Executar(artistaDAL);
//        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
//    }
//    else
//    {
//        Console.WriteLine("Opção inválida");
//    }
//}

//ExibirOpcoesDoMenu();